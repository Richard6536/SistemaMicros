﻿using System;
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
    public partial class CrearRutaIda : Form
    {
        Linea lineaDeRuta;
        Ruta rutaVuelta;

        bool editandoMapa;

        GMapOverlay previewIdaOverlay;
        GMapOverlay previewVueltaOverlay;
        GMapOverlay paraderosIdaOverlay;
        GMapOverlay paraderosVueltaOverlay;
        GMapOverlay otrosMarkersIdaOverlay;
        GMapOverlay otrosMarkersVueltaOverlay;

        List<PointLatLng> posVerticesIda;
        List<PointLatLng> puntosClickeadosIda;
        List<GMarkerGoogle> markParaderosIda;

        List<GMarkerGoogle> otrosMarkersList;
        List<GMapRoute> fragmentosDeRuta;

        GMarkerGoogle puntoFinal;
        GMarkerGoogle puntoInicioRuta;

        public CrearRutaIda(int _linea)
        {
            InitializeComponent();
            lineaDeRuta = Linea.BuscarLinea(_linea);
            rutaVuelta = Ruta.BuscarPorId(lineaDeRuta.RutaVueltaId.Value);

            lblLinea.Text = "Línea: " + lineaDeRuta.Nombre;
            btnDeshacer.Enabled = false;
            btnAceptarRuta.Enabled = false;
            btnGuardarDatos.Enabled = false;

            IniciarMapa();
 
            MapController.CargarRutaEnMapa(rutaVuelta, gmapController, paraderosVueltaOverlay, previewVueltaOverlay, Color.Blue);
            Coordenada verticeFinal = Ruta.ObtenerVerticesDeInicioAFin(rutaVuelta).First();
            puntoFinal = new GMarkerGoogle(new PointLatLng(verticeFinal.Latitud, verticeFinal.Longitud), GMarkerGoogleType.blue_small);
            puntoFinal.ToolTipText = "Inicio ruta vuelta";
            otrosMarkersVueltaOverlay.Markers.Add(puntoFinal);
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

            markParaderosIda = new List<GMarkerGoogle>();
            otrosMarkersList = new List<GMarkerGoogle>();
            posVerticesIda = new List<PointLatLng>();

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


            puntosClickeadosIda = new List<PointLatLng>();
            posVerticesIda = new List<PointLatLng>();
            fragmentosDeRuta = new List<GMapRoute>();
            markParaderosIda = new List<GMarkerGoogle>();

            otrosMarkersIdaOverlay.Clear();
            paraderosIdaOverlay.Clear();
            previewIdaOverlay.Clear();
            RefreshMap();
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
                if(res)
                    MapController.CrearPosicionParadero(posVerticesIda.Last().Lat, posVerticesIda.Last().Lng, fragmentosDeRuta, markParaderosIda, paraderosIdaOverlay);
            }
        }

        bool ClickNuevoPuntoRuta(double _lat, double _lng)
        {
            //extiende la ruta creada
            if (editandoMapa)
            {
                puntosClickeadosIda.Add(new PointLatLng(_lat, _lng));

                if (puntosClickeadosIda.Count == 1)
                {
                    puntoInicioRuta = new GMarkerGoogle(new PointLatLng(_lat, _lng), GMarkerGoogleType.red_small);
                    puntoInicioRuta.ToolTipText = "Inicio de ida";
                    otrosMarkersList.Add(puntoInicioRuta);
                    otrosMarkersIdaOverlay.Markers.Add(puntoInicioRuta);
                }

                if (puntosClickeadosIda.Count > 1)
                {
                    GDirections direccion;

                    int puntoActual = puntosClickeadosIda.Count - 1;
                    int puntoAnterior = puntoActual - 1;

                    var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, puntosClickeadosIda[puntoAnterior], puntosClickeadosIda[puntoActual], false, false, false, false, false);
                    if (direccion == null)
                    {
                        MessageBox.Show("No fue posible crear una ruta al lugar indicado.\nSe recomienda revisar su conexión a internet, por ser necesaria en la búsqueda de rutas.");
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
            return true;
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            //deshace el ultimo trozo de ruta creado
  
            if (editandoMapa && puntosClickeadosIda.Count == 1)
            {
                otrosMarkersIdaOverlay.Markers.Remove(puntoInicioRuta);
                puntosClickeadosIda.RemoveAt(puntosClickeadosIda.Count - 1);
                btnDeshacer.Enabled = false;

                RefreshMap();
            }

            //Quita el paradero si esque hay
            GMarkerGoogle m = markParaderosIda.Where(mp => Convert.ToString(mp.Tag) == fragmentosDeRuta.Count + "").FirstOrDefault();

            paraderosIdaOverlay.Markers.Remove(m);
            markParaderosIda.Remove(m);


            if (editandoMapa && puntosClickeadosIda.Count >= 2)
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
            
        }

        private void btnAceptarRuta_Click(object sender, EventArgs e)
        {
            editandoMapa = false;

            btnCrearRuta.Enabled = true;

            btnAceptarRuta.Enabled = false;
            btnDeshacer.Enabled = false;

            if(posVerticesIda.Count > 1)
                btnGuardarDatos.Enabled = true;

            //dibujar de nuevo en el mapa para comprobar errores
            otrosMarkersIdaOverlay.Clear();
            paraderosIdaOverlay.Clear();
            previewIdaOverlay.Clear();

            List<Coordenada> coor = MapController.CrearVertices(posVerticesIda);
            MapController.CargarPuntosEnMapa(posVerticesIda, markParaderosIda, gmapController, paraderosIdaOverlay, previewIdaOverlay, Color.Red);
            MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersIdaOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);
        }


        private void gmapController_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            GMarkerGoogle marker = item as GMarkerGoogle;

            if (puntoFinal == marker && editandoMapa && puntosClickeadosIda.Count > 1)
            {
                ClickNuevoPuntoRuta(marker.Position.Lat, marker.Position.Lng);
            }
        }

        private void gmapController_OnMarkerEnter(GMapMarker item)
        {
            GMarkerGoogle marker = item as GMarkerGoogle;

            if(puntoFinal == marker && editandoMapa && puntosClickeadosIda.Count > 1)
            {
                puntoFinal.ToolTipText = "Click para completar la ruta";
            }
        }

        private void gmapController_OnMarkerLeave(GMapMarker item)
        {
            GMarkerGoogle marker = item as GMarkerGoogle;

            if (puntoFinal == marker && editandoMapa && puntosClickeadosIda.Count > 1)
            {
                puntoFinal.ToolTipText = "Inicio ruta vuelta";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            List<Coordenada> verticesIda = MapController.CrearVertices(posVerticesIda);
            Coordenada ultima = verticesIda[verticesIda.Count - 1];

            string mensajeError = "";

            
            if (puntoFinal.Position.Lat != ultima.Latitud || puntoFinal.Position.Lng != ultima.Longitud)
            {
                mensajeError += "\n-El punto final de la ruta de ida debe ser el mismo que el inicio de la ruta de vuelta. (Se recomienda hacer click en el marcador para lograrlo.";
            }

            if (txtNombreLinea.Text == "")
            {
                mensajeError += "\n-No puede dejar el campo nombre vacío";
            }
            else if (Ruta.BuscarPorNombre(txtNombreLinea.Text) != null)
            {
                mensajeError += "\n-El nombre de esa ruta ya existe";
            }
            if (verticesIda.Count < 2)
            {
                mensajeError += "\n-No puede guardar la línea sin haber creado las rutas.";
            }

            if (mensajeError != "")
            {
                MessageBox.Show("Se encontraron los siguientes errores:" + mensajeError);
                return;
            }
            List<Paradero> paraderos = MapController.CrearParaderos(markParaderosIda);

            Ruta rutaCreada = Ruta.CrearRuta(lineaDeRuta.Id, txtNombreLinea.Text, Ruta.TipoRuta.ida, verticesIda, paraderos);

            if(rutaCreada != null)
            {
                MessageBox.Show("Nueva ruta de ida creada correctamente.");
                this.DialogResult = DialogResult.OK;
            }
            
        }

    }
}
