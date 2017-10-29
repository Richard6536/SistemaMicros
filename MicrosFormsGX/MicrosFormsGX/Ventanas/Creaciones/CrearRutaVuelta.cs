using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MicrosFormsGX.Classes;
using MicrosFormsGX.Model;
using MicrosFormsGX.Model.DatosTemporales;
using MicrosFormsGX.Ventanas;
using MicrosFormsGX.Ventanas.Creaciones;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MetroFramework;

namespace MicrosFormsGX.Ventanas.Creaciones
{
    public partial class CrearRutaVuelta : MetroFramework.Forms.MetroForm
    {
        int numeroIntentoDireccion = 5;
        LineaTP lineaDeRuta;
        RutaTP rutaDeIda;

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

        public CrearRutaVuelta(int _idLinea)
        {
            InitializeComponent();


            //lineaDeRuta = Linea.BuscarLinea(_idLinea);
            //rutaDeIda = Ruta.BuscarPorId(lineaDeRuta.RutaIdaId.Value);
            lineaDeRuta = LineaTP.todasLineas.Where(l => l.Id == _idLinea).FirstOrDefault();
            rutaDeIda = lineaDeRuta.rutaIda;

            lblLinea.Text = "Línea: " + lineaDeRuta.Nombre;
            btnDeshacer.Enabled = false;
            btnAceptarRuta.Enabled = false;
            btnGuardarDatos.Enabled = false;

            IniciarMapa();

            MapController.CargarRutaEnMapaOffline(rutaDeIda, gmapController, paraderosIdaOverlay, previewIdaOverlay, Color.Red);


            //List<Coordenada> coor = Ruta.ObtenerVerticesDeInicioAFin(rutaDeIda);
            List<Coordenada> coor = rutaDeIda.listaCoordenadas;
            MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersIdaOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);

            //Ruta rutaVueltaAnterior = Ruta.BuscarPorId(lineaDeRuta.RutaVueltaId.Value);
            //Coordenada puntoInicial = Coordenada.BuscarPorId(rutaVueltaAnterior.InicioId);

            RutaTP rutaVueltaAnterior = lineaDeRuta.rutaVuelta;
            Coordenada puntoInicial = rutaVueltaAnterior.listaCoordenadas.OrderBy(c => c.Orden).First();

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
            gmapController.MapProvider = MapController.provider;

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
            panelVuelta.Visible = true;

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

            if (editandoMapa && puntosClickeadosVuelta.Count == 1)
            {
                btnDeshacer.Enabled = false;
            }
        }

        private void btnAceptarRuta_Click(object sender, EventArgs e)
        {
            editandoMapa = false;
            panelVuelta.Visible = false;

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

            if (txtNombreRuta.Text == "")
            {
                mensajeError += "\n-No puede dejar el campo nombre vacío";
            }
            else if (Ruta.BuscarPorNombre(txtNombreRuta.Text) != null)
            {
                mensajeError += "\n-El nombre de esa ruta ya existe";
            }
            if (verticesVuelta.Count < 2)
            {
                mensajeError += "\n-No puede guardar la línea sin haber creado las rutas.";
            }

            if (mensajeError != "")
            {
                MetroMessageBox.Show(this,"Se encontraron los siguientes errores:" + mensajeError);
                return;
            }
            List<Paradero> paraderos = MapController.CrearParaderos(markParaderosVuelta);

            Ruta rutaCreada = Ruta.CrearRuta(lineaDeRuta.Id, txtNombreRuta.Text, Ruta.TipoRuta.vuelta, verticesVuelta, paraderos);

            if (rutaCreada != null)
            {
                CrearTemporales(rutaCreada, paraderos, verticesVuelta);
                MetroMessageBox.Show(this,"Nueva ruta de vuelta creada correctamente.");
                this.DialogResult = DialogResult.OK;
            }
        }

        void CrearTemporales(Ruta _rutaVueltaNueva, List<Paradero> _paraderos, List<Coordenada> _coors)
        {
            RutaTP rVueltaTP = new RutaTP();
            rVueltaTP.Id = _rutaVueltaNueva.Id;
            rVueltaTP.Nombre = _rutaVueltaNueva.Nombre;
            rVueltaTP.TipoRuta = Ruta.TipoRuta.vuelta;
            rVueltaTP.LineaId = lineaDeRuta.Id;
            rVueltaTP.Paraderos = _paraderos;
            rVueltaTP.listaCoordenadas = _coors;

            RutaTP.todasRutas.Add(rVueltaTP);
            lineaDeRuta.rutasDeLinea.Add(rVueltaTP);

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

                if (res)
                    MapController.CrearPosicionParadero(posVerticesVuelta.Last().Lat, posVerticesVuelta.Last().Lng, fragmentosDeRuta, markParaderosVuelta, paraderosVueltaOverlay);

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
                    int c = 0;
                    while (direccion == null && c < numeroIntentoDireccion)
                    {
                        rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, puntosClickeadosVuelta[puntoAnterior], puntosClickeadosVuelta[puntoActual], false, false, false, false, false);
                        c++;
                    }

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

        private void CrearRutaVuelta_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }
    }
}
