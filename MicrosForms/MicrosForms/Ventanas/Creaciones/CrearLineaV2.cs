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
    public partial class CrearLineaV2 : Form
    {
        bool editandoMapa;
        bool editandoIda;

        GMapOverlay previewIdaOverlay;
        GMapOverlay previewVueltaOverlay;
        GMapOverlay paraderosOverlay;
        GMapOverlay otrosMarkersOverlay;



        List<PointLatLng> posVerticesIda;
        List<PointLatLng> puntosClickeadosIda;

        List<PointLatLng> posVerticesVuelta;
        List<PointLatLng> puntosClickeadosVuelta;

        List<GMarkerGoogle> markParaderosIda;
        List<GMarkerGoogle> markParaderosVuelta;


        List<GMarkerGoogle> otrosMarkersList;

        GMarkerGoogle puntoInicioRuta;
        GMarkerGoogle puntoInicioRegreso;

        List<GMapRoute> fragmentosDeRuta;


        public CrearLineaV2()
        {
            InitializeComponent();

            IniciarMapa();

            btnComenzarVuelta.Enabled = false;
            btnDeshacer.Enabled = false;
            btnAceptarRuta.Enabled = false;

           

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
            paraderosOverlay = new GMapOverlay();
            otrosMarkersOverlay = new GMapOverlay();

            gmapController.Overlays.Add(previewIdaOverlay);
            gmapController.Overlays.Add(previewVueltaOverlay);
            gmapController.Overlays.Add(paraderosOverlay);
            gmapController.Overlays.Add(otrosMarkersOverlay);

            markParaderosIda = new List<GMarkerGoogle>();
            markParaderosVuelta = new List<GMarkerGoogle>();
            posVerticesIda = new List<PointLatLng>();
            posVerticesVuelta = new List<PointLatLng>();
        }

        #region Creacion rutas

        private void btnCrearRuta_Click(object sender, EventArgs e)
        {
            editandoMapa = true;
            editandoIda = true;

            btnCrearRuta.Enabled = false;

            btnDeshacer.Enabled = false;
            btnGuardarDatos.Enabled = false;

            btnAceptarRuta.Enabled = true;


            puntosClickeadosIda = new List<PointLatLng>();
            puntosClickeadosVuelta = new List<PointLatLng>();

            posVerticesIda = new List<PointLatLng>();
            posVerticesVuelta = new List<PointLatLng>();

            otrosMarkersList = new List<GMarkerGoogle>();
            fragmentosDeRuta = new List<GMapRoute>();

            markParaderosIda = new List<GMarkerGoogle>();
            markParaderosVuelta = new List<GMarkerGoogle>();

            otrosMarkersOverlay.Clear();
            paraderosOverlay.Clear();
            previewIdaOverlay.Clear();
            previewVueltaOverlay.Clear();

            RefreshMap();
        }

        void ClickNuevoPuntoRuta(double _lat, double _lng)
        {
            //extiende la ruta creada
            if (editandoMapa && editandoIda)
            {
                puntosClickeadosIda.Add(new PointLatLng(_lat, _lng));

                if (puntosClickeadosIda.Count == 1)
                {
                    puntoInicioRuta = new GMarkerGoogle(new PointLatLng(_lat, _lng), GMarkerGoogleType.red_small);
                    puntoInicioRuta.ToolTipText = "Inicio de ida";
                    otrosMarkersList.Add(puntoInicioRuta);
                    otrosMarkersOverlay.Markers.Add(puntoInicioRuta);
                }

                if (puntosClickeadosIda.Count > 1)
                {
                    btnComenzarVuelta.Enabled = true;
                    GDirections direccion;

                    int puntoActual = puntosClickeadosIda.Count - 1;
                    int puntoAnterior = puntoActual - 1;

                    var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, puntosClickeadosIda[puntoAnterior], puntosClickeadosIda[puntoActual], false, false, false, false, false);
                    if (direccion == null)
                    {
                        MessageBox.Show("No fue posible crear una ruta al lugar indicado.\nSe recomienda revisar su conexión a internet, por ser necesaria en la búsqueda de rutas.");
                        puntosClickeadosIda.Remove(puntosClickeadosIda.Last());
                        return;
                    }
                    GMapRoute ultimoFragmentoRuta = new GMapRoute(direccion.Route, "rutaPrevIda");


                    fragmentosDeRuta.Add(ultimoFragmentoRuta);

                    DibujarTramo(ultimoFragmentoRuta.Points, Color.Red, previewIdaOverlay, fragmentosDeRuta.Count);

                    RefreshMap();

                    for (int i = 0; i < ultimoFragmentoRuta.Points.Count; i++)
                    {
                        PointLatLng punto = ultimoFragmentoRuta.Points[i];
                        posVerticesIda.Add(punto);
                    }
                }

                btnDeshacer.Enabled = true;
            }
            else if(editandoMapa && !editandoIda)
            {
                puntosClickeadosVuelta.Add(new PointLatLng(_lat, _lng));

                btnComenzarVuelta.Enabled = false;
                GDirections direccion;

                int nActual = puntosClickeadosVuelta.Count - 1;
                int nAnterior = Math.Max(nActual - 1 , 0); //no permite ser menor que cero y evita error de index

                PointLatLng actual = puntosClickeadosVuelta[nActual];
                PointLatLng anterior =puntosClickeadosVuelta[nAnterior];

                if (puntosClickeadosVuelta.Count == 1) //EL punto anterior debe ser el ultimo de la ruta de ida
                    anterior = puntosClickeadosIda.Last();

                var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, anterior, actual, false, false, false, false, false);

                if (direccion == null)
                {
                    MessageBox.Show("No fue posible crear una ruta al lugar indicado.\nSe recomienda revisar su conexión a internet, por ser necesaria en la búsqueda de rutas.");
                    puntosClickeadosVuelta.Remove(puntosClickeadosVuelta.Last());
                    return;
                }
                GMapRoute ultimoFragmentoRuta = new GMapRoute(direccion.Route, "rutaPrevVuelta");

                fragmentosDeRuta.Add(ultimoFragmentoRuta);

                DibujarTramo(ultimoFragmentoRuta.Points, Color.Blue, previewVueltaOverlay, fragmentosDeRuta.Count);

                RefreshMap();

                for (int i = 0; i < ultimoFragmentoRuta.Points.Count; i++)
                {
                    PointLatLng punto = ultimoFragmentoRuta.Points[i];
                    posVerticesVuelta.Add(punto);
                }

            }
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

                GMapPolygon polygon = new GMapPolygon(puntos, _numeroFragmento+"");
                polygon.Stroke = new Pen(_color, 4);

                _overlay.Polygons.Add(polygon);
            }
        }

        void EliminarTramoDibujado(GMapOverlay _overlay, int _numeroFragmento)
        {
            List<GMapPolygon> borrables = new List<GMapPolygon>();

            foreach(GMapPolygon pol in _overlay.Polygons)
            {
                if(pol.Name == _numeroFragmento +"")
                {
                    borrables.Add(pol);
                }
            }

            foreach(GMapPolygon pol in borrables)
            {
                _overlay.Polygons.Remove(pol);
            }
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            //deshace el ultimo trozo de ruta creado
            if (editandoIda)
            {
                if (editandoMapa && puntosClickeadosIda.Count == 1)
                {
                    otrosMarkersOverlay.Markers.Remove(puntoInicioRuta);
                    puntosClickeadosIda.RemoveAt(puntosClickeadosIda.Count - 1);
                    btnDeshacer.Enabled = false;

                    RefreshMap();
                }

                //Quita el paradero si esque hay
                GMarkerGoogle m = markParaderosIda.Where(mp => Convert.ToString(mp.Tag) == fragmentosDeRuta.Count+"").FirstOrDefault();

                paraderosOverlay.Markers.Remove(m);
                markParaderosIda.Remove(m);


                if (editandoMapa && puntosClickeadosIda.Count >= 2)
                {
                    GMapRoute ultimoFragmento = fragmentosDeRuta.Last();

                    List<PointLatLng> verticesUltimoFragmento = ultimoFragmento.Points;

                    foreach (PointLatLng p in verticesUltimoFragmento)
                    {
                        posVerticesIda.Remove(p);
                    }

                    EliminarTramoDibujado(previewIdaOverlay, fragmentosDeRuta.Count);

                    fragmentosDeRuta.Remove(ultimoFragmento);
                    puntosClickeadosIda.RemoveAt(puntosClickeadosIda.Count - 1);

                }

                if(puntosClickeadosIda.Count < 2)
                {
                    btnComenzarVuelta.Enabled = false;
                }
            }
            else
            {
                if(editandoMapa && puntosClickeadosVuelta.Count == 0)
                {
                    //Deshace el ultimo trampo de ida y elimina el marker con el tag InicioRegreso

                    GMapRoute ultimoFragmento = fragmentosDeRuta.Last();

                    EliminarTramoDibujado(previewIdaOverlay, fragmentosDeRuta.Count);

                    fragmentosDeRuta.Remove(ultimoFragmento);
                    puntosClickeadosIda.RemoveAt(puntosClickeadosIda.Count - 1);

                    otrosMarkersOverlay.Markers.Remove(puntoInicioRegreso);
                    puntoInicioRegreso = null;

                    btnComenzarVuelta.Enabled = true;
                    editandoIda = true;
                }

                if (editandoMapa && puntosClickeadosVuelta.Count >= 1)
                {

                    //Quita el paradero si esque hay
                    GMarkerGoogle m = markParaderosVuelta.Where(mp => Convert.ToString(mp.Tag) == fragmentosDeRuta.Count + "").FirstOrDefault();
                    paraderosOverlay.Markers.Remove(m);
                    markParaderosVuelta.Remove(m);

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
            }

        }

        private void btnAceptarRuta_Click(object sender, EventArgs e)
        {
            editandoMapa = false;

            btnCrearRuta.Enabled = true;
            btnGuardarDatos.Enabled = true;

            btnAceptarRuta.Enabled = false;
            btnDeshacer.Enabled = false;
            btnComenzarVuelta.Enabled = false;

            //dibujar de nuevo en el mapa para comprobar errores
            otrosMarkersOverlay.Clear();
            paraderosOverlay.Clear();
            previewIdaOverlay.Clear();
            previewVueltaOverlay.Clear();

            CargarPuntosEnMapa(posVerticesIda, markParaderosIda, Ruta.TipoRuta.ida);
            CargarPuntosEnMapa(posVerticesVuelta, markParaderosVuelta, Ruta.TipoRuta.vuelta);

        }

        private void btnComenzarVuelta_Click(object sender, EventArgs e)
        {
            editandoIda = false;
            btnComenzarVuelta.Enabled = false;
        }
        #endregion


        #region Creacion paraderos

        void CrearPosicionParadero(double _lat, double _lng)
        {
            //Se hace doble click en el lugar donde se quiere hacer un paradero

            if (editandoMapa)
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(_lat, _lng), GMarkerGoogleType.purple_small);
                paraderoMarker.Tag = fragmentosDeRuta.Count + "";

                if (editandoIda)
                    markParaderosIda.Add(paraderoMarker);
                    
                if(!editandoIda)
                    markParaderosVuelta.Add(paraderoMarker);
                
                paraderosOverlay.Markers.Add(paraderoMarker);
            }
        }


        #endregion


       

        void CargarPuntosEnMapa(List<PointLatLng> _vertices, List<GMarkerGoogle> _paraderos, Ruta.TipoRuta _tipoRuta)
        {
            //al apretar aceptarRuta, se redibujan las 2 rutas de nuevo para comprobar errores

            if (!ConnectionTester.IsConnectionActive())
                return;

            List<GMarkerGoogle> paraderos = _paraderos;
            List<PointLatLng> vertices = _vertices;


            foreach (GMarkerGoogle p in paraderos) //Crear paraderos en el mapa
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(p.Position.Lat, p.Position.Lng), GMarkerGoogleType.purple_small);

                paraderosOverlay.Markers.Add(paraderoMarker);
            }

            GMarkerGoogleType iconoMarcador = GMarkerGoogleType.arrow;
            string toolTipText = "";
            PointLatLng actual;
            PointLatLng siguiente;
            for (int i = 0; i < vertices.Count - 1; i++)
            {

                actual = vertices[i];
                siguiente = vertices[i + 1];


                if (i == 0)
                {
                    //Crea marcador al inicio de la ruta
                    if (_tipoRuta == Ruta.TipoRuta.ida)
                    {
                        gmapController.Position = new PointLatLng(actual.Lat, actual.Lng); //enfoca el mapa en el inicio
                        iconoMarcador = GMarkerGoogleType.red_small; //icono ida
                        toolTipText = "Inicio ruta ida";
                    }
                    else
                    {
                        iconoMarcador = GMarkerGoogleType.blue_small; //icono vuelta
                        toolTipText = "Inicio ruta vuelta";
                    }

                    GMarkerGoogle InicioMarker = new GMarkerGoogle(new PointLatLng(actual.Lat, actual.Lng), iconoMarcador);
                    InicioMarker.ToolTipText = toolTipText;

                    otrosMarkersOverlay.Markers.Add(InicioMarker);
                }

                if (i == vertices.Count - 2)
                {
                    //Crea marcador al final de la ruta
                    //solo en la de ruta de vuelta
                    if (_tipoRuta == Ruta.TipoRuta.vuelta)
                    {
                        gmapController.Position = new PointLatLng(actual.Lat, actual.Lng); //enfoca el mapa en el inicio
                        iconoMarcador = GMarkerGoogleType.blue_small; //icono ida
                        toolTipText = "Final ruta vuelta";

                        GMarkerGoogle FinalMarker = new GMarkerGoogle(new PointLatLng(siguiente.Lat, siguiente.Lng), iconoMarcador);
                        FinalMarker.ToolTipText = toolTipText;

                        otrosMarkersOverlay.Markers.Add(FinalMarker);
                    }

                }

                List<PointLatLng> puntos = new List<PointLatLng>();
                puntos.Add(new PointLatLng(actual.Lat, actual.Lng));
                puntos.Add(new PointLatLng(siguiente.Lat, siguiente.Lng));

                //GMapPolygon polygon = new GMapPolygon(puntos, "mypolygon");
                GMapRoute ruta = new GMapRoute(puntos, "asdf");

                if (_tipoRuta == Ruta.TipoRuta.ida)
                {
                    ruta.Stroke = new Pen(Color.Red, 4);
                    previewIdaOverlay.Routes.Add(ruta);
                }
                    
                if (_tipoRuta == Ruta.TipoRuta.vuelta)
                {
                    ruta.Stroke = new Pen(Color.Blue, 4);
                    previewVueltaOverlay.Routes.Add(ruta);
                }
                    
                
            }

            RefreshMap();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Volver atras simplemente con dialogresult
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            string mensajeError = "";

            List<Coordenada> verticesIda = CrearVertices(posVerticesIda);
            List<Coordenada> verticesVuelta = CrearVertices(posVerticesVuelta);

            if (txtNombreLinea.Text == "")
            {
                mensajeError += "\n-No puede dejar el campo nombre vacío";
            }
            else if(Linea.BuscarLineaPorNombre(txtNombreLinea.Text) != null)
            {
                mensajeError += "\n-El nombre de esa línea ya existe";
            }

            if (verticesIda.Count < 2)
            {
                mensajeError += "\n-No puede guardar la línea sin haber creado las rutas.";
            }
            else if(verticesVuelta.Count < 2 )
            {
                mensajeError += "\n-No puede guardar la línea porque faltó definir la ruta de vuelta.";
            }

            if(mensajeError != "")
            {
                MessageBox.Show("Se encontraron los siguientes errores:"+mensajeError);
                return;
            }

            List<Paradero> paraderosIda = CrearParaderos(markParaderosIda);
            List<Paradero> paraderosVuelta = CrearParaderos(markParaderosVuelta);


            Linea nuevaLinea = Linea.CrearLinea(txtNombreLinea.Text);

            Ruta rutaIda = Ruta.CrearRuta(nuevaLinea.Id,txtNombreLinea.Text+"_ida1", Ruta.TipoRuta.ida, verticesIda, paraderosIda);
            Ruta rutaVuelta = Ruta.CrearRuta(nuevaLinea.Id, txtNombreLinea.Text+"_vuelta1", Ruta.TipoRuta.vuelta, verticesVuelta, paraderosVuelta);

            if(nuevaLinea != null && rutaIda != null && rutaVuelta != null)
            {
                rutaIda.AsignarRutaComoUsable();
                rutaVuelta.AsignarRutaComoUsable();

                MessageBox.Show("Linea creada correctamente");
                this.DialogResult = DialogResult.OK;
            }
        }


        void RefreshMap()
        {
            gmapController.Zoom = gmapController.Zoom + 1;
            gmapController.Zoom = gmapController.Zoom - 1;
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

        private void gmapController_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double lat = gmapController.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gmapController.FromLocalToLatLng(e.X, e.Y).Lng;

            if(e.Button == MouseButtons.Left)
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

            if (e.Button == MouseButtons.Right && editandoMapa && puntosClickeadosIda.Count > 0)
            {
                ClickNuevoPuntoRuta(lat, lng);

                if (editandoIda )
                {
                    CrearPosicionParadero(posVerticesIda.Last().Lat, posVerticesIda.Last().Lng);
                }
                else
                {
                    CrearPosicionParadero(posVerticesVuelta.Last().Lat, posVerticesVuelta.Last().Lng);
                }

            }
        }
    }
}
