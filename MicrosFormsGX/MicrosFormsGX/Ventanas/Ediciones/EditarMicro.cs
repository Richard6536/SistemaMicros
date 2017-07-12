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
    public partial class EditarMicro : MetroFramework.Forms.MetroForm
    {
        Micro microAEditar;

        public EditarMicro(String _patenteMicro)
        {
            InitializeComponent();
            microAEditar = Micro.BuscarPorPatente(_patenteMicro);
            txtPatente.Text = microAEditar.Patente;

            CargarComboboxes();
        }

        void CargarComboboxes()
        {
            List<Linea> lineas = new List<Linea>();
            List<Usuario> choferes = new List<Usuario>();

            lineas.Add(new Linea() { Nombre = "SIN ASIGNAR" });
            choferes.Add(new Usuario() { Nombre = "SIN ASIGNAR" });

            Usuario choferActual = new Usuario(); ;
            if (microAEditar.MicroChoferId != null)
            {
                choferActual = MicroChofer.GetChofer(microAEditar.MicroChoferId.Value);
                choferes.Add(choferActual);
            }
            Linea lineaActual = new Linea();
            if (microAEditar.LineaId != null)
            {
                lineaActual = Linea.BuscarLinea(microAEditar.LineaId.Value);
            }

            List<Linea> todasLineas = Linea.ObtenerTodasLasLineas().OrderBy(l => l.Nombre).ToList();

            for (int i = 0; i < todasLineas.Count; i++)
            {
                lineas.Add(todasLineas[i]);
            }
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
            cmbChofer.SelectedIndex = 0;

            if (microAEditar.MicroChoferId != null)
            {
                cmbChofer.SelectedValue = choferActual.Id;
            }

            cmbLinea.DataSource = lineas;
            cmbLinea.ValueMember = "Id";
            cmbLinea.DisplayMember = "Nombre";
            cmbLinea.SelectedIndex = 0;

            if (microAEditar.LineaId != null)
            {
                cmbLinea.SelectedValue = lineaActual.Id;
            }

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

            if (cmbLinea.Text == "SIN ASIGNAR")
                linea = null;
            if (cmbChofer.Text == "SIN ASIGNAR")
                chofer = null;

            string mensajeError = "";

            if (patente == "")
            {
                mensajeError += "\n-No deje el campo patente vacío.";
            }
            if (Micro.yaExisteMicro(patente) && patente != microAEditar.Patente)
            {
                mensajeError += "\n-La patente que intenta ingresar ya existe en la base de datos";
            }
            if (chofer == null && cmbChofer.Text != "" && cmbChofer.Text != "SIN ASIGNAR")
            {
                mensajeError += "\n-El chofer que intenta registrar no existe.";
            }
            if (linea == null && cmbLinea.Text != "" && cmbLinea.Text != "SIN ASIGNAR")
            {
                mensajeError += "\n-La línea que intenta registrar no existe";
            }

            if (mensajeError != "")
            {
                MetroMessageBox.Show(this,"Se encontraron los siguientes errores:" + mensajeError);
                return;
            }

            bool r1 = Micro.EditarPatente(microAEditar.Id, patente);

            bool r2 = Micro.AsignarChofer(microAEditar.Id, chofer);

            bool r3 = Micro.AsignarLinea(microAEditar.Id, linea);

            if (r1 && r2 && r3)
            {
                MetroMessageBox.Show(this,"Edición completada exitósamente.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void EditarMicro_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }
    }
}
