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
                MessageBox.Show("Error conectando");
            }


            if (Usuario.VerificarExistenciaUsusuarios() == false)
            {
                //abrir ventana de creacion de admin
                
            }
            else
            {
                if (Usuario.EsPasswordValida(nombre, pass))
                {
                    //enviar a ventana de control
                }          
            }

        }
    }
}
