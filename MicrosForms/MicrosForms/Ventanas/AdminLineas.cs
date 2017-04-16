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

namespace MicrosForms.Ventanas
{
    public partial class AdminLineas : Form
    {
        public AdminLineas()
        {
            InitializeComponent();
        }



        #region toolstrips

        private void rutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminRutas());
        }

        private void microsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminMicros());
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminUsuarios());
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new Login());
        }

        private void VentanaInicioMenuItem1_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new InicioReal());
        }
        #endregion
    }
}
