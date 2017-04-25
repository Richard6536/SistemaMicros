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
    public partial class CambiarNombreLinea : Form
    {
        Linea lineaActual;

        public CambiarNombreLinea(int _idLinea)
        {
            InitializeComponent();

            lineaActual = Linea.BuscarLinea(_idLinea);
            txtNombre.Text = lineaActual.Nombre;
            btnGuardar.Enabled = false;
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

            if(mensajeError != "")
            {
                MessageBox.Show("Se encontraron los siguientes errores:" + mensajeError);
                return;
            }

            bool res = Linea.EditarNombre(lineaActual.Id, nuevoNombre);

            if(res)
            {
                MessageBox.Show("Nombre editado correctamente");
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
