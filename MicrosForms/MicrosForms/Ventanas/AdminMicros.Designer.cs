namespace MicrosForms.Ventanas
{
    partial class AdminMicros
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
            this.datagridMicros = new System.Windows.Forms.DataGridView();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineaMicro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerHistorial = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCrearMicro = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.líneasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaInicio = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.datagridMicros)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagridMicros
            // 
            this.datagridMicros.AllowUserToAddRows = false;
            this.datagridMicros.AllowUserToDeleteRows = false;
            this.datagridMicros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridMicros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Patente,
            this.LineaMicro,
            this.Clasificacion,
            this.Chofer,
            this.VerHistorial,
            this.Editar});
            this.datagridMicros.Location = new System.Drawing.Point(12, 59);
            this.datagridMicros.Name = "datagridMicros";
            this.datagridMicros.Size = new System.Drawing.Size(607, 301);
            this.datagridMicros.TabIndex = 0;
            this.datagridMicros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridMicros_CellContentClick);
            // 
            // Patente
            // 
            this.Patente.HeaderText = "Patente";
            this.Patente.Name = "Patente";
            this.Patente.ReadOnly = true;
            this.Patente.Width = 70;
            // 
            // LineaMicro
            // 
            this.LineaMicro.HeaderText = "Linea";
            this.LineaMicro.Name = "LineaMicro";
            this.LineaMicro.ReadOnly = true;
            // 
            // Clasificacion
            // 
            this.Clasificacion.HeaderText = "Clasificación";
            this.Clasificacion.Name = "Clasificacion";
            this.Clasificacion.ReadOnly = true;
            this.Clasificacion.Width = 70;
            // 
            // Chofer
            // 
            this.Chofer.HeaderText = "Nombre de chofer";
            this.Chofer.Name = "Chofer";
            this.Chofer.ReadOnly = true;
            this.Chofer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chofer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // VerHistorial
            // 
            this.VerHistorial.HeaderText = "Historial";
            this.VerHistorial.Name = "VerHistorial";
            this.VerHistorial.Text = "Ver historial";
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.Text = "Editar datos";
            // 
            // btnCrearMicro
            // 
            this.btnCrearMicro.Location = new System.Drawing.Point(662, 59);
            this.btnCrearMicro.Name = "btnCrearMicro";
            this.btnCrearMicro.Size = new System.Drawing.Size(150, 54);
            this.btnCrearMicro.TabIndex = 1;
            this.btnCrearMicro.Text = "Crear nueva micro";
            this.btnCrearMicro.UseVisualStyleBackColor = true;
            this.btnCrearMicro.Click += new System.EventHandler(this.btnCrearMicro_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.ventanaInicio});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.líneasToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.administrarToolStripMenuItem.Text = "Administrar";
            // 
            // líneasToolStripMenuItem
            // 
            this.líneasToolStripMenuItem.Name = "líneasToolStripMenuItem";
            this.líneasToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.líneasToolStripMenuItem.Text = "Líneas";
            this.líneasToolStripMenuItem.Click += new System.EventHandler(this.líneasToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
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
            // AdminMicros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 392);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnCrearMicro);
            this.Controls.Add(this.datagridMicros);
            this.Name = "AdminMicros";
            this.Text = "AdminMicros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminMicros_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminMicros_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.datagridMicros)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridMicros;
        private System.Windows.Forms.Button btnCrearMicro;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem líneasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventanaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineaMicro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chofer;
        private System.Windows.Forms.DataGridViewButtonColumn VerHistorial;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
    }
}