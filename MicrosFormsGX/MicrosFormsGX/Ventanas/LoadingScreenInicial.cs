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
using MicrosFormsGX.Ventanas.Creaciones;
using MicrosFormsGX.Classes;
using MicrosFormsGX.Model.DatosTemporales;
using MetroFramework;

namespace MicrosFormsGX.Ventanas
{
    public partial class LoadingScreenInicial : MetroFramework.Forms.MetroForm
    {
        Login login = null;
        public LoadingScreenInicial(Login log)
        {
            login = log;
            InitializeComponent();     
        }

        void CheckearPorcentaje()
        {
            if(login != null)
            {
                progresBar.Value = login.porcentajeTotal;
            }   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckearPorcentaje();
        }
    }
}
