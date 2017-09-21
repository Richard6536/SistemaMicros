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
            txtTarifa.Text = lineaActual.Tarifa + "";
            btnGuardar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int nuevaTarifa = 0;
            string nuevoNombre = txtNombre.Text;

            bool errorTarifa = false;

            try
            {
                nuevaTarifa = Convert.ToInt32(txtTarifa.Text);
            }
            catch
            {
                errorTarifa = true;
            }

            Linea repetido = Linea.BuscarLineaPorNombre(nuevoNombre);

            if (repetido.Id == lineaActual.Id)
                repetido = null; 

            string mensajeError = "";

            if (repetido != null)
                mensajeError += "\n-El nombre de esa línea ya existe.";
            if (nuevoNombre == "" || txtTarifa.Text == "")
                mensajeError += "\n-No deje campos de texto vacíos.";

            if (errorTarifa == true)
                mensajeError += "\n-No se ingresaron valores numéricos para la tarifa.";
            else if (nuevaTarifa <= 0)
                mensajeError += "\n-La tarifa debe tener un valor mayor a 0.";

            if (mensajeError != "")
            {
                MetroMessageBox.Show(this,"Se encontraron los siguientes errores:" + mensajeError);
                return;
            }

            bool res = Linea.EditarDatos(lineaActual.Id, nuevoNombre, nuevaTarifa);

            if (res)
            {
                LineaTP ltp = LineaTP.todasLineas.Where(l => l.Id == lineaActual.Id).FirstOrDefault();
                ltp.Nombre = nuevoNombre;
                ltp.Tarifa = nuevaTarifa;

                MetroMessageBox.Show(this,"Datos editados correctamente");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text == lineaActual.Nombre && txtTarifa.Text == lineaActual.Tarifa +"")
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

        private void txtTarifa_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text == lineaActual.Nombre && txtTarifa.Text == lineaActual.Tarifa + "")
            {
                btnGuardar.Enabled = false;
            }
            else
            {
                btnGuardar.Enabled = true;
            }
        }
    }
}
