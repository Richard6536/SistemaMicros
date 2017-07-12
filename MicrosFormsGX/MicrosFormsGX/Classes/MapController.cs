using System;
using System.Device.Location;
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
using MicrosFormsGX.Ventanas.Ediciones;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MetroFramework;

namespace MicrosFormsGX.Classes
{
    class MapController
    {
        //imagenMarcadorParadero = new Bitmap(MicrosForms.Properties.Resources.marcadorParaderoMini);
        public static Bitmap marcadorParadero = new Bitmap(MicrosFormsGX.Properties.Resources.paradero2Mini);
        public static Bitmap marcadorMicro = new Bitmap(MicrosFormsGX.Properties.Resources.microMarkerMini);


        public static void CargarRutaEnMapa(Ruta _ruta, GMapControl _gmapController, GMapOverlay _paraderosOverlay, GMapOverlay _rutaOverlay, Color _colorRuta)
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            List<Paradero> paraderos = Ruta.ObtenerParaderosRuta(_ruta);
            List<Coordenada> vertices = Ruta.ObtenerVerticesDeInicioAFin(_ruta);


            foreach (Paradero p in paraderos) //Crear paraderos en el mapa
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(p.Latitud, p.Longitud), marcadorParadero);

                _paraderosOverlay.Markers.Add(paraderoMarker);
            }


            Coordenada actual;
            Coordenada siguiente;
            for (int i = 0; i < vertices.Count - 1; i++)
            {

                actual = vertices[i];
                siguiente = vertices[i + 1];

                List<PointLatLng> puntos = new List<PointLatLng>();
                puntos.Add(new PointLatLng(actual.Latitud, actual.Longitud));
                puntos.Add(new PointLatLng(siguiente.Latitud, siguiente.Longitud));

                GMapRoute ruta = new GMapRoute(puntos, "asdf");
                ruta.Stroke = new Pen(_colorRuta, 4);

                _rutaOverlay.Routes.Add(ruta);
            }

            _gmapController.Zoom++;
            _gmapController.Zoom--;

        }

        public static void CargarRutaEnMapaOffline(RutaTP _ruta, GMapControl _gmapController, GMapOverlay _paraderosOverlay, GMapOverlay _rutaOverlay, Color _colorRuta)
        {
            List<Paradero> paraderos = _ruta.Paraderos;
            List<Coordenada> vertices = _ruta.listaCoordenadas;

            foreach (Paradero p in paraderos) //Crear paraderos en el mapa
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(p.Latitud, p.Longitud), marcadorParadero);

                _paraderosOverlay.Markers.Add(paraderoMarker);
            }

            Coordenada actual;
            Coordenada siguiente;
            for (int i = 0; i < vertices.Count - 1; i++)
            {

                actual = vertices[i];
                siguiente = vertices[i + 1];

                List<PointLatLng> puntos = new List<PointLatLng>();
                puntos.Add(new PointLatLng(actual.Latitud, actual.Longitud));
                puntos.Add(new PointLatLng(siguiente.Latitud, siguiente.Longitud));

                GMapRoute ruta = new GMapRoute(puntos, "asdf");
                ruta.Stroke = new Pen(_colorRuta, 4);

                _rutaOverlay.Routes.Add(ruta);
            }

            _gmapController.Zoom++;
            _gmapController.Zoom--;

        }

        public static List<Paradero> CrearParaderos(List<GMarkerGoogle> _listaMarcadores)
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

        public static List<Coordenada> CrearVertices(List<PointLatLng> _puntosVertices)
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

        public static void CargarPuntosEnMapa(List<PointLatLng> _vertices, List<GMarkerGoogle> _paraderos, GMapControl _gmapController, GMapOverlay _paraderosOverlay, GMapOverlay _rutaOverlay, Color _color)
        {
            //al apretar aceptarRuta, se redibujan las 2 rutas de nuevo para comprobar errores

            List<GMarkerGoogle> paraderos = _paraderos;
            List<PointLatLng> vertices = _vertices;


            foreach (GMarkerGoogle p in paraderos) //Crear paraderos en el mapa
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(p.Position.Lat, p.Position.Lng), marcadorParadero);

                _paraderosOverlay.Markers.Add(paraderoMarker);
            }

            PointLatLng actual;
            PointLatLng siguiente;
            for (int i = 0; i < vertices.Count - 1; i++)
            {

                actual = vertices[i];
                siguiente = vertices[i + 1];

                List<PointLatLng> puntos = new List<PointLatLng>();
                puntos.Add(new PointLatLng(actual.Lat, actual.Lng));
                puntos.Add(new PointLatLng(siguiente.Lat, siguiente.Lng));

                GMapRoute ruta = new GMapRoute(puntos, "asdf");
                ruta.Stroke = new Pen(_color, 4);

                _rutaOverlay.Routes.Add(ruta);
            }

            _gmapController.Zoom++;
            _gmapController.Zoom--;

        }

        public static void DibujarTramo(List<PointLatLng> _puntos, Color _color, GMapOverlay _overlay, int _numeroFragmento)
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

        public static void EliminarTramoDibujado(GMapOverlay _overlay, int _numeroFragmento)
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

        public static void CrearPosicionParadero(double _lat, double _lng, List<GMapRoute> fragmentosDeRuta, List<GMarkerGoogle> markParaderos, GMapOverlay _overlayParaderos)
        {

            GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(_lat, _lng), marcadorParadero);
            paraderoMarker.Tag = fragmentosDeRuta.Count + "";
            markParaderos.Add(paraderoMarker);

            _overlayParaderos.Markers.Add(paraderoMarker);
        }

        public static void CrearMarcadorInicio(List<Coordenada> _coordendas,GMapControl _gmapController, GMapOverlay _overlay, string _toolTip, GMarkerGoogleType tipoMarcador)
        {
            Coordenada primerVertice = _coordendas.First();
            GMarkerGoogle marcador = new GMarkerGoogle(new PointLatLng(primerVertice.Latitud, primerVertice.Longitud), tipoMarcador);
            marcador.ToolTipText = _toolTip;
            _overlay.Markers.Add(marcador);

            _gmapController.Zoom++;
            _gmapController.Zoom--;
        }

        public static double DistanciaEntrePuntos(PointLatLng punto1, PointLatLng punto2)
        {
        
            var sCoord = new GeoCoordinate(punto1.Lat, punto1.Lng);
            var eCoord = new GeoCoordinate(punto2.Lat, punto2.Lng);

            return sCoord.GetDistanceTo(eCoord);
        }

    }
}
