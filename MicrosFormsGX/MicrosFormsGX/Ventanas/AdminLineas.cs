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
using MicrosFormsGX.Ventanas.Ediciones;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MetroFramework;


namespace MicrosFormsGX.Ventanas
{
    public partial class AdminLineas : MetroFramework.Forms.MetroForm
    {
        LineaTP lineaActual;

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
        #region Toolstrips
        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminUsuarios());
        }

        private void administrarMicrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminMicros());
        }

        private void ventanaInicioToolstrip_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new InicioReal());
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new Login());
        }
        #endregion

        bool tabVisible = false;
        private void btnVerMenuLinea_Click(object sender, EventArgs e)
        {
            if(tabVisible)
            {
                tabVisible = false;
                metroTabControl1.Visible = false;
            }
            else
            {
                tabVisible = true;
                metroTabControl1.Visible = true;
            }

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

        public void CargarComboboxLineas()
        {
            //if (!ConnectionTester.IsConnectionActive())
            //    return;

            //List<Linea> lineasCMB = Linea.ObtenerTodasLasLineas();
            //List<Linea> lineasCMBOrdenadas = lineasCMB.OrderBy(l => l.Nombre).ToList();
            List<LineaTP> lineasCMB = LineaTP.todasLineas;

            cmbLinea.DataSource = null;
            cmbLinea.DataSource = lineasCMB;

            cmbLinea.DisplayMember = "Nombre";
            cmbLinea.ValueMember = "Id";

            //lineaActual = Linea.BuscarLinea(Convert.ToInt32(cmbLinea.SelectedValue));
            lineaActual = LineaTP.todasLineas.Where(l => l.Id == Convert.ToInt32(cmbLinea.SelectedValue)).FirstOrDefault();
            if (lineaActual != null)
            {
                CargarLineaActual();
            }

        }

        void CargarLineaActual()
        {
            lineaActual = lineaActual = LineaTP.todasLineas.Where(l => l.Id == Convert.ToInt32(cmbLinea.SelectedValue)).FirstOrDefault();

            //Ruta rIda = Ruta.BuscarPorId(lineaActual.RutaIdaId.Value);
            //Ruta rVuelta = Ruta.BuscarPorId(lineaActual.RutaVueltaId.Value);
            RutaTP rIda = lineaActual.rutaIda;
            RutaTP rVuelta = lineaActual.rutaVuelta;


            MapController.CargarRutaEnMapaOffline(rIda, gmapController, paraderosOverlay, previewOverlay, Color.Red);
            MapController.CargarRutaEnMapaOffline(rVuelta, gmapController, paraderosOverlay, previewOverlay, Color.Blue);


            //List<Coordenada> coor = Ruta.ObtenerVerticesDeInicioAFin(rIda);
            List<Coordenada> coor = rIda.listaCoordenadas;
            MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);

            lblRutaIda.Text =  rIda.Nombre;
            lblRutaVuelta.Text = rVuelta.Nombre;

            //List<Ruta> rutasIda = Linea.ObtenerRutasPorTipo(lineaActual.Id, Ruta.TipoRuta.ida);
            //List<Ruta> rutasVuelta = Linea.ObtenerRutasPorTipo(lineaActual.Id, Ruta.TipoRuta.vuelta);
            List<RutaTP> rutasIda = lineaActual.ObtenerRutasPorTipo(Ruta.TipoRuta.ida);
            List<RutaTP> rutasVuelta = lineaActual.ObtenerRutasPorTipo(Ruta.TipoRuta.vuelta);

            cmbRutaIda.DataSource = null;
            cmbRutaIda.DataSource = rutasIda;
            cmbRutaIda.ValueMember = "Id";
            cmbRutaIda.DisplayMember = "Nombre";
            cmbRutaIda.SelectedValue = rIda.Id;

            cmbRutaVuelta.DataSource = null;
            cmbRutaVuelta.DataSource = rutasVuelta;
            cmbRutaVuelta.ValueMember = "Id";
            cmbRutaVuelta.DisplayMember = "Nombre";
            cmbRutaVuelta.SelectedValue = rVuelta.Id;
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            DialogResult dr = MetroMessageBox.Show(this,"¿Está seguro que desea borrar esta línea?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No)
                return;

            List<Micro> micros = Linea.ObtenerMicrosDeLinea(lineaActual.Id);
            if (micros.Count >= 1)
            {
                MetroMessageBox.Show(this,"No puede eliminar una línea que contenga ya micros.");
                return;
            }

            Linea.EliminarLinea(lineaActual.Id);
            LineaTP ltpBorrar = LineaTP.todasLineas.Where(l => l.Id == lineaActual.Id).FirstOrDefault();

            cmbLinea.DataSource = null;

            #region ELimiar temporales

            foreach(RutaTP r in ltpBorrar.rutasDeLinea)
            {
                RutaTP.todasRutas.Remove(r);
            }
            LineaTP.todasLineas.Remove(ltpBorrar);
            #endregion

            MetroMessageBox.Show(this,"Línea eliminada correctamente.");

            previewOverlay.Clear();
            completeOverlay.Clear();
            paraderosOverlay.Clear();
            otrosMarkersOverlay.Clear();

            cmbLinea.SelectedIndex = -1;
            CargarComboboxLineas();
            cmbLinea.DisplayMember = "Nombre";
            cmbLinea.SelectedIndex = 0;
            cmbLinea.DisplayMember = "Nombre";         
        }

        private void btnVerMicros_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            var form = new EditarMicrosDeLinea(lineaActual.Id);
            FormManager.MostrarShowDialog(this, form);
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

                    //Ruta rIda = Ruta.BuscarPorId((int)cmbRutaIda.SelectedValue);
                    //Ruta rVuelta = Ruta.BuscarPorId(lineaActual.RutaVueltaId.Value);
                    RutaTP rIda = RutaTP.todasRutas.Where(r => r.Id == (int)cmbRutaIda.SelectedValue).FirstOrDefault();
                    RutaTP rVuelta = lineaActual.rutaVuelta;

                    MapController.CargarRutaEnMapaOffline(rIda, gmapController, paraderosOverlay, previewOverlay, Color.Red);
                    MapController.CargarRutaEnMapaOffline(rVuelta, gmapController, paraderosOverlay, previewOverlay, Color.Blue);

                    //List<Coordenada> coor = Ruta.ObtenerVerticesDeInicioAFin(rIda);
                    List<Coordenada> coor = rIda.listaCoordenadas;
                    MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);



                    cmbIdaSwitch = false;
                }
            }
            catch
            {

                return;
            }
        }

        private void btnCrearIda_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            var form = new CrearRutaIda(lineaActual.Id);
            FormManager.MostrarShowDialog(this, form);

            if (form.DialogResult == DialogResult.OK)
            {
                int idLinea = lineaActual.Id;
                CargarComboboxLineas();
                cmbLinea.SelectedValue = idLinea;
            }
        }

        private void btnEliminarIda_Click(object sender, EventArgs e)
        {
            if(lineaActual == null)
                return;

            DialogResult dr = MetroMessageBox.Show(this,"¿Está seguro que desea borrar esta ruta de ida?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No)
                return;


            if (cmbRutaIda.Items.Count > 0)
            {

                //Ruta rutaIda = Ruta.BuscarPorId((int)cmbRutaIda.SelectedValue);
                int idLinea = lineaActual.Id;
                //int idRutaAsignada = lineaActual.RutaIdaId.Value;

                RutaTP rutaABorrar = RutaTP.todasRutas.Where(r => r.Id == (int)cmbRutaIda.SelectedValue).FirstOrDefault();
                int idAsignada = lineaActual.rutaIda.Id;

                if (idAsignada == rutaABorrar.Id)
                {
                    MetroMessageBox.Show(this,"No puede eliminar la ruta que está actualmente asignada.");
                    return;
                }

                RutaTP rtpBorrar = RutaTP.todasRutas.Where(r => r.Id == rutaABorrar.Id).FirstOrDefault();
                RutaTP.todasRutas.Remove(rtpBorrar);
                lineaActual.rutasDeLinea.Remove(rtpBorrar);

                Ruta.EliminarRuta(rutaABorrar.Id);

                cmbRutaIda.DataSource = null;
                CargarComboboxLineas();
                cmbLinea.SelectedValue = idLinea;
                MetroMessageBox.Show(this,"Ruta eliminada correctamente");
            }
        }

        private void btnAsignarIda_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            Ruta rutaIda = Ruta.BuscarPorId((int)cmbRutaIda.SelectedValue);

            int idLinea = lineaActual.Id;
            rutaIda.AsignarRutaComoUsable();

            RutaTP rTP = RutaTP.todasRutas.Where(r => r.Id == rutaIda.Id).FirstOrDefault();
            lineaActual.rutaIda = rTP;

            CargarComboboxLineas();
            cmbLinea.SelectedValue = idLinea;

            MetroMessageBox.Show(this,"Ruta " + rutaIda.Nombre + " asignada como la ruta a usar.");
        }

        bool cmbVueltaSwitch = false;
        private void cmbRutaVuelta_Click(object sender, EventArgs e)
        {
            cmbVueltaSwitch = true;
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

                    //Ruta rIda = Ruta.BuscarPorId(lineaActual.RutaIdaId.Value);
                    //Ruta rVuelta = Ruta.BuscarPorId((int)cmbRutaVuelta.SelectedValue);

                    RutaTP rIda = lineaActual.rutaIda;
                    RutaTP rVuelta = RutaTP.todasRutas.Where(r => r.Id == (int)cmbRutaVuelta.SelectedValue).FirstOrDefault();

                    MapController.CargarRutaEnMapaOffline(rIda, gmapController, paraderosOverlay, previewOverlay, Color.Red);
                    MapController.CargarRutaEnMapaOffline(rVuelta, gmapController, paraderosOverlay, previewOverlay, Color.Blue);

                    //List<Coordenada> coor = Ruta.ObtenerVerticesDeInicioAFin(rIda);
                    List<Coordenada> coor = rIda.listaCoordenadas;
                    MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);



                    cmbVueltaSwitch = false;
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

        private void btnEliminarVuelta_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            DialogResult dr = MetroMessageBox.Show(this,"¿Está seguro que desea borrar esta ruta de vuelta?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No)
                return;

            if (cmbRutaVuelta.Items.Count > 0)
            {

                //Ruta rutaVuelta = Ruta.BuscarPorId((int)cmbRutaVuelta.SelectedValue);
                int idLinea = lineaActual.Id;
                //int idRutaAsignada = lineaActual.RutaVueltaId.Value;

                RutaTP rutaABorrar = RutaTP.todasRutas.Where(r => r.Id == (int)cmbRutaVuelta.SelectedValue).FirstOrDefault();
                int idAsignada = lineaActual.rutaVuelta.Id;

                if (idAsignada == rutaABorrar.Id)
                {
                    MetroMessageBox.Show(this,"No puede eliminar la ruta que está actualmente asignada.");
                    return;
                }

                RutaTP rtpBorrar = RutaTP.todasRutas.Where(r => r.Id == rutaABorrar.Id).FirstOrDefault();
                RutaTP.todasRutas.Remove(rtpBorrar);
                lineaActual.rutasDeLinea.Remove(rtpBorrar);

                Ruta.EliminarRuta(rutaABorrar.Id);

                CargarComboboxLineas();
                cmbLinea.SelectedValue = idLinea;
                MetroMessageBox.Show(this,"Ruta eliminada correctamente");
            }
        }

        private void btnAsignarVuelta_Click(object sender, EventArgs e)
        {
            if (lineaActual == null)
                return;

            Ruta RutaVuelta = Ruta.BuscarPorId((int)cmbRutaVuelta.SelectedValue);

            int idLinea = lineaActual.Id;
            RutaVuelta.AsignarRutaComoUsable();

            RutaTP rTP = RutaTP.todasRutas.Where(r => r.Id == RutaVuelta.Id).FirstOrDefault();
            lineaActual.rutaVuelta = rTP;

            CargarComboboxLineas();
            cmbLinea.SelectedValue = idLinea;

            MetroMessageBox.Show(this,"Ruta " + RutaVuelta.Nombre + " asignada como la ruta a usar.");
        }

        private void AdminLineas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormManager.cerrandoAplicacion == true)
                return;

            var res = MetroMessageBox.Show(this, "¿Seguro desea cerrar la aplicación?", "Exit",
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

        private void AdminLineas_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }

    }
}
