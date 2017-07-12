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
    public partial class CrearLineaV2 : MetroFramework.Forms.MetroForm
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

        private void btnCrearRuta_Click(object sender, EventArgs e)
        {
            editandoMapa = true;
            editandoIda = true;
            panelIda.Visible = true;
            lblIda.Visible = true;
            lblVuelta.Visible = false;

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

        private bool ClickNuevoPuntoRuta(double _lat, double _lng)
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
                        MetroMessageBox.Show(this,"No fue posible crear una ruta al lugar indicado.\nSe recomienda revisar su conexión a internet, por ser necesaria en la búsqueda de rutas.");
                        puntosClickeadosIda.Remove(puntosClickeadosIda.Last());
                        return false;
                    }
                    GMapRoute ultimoFragmentoRuta = new GMapRoute(direccion.Route, "rutaPrevIda");


                    fragmentosDeRuta.Add(ultimoFragmentoRuta);

                    MapController.DibujarTramo(ultimoFragmentoRuta.Points, Color.Red, previewIdaOverlay, fragmentosDeRuta.Count);

                    RefreshMap();

                    for (int i = 0; i < ultimoFragmentoRuta.Points.Count; i++)
                    {
                        PointLatLng punto = ultimoFragmentoRuta.Points[i];
                        posVerticesIda.Add(punto);
                    }
                }

                btnDeshacer.Enabled = true;
            }
            else if (editandoMapa && !editandoIda)
            {
                puntosClickeadosVuelta.Add(new PointLatLng(_lat, _lng));

                btnComenzarVuelta.Enabled = false;
                GDirections direccion;

                int nActual = puntosClickeadosVuelta.Count - 1;
                int nAnterior = Math.Max(nActual - 1, 0); //no permite ser menor que cero y evita error de index

                PointLatLng actual = puntosClickeadosVuelta[nActual];
                PointLatLng anterior = puntosClickeadosVuelta[nAnterior];

                if (puntosClickeadosVuelta.Count == 1) //EL punto anterior debe ser el ultimo de la ruta de ida
                    anterior = puntosClickeadosIda.Last();

                var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, anterior, actual, false, false, false, false, false);

                if (direccion == null)
                {
                    MetroMessageBox.Show(this,"No fue posible crear una ruta al lugar indicado.\nSe recomienda revisar su conexión a internet, por ser necesaria en la búsqueda de rutas.");
                    puntosClickeadosVuelta.Remove(puntosClickeadosVuelta.Last());
                    return false;
                }
                GMapRoute ultimoFragmentoRuta = new GMapRoute(direccion.Route, "rutaPrevVuelta");

                fragmentosDeRuta.Add(ultimoFragmentoRuta);

                MapController.DibujarTramo(ultimoFragmentoRuta.Points, Color.Blue, previewVueltaOverlay, fragmentosDeRuta.Count);

                RefreshMap();

                for (int i = 0; i < ultimoFragmentoRuta.Points.Count; i++)
                {
                    PointLatLng punto = ultimoFragmentoRuta.Points[i];
                    posVerticesVuelta.Add(punto);
                }

            }

            return true;
        }

        private void btnComenzarVuelta_Click(object sender, EventArgs e)
        {
            editandoIda = false;
            lblIda.Visible = false;
            lblVuelta.Visible = true;
            btnComenzarVuelta.Enabled = false;
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            if (editandoMapa)
            {
                //deshace el ultimo trozo de ruta creado
                if (editandoIda)
                {
                    if (puntosClickeadosIda.Count == 1)
                    {
                        otrosMarkersOverlay.Markers.Remove(puntoInicioRuta);
                        puntosClickeadosIda.RemoveAt(puntosClickeadosIda.Count - 1);
                        btnDeshacer.Enabled = false;

                        RefreshMap();
                    }

                    //Quita el paradero si esque hay
                    GMarkerGoogle m = markParaderosIda.Where(mp => Convert.ToString(mp.Tag) == fragmentosDeRuta.Count + "").FirstOrDefault();

                    paraderosOverlay.Markers.Remove(m);
                    markParaderosIda.Remove(m);


                    if (puntosClickeadosIda.Count >= 2)
                    {
                        GMapRoute ultimoFragmento = fragmentosDeRuta.Last();

                        List<PointLatLng> verticesUltimoFragmento = ultimoFragmento.Points;

                        foreach (PointLatLng p in verticesUltimoFragmento)
                        {
                            posVerticesIda.Remove(p);
                        }

                        MapController.EliminarTramoDibujado(previewIdaOverlay, fragmentosDeRuta.Count);

                        fragmentosDeRuta.Remove(ultimoFragmento);
                        puntosClickeadosIda.RemoveAt(puntosClickeadosIda.Count - 1);

                    }

                    if (puntosClickeadosIda.Count < 2)
                    {
                        btnComenzarVuelta.Enabled = false;
                    }
                }
                else
                {

                    if (puntosClickeadosVuelta.Count == 0)
                    {
                        //Quita el paradero si esque hay (el ultimo del tramo de ida)
                        GMarkerGoogle m = markParaderosIda.Where(mp => Convert.ToString(mp.Tag) == fragmentosDeRuta.Count + "").FirstOrDefault();
                        paraderosOverlay.Markers.Remove(m);
                        markParaderosVuelta.Remove(m);


                        //Deshace el ultimo trampo de ida y elimina el marker con el tag InicioRegreso
                        GMapRoute ultimoFragmento = fragmentosDeRuta.Last();
                        List<PointLatLng> verticesUltimoFragmento = ultimoFragmento.Points;

                        foreach (PointLatLng p in verticesUltimoFragmento)
                        {
                            posVerticesIda.Remove(p);
                        }


                        MapController.EliminarTramoDibujado(previewIdaOverlay, fragmentosDeRuta.Count);

                        fragmentosDeRuta.Remove(ultimoFragmento);
                        puntosClickeadosIda.RemoveAt(puntosClickeadosIda.Count - 1);

                        otrosMarkersOverlay.Markers.Remove(puntoInicioRegreso);
                        puntoInicioRegreso = null;

                        btnComenzarVuelta.Enabled = true;
                        editandoIda = true;
                        lblIda.Visible = true;
                        lblVuelta.Visible = false;

                    }

                    if (puntosClickeadosVuelta.Count >= 1)
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

                        MapController.EliminarTramoDibujado(previewVueltaOverlay, fragmentosDeRuta.Count);

                        fragmentosDeRuta.Remove(ultimoFragmento);
                        puntosClickeadosVuelta.RemoveAt(puntosClickeadosVuelta.Count - 1);

                    }
                }
            }
        }

        private void btnAceptarRuta_Click(object sender, EventArgs e)
        {
            editandoMapa = false;
            panelIda.Visible = false;

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


            MapController.CargarPuntosEnMapa(posVerticesIda, markParaderosIda, gmapController, paraderosOverlay, previewIdaOverlay, Color.Red);
            MapController.CargarPuntosEnMapa(posVerticesVuelta, markParaderosVuelta, gmapController, paraderosOverlay, previewVueltaOverlay, Color.Blue);
            List<Coordenada> coordenadas = MapController.CrearVertices(posVerticesIda);
            MapController.CrearMarcadorInicio(coordenadas, gmapController, otrosMarkersOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);

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

            List<Coordenada> verticesIda = MapController.CrearVertices(posVerticesIda);
            List<Coordenada> verticesVuelta = MapController.CrearVertices(posVerticesVuelta);

            if (txtNombreLinea.Text == "")
            {
                mensajeError += "\n-No puede dejar el campo nombre vacío";
            }
            else if (Linea.BuscarLineaPorNombre(txtNombreLinea.Text) != null)
            {
                mensajeError += "\n-El nombre de esa línea ya existe";
            }

            if (verticesIda.Count < 2)
            {
                mensajeError += "\n-No puede guardar la línea sin haber creado las rutas.";
            }
            else if (verticesVuelta.Count < 2)
            {
                mensajeError += "\n-No puede guardar la línea porque faltó definir la ruta de vuelta.";
            }

            if (mensajeError != "")
            {
                MetroMessageBox.Show(this,"Se encontraron los siguientes errores:" + mensajeError);
                return;
            }

            List<Paradero> paraderosIda = MapController.CrearParaderos(markParaderosIda);
            List<Paradero> paraderosVuelta = MapController.CrearParaderos(markParaderosVuelta);


            Linea nuevaLinea = Linea.CrearLinea(txtNombreLinea.Text);

            Ruta rutaIda = Ruta.CrearRuta(nuevaLinea.Id, txtNombreLinea.Text + "_ida1", Ruta.TipoRuta.ida, verticesIda, paraderosIda);
            Ruta rutaVuelta = Ruta.CrearRuta(nuevaLinea.Id, txtNombreLinea.Text + "_vuelta1", Ruta.TipoRuta.vuelta, verticesVuelta, paraderosVuelta);

            if (nuevaLinea != null && rutaIda != null && rutaVuelta != null)
            {
                rutaIda.AsignarRutaComoUsable();
                rutaVuelta.AsignarRutaComoUsable();

                CrearTemporales(nuevaLinea, rutaIda, paraderosIda, verticesIda, rutaVuelta, paraderosVuelta, verticesVuelta);

                MetroMessageBox.Show(this,"Linea creada correctamente");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void CrearTemporales(Linea _linea, Ruta _rIda, List<Paradero> _paraIda, List<Coordenada> _coorIda, Ruta _rVuelta, List<Paradero> _paraVuelta, List<Coordenada> _coorVuelta)
        {
            RutaTP rIdaTP = new RutaTP();
            rIdaTP.Id = _rIda.Id;
            rIdaTP.Nombre = _rIda.Nombre;
            rIdaTP.TipoRuta = Ruta.TipoRuta.ida;
            rIdaTP.LineaId = _linea.Id;
            rIdaTP.Paraderos = _paraIda;
            rIdaTP.listaCoordenadas = _coorIda;

            RutaTP rVueltaTP = new RutaTP();
            rVueltaTP.Id = _rVuelta.Id;
            rVueltaTP.Nombre = _rVuelta.Nombre;
            rVueltaTP.TipoRuta = Ruta.TipoRuta.vuelta;
            rVueltaTP.LineaId = _linea.Id;
            rVueltaTP.Paraderos = _paraVuelta;
            rVueltaTP.listaCoordenadas = _coorVuelta;

            LineaTP lineaTP = new LineaTP();
            lineaTP.Id = _linea.Id;
            lineaTP.Nombre = _linea.Nombre;
            lineaTP.Micros = new List<Micro>();
            lineaTP.rutaIda = rIdaTP;
            lineaTP.rutaVuelta = rVueltaTP;

            lineaTP.rutasDeLinea = new List<RutaTP>();
            lineaTP.rutasDeLinea.Add(rIdaTP);
            lineaTP.rutasDeLinea.Add(rVueltaTP);

            RutaTP.todasRutas.Add(rIdaTP);
            RutaTP.todasRutas.Add(rVueltaTP);
            LineaTP.todasLineas.Add(lineaTP);
        }


        void RefreshMap()
        {
            gmapController.Zoom = gmapController.Zoom + 1;
            gmapController.Zoom = gmapController.Zoom - 1;
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

            if (e.Button == MouseButtons.Right && editandoMapa && puntosClickeadosIda.Count > 0)
            {
                bool res = ClickNuevoPuntoRuta(lat, lng);

                if (res == false)
                    return;

                if (editandoMapa)
                {
                    if (editandoIda)
                    {
                        MapController.CrearPosicionParadero(posVerticesIda.Last().Lat, posVerticesIda.Last().Lng, fragmentosDeRuta, markParaderosIda, paraderosOverlay);
                    }
                    else
                    {
                        MapController.CrearPosicionParadero(posVerticesVuelta.Last().Lat, posVerticesVuelta.Last().Lng, fragmentosDeRuta, markParaderosVuelta, paraderosOverlay);
                    }
                }

            }
        }

        private void CrearLineaV2_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }


    }
}
