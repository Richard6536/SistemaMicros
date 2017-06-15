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
            string mail = txtEmail.Text;
            string pass = txtPassword.Text;

            if(!ConnectionTester.IsConnectionActive())
            {
                return;
            }

            if(txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("No deje campos en blanco");
                return;
            }

            if (Usuario.VerificarExistenciaUsusuarios() == false)
            {
                MessageBox.Show("No hay usuarios creados en la base de datos. Se procederá a crear el primer adminsitrador.");

                txtEmail.Text = "";
                txtPassword.Text = "";

                this.Enabled = false;
                var form = new CrearPrimerUsuario();

                form.ShowDialog();

                this.Enabled = true;

            }
            else
            {
                if (Usuario.EsPasswordValida(mail, pass))
                {
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    FormManager.CambiarForm(this, new InicioReal());
                }
                else
                {
                    MessageBox.Show("Usuario/contraseña no válidos");
                }
            }

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.cerrandoAplicacion = true;
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
