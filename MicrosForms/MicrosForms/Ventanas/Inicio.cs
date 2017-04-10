using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace MicrosForms.Ventanas
{
    public partial class Inicio : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        double latitud = -40.574984;
        double longitud = -73.125183;

        //ruta automatizada 
        bool trazarRuta = false;
        int contadorIndicadoresDeRuta = 0;
        PointLatLng inicio;
        PointLatLng final;

        public Inicio()
        {
            InitializeComponent();

            IniciarMapa();
        }

        void IniciarMapa()
        {
            gMapControllador.MapProvider = GMapProviders.GoogleMap;

            gMapControllador.DragButton = MouseButtons.Left;
            gMapControllador.CanDragMap = true;
            gMapControllador.Position = new PointLatLng(latitud, longitud);

            gMapControllador.MinZoom = 4;
            gMapControllador.MaxZoom = 18;
            gMapControllador.Zoom = 14;

            gMapControllador.IgnoreMarkerOnMouseWheel = true;


            //marcador
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(latitud, longitud), GMarkerGoogleType.arrow);
            //ruta = new GMapRoute....

            markerOverlay.Markers.Add(marker);

            //tooltip al marcador
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = "ubicacion: " + latitud + "," + longitud;

            gMapControllador.Overlays.Add(markerOverlay);

        }

        private void gMapControllador_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //obtener posicion donde se hizo click

            double lat = gMapControllador.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControllador.FromLocalToLatLng(e.X, e.Y).Lng;

            txtLatitud.Text = lat + "";
            txtLongitud.Text = lng + "";

            //marker.Position = new PointLatLng(lat, lng);

            CrearDireccionTrazarRuta(lat, lng);
            AgregarPuntoARuta(lat, lng);
        }

        private void btnComoLlegar_Click(object sender, EventArgs e)
        {
            trazarRuta = true;
            btnComoLlegar.Enabled = false;

            gMapControllador.Overlays.Clear();
            gMapControllador.Zoom = gMapControllador.Zoom + 1;
            gMapControllador.Zoom = gMapControllador.Zoom - 1;
        }

        void CrearDireccionTrazarRuta(double lat, double lng)
        {
            if(trazarRuta)
            {
                if(contadorIndicadoresDeRuta == 0)
                {
                    contadorIndicadoresDeRuta++;
                    inicio = new PointLatLng(lat, lng);

                }
                else if(contadorIndicadoresDeRuta == 1)
                {
                    contadorIndicadoresDeRuta++;
                    final = new PointLatLng(lat, lng);
                    GDirections direccion;

                    var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion,inicio,final,false,false,false,false,false);
                    
                    GMapRoute rutaObtenida = new GMapRoute(direccion.Route, "rutaUbicacion");
                    GMapOverlay capaRuta = new GMapOverlay("capaRutas");
                    capaRuta.Routes.Add(rutaObtenida);
                    gMapControllador.Overlays.Add(capaRuta);

                    gMapControllador.Zoom = gMapControllador.Zoom + 1;
                    gMapControllador.Zoom = gMapControllador.Zoom - 1;

                    contadorIndicadoresDeRuta = 0;
                    trazarRuta = false;
                    btnComoLlegar.Enabled = true;
                }
            }
        }

        GMapOverlay RutasCreadasOverlay;
        GMapOverlay RutaPreviewOverlay;
        bool creandoRuta = false;

        List<PointLatLng> listaPuntos;
        List<PointLatLng> puntosDireccion;

        private void btnCrearRuta_Click(object sender, EventArgs e)
        {
            RutasCreadasOverlay = new GMapOverlay("RutasCreadas");
            RutaPreviewOverlay = new GMapOverlay("RutaPreview");
            listaPuntos = new List<PointLatLng>();
            puntosDireccion = new List<PointLatLng>();

            double lng, lat;

            creandoRuta = true;
            btnCrearRuta.Enabled = false;
            gMapControllador.Overlays.Clear();

            gMapControllador.Overlays.Add(RutaPreviewOverlay);

            RefreshMap();
        }

        void AgregarPuntoARuta(double lat, double lng)
        {
            if(creandoRuta)
            {
                listaPuntos.Add(new PointLatLng(lat, lng));

                if(listaPuntos.Count > 1)
                {
                    GDirections direccion;

                    int puntoActual = listaPuntos.Count - 1;
                    int puntoAnterior = puntoActual - 1;

                    var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, listaPuntos[puntoAnterior], listaPuntos[puntoActual], false, false, false, false, false);
                    GMapRoute fragRuta = new GMapRoute(direccion.Route, "rutaPrev");
                    RutaPreviewOverlay.Routes.Add(fragRuta);
                    RefreshMap();
                    


                    foreach(PointLatLng punto in direccion.Route)
                    {
                        puntosDireccion.Add(punto);
                    }
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            creandoRuta = false;
            btnCrearRuta.Enabled = true;

            GMapRoute ruta = new GMapRoute(puntosDireccion, "ruta");
            RutasCreadasOverlay.Routes.Add(ruta);

            gMapControllador.Overlays.Add(RutasCreadasOverlay);

            RefreshMap();

        }

        void RefreshMap()
        {
            
            gMapControllador.Zoom = gMapControllador.Zoom + 1;
            gMapControllador.Zoom = gMapControllador.Zoom - 1;
        }
    }
}
