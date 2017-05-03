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

namespace MicrosForms.Ventanas.Ediciones
{
    public partial class EditarMicrosDeLinea : Form
    {
        Linea lineaActual;
        List<Micro> micros;

        public EditarMicrosDeLinea(int _idLinea)
        {
            InitializeComponent();

            lineaActual = Linea.BuscarLinea(_idLinea);
            micros = Linea.ObtenerMicrosDeLinea(lineaActual.Id);
            CargarTabla(micros);
            CargarCombobox();
            lblLinea.Text = lineaActual.Nombre;
        }

        void CargarCombobox()
        {
            List<Micro> microsLibres = new List<Micro>();
            List<Micro> todas = Micro.BuscarTodasLasMicros();

            for (int i = 0; i < todas.Count; i++)
            {
                if (todas[i].LineaId == null)
                {
                    microsLibres.Add(todas[i]);
                }
            }

            cmbMicros.DataSource = microsLibres;
            cmbMicros.ValueMember = "Id";
            cmbMicros.DisplayMember = "Patente";

            cmbMicros.Text = "Micros disponibles";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cmbMicros.SelectedValue+"" == "")
            {
                MessageBox.Show("No se seleccionó una micro válida.");
                return;
            }

            Micro micro = Micro.BuscarMicro((int)cmbMicros.SelectedValue);
            Micro.AsignarLinea(micro.Id, lineaActual);
            MessageBox.Show("Micro asignada correctamente");
            micros = Linea.ObtenerMicrosDeLinea(lineaActual.Id);
            CargarTabla(micros);
            CargarCombobox();
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
            string choferNombre = "--NO ASIGNADO--";

            if (m.MicroChoferId != null)
            {
                Usuario chofer = MicroChofer.GetChofer(m.MicroChoferId.Value);
                choferNombre = chofer.Nombre;
            }

            datagridMicros.Rows.Add(m.Patente, m.Calificacion, choferNombre, "Ver historial", "Quitar");

        }

        private void datagridMicros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && (e.RowIndex >= 0))
            {
                int indexClickeado = e.RowIndex;

                string patenteMicro = datagridMicros.Rows[indexClickeado].Cells[0].Value + "";

                if (e.ColumnIndex == 3) //Historial
                {
                    var forms = new MicrosForms.Ventanas.Historiales.HistorialDiario(patenteMicro);
                    FormManager.MostrarShowDialog(this, forms);

                }
                else if (e.ColumnIndex == 4) //Desligar de la línea
                {
                    DialogResult dr = MessageBox.Show("¿Está seguro que desea quitar esta micro?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.No)
                        return;

                    Micro m = Micro.BuscarPorPatente(patenteMicro);
                    Micro.AsignarLinea(m.Id, null);
                    MessageBox.Show("Micro desligada de la línea correctamente.");
                    micros = Linea.ObtenerMicrosDeLinea(lineaActual.Id);
                    CargarTabla(micros);
                    CargarCombobox();
                }

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
