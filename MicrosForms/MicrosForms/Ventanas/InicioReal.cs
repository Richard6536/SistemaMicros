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
using MicrosForms.Ventanas.Ediciones;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace MicrosForms.Ventanas
{
    public partial class InicioReal : Form
    {
        Linea lineaActual;

        GMapOverlay previewOverlay;
        GMapOverlay completeOverlay;
        GMapOverlay paraderosOverlay;
        GMapOverlay otrosMarkersOverlay;

        #region ToolStrips

        private void líneasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminLineas());
        }

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

        #endregion


        public InicioReal()
        {
            InitializeComponent();

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
            completeOverlay = new GMapOverlay();
            paraderosOverlay = new GMapOverlay();
            otrosMarkersOverlay = new GMapOverlay();

            gmapController.Overlays.Add(previewOverlay);
            gmapController.Overlays.Add(completeOverlay);
            gmapController.Overlays.Add(paraderosOverlay);
            gmapController.Overlays.Add(otrosMarkersOverlay);
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

            if (lineaActual != null)
            {
                CargarLineaActual();
            }

        }

        void CargarLineaActual()
        {
            lineaActual = Linea.BuscarLinea(Convert.ToInt32(cmbLinea.SelectedValue));

            Ruta rIda = Ruta.BuscarPorId(lineaActual.RutaIdaId.Value);
            Ruta rVuelta = Ruta.BuscarPorId(lineaActual.RutaVueltaId.Value);

            MapController.CargarRutaEnMapa(rIda, gmapController, paraderosOverlay, previewOverlay, Color.Red);
            MapController.CargarRutaEnMapa(rVuelta, gmapController, paraderosOverlay, previewOverlay, Color.Blue);
            List<Coordenada> coor = Ruta.ObtenerVerticesDeInicioAFin(rIda);
            MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);
        }

        private void InicioReal_Activated(object sender, EventArgs e)
        {
            IniciarMapa();

            CargarComboboxLineas();
        }

        private void cmbLinea_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Recargar comboboxes de rutas
            try
            {
                previewOverlay.Clear();
                completeOverlay.Clear();
                paraderosOverlay.Clear();
                otrosMarkersOverlay.Clear();

                CargarLineaActual();
            }
            catch
            {

                return;
            }
        }

        private void InicioReal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormManager.cerrandoAplicacion == true)
                return;

            var res = MessageBox.Show(this , "¿Seguro desea cerrar la aplicación?", "Exit",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            FormManager.cerrandoAplicacion = true;
        }

        private void InicioReal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
