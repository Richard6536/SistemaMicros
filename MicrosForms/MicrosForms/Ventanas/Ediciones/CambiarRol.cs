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
using MicrosForms.Ventanas.Creaciones;

namespace MicrosForms.Ventanas.Ediciones
{
    public partial class CambiarRol : Form
    {
        Usuario userEditar;

        public CambiarRol(int _idUsuario)
        {
            InitializeComponent();

            userEditar = Usuario.BuscarUsuario(_idUsuario);
            cmbRoles.DataSource = Enum.GetValues(typeof(Usuario.RolUsuario));
            int enumValue = (int)userEditar.Rol;
            cmbRoles.SelectedIndex = enumValue;

            btnAceptar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario.RolUsuario rolSeleccionado = (Usuario.RolUsuario)Enum.Parse(typeof(Usuario.RolUsuario), cmbRoles.SelectedValue + "");

            string mensajeError = "";

            if(userEditar.Rol == Usuario.RolUsuario.Chofer && userEditar.MicroChoferId != null)
            {
                mensajeError += "\n-No puede quitarle el rol de chofer si es que se encuentra ya asignado a una micro.";
            }
            if(userEditar.Rol == Usuario.RolUsuario.Admin && Usuario.BuscarTodosLosUsuariosPorRol(Usuario.RolUsuario.Admin).Count == 1)
            {
                mensajeError += "\n-No puede quitarle el rol de administrador si es que es el único administrador restante en el sistema.";
            }

            if(mensajeError != "")
            {
                MessageBox.Show("Se encontraron los siguientes errores:" + mensajeError);
                return;
            }

            bool res = Usuario.EditarUsuario(userEditar.Id, userEditar.Nombre, userEditar.Email, rolSeleccionado, userEditar.Password);

            if(res)
            {
                MessageBox.Show("Rol editado correctamente.");
                this.DialogResult = DialogResult.OK;
            }
                
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario.RolUsuario rolSeleccionado = (Usuario.RolUsuario)Enum.Parse(typeof(Usuario.RolUsuario), cmbRoles.SelectedValue + "");

            if(rolSeleccionado == userEditar.Rol)
            {
                btnAceptar.Enabled = false;
            }
            else
            {
                btnAceptar.Enabled = true;
            }
        }
    }
}
