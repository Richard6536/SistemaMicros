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
using MicrosFormsGX.Ventanas;
using MicrosFormsGX.Ventanas.Creaciones;
using MicrosFormsGX.Ventanas.Ediciones;
using MicrosFormsGX.Ventanas.Historiales;

using MetroFramework;

namespace MicrosFormsGX.Ventanas
{
    public partial class AdminMicros : MetroFramework.Forms.MetroForm
    {

        List<Micro> micros;

        public AdminMicros()
        {
            InitializeComponent();
            micros = Micro.BuscarTodasLasMicros();
            CargarTabla(micros);
        }

        #region toolstrips
        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminUsuarios());
        }

        private void administrarLineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminLineas());
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

        private void btnCrearMicro_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Form form = new CrearMicro();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            this.Enabled = true;

            if (form.DialogResult == DialogResult.OK)
            {
                micros = Micro.BuscarTodasLasMicros();
                CargarTabla(micros);
            }
        }

        private void CargarTabla(List<Micro> _micros)
        {
            _micros.OrderBy(m => m.Patente);
            datagridMicros.Rows.Clear();

            foreach (Micro m in _micros)
            {
                CargarLinea(m);
            }

        }

        private void CargarLinea(Micro m)
        {
            string lineaNombre = "--NO ASIGNADA--";
            string choferNombre = "--NO ASIGNADO--";
            if (m.LineaId != null)
            {
                Linea linea = Linea.BuscarLinea(m.LineaId.Value);
                lineaNombre = linea.Nombre;
            }
            if (m.MicroChoferId != null)
            {
                Usuario chofer = MicroChofer.GetChofer(m.MicroChoferId.Value);
                choferNombre = chofer.Nombre;
            }

            datagridMicros.Rows.Add(m.Patente, lineaNombre, m.Calificacion, choferNombre, "Ver historial", "Editar datos");

        }

        private void dataGridMicros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && (e.RowIndex >= 0))
            {
                int indexClickeado = e.RowIndex;

                string patenteMicro = datagridMicros.Rows[indexClickeado].Cells[0].Value + "";

                if (e.ColumnIndex == 4) //Historial
                {
                    var forms = new MicrosFormsGX.Ventanas.Historiales.HistorialDiario(patenteMicro);
                    FormManager.MostrarShowDialog(this, forms);

                }
                else if (e.ColumnIndex == 5) //Editar
                {

                    var forms = new EditarMicro(patenteMicro);

                    Micro micro = Micro.BuscarPorPatente(patenteMicro);
                    if(micro.MicroChoferId != null)
                    {
                        Usuario chofer = MicroChofer.GetChofer(micro.MicroChoferId.Value);

                        if(chofer.TransmitiendoPosicion == true)
                        {
                            MetroMessageBox.Show(this, "No puede editar datos de esta micro mientras se encuentre en un recorrido.");
                            return;
                        }
                    }
                    

                    DialogResult result = FormManager.MostrarShowDialog(this, forms);

                    if (result == DialogResult.OK)
                    {
                        micros = Micro.BuscarTodasLasMicros();
                        CargarTabla(micros);
                        SeleccionarIndexPorPatente(patenteMicro);

                    }
                }

            }
        }

        private void SeleccionarIndexPorPatente(string _patente)
        {
            int index = -1;

            foreach (DataGridViewRow row in datagridMicros.Rows)
            {
                if (row.Cells[0].Value + "" == _patente)
                {
                    index = row.Index;
                }
            }

            datagridMicros.Rows[0].Selected = false;
            datagridMicros.Rows[index].Selected = true;
        }

        private void AdminMicros_FormClosing(object sender, FormClosingEventArgs e)
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

        private void AdminMicros_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AdminMicros_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }
    }
}
