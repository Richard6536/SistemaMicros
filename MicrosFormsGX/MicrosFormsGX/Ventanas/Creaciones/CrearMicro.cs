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
    public partial class CrearMicro : MetroFramework.Forms.MetroForm
    {
        public CrearMicro()
        {
            InitializeComponent();
            CargarComboboxes();
        }

        void CargarComboboxes()
        {
            List<Linea> lineas = Linea.ObtenerTodasLasLineas().OrderBy(l => l.Nombre).ToList();
            List<Usuario> choferes = new List<Usuario>();

            foreach (Usuario u in Usuario.BuscarTodosUsuarios())
            {
                if (u.Rol == Usuario.RolUsuario.Chofer && u.MicroChoferId == null)
                {
                    choferes.Add(u);
                }
            }

            cmbChofer.DataSource = choferes;
            cmbChofer.ValueMember = "Id";
            cmbChofer.DisplayMember = "Nombre";
            cmbChofer.SelectedIndex = -1;

            cmbLinea.DataSource = lineas;
            cmbLinea.ValueMember = "Id";
            cmbLinea.DisplayMember = "Nombre";
            cmbLinea.SelectedIndex = -1;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string patente = txtPatente.Text;
            Usuario chofer = Usuario.BuscarUsuario(Convert.ToInt32(cmbChofer.SelectedValue));
            Linea linea = Linea.BuscarLinea(Convert.ToInt32(cmbLinea.SelectedValue));

            string mensajeError = "";

            if (patente == "")
            {
                mensajeError += "\n-No deje el campo patente vacío.";
            }
            if (Micro.yaExisteMicro(patente))
            {
                mensajeError += "\n-La patente que intenta ingresar ya existe en la base de datos";
            }
            if (chofer == null && cmbChofer.Text != "")
            {
                mensajeError += "\n-El chofer que intenta registrar no existe.";
            }
            if (linea == null && cmbLinea.Text != "")
            {
                mensajeError += "\n-La línea que intenta registrar no existe";
            }

            if (mensajeError != "")
            {
                MetroMessageBox.Show(this,"Se encontraron los siguientes errores:" + mensajeError);
                return;
            }

            bool resultado = Micro.CrearMicro(patente, linea, chofer);

            if (resultado)
            {
                MetroMessageBox.Show(this,"Micro creada exitósamente.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void CrearMicro_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }
    }
}
