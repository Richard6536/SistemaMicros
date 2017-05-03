using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MicrosForms.Classes;
using MicrosForms.Model;
using MicrosForms.Ventanas;
using MicrosForms.Ventanas.Creaciones;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace MicrosForms.Ventanas.Creaciones
{
    public partial class CrearRutaVuelta : Form
    {
        Linea lineaDeRuta;
        Ruta rutaDeIda;
       
        bool editandoMapa;

        GMapOverlay previewIdaOverlay;
        GMapOverlay previewVueltaOverlay;
        GMapOverlay paraderosIdaOverlay;
        GMapOverlay paraderosVueltaOverlay;
        GMapOverlay otrosMarkersIdaOverlay;
        GMapOverlay otrosMarkersVueltaOverlay;

        List<PointLatLng> posVerticesVuelta;
        List<PointLatLng> puntosClickeadosVuelta;
        List<GMarkerGoogle> markParaderosVuelta;

        List<GMarkerGoogle> otrosMarkersList;
        List<GMapRoute> fragmentosDeRuta;

        GMarkerGoogle puntoInicioRutaVuelta;

        public CrearRutaVuelta(int _linea)
        {
            InitializeComponent();

            lineaDeRuta = Linea.BuscarLinea(_linea);
            rutaDeIda = Ruta.BuscarPorId(lineaDeRuta.RutaIdaId.Value);

            lblLinea.Text = "Línea: " + lineaDeRuta.Nombre;
            btnDeshacer.Enabled = false;
            btnAceptarRuta.Enabled = false;
            btnGuardarDatos.Enabled = false;

            IniciarMapa();
            CargarRutaEnMapa(rutaDeIda);

            Ruta rutaVueltaAnterior = Ruta.BuscarPorId(lineaDeRuta.RutaVueltaId.Value);
            Coordenada puntoInicial = Coordenada.BuscarPorId(rutaVueltaAnterior.InicioId);

            GMarkerGoogleType iconoMarcador = GMarkerGoogleType.blue_small; //icono ida
            string toolTipText = "Inicio ruta de vuelta";
            puntoInicioRutaVuelta = new GMarkerGoogle(new PointLatLng(puntoInicial.Latitud, puntoInicial.Longitud), iconoMarcador);
            puntoInicioRutaVuelta.ToolTipText = toolTipText;
            otrosMarkersIdaOverlay.Markers.Add(puntoInicioRutaVuelta);

        }

        double latOsorno = -40.574984;
        double lngOsorno = -73.125183;

        void IniciarMapa()
        {
            gmapController.MapProvider = GMapProviders.GoogleMap;

            gmapController.DragButton = MouseButtons.Left;
            gmapController.CanDragMap = true;
            gmapController.Position = new PointLatLng(latOsorno, lngOsorno);

            gmapController.MinZoom = 4;
            gmapController.MaxZoom = 19;  //19
            gmapController.Zoom = 14;

            gmapController.IgnoreMarkerOnMouseWheel = true;

            previewIdaOverlay = new GMapOverlay();
            previewVueltaOverlay = new GMapOverlay();
            paraderosIdaOverlay = new GMapOverlay();
            paraderosVueltaOverlay = new GMapOverlay();
            otrosMarkersIdaOverlay = new GMapOverlay();
            otrosMarkersVueltaOverlay = new GMapOverlay();

            gmapController.Overlays.Add(previewIdaOverlay);
            gmapController.Overlays.Add(previewVueltaOverlay);
            gmapController.Overlays.Add(paraderosIdaOverlay);
            gmapController.Overlays.Add(paraderosVueltaOverlay);
            gmapController.Overlays.Add(otrosMarkersIdaOverlay);
            gmapController.Overlays.Add(otrosMarkersVueltaOverlay);

            markParaderosVuelta = new List<GMarkerGoogle>();
            otrosMarkersList = new List<GMarkerGoogle>();
            posVerticesVuelta = new List<PointLatLng>();

        }

        void CargarRutaEnMapa(Ruta _ruta)
        {
            //Solo ida
            if (!ConnectionTester.IsConnectionActive())
                return;

            List<Paradero> paraderos = Ruta.ObtenerParaderosRuta(_ruta);
            List<Coordenada> vertices = Ruta.ObtenerVerticesDeInicioAFin(_ruta);


            foreach (Paradero p in paraderos) //Crear paraderos en el mapa
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(p.Latitud, p.Longitud), GMarkerGoogleType.purple_small);
                if (_ruta.TipoDeRuta == Ruta.TipoRuta.ida)
                    paraderosIdaOverlay.Markers.Add(paraderoMarker);
                if (_ruta.TipoDeRuta == Ruta.TipoRuta.vuelta)
                    paraderosVueltaOverlay.Markers.Add(paraderoMarker);
            }

            GMarkerGoogleType iconoMarcador = GMarkerGoogleType.arrow;
            string toolTipText = "";
            Coordenada actual;
            Coordenada siguiente;
            for (int i = 0; i < vertices.Count - 1; i++)
            {

                actual = vertices[i];
                siguiente = vertices[i + 1];


                if (i == 0)
                {
                    //Crea marcador al inicio de la ruta
                    if (_ruta.TipoDeRuta == Ruta.TipoRuta.ida)
                    {
                        gmapController.Position = new PointLatLng(actual.Latitud, actual.Longitud); //enfoca el mapa en el inicio
                        iconoMarcador = GMarkerGoogleType.red_small; //icono ida
                        toolTipText = "Inicio ruta ida";

                        GMarkerGoogle InicioMarker = new GMarkerGoogle(new PointLatLng(actual.Latitud, actual.Longitud), iconoMarcador);
                        InicioMarker.ToolTipText = toolTipText;

                        otrosMarkersIdaOverlay.Markers.Add(InicioMarker);
                    }
                }

                List<PointLatLng> puntos = new List<PointLatLng>();
                puntos.Add(new PointLatLng(actual.Latitud, actual.Longitud));
                puntos.Add(new PointLatLng(siguiente.Latitud, siguiente.Longitud));

                GMapRoute ruta = new GMapRoute(puntos, "asdf");

                if (_ruta.TipoDeRuta == Ruta.TipoRuta.ida)
                {
                    ruta.Stroke = new Pen(Color.Red, 4);
                    previewIdaOverlay.Routes.Add(ruta);
                }

                if (_ruta.TipoDeRuta == Ruta.TipoRuta.vuelta)
                {
                    ruta.Stroke = new Pen(Color.Blue, 4);
                    previewVueltaOverlay.Routes.Add(ruta);
                }
            }

            RefreshMap();
        }

        void RefreshMap()
        {
            gmapController.Zoom++;
            gmapController.Zoom--;
        }

        private void btnCrearRuta_Click(object sender, EventArgs e)
        {
            editandoMapa = true;

            btnCrearRuta.Enabled = false;
            btnDeshacer.Enabled = false;
            btnGuardarDatos.Enabled = false;

            btnAceptarRuta.Enabled = true;


            puntosClickeadosVuelta = new List<PointLatLng>();
            posVerticesVuelta = new List<PointLatLng>();
            fragmentosDeRuta = new List<GMapRoute>();
            markParaderosVuelta = new List<GMarkerGoogle>();

            otrosMarkersVueltaOverlay.Clear();
            paraderosVueltaOverlay.Clear();
            previewVueltaOverlay.Clear();
            RefreshMap();

            puntosClickeadosVuelta.Add(new PointLatLng(puntoInicioRutaVuelta.Position.Lat, puntoInicioRutaVuelta.Position.Lng));
        }

        void DibujarTramo(List<PointLatLng> _puntos, Color _color, GMapOverlay _overlay, int _numeroFragmento)
        {
            PointLatLng actual;
            PointLatLng siguiente;
            for (int i = 0; i < _puntos.Count - 1; i++)
            {

                actual = _puntos[i];
                siguiente = _puntos[i + 1];

                List<PointLatLng> puntos = new List<PointLatLng>();
                puntos.Add(actual);
                puntos.Add(siguiente);

                GMapPolygon polygon = new GMapPolygon(puntos, _numeroFragmento + "");
                polygon.Stroke = new Pen(_color, 4);

                _overlay.Polygons.Add(polygon);
            }
        }

        void EliminarTramoDibujado(GMapOverlay _overlay, int _numeroFragmento)
        {
            List<GMapPolygon> borrables = new List<GMapPolygon>();

            foreach (GMapPolygon pol in _overlay.Polygons)
            {
                if (pol.Name == _numeroFragmento + "")
                {
                    borrables.Add(pol);
                }
            }

            foreach (GMapPolygon pol in borrables)
            {
                _overlay.Polygons.Remove(pol);
            }
        }

        private List<Paradero> CrearParaderos(List<GMarkerGoogle> _listaMarcadores)
        {
            //se revisan los elementos de la lista de markParaderos para crear los paraderos de verdad
            //usado antes de guardar datos

            List<Paradero> paraderos = new List<Paradero>();

            foreach (var mark in _listaMarcadores)
            {
                Paradero p = new Paradero(mark.Position.Lat, mark.Position.Lng);
                paraderos.Add(p);
            }

            return paraderos;
        }

        private List<Coordenada> CrearVertices(List<PointLatLng> _puntosVertices)
        {
            //se revisan los puntos de la ruta para crear las coordenadas 

            List<Coordenada> vertices = new List<Coordenada>();

            for (int i = 0; i < _puntosVertices.Count; i++)
            {
                PointLatLng punto = _puntosVertices[i];

                Coordenada c = new Coordenada(punto.Lat, punto.Lng, null);
                vertices.Add(c);
            }
            return vertices;
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            //deshace el ultimo trozo de ruta creado

            //Quita el paradero si esque hay
            GMarkerGoogle m = markParaderosVuelta.Where(mp => Convert.ToString(mp.Tag) == fragmentosDeRuta.Count + "").FirstOrDefault();

            paraderosVueltaOverlay.Markers.Remove(m);
            markParaderosVuelta.Remove(m);


            if (editandoMapa && puntosClickeadosVuelta.Count >= 2)
            {
                GMapRoute ultimoFragmento = fragmentosDeRuta.Last();

                List<PointLatLng> verticesUltimoFragmento = ultimoFragmento.Points;

                foreach (PointLatLng p in verticesUltimoFragmento)
                {
                    posVerticesVuelta.Remove(p);
                }

                EliminarTramoDibujado(previewVueltaOverlay, fragmentosDeRuta.Count);

                fragmentosDeRuta.Remove(ultimoFragmento);
                puntosClickeadosVuelta.RemoveAt(puntosClickeadosVuelta.Count - 1);

                
            }

            if(editandoMapa && puntosClickeadosVuelta.Count == 1)
            {
                btnDeshacer.Enabled = false;
            }
        }

        private void btnAceptarRuta_Click(object sender, EventArgs e)
        {
            editandoMapa = false;

            btnCrearRuta.Enabled = true;

            btnAceptarRuta.Enabled = false;
            btnDeshacer.Enabled = false;

            if (posVerticesVuelta.Count > 1)
                btnGuardarDatos.Enabled = true;

            //redibuja para confirmar errores
            otrosMarkersVueltaOverlay.Clear();
            paraderosVueltaOverlay.Clear();
            previewVueltaOverlay.Clear();

            CargarPuntosEnMapa(posVerticesVuelta, markParaderosVuelta);
        }

        void CargarPuntosEnMapa(List<PointLatLng> _vertices, List<GMarkerGoogle> _paraderos)
        {
            //al apretar aceptarRuta, se redibujan las 2 rutas de nuevo para comprobar errores

            if (!ConnectionTester.IsConnectionActive())
                return;

            List<GMarkerGoogle> paraderos = _paraderos;
            List<PointLatLng> vertices = _vertices;


            foreach (GMarkerGoogle p in paraderos) //Crear paraderos en el mapa
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(p.Position.Lat, p.Position.Lng), GMarkerGoogleType.purple_small);

                paraderosVueltaOverlay.Markers.Add(paraderoMarker);
            }

            GMarkerGoogleType iconoMarcador = GMarkerGoogleType.arrow;
            string toolTipText = "";
            PointLatLng actual;
            PointLatLng siguiente;
            for (int i = 0; i < vertices.Count - 1; i++)
            {

                actual = vertices[i];
                siguiente = vertices[i + 1];


                if (i == vertices.Count - 2)
                {
                    //Crea marcador al final de la ruta
                    //solo en la de ruta de vuelta
  
                    gmapController.Position = new PointLatLng(actual.Lat, actual.Lng); //enfoca el mapa en el inicio
                    iconoMarcador = GMarkerGoogleType.blue_small; //icono ida
                    toolTipText = "Final ruta vuelta";

                    GMarkerGoogle FinalMarker = new GMarkerGoogle(new PointLatLng(siguiente.Lat, siguiente.Lng), iconoMarcador);
                    FinalMarker.ToolTipText = toolTipText;

                    otrosMarkersVueltaOverlay.Markers.Add(FinalMarker);


                }

                List<PointLatLng> puntos = new List<PointLatLng>();
                puntos.Add(new PointLatLng(actual.Lat, actual.Lng));
                puntos.Add(new PointLatLng(siguiente.Lat, siguiente.Lng));

                GMapRoute ruta = new GMapRoute(puntos, "asdf");

                ruta.Stroke = new Pen(Color.Blue, 4);
                previewVueltaOverlay.Routes.Add(ruta);
            }

            RefreshMap();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            List<Coordenada> verticesVuelta = CrearVertices(posVerticesVuelta);
            Coordenada ultima = verticesVuelta[verticesVuelta.Count - 1];

            string mensajeError = "";

            if (txtNombreLinea.Text == "")
            {
                mensajeError += "\n-No puede dejar el campo nombre vacío";
            }
            else if (Ruta.BuscarPorNombre(txtNombreLinea.Text) != null)
            {
                mensajeError += "\n-El nombre de esa ruta ya existe";
            }
            if (verticesVuelta.Count < 2)
            {
                mensajeError += "\n-No puede guardar la línea sin haber creado las rutas.";
            }

            if (mensajeError != "")
            {
                MessageBox.Show("Se encontraron los siguientes errores:" + mensajeError);
                return;
            }
            List<Paradero> paraderos = CrearParaderos(markParaderosVuelta);

            Ruta rutaCreada = Ruta.CrearRuta(lineaDeRuta.Id, txtNombreLinea.Text, Ruta.TipoRuta.vuelta, verticesVuelta, paraderos);

            if (rutaCreada != null)
            {
                MessageBox.Show("Nueva ruta de vuelta creada correctamente.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void gmapController_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double lat = gmapController.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gmapController.FromLocalToLatLng(e.X, e.Y).Lng;

            if (e.Button == MouseButtons.Left)
            {
                ClickNuevoPuntoRuta(lat, lng);
            }
        }

        private void gmapController_MouseClick(object sender, MouseEventArgs e)
        {
            //Extiende la ruta hasta ese lugar
            //luego en el ultimo punto crea un paradero

            double lat = gmapController.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gmapController.FromLocalToLatLng(e.X, e.Y).Lng;

            if (e.Button == MouseButtons.Right && editandoMapa && puntosClickeadosVuelta.Count > 0)
            {
                ClickNuevoPuntoRuta(lat, lng);              

            }
        }

        void ClickNuevoPuntoRuta(double _lat, double _lng)
        {
            //extiende la ruta creada
            if (editandoMapa)
            {
                puntosClickeadosVuelta.Add(new PointLatLng(_lat, _lng));

                if (puntosClickeadosVuelta.Count > 1)
                {
                    GDirections direccion;

                    int puntoActual = puntosClickeadosVuelta.Count - 1;
                    int puntoAnterior = puntoActual - 1;

                    var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, puntosClickeadosVuelta[puntoAnterior], puntosClickeadosVuelta[puntoActual], false, false, false, false, false);
                    if (direccion == null)
                    {
                        MessageBox.Show("No fue posible crear una ruta al lugar indicado.\nSe recomienda revisar su conexión a internet, por ser necesaria en la búsqueda de rutas.");
                        puntosClickeadosVuelta.Remove(puntosClickeadosVuelta.Last());
                        return;
                    }
                    GMapRoute ultimoFragmentoRuta = new GMapRoute(direccion.Route, "rutaPrevIda");


                    fragmentosDeRuta.Add(ultimoFragmentoRuta);

                    DibujarTramo(ultimoFragmentoRuta.Points, Color.Blue, previewVueltaOverlay, fragmentosDeRuta.Count);

                    RefreshMap();

                    for (int i = 0; i < ultimoFragmentoRuta.Points.Count; i++)
                    {
                        PointLatLng punto = ultimoFragmentoRuta.Points[i];
                        posVerticesVuelta.Add(punto);
                    }
                }

                btnDeshacer.Enabled = true;
                CrearPosicionParadero(posVerticesVuelta.Last().Lat, posVerticesVuelta.Last().Lng);
            }
        }

        void CrearPosicionParadero(double _lat, double _lng)
        {
            //Se hace doble click en el lugar donde se quiere hacer un paradero

            if (editandoMapa)
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(_lat, _lng), GMarkerGoogleType.purple_small);
                paraderoMarker.Tag = fragmentosDeRuta.Count + "";
                markParaderosVuelta.Add(paraderoMarker);
                paraderosVueltaOverlay.Markers.Add(paraderoMarker);
            }
        }
    }
}
