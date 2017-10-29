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
using MetroFramework;

namespace MicrosFormsGX.Ventanas.Historiales
{
    public partial class HistorialesIdaVuelta : MetroFramework.Forms.MetroForm
    {
        List<HistorialIdaVuelta> historialesIdaVuelta;

        public HistorialesIdaVuelta(int _idHistorialDiario)
        {
            InitializeComponent();

            lblPatente.Text = MicrosFormsGX.Model.HistorialDiario.ObtenerMicro(_idHistorialDiario).Patente;
            lblFecha.Text = MicrosFormsGX.Model.HistorialDiario.BuscarPorId(_idHistorialDiario).Fecha + "";

            historialesIdaVuelta = MicrosFormsGX.Model.HistorialDiario.ObtenerHistorialesIdaVuelta(_idHistorialDiario);

            CargarTabla();
        }


        private void CargarTabla()
        {
            historialesIdaVuelta.OrderBy(h => h.Orden);
            datagridHistorial.Rows.Clear();

            foreach (HistorialIdaVuelta historial in historialesIdaVuelta)
            {
                if (historial.HoraInicio != historial.HoraTermino)
                {
                    CargarLinea(historial);
                }
            }

        }

        private void CargarLinea(HistorialIdaVuelta h)
        {
            DataGridViewRow row = new DataGridViewRow();

            string horaInicio = (h.HoraInicio + "").Split(' ')[1];
            string horaFinal = (h.HoraTermino + "").Split(' ')[1];
            string duracion = (h.DuracionRecorrido + "").Split('.')[0];

            row.CreateCells(datagridHistorial, h.Orden, horaInicio, horaFinal, duracion, h.PasajerosTransportados,
                "Ver historial paraderos");

            row.Tag = h.Id;

            datagridHistorial.Rows.Add(row);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void HistorialesIdaVuelta_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }

        private void datagridHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && (e.RowIndex >= 0))
            {
                int indexClickeado = e.RowIndex;

                if (e.ColumnIndex == 5) //Historiales ida vuelta
                {
                    DataGridViewRow rowClickeada = senderGrid.Rows[e.RowIndex];
                    int idHistorialIdaVuelta = Convert.ToInt32(rowClickeada.Tag);
                    int numeroRecorrido = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value);
                    var forms = new HistorialesParaderos(idHistorialIdaVuelta, numeroRecorrido);
                    FormManager.MostrarShowDialog(this, forms);

                }

            }
        }
    }
}
