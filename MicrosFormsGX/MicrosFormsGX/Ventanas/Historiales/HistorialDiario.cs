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

namespace MicrosFormsGX.Ventanas.Historiales
{
    public partial class HistorialDiario : MetroFramework.Forms.MetroForm
    {
        Micro micro;
        List<MicrosFormsGX.Model.HistorialDiario> historialesDiarios;

        public HistorialDiario(string _patenteMicro)
        {
            InitializeComponent();
            micro = Micro.BuscarPorPatente(_patenteMicro);
            historialesDiarios = Micro.ObtenerHistorialesDiarios(micro.Id);

            lblPatente.Text = micro.Patente;


            datePickerDesde.Value = datePickerDesde.MinDate;
            datePickerHasta.Value = DateTime.Today.Date;
            CargarTabla();
        }

        DateTime desde;
        DateTime hasta;
        private void CargarTabla()
        {
            desde = datePickerDesde.Value.Date;
            hasta = datePickerHasta.Value.Date;
            historialesDiarios.OrderByDescending(h => h.Fecha);
            datagridHistorial.Rows.Clear();

            foreach (var historial in historialesDiarios)
            {
                CargarLinea(historial);
            }

        }

        private void CargarLinea(MicrosFormsGX.Model.HistorialDiario h)
        {
            if (h.Fecha < desde || h.Fecha > hasta)
                return;

            if (h.HoraInicio != h.HoraFinal)
            {

                DataGridViewRow row = new DataGridViewRow();

                string fecha = (h.Fecha + "").Split(' ')[0];
                string horaInicio = (h.HoraInicio.TimeOfDay + "").Split('.')[0];
                string horaFinal = (h.HoraFinal.TimeOfDay + "").Split('.')[0];

                row.CreateCells(datagridHistorial, fecha, h.NombreChofer, horaInicio, horaFinal, h.KilometrosRecorridos,
                    h.CalificacionesRecibidas, h.CalificacionDiaria, h.PasajerosTransportados, h.NumeroIdaVueltas,
                    "Ver historial recorridos");


                row.Tag = h.Id;


                datagridHistorial.Rows.Add(row);

            }
        }


        private void datePickerDesde_ValueChanged(object sender, EventArgs e)
        {
            var datePicker = (DateTimePicker)sender;
            if (datePicker.Value.Date > DateTime.Today.Date)
            {
                MetroMessageBox.Show(this,"No puede seleccionar una fecha futura.");
                datePicker.Value = DateTime.Today;
            }

            CargarTabla();
        }

        private void datePickerHasta_ValueChanged(object sender, EventArgs e)
        {
            var datePicker = (DateTimePicker)sender;
            if (datePicker.Value.Date > DateTime.Today.Date)
            {
                MetroMessageBox.Show(this,"No puede seleccionar una fecha futura.");
                datePicker.Value = DateTime.Today;
            }

            CargarTabla();
        }

        private void datagridHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && (e.RowIndex >= 0))
            {
                int indexClickeado = e.RowIndex;

                if (e.ColumnIndex == 9) //Historiales ida vuelta
                {
                    DataGridViewRow rowClickeada = senderGrid.Rows[e.RowIndex];
                    int idHistorialDiario = Convert.ToInt32(rowClickeada.Tag);
                    var forms = new HistorialesIdaVuelta(idHistorialDiario);
                    FormManager.MostrarShowDialog(this, forms);

                }

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnMostrarTodas_Click(object sender, EventArgs e)
        {
            historialesDiarios = Micro.ObtenerHistorialesDiarios(micro.Id);
            desde = DateTime.MinValue;
            hasta = DateTime.Today.Date;

            CargarTabla();
        }

        private void HistorialDiario_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }
    }
}
