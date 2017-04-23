using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MicrosForms.Model;
using MicrosForms.Ventanas;
using MicrosForms.Classes;

namespace MicrosForms.Ventanas.Creaciones
{
    public partial class CrearPrimerUsuario : Form
    {
        public CrearPrimerUsuario()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }

            if(!ConnectionTester.IsConnectionActive())
            {
                return;
            }

            string nombre = txtNombre.Text;
            string email = txtEmail.Text;
            string pass = txtPassword.Text;

            bool creacionExitosa = Usuario.CrearUsuario(nombre, email, Usuario.RolUsuario.Admin, pass);

            if(creacionExitosa)
            {
                MessageBox.Show("Creación de primer administrador exitosa.");
                this.DialogResult = DialogResult.OK;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
