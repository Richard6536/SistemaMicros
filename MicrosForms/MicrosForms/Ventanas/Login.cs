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
using MicrosForms.Ventanas.Creaciones;
using MicrosForms.Classes;

namespace MicrosForms.Ventanas
{
    public partial class Login : Form
    {


        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string pass = txtPassword.Text;

            if(!ConnectionTester.IsConnectionActive())
            {
                return;
            }

            if(txtNombre.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("No deje campos en blanco");
                return;
            }

            if (Usuario.VerificarExistenciaUsusuarios() == false)
            {
                FormManager.CambiarForm(this, new CrearPrimerUsuario());

            }
            else
            {
                if (Usuario.EsPasswordValida(nombre, pass))
                {
                    FormManager.CambiarForm(this, new InicioReal());
                }
                else
                {
                    MessageBox.Show("Usuario/contraseña no válidos");
                }
            }

        }
    }
}
