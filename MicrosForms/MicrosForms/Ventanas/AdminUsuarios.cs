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
using MicrosForms.Ventanas.Ediciones;


namespace MicrosForms.Ventanas
{
    public partial class AdminUsuarios : Form
    {
        List<Usuario> usuarios;

        public AdminUsuarios()
        {
            InitializeComponent();

            usuarios = Usuario.BuscarTodosUsuarios();
            CargarTabla(usuarios);

        }

        #region toolstrips

        private void líneasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminLineas());
        }

        private void microsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminMicros());
        }

        private void ventanaInicio_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new InicioReal());
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new Login());
        }
        #endregion

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            var forms = new CrearUsuario();
            forms.ShowDialog();

            this.Enabled = true;

            if (forms.DialogResult == DialogResult.OK)
            {
                usuarios = Usuario.BuscarTodosUsuarios();
                CargarTabla(usuarios);
            }
        }

        private void CargarTabla(List<Usuario> _usuarios)
        {
            _usuarios.OrderBy(u => u.Nombre);
            dataGridUsuarios.Rows.Clear();

            foreach (var cmb in dataGridUsuarios.Columns)
            {
                if(cmb is DataGridViewComboBoxColumn)
                {
                    var cmbColumn = cmb as DataGridViewComboBoxColumn;
                    cmbColumn.ValueType = typeof(Usuario.RolUsuario);
                    cmbColumn.DataSource = Enum.GetValues(typeof(Usuario.RolUsuario));
                }          
            }

            foreach (Usuario u in _usuarios)
            {
                CargarLinea(u);
            }

        }

        private void CargarLinea(Usuario u)
        {
            Micro microAsignada = null;
            string patenteMicro = "--NO ASIGNADO--";

            if(u.MicroChoferId != null)
            {
                microAsignada = MicroChofer.GetMicro(u.MicroChoferId.Value);
                patenteMicro = microAsignada.Patente;
            }

            dataGridUsuarios.Rows.Add(u.Nombre, u.Email , u.Rol , patenteMicro, "Asignar micro");

        }

        private void dataGridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int indexClickeado = e.RowIndex;

                string nombreUsuario = dataGridUsuarios.Rows[indexClickeado].Cells[0].Value + "";
                Usuario user = Usuario.BuscarUsuarioPorNombre(nombreUsuario);

                DialogResult result = DialogResult.Cancel;
                if (e.ColumnIndex == 4) //Asignar micro
                {
                    var forms = new AsignarMicro(user.Id);
                    result = FormManager.MostrarShowDialog(this, forms);
                }
                if (e.ColumnIndex == 2) //Editar Rol
                {
                    var forms = new CambiarRol(user.Id);
                    result = FormManager.MostrarShowDialog(this, forms);
                }
                if(result == DialogResult.OK)
                {
                    usuarios = Usuario.BuscarTodosUsuarios();
                    CargarTabla(usuarios);
                    SeleccionarIndexPorNombre(nombreUsuario);
                }
            }
        }

        private void SeleccionarIndexPorNombre(string _nombre)
        {
            int index = -1;

            foreach (DataGridViewRow row in dataGridUsuarios.Rows)
            {
                if (row.Cells[0].Value + "" == _nombre)
                {
                    index = row.Index;
                }
            }

            dataGridUsuarios.Rows[0].Selected = false;
            dataGridUsuarios.Rows[index].Selected = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            usuarios = Usuario.BuscarTodosUsuarios();
            CargarTabla(usuarios);
        }

        private void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtFiltroNombre.Text == "")
                {
                    CargarTabla(usuarios);
                    return;
                }

                dataGridUsuarios.Rows.Clear();

                foreach (Usuario u in usuarios)
                {
                    if (u.Nombre.ToUpper().Contains(txtFiltroNombre.Text.ToUpper()))
                    {
                        CargarLinea(u);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
