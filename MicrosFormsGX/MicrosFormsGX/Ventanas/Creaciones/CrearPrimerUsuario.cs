using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MicrosFormsGX.Model;
using MicrosFormsGX.Ventanas;
using MicrosFormsGX.Classes;
using MetroFramework;
namespace MicrosFormsGX.Ventanas.Creaciones
{
    public partial class CrearPrimerUsuario : MetroFramework.Forms.MetroForm
    {
        public CrearPrimerUsuario()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MetroMessageBox.Show(this,"Las contraseñas no coinciden");
                return;
            }

            if (!ConnectionTester.IsConnectionActive())
            {
                return;
            }

            string patente = txtPatente.Text;
            string email = txtEmail.Text;
            string pass = txtPassword.Text;

            bool creacionExitosa = Usuario.CrearUsuario(patente, email, Usuario.RolUsuario.Admin, pass);

            if (creacionExitosa)
            {
                MetroMessageBox.Show(this,"Creación de primer administrador exitosa.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void CrearPrimerUsuario_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }
    }
}
