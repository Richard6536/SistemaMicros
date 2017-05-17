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

            MapController.CargarRutaEnMapa(rutaDeIda, gmapController, paraderosIdaOverlay, previewIdaOverlay, Color.Red);
            List<Coordenada> coor = Ruta.ObtenerVerticesDeInicioAFin(rutaDeIda);
            MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersIdaOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);

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

                MapController.EliminarTramoDibujado(previewVueltaOverlay, fragmentosDeRuta.Count);

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

            MapController.CargarPuntosEnMapa(posVerticesVuelta, markParaderosVuelta, gmapController, paraderosVueltaOverlay, previewVueltaOverlay, Color.Blue);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            List<Coordenada> verticesVuelta = MapController.CrearVertices(posVerticesVuelta);
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
            List<Paradero> paraderos = MapController.CrearParaderos(markParaderosVuelta);

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
                bool res = ClickNuevoPuntoRuta(lat, lng);

                if(res)
                    MapController.CrearPosicionParadero(posVerticesVuelta.Last().Lat, posVerticesVuelta.Last().Lng, fragmentosDeRuta, markParaderosVuelta, paraderosVueltaOverlay);

            }
        }

        bool ClickNuevoPuntoRuta(double _lat, double _lng)
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
                        return false;
                    }
                    GMapRoute ultimoFragmentoRuta = new GMapRoute(direccion.Route, "rutaPrevIda");


                    fragmentosDeRuta.Add(ultimoFragmentoRuta);

                    MapController.DibujarTramo(ultimoFragmentoRuta.Points, Color.Blue, previewVueltaOverlay, fragmentosDeRuta.Count);

                    RefreshMap();

                    for (int i = 0; i < ultimoFragmentoRuta.Points.Count; i++)
                    {
                        PointLatLng punto = ultimoFragmentoRuta.Points[i];
                        posVerticesVuelta.Add(punto);
                    }
                }

                btnDeshacer.Enabled = true;
            }
            return true;
        }

    }
}
