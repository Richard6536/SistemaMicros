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

using MetroFramework;

namespace MicrosFormsGX.Ventanas.Creaciones
{
    public partial class CrearLineaDatos : MetroFramework.Forms.MetroForm
    {
        CrearLineaV2 formCreacion;

        public CrearLineaDatos(CrearLineaV2 _formCreacion)
        {
            formCreacion = _formCreacion;
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int tarifa = 0;
            string nombre = txtNombre.Text;

            bool errorTarifa = false;

            try
            {
                tarifa = Convert.ToInt32(txtTarifa.Text);
            }
            catch
            {
                errorTarifa = true;
            }

            Linea repetido = Linea.BuscarLineaPorNombre(nombre);

            string mensajeError = "";

            if (repetido != null)
                mensajeError += "\n-El nombre de esa línea ya existe.";
            if (nombre == "" || txtTarifa.Text == "")
                mensajeError += "\n-No deje campos detexto vacíos";

            if (errorTarifa == true)
                mensajeError += "\n-No se ingresaron valores numéricos para la tarifa.";
            else if (tarifa <= 0)
                mensajeError += "\n-La tarifa debe tener un valor mayor a 0.";

            if (mensajeError != "")
            {
                MetroMessageBox.Show(this, "Se encontraron los siguientes errores:" + mensajeError);
                return;
            }

            formCreacion.NombreLinea = nombre;
            formCreacion.Tarifa = tarifa;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
