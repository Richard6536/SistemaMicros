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
using MetroFramework;

namespace MicrosFormsGX.Ventanas.Creaciones
{
    public partial class CrearUsuario : MetroFramework.Forms.MetroForm
    {
        public CrearUsuario()
        {
            InitializeComponent();

            cmbRol.DataSource = Enum.GetValues(typeof(Usuario.RolUsuario));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            string nombre = txtNombre.Text;
            string email = txtEmail.Text;
            string pass = txtPassword.Text;
            Usuario.RolUsuario rol = (Usuario.RolUsuario)Enum.Parse(typeof(Usuario.RolUsuario), cmbRol.SelectedValue + "");

            string mensajeError = "";

            if (nombre == "" || email == "" || pass == "" || txtConfirmarPassword.Text == "")
            {
                mensajeError += "\n-No deje campos de texto vacíos.";
            }
            if (Usuario.yaExisteUsuario(nombre))
            {
                mensajeError += "\n-El nombre de usuario ya existe.";
            }
            if(Usuario.BuscarUsuarioPorEmail(email) != null)
            {
                mensajeError += "\n-El e-mail ingresado ya existe.";
            }
            if (pass != txtConfirmarPassword.Text)
            {
                mensajeError += "\n-Las contraseñas no coinciden.";
            }

            if (mensajeError != "")
            {
                MetroMessageBox.Show(this,"Se encontraron los siguientes errores:" + mensajeError);
                return;
            }


            bool creacionExitosa = Usuario.CrearUsuario(nombre, email, rol, pass);

            if (creacionExitosa)
            {
                MetroMessageBox.Show(this,"Creación de usuario existosa.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void CrearUsuario_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }
    }
}
