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

namespace MicrosForms.Ventanas.Creaciones
{
    public partial class CrearUsuario : Form
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

            if (nombre == "" || email == "" || pass == "" || txtConfrimarPassword.Text == "")
            {
                mensajeError += "\n-No deje campos de texto vacíos.";
            }
            if (Usuario.yaExisteUsuario(nombre))
            {
                mensajeError += "\n-El nombre de usuario ya existe.";
            }
            if (pass != txtConfrimarPassword.Text)
            {
                mensajeError += "\n-Las contraseñas no coinciden.";
            }

            if (mensajeError != "")
            {
                MessageBox.Show("Se encontraron los siguientes errores:" + mensajeError);
                return;
            }


            bool creacionExitosa = Usuario.CrearUsuario(nombre, email, rol, pass);

            if(creacionExitosa)
            {
                MessageBox.Show("Creación de usuario existosa.");
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
