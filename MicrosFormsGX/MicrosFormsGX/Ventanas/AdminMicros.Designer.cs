namespace MicrosFormsGX.Ventanas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMicros));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarLineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaInicioToolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.datagridMicros = new MetroFramework.Controls.MetroGrid();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreChofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Historial = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCrearMicro = new MetroFramework.Controls.MetroTile();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridMicros)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarUsuariosToolStripMenuItem,
            this.administrarLineasToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.ventanaInicioToolstrip});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(946, 55);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrarUsuariosToolStripMenuItem
            // 
            this.administrarUsuariosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("administrarUsuariosToolStripMenuItem.Image")));
            this.administrarUsuariosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.administrarUsuariosToolStripMenuItem.Name = "administrarUsuariosToolStripMenuItem";
            this.administrarUsuariosToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.administrarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(129, 51);
            this.administrarUsuariosToolStripMenuItem.Text = "Administrar Usuarios";
            this.administrarUsuariosToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.administrarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administrarUsuariosToolStripMenuItem_Click);
            // 
            // administrarLineasToolStripMenuItem
            // 
            this.administrarLineasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("administrarLineasToolStripMenuItem.Image")));
            this.administrarLineasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.administrarLineasToolStripMenuItem.Name = "administrarLineasToolStripMenuItem";
            this.administrarLineasToolStripMenuItem.Size = new System.Drawing.Size(114, 51);
            this.administrarLineasToolStripMenuItem.Text = "Administrar lineas";
            this.administrarLineasToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.administrarLineasToolStripMenuItem.Click += new System.EventHandler(this.administrarLineasToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cerrarSesiónToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarSesiónToolStripMenuItem.Image")));
            this.cerrarSesiónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(87, 51);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // ventanaInicioToolstrip
            // 
            this.ventanaInicioToolstrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ventanaInicioToolstrip.Image = ((System.Drawing.Image)(resources.GetObject("ventanaInicioToolstrip.Image")));
            this.ventanaInicioToolstrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ventanaInicioToolstrip.Name = "ventanaInicioToolstrip";
            this.ventanaInicioToolstrip.Size = new System.Drawing.Size(93, 51);
            this.ventanaInicioToolstrip.Text = "Ventana inicio";
            this.ventanaInicioToolstrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ventanaInicioToolstrip.Click += new System.EventHandler(this.ventanaInicioToolstrip_Click);
            // 
            // datagridMicros
            // 
            this.datagridMicros.AllowUserToAddRows = false;
            this.datagridMicros.AllowUserToDeleteRows = false;
            this.datagridMicros.AllowUserToResizeRows = false;
            this.datagridMicros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridMicros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.datagridMicros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridMicros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datagridMicros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridMicros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridMicros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridMicros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Patente,
            this.NombreLinea,
            this.Calificacion,
            this.NombreChofer,
            this.Historial,
            this.Editar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridMicros.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagridMicros.EnableHeadersVisualStyles = false;
            this.datagridMicros.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.datagridMicros.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.datagridMicros.Location = new System.Drawing.Point(20, 186);
            this.datagridMicros.Name = "datagridMicros";
            this.datagridMicros.ReadOnly = true;
            this.datagridMicros.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridMicros.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datagridMicros.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagridMicros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridMicros.Size = new System.Drawing.Size(946, 497);
            this.datagridMicros.Style = MetroFramework.MetroColorStyle.Green;
            this.datagridMicros.TabIndex = 8;
            this.datagridMicros.UseCustomBackColor = true;
            this.datagridMicros.UseStyleColors = true;
            this.datagridMicros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMicros_CellContentClick);
            // 
            // Patente
            // 
            this.Patente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Patente.HeaderText = "Patente";
            this.Patente.Name = "Patente";
            this.Patente.ReadOnly = true;
            // 
            // NombreLinea
            // 
            this.NombreLinea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreLinea.HeaderText = "Linea";
            this.NombreLinea.Name = "NombreLinea";
            this.NombreLinea.ReadOnly = true;
            // 
            // Calificacion
            // 
            this.Calificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Calificacion.HeaderText = "Calificación";
            this.Calificacion.Name = "Calificacion";
            this.Calificacion.ReadOnly = true;
            // 
            // NombreChofer
            // 
            this.NombreChofer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreChofer.HeaderText = "Nombre de chofer";
            this.NombreChofer.Name = "NombreChofer";
            this.NombreChofer.ReadOnly = true;
            // 
            // Historial
            // 
            this.Historial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Historial.HeaderText = "Historial";
            this.Historial.Name = "Historial";
            this.Historial.ReadOnly = true;
            // 
            // Editar
            // 
            this.Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // btnCrearMicro
            // 
            this.btnCrearMicro.ActiveControl = null;
            this.btnCrearMicro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearMicro.Location = new System.Drawing.Point(816, 118);
            this.btnCrearMicro.Name = "btnCrearMicro";
            this.btnCrearMicro.Size = new System.Drawing.Size(147, 62);
            this.btnCrearMicro.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCrearMicro.TabIndex = 12;
            this.btnCrearMicro.Text = "Crear nueva Micro";
            this.btnCrearMicro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrearMicro.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCrearMicro.TileImage")));
            this.btnCrearMicro.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrearMicro.UseSelectable = true;
            this.btnCrearMicro.UseStyleColors = true;
            this.btnCrearMicro.UseTileImage = true;
            this.btnCrearMicro.Click += new System.EventHandler(this.btnCrearMicro_Click);
            // 
            // AdminMicros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 706);
            this.Controls.Add(this.btnCrearMicro);
            this.Controls.Add(this.datagridMicros);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(657, 169);
            this.Name = "AdminMicros";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Administración de micros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.AdminMicros_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminMicros_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminMicros_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridMicros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarLineasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventanaInicioToolstrip;
        private MetroFramework.Controls.MetroGrid datagridMicros;
        private MetroFramework.Controls.MetroTile btnCrearMicro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreChofer;
        private System.Windows.Forms.DataGridViewButtonColumn Historial;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
    }
}