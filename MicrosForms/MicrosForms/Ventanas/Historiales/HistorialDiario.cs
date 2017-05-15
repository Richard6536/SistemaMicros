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
using MicrosForms.Ventanas.Historiales;

namespace MicrosForms.Ventanas.Historiales
{
    public partial class HistorialDiario : Form
    {
        Micro micro;
        List<MicrosForms.Model.HistorialDiario> historialesDiarios;


        public HistorialDiario(string _patenteMicro)
        {
            InitializeComponent();

            micro = Micro.BuscarPorPatente(_patenteMicro);
            historialesDiarios = Micro.ObtenerHistorialesDiarios(micro.Id);

            lblPatente.Text = micro.Patente;

            desde = DateTime.MinValue;
            hasta = DateTime.Today.Date;
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

        private void CargarLinea(MicrosForms.Model.HistorialDiario h)
        {
            if (h.Fecha < desde || h.Fecha > hasta)
                return;

            datagridHistorial.Rows.Add(h.Fecha, h.NombreChofer, h.HoraInicio, h.HoraFinal, h.KilometrosRecorridos,
                h.CalificacionesRecibidas, h.CalificacionDiaria, h.PasajerosTransportados, h.NumeroIdaVueltas,
                "Ver historial recorridos");

        }

        private void datagridHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && (e.RowIndex >= 0))
            {
                int indexClickeado = e.RowIndex;

                if (e.ColumnIndex == 9) //Historiales ida vuelta
                {
                    var forms = new HistorialesIdaVuelta(micro.Id);
                    FormManager.MostrarShowDialog(this, forms);

                }

            }
        }


        private void datePickerDesde_ValueChanged(object sender, EventArgs e)
        {
            var datePicker = (DateTimePicker)sender;
            if (datePicker.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("No puede seleccionar una fecha futura.");
                datePicker.Value = DateTime.Today;
            }

            CargarTabla();
        }

        private void datePickerHasta_ValueChanged(object sender, EventArgs e)
        {
            var datePicker = (DateTimePicker)sender;
            if (datePicker.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("No puede seleccionar una fecha futura.");
                datePicker.Value = DateTime.Today;
            }

            CargarTabla();
        }

        private void btnMostrarTodas_Click(object sender, EventArgs e)
        {
            historialesDiarios = Micro.ObtenerHistorialesDiarios(micro.Id);
            desde = DateTime.MinValue;
            hasta = DateTime.Today.Date;

            CargarTabla();
        }
    }
}
