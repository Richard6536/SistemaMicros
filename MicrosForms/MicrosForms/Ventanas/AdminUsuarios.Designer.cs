namespace MicrosForms.Ventanas
{
    partial class AdminUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridUsuarios = new System.Windows.Forms.DataGridView();
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.líneasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.VerMicro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AsignarMicro = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuarios)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridUsuarios
            // 
            this.dataGridUsuarios.AllowUserToAddRows = false;
            this.dataGridUsuarios.AllowUserToDeleteRows = false;
            this.dataGridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Email,
            this.Rol,
            this.VerMicro,
            this.AsignarMicro});
            this.dataGridUsuarios.Location = new System.Drawing.Point(12, 71);
            this.dataGridUsuarios.Name = "dataGridUsuarios";
            this.dataGridUsuarios.Size = new System.Drawing.Size(580, 290);
            this.dataGridUsuarios.TabIndex = 0;
            this.dataGridUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridUsuarios_CellContentClick);
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.Location = new System.Drawing.Point(630, 71);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(163, 40);
            this.btnCrearUsuario.TabIndex = 2;
            this.btnCrearUsuario.Text = "Crear nuevo usuario";
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.ventanaInicio});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(873, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.líneasToolStripMenuItem,
            this.microsToolStripMenuItem});
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.administrarToolStripMenuItem.Text = "Administrar";
            // 
            // líneasToolStripMenuItem
            // 
            this.líneasToolStripMenuItem.Name = "líneasToolStripMenuItem";
            this.líneasToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.líneasToolStripMenuItem.Text = "Líneas";
            this.líneasToolStripMenuItem.Click += new System.EventHandler(this.líneasToolStripMenuItem_Click);
            // 
            // microsToolStripMenuItem
            // 
            this.microsToolStripMenuItem.Name = "microsToolStripMenuItem";
            this.microsToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.microsToolStripMenuItem.Text = "Micros";
            this.microsToolStripMenuItem.Click += new System.EventHandler(this.microsToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // ventanaInicio
            // 
            this.ventanaInicio.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ventanaInicio.Name = "ventanaInicio";
            this.ventanaInicio.Size = new System.Drawing.Size(109, 20);
            this.ventanaInicio.Text = "Ventana de inicio";
            this.ventanaInicio.Click += new System.EventHandler(this.ventanaInicio_Click);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "E-Mail";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Rol
            // 
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // VerMicro
            // 
            this.VerMicro.HeaderText = "Micro asignada";
            this.VerMicro.Name = "VerMicro";
            this.VerMicro.ReadOnly = true;
            this.VerMicro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VerMicro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VerMicro.ToolTipText = "Patente de la micro asignada a este usuario si esque hay.";
            // 
            // AsignarMicro
            // 
            this.AsignarMicro.HeaderText = "Asignar diferente micro";
            this.AsignarMicro.Name = "AsignarMicro";
            this.AsignarMicro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AsignarMicro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AsignarMicro.Text = "Asignar micro";
            this.AsignarMicro.ToolTipText = "Asigna una micro a tal usuario, lo que tambien actualizaría su rol a \"chofer\".";
            this.AsignarMicro.Width = 105;
            // 
            // AdminUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 373);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.dataGridUsuarios);
            this.Name = "AdminUsuarios";
            this.Text = "AdminUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuarios)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridUsuarios;
        private System.Windows.Forms.Button btnCrearUsuario;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem líneasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventanaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewButtonColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn VerMicro;
        private System.Windows.Forms.DataGridViewButtonColumn AsignarMicro;
    }
}