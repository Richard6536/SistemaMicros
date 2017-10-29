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
    public partial class InicioReal : MetroFramework.Forms.MetroForm
    {
        bool cargarLinea;
        LineaTP lineaActual;
        List<Usuario> choferesLineaActual;
        Dictionary<int, GMarkerGoogle> marcadoresMicros;
        bool actualizarTimer;

        GMapOverlay previewOverlay;
        GMapOverlay completeOverlay;
        GMapOverlay paraderosOverlay;
        GMapOverlay otrosMarkersOverlay;
        GMapOverlay microsOverlay;

        #region Toolstrips
        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminUsuarios());
            actualizarTimer = false;
        }

        private void administrarMicrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminMicros());
            actualizarTimer = false;
        }

        private void administrarLineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminLineas());
            actualizarTimer = false;
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new Login());
            actualizarTimer = false;
        }
        #endregion

        public InicioReal()
        {
            
            InitializeComponent();
            IniciarMapa();
        }

        double latOsorno = -40.574984;
        double lngOsorno = -73.125183;

        void IniciarMapa()
        {
            gmapController.MapProvider = MapController.provider;

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
            microsOverlay = new GMapOverlay();

            gmapController.Overlays.Add(previewOverlay);
            gmapController.Overlays.Add(completeOverlay);
            gmapController.Overlays.Add(paraderosOverlay);
            gmapController.Overlays.Add(otrosMarkersOverlay);
            gmapController.Overlays.Add(microsOverlay);
        }

        void CargarComboboxLineas()
        {
            if (!ConnectionTester.IsConnectionActive())
                return;
            //List<Linea> lineasCMB = Linea.ObtenerTodasLasLineas();
            //List<Linea> lineasCMBOrdenadas = lineasCMB.OrderBy(l => l.Nombre).ToList();
            List<LineaTP> lineasCMB = LineaTP.todasLineas.OrderBy(l => l.Nombre).ToList();
            cmbLinea.DataSource = lineasCMB;
            cmbLinea.DisplayMember = "Nombre";
            cmbLinea.ValueMember = "Id";


            //lineaActual = Linea.BuscarLinea(Convert.ToInt32(cmbLinea.SelectedValue));
            //lineaActual = LineaTP.todasLineas.Where(l => l.Id == Convert.ToInt32(cmbLinea.SelectedValue)).FirstOrDefault();

            //if (lineaActual != null)
            //{
            //    CargarLineaActual();
            //}

        }

        void CargarLineaActual()
        {
            //lineaActual = Linea.BuscarLinea(Convert.ToInt32(cmbLinea.SelectedValue));
            lineaActual = LineaTP.todasLineas.Where(l => l.Id == Convert.ToInt32(cmbLinea.SelectedValue)).FirstOrDefault();

            if (lineaActual != null)
            {
                //Ruta rIda = Ruta.BuscarPorId(lineaActual.RutaIdaId.Value);
                //Ruta rVuelta = Ruta.BuscarPorId(lineaActual.RutaVueltaId.Value);
                RutaTP rIda = lineaActual.rutaIda;
                RutaTP rVuelta = lineaActual.rutaVuelta;

                MapController.CargarRutaEnMapaOffline(rIda, gmapController, paraderosOverlay, previewOverlay, Color.Red);
                MapController.CargarRutaEnMapaOffline(rVuelta, gmapController, paraderosOverlay, previewOverlay, Color.Blue);

                //List<Coordenada> coor = Ruta.ObtenerVerticesDeInicioAFin(rIda);
                List<Coordenada> coor = rIda.listaCoordenadas;

                MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);


                //Se crean todos los marcadores (activos e inactivos)
                //el timer actualiza todas las posiciones de los marcadores
                //y tan solo filtra si el overlay los muestra o no

                marcadoresMicros = new Dictionary<int, GMarkerGoogle>();

                choferesLineaActual = Linea.ObtenerChoferes(Convert.ToInt32(cmbLinea.SelectedValue));
                CargarTabla(choferesLineaActual);

                foreach (Usuario u in choferesLineaActual)
                {
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(u.Latitud, u.Longitud), MapController.marcadorMicro);
                    marcadoresMicros.Add(u.Id, marker);
                }
                actualizarTimer = true;
            }

        }

        private void InicioReal_Activated(object sender, EventArgs e)
        {
            cargarLinea = false;
            int index = cmbLinea.SelectedIndex;
            CargarComboboxLineas();
            cmbLinea.SelectedIndex = index;
            cargarLinea = true;
            CargarLineaActual();
            FormManager.formAbiertaActual = this;
        }

        private void cmbLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Recargar comboboxes de rutas
            try
            {

                if(cargarLinea)
                {
                    previewOverlay.Clear();
                    completeOverlay.Clear();
                    paraderosOverlay.Clear();
                    otrosMarkersOverlay.Clear();
                    microsOverlay.Clear();
                    CargarLineaActual();
                }
            
            }
            catch
            {

                return;
            }
        }

        private void CargarTabla(List<Usuario> _usuarios)
        {

            datagridMicros.Rows.Clear();

            foreach (Usuario u in _usuarios)
            {
                if (u.TransmitiendoPosicion)
                    CargarLineaTabla(u);
            }
        }

        private void CargarLineaTabla(Usuario u)
        {
            Micro microAsociada = MicroChofer.GetMicro(u.MicroChoferId.Value);
            datagridMicros.Rows.Add(microAsociada.Patente, u.Nombre);

        }

        private void QuitarLineaTabla(Usuario u)
        {
            Micro microAsociada = MicroChofer.GetMicro(u.MicroChoferId.Value);
            int index = -1;
            foreach (DataGridViewRow row in datagridMicros.Rows)
            {
                if (row.Cells[0].Value + "" == microAsociada.Patente)
                {
                    index = row.Index;
                }
            }

            if (index >= 0)
            {
                datagridMicros.Rows.RemoveAt(index);
            }
        }

        private bool VerificarExistenciaEnTabla(Usuario u)
        {
            Micro microAsociada = MicroChofer.GetMicro(u.MicroChoferId.Value);
            bool existe = false;

            foreach (DataGridViewRow row in datagridMicros.Rows)
            {
                if (row.Cells[0].Value + "" == microAsociada.Patente)
                {
                    existe = true;
                }
            }
            return existe;
        }

        private void InicioReal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void InicioReal_FormClosing(object sender, FormClosingEventArgs e)
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


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (actualizarTimer == false)
            {
                return;
            }

            if (marcadoresMicros.Count > 0)
            {
                microsOverlay.Markers.Clear();
                choferesLineaActual = Usuario.CalibrarMarcadoresMapa(marcadoresMicros, microsOverlay);

                foreach (Usuario u in choferesLineaActual)
                {
                    if (u.TransmitiendoPosicion == true)
                    {
                        if (VerificarExistenciaEnTabla(u) == false)
                            CargarLineaTabla(u);
                    }
                    else if (u.TransmitiendoPosicion == false)
                    {
                        if (VerificarExistenciaEnTabla(u) == true)
                            QuitarLineaTabla(u);
                    }
                }
            }
        }

        
        private void btnVerEsconderMicros_Click(object sender, EventArgs e)
        {
            if(datagridMicros.Visible)
            {
                datagridMicros.Visible = false;
                btnVerEsconderMicros.Text = "Ver listado micros";

            }
            else
            {
                datagridMicros.Visible = true;
                btnVerEsconderMicros.Text = "Esconder listado micros";
            }
        }



    }

}
