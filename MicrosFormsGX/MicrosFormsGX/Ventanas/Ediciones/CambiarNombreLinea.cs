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
using MicrosFormsGX.Model.DatosTemporales;

namespace MicrosFormsGX.Ventanas.Ediciones
{
    public partial class CambiarNombreLinea : MetroFramework.Forms.MetroForm
    {
        Linea lineaActual;

        public CambiarNombreLinea(int _idLinea)
        {
            InitializeComponent();
            lineaActual = Linea.BuscarLinea(_idLinea);
            txtNombre.Text = lineaActual.Nombre;
            btnGuardar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtNombre.Text;

            Linea repetido = Linea.BuscarLineaPorNombre(nuevoNombre);

            string mensajeError = "";

            if (repetido != null)
                mensajeError += "\n-El nombre de esa línea ya existe.";
            if (nuevoNombre == "")
                mensajeError += "\n-No deje el campo nombre vacío";

            if (mensajeError != "")
            {
                MetroMessageBox.Show(this,"Se encontraron los siguientes errores:" + mensajeError);
                return;
            }

            bool res = Linea.EditarNombre(lineaActual.Id, nuevoNombre);

            if (res)
            {
                LineaTP ltp = LineaTP.todasLineas.Where(l => l.Id == lineaActual.Id).FirstOrDefault();
                ltp.Nombre = nuevoNombre;

                MetroMessageBox.Show(this,"Nombre editado correctamente");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text == lineaActual.Nombre)
            {
                btnGuardar.Enabled = false;
            }
            else
            {
                btnGuardar.Enabled = true;
            }
        }

        private void CambiarNombreLinea_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }
    }
}
