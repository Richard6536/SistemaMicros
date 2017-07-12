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

namespace MicrosFormsGX.Ventanas.Ediciones
{
    public partial class AsignarMicro : MetroFramework.Forms.MetroForm
    {
        Usuario userEditar;

        public AsignarMicro(int _idUsuario)
        {
            InitializeComponent();

            userEditar = Usuario.BuscarUsuario(_idUsuario);
            CargarCombobox();

            cmbMicros.SelectedIndex = -1;

            if (userEditar.MicroChoferId != null)
            {
                Micro asignada = MicroChofer.GetMicro(userEditar.MicroChoferId.Value);
                cmbMicros.SelectedValue = asignada.Id;
            }
        }

        void CargarCombobox()
        {
            List<Micro> microsLibres = new List<Micro>();
            List<Micro> todas = Micro.BuscarTodasLasMicros();

            if (userEditar.MicroChoferId != null)
            {
                Micro asignada = MicroChofer.GetMicro(userEditar.MicroChoferId.Value);
                microsLibres.Add(asignada);
            }

            for (int i = 0; i < todas.Count; i++)
            {
                if (todas[i].MicroChoferId == null)
                {
                    microsLibres.Add(todas[i]);
                }
            }

            cmbMicros.DataSource = microsLibres;
            cmbMicros.ValueMember = "Id";
            cmbMicros.DisplayMember = "Patente";

            if(microsLibres.Count == 0)
            {
                cmbMicros.Text = "-Sin asignar-";
            }

        }

        private void cmbMicros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMicros.SelectedValue + "" == "" && cmbMicros.Text == "")
            {
                cmbMicros.Text = "-Sin asignar-";
            }
        }

        private void cmbMicros_TextChanged(object sender, EventArgs e)
        {
            if (cmbMicros.Text == "")
            {
                cmbMicros.Text = "-Sin asignar-";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Micro nueva = Micro.BuscarPorPatente(cmbMicros.Text);

            string mensajeError = "";

            if (cmbMicros.SelectedValue + "" == "" && cmbMicros.Text != "-Sin asignar-")
            {
                mensajeError += "\n-La patente ingresada no es válida.";
            }

            if (mensajeError != "")
            {
                MetroMessageBox.Show(this,"Se encontraron los siguientes errores:" + mensajeError);
                return;
            }

            bool res = Usuario.AsignarMicro(userEditar.Id, nueva);

            if (res)
            {
                MetroMessageBox.Show(this,"Datos guardados exitósamente.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void AsignarMicro_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }
    }
}
