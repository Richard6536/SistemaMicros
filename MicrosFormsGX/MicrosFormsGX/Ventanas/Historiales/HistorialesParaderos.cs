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
            historialesParadero.OrderBy(h => h.Orden);
            datagridHistorial.Rows.Clear();

            foreach (HistorialParadero historial in historialesParadero)
            {
                CargarLinea(historial);
            }

        }

        private void CargarLinea(HistorialParadero h)
        {
            string horaLlegada = (h.HoraLlegada + "").Split(' ')[1];
            string tiempoDet = (h.TiempoDetenido + "").Split('.')[0];

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(datagridHistorial, h.Orden, horaLlegada, tiempoDet, h.PasajerosRecibidos);

            datagridHistorial.Rows.Add(row);

        }
    }
}
