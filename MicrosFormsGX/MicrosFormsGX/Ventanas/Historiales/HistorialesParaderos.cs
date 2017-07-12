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
    public partial class HistorialesParaderos : MetroFramework.Forms.MetroForm
    {
        List<HistorialParadero> historialesParadero;


        public HistorialesParaderos(int _idHistorialIdaVuelta, int _numeroRecorrido)
        {
            InitializeComponent();

            historialesParadero = HistorialIdaVuelta.ObtenerHistorialesParaderos(_idHistorialIdaVuelta);

            lblPatente.Text = HistorialIdaVuelta.BuscarPorId(_idHistorialIdaVuelta).HistorialDiario.Micro.Patente;
            lblFecha.Text = HistorialIdaVuelta.BuscarPorId(_idHistorialIdaVuelta).HistorialDiario.Fecha.ToString("");
            lblNumeroRecorrido.Text = _numeroRecorrido + "";

            CargarTabla();
        }

        private void HistorialesParaderos_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CargarTabla()
        {
            historialesParadero.OrderBy(h => h.Id);
            datagridHistorial.Rows.Clear();

            int c = 1;

            foreach (HistorialParadero historial in historialesParadero)
            {
                CargarLinea(historial, c);
                c++;
            }

        }

        private void CargarLinea(HistorialParadero h, int _numeroParadero)
        {

            DataGridViewRow row = new DataGridViewRow();
            row.SetValues(_numeroParadero, h.HoraLlegada, h.TiempoDetenido, h.PasajerosRecibidos);

            datagridHistorial.Rows.Add(row);

        }
    }
}
