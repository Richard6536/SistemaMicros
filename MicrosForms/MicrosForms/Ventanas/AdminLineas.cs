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
    public partial class AdminLineas : Form
    {

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
            var forms = new CrearLineaV2();
            FormManager.MostrarShowDialog(this, forms);


            if (forms.DialogResult == DialogResult.OK)
            {
                CargarComboboxLineas();
            }
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

            lblRutaIda.Text = "Ruta de ida actual: " + rIda.Nombre;
            lblRutaVuelta.Text = "Ruta de vuelta actual: " + rVuelta.Nombre;

            List<Ruta> rutasIda = Linea.ObtenerRutasPorTipo(lineaActual.Id, Ruta.TipoRuta.ida);
            List<Ruta> rutasVuelta = Linea.ObtenerRutasPorTipo(lineaActual.Id, Ruta.TipoRuta.vuelta);

            cmbRutaIda.DataSource = rutasIda;
            cmbRutaIda.ValueMember = "Id";
            cmbRutaIda.DisplayMember = "Nombre";
            cmbRutaIda.SelectedValue = lineaActual.RutaIdaId;

            cmbRutaVuelta.DataSource = rutasVuelta;
            cmbRutaVuelta.ValueMember = "Id";
            cmbRutaVuelta.DisplayMember = "Nombre";
            cmbRutaVuelta.SelectedValue = lineaActual.RutaVueltaId;
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

                CargarLineaActual();
            }
            catch
            {
                
                return;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            DialogResult dr = MessageBox.Show("¿Está seguro que desea borrar esta línea?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No)
                return;

            List<Micro> micros = Linea.ObtenerMicrosDeLinea(lineaActual.Id);
            if(micros.Count >= 1)
            {
                MessageBox.Show("No puede eliminar una línea que contenga ya micros.");
                return;
            }

            Linea.EliminarLinea(lineaActual.Id);
            MessageBox.Show("Línea eliminada correctamente.");

            previewOverlay.Clear();
            completeOverlay.Clear();
            paraderosOverlay.Clear();
            otrosMarkersOverlay.Clear();
            CargarComboboxLineas();
        }

        private void btnCambiarNombreLinea_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            var form = new CambiarNombreLinea(lineaActual.Id);
            DialogResult dr = FormManager.MostrarShowDialog(this, form);

            if (dr == DialogResult.OK)
            {
                int idLinea = lineaActual.Id;
                CargarComboboxLineas();
                cmbLinea.SelectedValue = idLinea;
            }
        }


        private void btnCrearIda_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            var form = new CrearRutaIda(lineaActual.Id);
            FormManager.MostrarShowDialog(this, form);

            if(form.DialogResult == DialogResult.OK)
            {
                int idLinea = lineaActual.Id;
                CargarComboboxLineas();
                cmbLinea.SelectedValue = idLinea;
            }
        }

        private void btnAsignarIda_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            Ruta rutaIda = Ruta.BuscarPorId((int)cmbRutaIda.SelectedValue);

            int idLinea = lineaActual.Id;
            rutaIda.AsignarRutaComoUsable();

            CargarComboboxLineas();
            cmbLinea.SelectedValue = idLinea;

            MessageBox.Show("Ruta " + rutaIda.Nombre + " asignada como la ruta a usar.");
        }

        bool cmbIdaSwitch = false;

        private void cmbRutaIda_Click(object sender, EventArgs e)
        {
            cmbIdaSwitch = true;
        }

        private void cmbRutaIda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbIdaSwitch == true)
                {
                    previewOverlay.Clear();
                    completeOverlay.Clear();
                    paraderosOverlay.Clear();
                    otrosMarkersOverlay.Clear();

                    Ruta rIda = Ruta.BuscarPorId((int)cmbRutaIda.SelectedValue);
                    Ruta rVuelta = Ruta.BuscarPorId(lineaActual.RutaVueltaId.Value);

                    MapController.CargarRutaEnMapa(rIda, gmapController, paraderosOverlay, previewOverlay, Color.Red);
                    MapController.CargarRutaEnMapa(rVuelta, gmapController, paraderosOverlay, previewOverlay, Color.Blue);
                    List<Coordenada> coor = Ruta.ObtenerVerticesDeInicioAFin(rIda);
                    MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);



                    cmbIdaSwitch = false;
                }
            }
            catch
            {

                return;
            }
        }

        private void btnCrearVuelta_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            var form = new CrearRutaVuelta(lineaActual.Id);
            FormManager.MostrarShowDialog(this, form);

            if (form.DialogResult == DialogResult.OK)
            {
                int idLinea = lineaActual.Id;
                CargarComboboxLineas();
                cmbLinea.SelectedValue = idLinea;
            }
        }

        private void btnAsignarVuelta_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            Ruta RutaVuelta = Ruta.BuscarPorId((int)cmbRutaVuelta.SelectedValue);

            int idLinea = lineaActual.Id;
            RutaVuelta.AsignarRutaComoUsable();

            CargarComboboxLineas();
            cmbLinea.SelectedValue = idLinea;

            MessageBox.Show("Ruta " + RutaVuelta.Nombre + " asignada como la ruta a usar.");
        }

        private void cmbRutaVuelta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbVueltaSwitch == true)
                {
                    previewOverlay.Clear();
                    completeOverlay.Clear();
                    paraderosOverlay.Clear();
                    otrosMarkersOverlay.Clear();

                    Ruta rIda = Ruta.BuscarPorId(lineaActual.RutaIdaId.Value);
                    Ruta rVuelta = Ruta.BuscarPorId((int)cmbRutaVuelta.SelectedValue);

                    MapController.CargarRutaEnMapa(rIda, gmapController, paraderosOverlay, previewOverlay, Color.Red);
                    MapController.CargarRutaEnMapa(rVuelta, gmapController, paraderosOverlay, previewOverlay, Color.Blue);
                    List<Coordenada> coor = Ruta.ObtenerVerticesDeInicioAFin(rIda);
                    MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);



                    cmbVueltaSwitch = false;
                }
            }
            catch
            {
                return;
            }
        }
        bool cmbVueltaSwitch = false;
        private void cmbRutaVuelta_MouseClick(object sender, MouseEventArgs e)
        {
            cmbVueltaSwitch = true;
        }

        private void btnEliminarIda_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            DialogResult dr = MessageBox.Show("¿Está seguro que desea borrar esta ruta de ida?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No)
                return;


            if (cmbRutaIda.Items.Count > 0)
            {

                Ruta rutaIda = Ruta.BuscarPorId((int)cmbRutaIda.SelectedValue);
                int idLinea = lineaActual.Id;
                int idRutaAsignada = lineaActual.RutaIdaId.Value;

                if (idRutaAsignada == rutaIda.Id)
                {
                    MessageBox.Show("No puede eliminar la ruta que está actualmente asignada.");
                    return;
                }

                Ruta.EliminarRuta(rutaIda.Id);

                CargarComboboxLineas();
                cmbLinea.SelectedValue = idLinea;
                MessageBox.Show("Ruta eliminada correctamente");
            }
        }

        private void btnEliminarVuelta_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            DialogResult dr = MessageBox.Show("¿Está seguro que desea borrar esta ruta de vuelta?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No)
                return;

            if (cmbRutaVuelta.Items.Count > 0)
            {

                Ruta rutaVuelta = Ruta.BuscarPorId((int)cmbRutaVuelta.SelectedValue);
                int idLinea = lineaActual.Id;
                int idRutaAsignada = lineaActual.RutaVueltaId.Value;

                if (idRutaAsignada == rutaVuelta.Id)
                {
                    MessageBox.Show("No puede eliminar la ruta que está actualmente asignada.");
                    return;
                }

                Ruta.EliminarRuta(rutaVuelta.Id);

                CargarComboboxLineas();
                cmbLinea.SelectedValue = idLinea;
                MessageBox.Show("Ruta eliminada correctamente");
            }
        }

        private void btnVerMicros_Click_1(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            var form = new EditarMicrosDeLinea(lineaActual.Id);
            FormManager.MostrarShowDialog(this, form);
        }


        private void AdminLineas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormManager.cerrandoAplicacion == true)
                return;

            var res = MessageBox.Show(this, "¿Seguro desea cerrar la aplicación?", "Exit",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
            FormManager.cerrandoAplicacion = true;
        }

        private void AdminLineas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
