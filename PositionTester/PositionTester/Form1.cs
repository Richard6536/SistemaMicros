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

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace PositionTester
{
    public partial class Form1 : Form
    {
        Linea lineaActual;

        List<Usuario> usuariosControlados;
        List<GMarkerGoogle> usersMarkers;

        Usuario userControlandoActual;


        GMapOverlay previewOverlay;
        GMapOverlay paraderosOverlay;
        GMapOverlay otrosMarkersOverlay;
        GMapOverlay userControladoOverlay;

        public Form1()
        {
            InitializeComponent();
            IniciarMapa();
            CargarComboboxLineas();

            usuariosControlados = new List<Usuario>();
            usersMarkers = new List<GMarkerGoogle>();
            lblUserMoviendo.Text = "";
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
            gmapController.MaxZoom = 19;
            gmapController.Zoom = 14;

            gmapController.IgnoreMarkerOnMouseWheel = true;

            previewOverlay = new GMapOverlay();
            paraderosOverlay = new GMapOverlay();
            otrosMarkersOverlay = new GMapOverlay();
            userControladoOverlay = new GMapOverlay();

            gmapController.Overlays.Add(previewOverlay);
            gmapController.Overlays.Add(paraderosOverlay);
            gmapController.Overlays.Add(otrosMarkersOverlay);
            gmapController.Overlays.Add(userControladoOverlay);


        }

        #region ComboBox lineas
        void CargarComboboxLineas()
        {
            List<Linea> lineasCMB = Linea.ObtenerTodasLasLineas();
            List<Linea> lineasCMBOrdenadas = lineasCMB.OrderBy(l => l.Nombre).ToList();
            
            cmbLineas.DataSource = lineasCMBOrdenadas;

            cmbLineas.DisplayMember = "Nombre";
            cmbLineas.ValueMember = "Id";

            lineaActual = Linea.BuscarLinea(Convert.ToInt32(cmbLineas.SelectedValue));

            if (lineaActual != null)
            {
                CargarLineaActual();
            }
        }

        void CargarLineaActual()
        {
            previewOverlay.Clear();
            paraderosOverlay.Clear();
            otrosMarkersOverlay.Clear();

            Ruta rIda = Ruta.BuscarPorId(lineaActual.RutaIdaId.Value);
            Ruta rVuelta = Ruta.BuscarPorId(lineaActual.RutaVueltaId.Value);

            MapController.CargarRutaEnMapa(rIda, gmapController, paraderosOverlay, previewOverlay, Color.Red);
            MapController.CargarRutaEnMapa(rVuelta, gmapController, paraderosOverlay, previewOverlay, Color.Blue);
            List<Coordenada> coor = Ruta.ObtenerVerticesDeInicioAFin(rIda);
            MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);
        }

        private void btnBorrarLinea_Click(object sender, EventArgs e)
        {
            previewOverlay.Clear();
            paraderosOverlay.Clear();
            otrosMarkersOverlay.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lineaActual = Linea.BuscarLinea(Convert.ToInt32(cmbLineas.SelectedValue));
                CargarLineaActual();
            }
            catch
            {

            }

        }
        #endregion


        private void btnTomarControl_Click(object sender, EventArgs e)
        {
            Usuario userActual = Usuario.BuscarUsuarioPorMail(txtEmail.Text);

            if(userActual == null)
            {
                MessageBox.Show("No existe ese mail");
                return;
            }

            //crear marcador con su posicion
            GMarkerGoogle userMarker = new GMarkerGoogle(new PointLatLng(userActual.Latitud, userActual.Longitud), GMarkerGoogleType.green_small);
            userMarker.ToolTipText = userActual.Email;
            userMarker.Tag = userActual.Id;
            userControladoOverlay.Markers.Add(userMarker);

            usuariosControlados.Add(userActual);
            usersMarkers.Add(userMarker);
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (userControlandoActual == null)
                return;

            GMarkerGoogle userMarker = usersMarkers.Where(m => m.Tag + "" == userControlandoActual.Id.ToString()).FirstOrDefault();
            Usuario.ActualizarPosicion(userControlandoActual.Id, userMarker.Position.Lat, userMarker.Position.Lng);
        }

        private void gmapController_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            GMarkerGoogle marker = (GMarkerGoogle)item;

            if(usersMarkers.Contains(marker) == false)
                return;


            Usuario userClickeado = usuariosControlados.Where(u => u.Id == Convert.ToInt32(marker.Tag)).FirstOrDefault();

            if (e.Button == MouseButtons.Right)
            {
                //Boton derecho detiene la actualizacion de posicion del marcador y lo borra      
                Usuario.PararActualizaciónPosicion(userClickeado.Id);
                userControladoOverlay.Markers.Remove(marker);

                usuariosControlados.Remove(userClickeado);
                usersMarkers.Remove(marker);
                lblUserMoviendo.Text = "";
            }
            else
            {
                if(userControlandoActual != null)
                {
                    userControlandoActual = null;
                    lblUserMoviendo.Text = "";
                }
                else
                {
                    userControlandoActual = userClickeado;
                    lblUserMoviendo.Text = userControlandoActual.Email;
                }
            }

        }

        private void gmapController_MouseMove(object sender, MouseEventArgs e)
        {
            if (userControlandoActual == null)
                return;

            GMarkerGoogle userMarker = usersMarkers.Where(m => Convert.ToInt32(m.Tag) == userControlandoActual.Id).FirstOrDefault();
            //marcador sigue al mouse
            double lat = gmapController.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gmapController.FromLocalToLatLng(e.X, e.Y).Lng;

            userMarker.Position = new PointLatLng(lat, lng);
        }

        private void gmapController_MouseLeave(object sender, EventArgs e)
        {
            userControlandoActual = null;
        }

        private void btnDetenerTodo_Click(object sender, EventArgs e)
        {
            Usuario.PararActualizacionTodos();

            userControladoOverlay.Clear();

            usersMarkers.Clear();
            usuariosControlados.Clear();
        }
    }
}
