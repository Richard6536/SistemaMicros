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

namespace MicrosForms.Ventanas
{
    public partial class AdminLineas : Form
    {
        public enum TipoRuta { ida, vuelta}


        Linea lineaActual;

        GMapOverlay previewOverlay;
        GMapOverlay completeOverlay;
        GMapOverlay paraderosOverlay;
        GMapOverlay otrosMarkersOverlay;


        public AdminLineas()
        {
            InitializeComponent();

            IniciarMapa();

            CargarComboboxLineas();
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
            gmapController.MaxZoom = 18;
            gmapController.Zoom = 14;

            gmapController.IgnoreMarkerOnMouseWheel = true;

            previewOverlay = new GMapOverlay();
            completeOverlay = new GMapOverlay();
            paraderosOverlay = new GMapOverlay();
            otrosMarkersOverlay = new GMapOverlay();

            gmapController.Overlays.Add(previewOverlay);
            gmapController.Overlays.Add(completeOverlay);
            gmapController.Overlays.Add(paraderosOverlay);
            gmapController.Overlays.Add(otrosMarkersOverlay);
        }


        #region toolstrips


        private void microsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminMicros());
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminUsuarios());
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new Login());
        }

        private void VentanaInicioMenuItem1_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new InicioReal());
        }
        #endregion

        private void btnCrearLinea_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            var forms = new CrearLineaV2();
            forms.ShowDialog();

            this.Enabled = true;

            if (forms.DialogResult == DialogResult.OK)
            {
                CargarComboboxLineas();
            }

        }



        void CargarRutaEnMapa(Ruta _ruta, TipoRuta _tipoRuta)
        {
            if (!ConnectionTester.IsConnectionActive())
                return;


            List<Paradero> paraderos = Ruta.ObtenerParaderosRuta(_ruta);
            List<Coordenada> vertices = Ruta.ObtenerVerticesDeInicioAFin(_ruta);


            foreach (Paradero p in paraderos) //Crear paraderos en el mapa
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(p.Latitud, p.Longitud), GMarkerGoogleType.purple_small);

                paraderosOverlay.Markers.Add(paraderoMarker);
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
                    if (_tipoRuta == TipoRuta.ida)
                    {
                        gmapController.Position = new PointLatLng(actual.Latitud, actual.Longitud); //enfoca el mapa en el inicio
                        iconoMarcador = GMarkerGoogleType.red_small; //icono ida
                        toolTipText = "Inicio ruta ida";
                    }
                    else
                    {
                        iconoMarcador = GMarkerGoogleType.blue_small; //icono vuelta
                        toolTipText = "Inicio ruta vuelta";
                    }

                    GMarkerGoogle InicioMarker = new GMarkerGoogle(new PointLatLng(actual.Latitud, actual.Longitud), iconoMarcador);
                    InicioMarker.ToolTipText = toolTipText;

                    otrosMarkersOverlay.Markers.Add(InicioMarker);
                } 

                if (i == vertices.Count - 2)
                {
                    //Crea marcador al final de la ruta
                    //solo en la de ruta de vuelta
                    if (_tipoRuta == TipoRuta.vuelta)
                    {
                        
                        iconoMarcador = GMarkerGoogleType.blue_small; //icono ida
                        toolTipText = "Final ruta vuelta";

                        GMarkerGoogle FinalMarker = new GMarkerGoogle(new PointLatLng(siguiente.Latitud, siguiente.Longitud), iconoMarcador);
                        FinalMarker.ToolTipText = toolTipText;

                        otrosMarkersOverlay.Markers.Add(FinalMarker);
                    }

                } 

                List<PointLatLng> puntos = new List<PointLatLng>();
                puntos.Add(new PointLatLng(actual.Latitud, actual.Longitud));
                puntos.Add(new PointLatLng(siguiente.Latitud, siguiente.Longitud));

                //GMapPolygon polygon = new GMapPolygon(puntos, "mypolygon");
                GMapRoute ruta = new GMapRoute(puntos, "asdf");

                if (_tipoRuta == TipoRuta.ida)
                    ruta.Stroke = new Pen(Color.Red, 4);
                if (_tipoRuta == TipoRuta.vuelta)
                    ruta.Stroke = new Pen(Color.Blue, 4);

                //previewOverlay.Polygons.Add(polygon);
                previewOverlay.Routes.Add(ruta);
            }

            RefreshMap();

        }

        void DebugMarker(Coordenada _coordenda)
        {

            GMarkerGoogle debugMarker = new GMarkerGoogle(new PointLatLng(_coordenda.Latitud, _coordenda.Longitud), GMarkerGoogleType.yellow_small);
            debugMarker.ToolTipText = _coordenda.Id + "";
            debugMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

            otrosMarkersOverlay.Markers.Add(debugMarker);
        }

        void RefreshMap()
        {
            gmapController.Zoom = gmapController.Zoom + 1;
            gmapController.Zoom = gmapController.Zoom - 1;
        }

        void CargarComboboxLineas()
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            List<Linea> lineasCMB = Linea.ObtenerTodasLasLineas();
            List<Linea> lineasCMBOrdenadas = lineasCMB.OrderBy(l => l.Nombre).ToList();

            cmbLinea.DataSource = lineasCMBOrdenadas;

            cmbLinea.DisplayMember = "Nombre";
            cmbLinea.ValueMember = "Id";

            lineaActual = Linea.BuscarLinea(Convert.ToInt32(cmbLinea.SelectedValue));

            Ruta rIda = Ruta.BuscarPorId(lineaActual.RutaInicioId);
            Ruta rVuelta = Ruta.BuscarPorId(lineaActual.RutaFinId);

            CargarRutaEnMapa(rIda, TipoRuta.ida);
            CargarRutaEnMapa(rVuelta, TipoRuta.vuelta);

        }

        private void cmbLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Recargar comboboxes de rutas
            try
            {
                previewOverlay.Clear();
                completeOverlay.Clear();
                paraderosOverlay.Clear();
                otrosMarkersOverlay.Clear();

                lineaActual = Linea.BuscarLinea(Convert.ToInt32(cmbLinea.SelectedValue));

                Ruta rIda = Ruta.BuscarPorId( lineaActual.RutaInicioId);
                Ruta rVuelta = Ruta.BuscarPorId(lineaActual.RutaFinId);

                CargarRutaEnMapa(rIda, TipoRuta.ida);
                CargarRutaEnMapa(rVuelta, TipoRuta.vuelta);
            }
            catch
            {
                
                return;
            }
        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnVerMicros_Click(object sender, EventArgs e)
        {

        }
    }
}
