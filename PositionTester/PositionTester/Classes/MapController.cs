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

using PositionTester.Model;
using PositionTester.Classes;
using PositionTester.Model.DatosTemporales;

namespace PositionTester.Classes
{
    public class MapController
    {
        public static Bitmap marcadorParadero = new Bitmap(PositionTester.Properties.Resources.paradero2Mini);
        public static Bitmap marcadorMicro = new Bitmap(PositionTester.Properties.Resources.microMarkerMini);

        public static void CargarRutaEnMapa(Ruta _ruta, GMapControl _gmapController, GMapOverlay _paraderosOverlay, GMapOverlay _rutaOverlay, Color _colorRuta)
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            List<Paradero> paraderos = Ruta.ObtenerParaderosRuta(_ruta);
            List<Coordenada> vertices = _ruta.Coordenadas.OrderBy(c => c.Orden).ToList();


            foreach (Paradero p in paraderos) //Crear paraderos en el mapa
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(p.Latitud, p.Longitud), marcadorParadero);
                paraderoMarker.ToolTipText = p.Id + "";
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
            if (!ConnectionTester.IsConnectionActive())
                return;

            List<Paradero> paraderos = _ruta.Paraderos;
            List<Coordenada> vertices = _ruta.listaCoordenadas.OrderBy(c => c.Orden).ToList();


            foreach (Paradero p in paraderos) //Crear paraderos en el mapa
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(p.Latitud, p.Longitud), marcadorParadero);
                //paraderoMarker.ToolTipText = p.Id + "";
                paraderoMarker.ToolTipText = p.Orden + "\nId:"+ p.Id;
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

       

        public static void CargarPuntosEnMapa(List<PointLatLng> _vertices, List<GMarkerGoogle> _paraderos, GMapControl _gmapController, GMapOverlay _paraderosOverlay, GMapOverlay _rutaOverlay, Color _color)
        {
            //al apretar aceptarRuta, se redibujan las 2 rutas de nuevo para comprobar errores

            if (!ConnectionTester.IsConnectionActive())
                return;

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

        public static void CrearMarcadorInicio(List<Coordenada> _coordenadas, GMapControl _gmapController, GMapOverlay _overlay, string _toolTip, GMarkerGoogleType tipoMarcador)
        {
            Coordenada coorInicio = _coordenadas.Where(c => c.Orden == 0).FirstOrDefault();

            GMarkerGoogle marcador = new GMarkerGoogle(new PointLatLng(coorInicio.Latitud, coorInicio.Longitud), tipoMarcador);

            marcador.ToolTipText = _toolTip;
            _overlay.Markers.Add(marcador);

            _gmapController.Zoom++;
            _gmapController.Zoom--;
        }


    }
}
