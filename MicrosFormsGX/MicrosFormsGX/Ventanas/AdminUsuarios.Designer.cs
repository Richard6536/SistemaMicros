namespace MicrosFormsGX.Ventanas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUsuarios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrarMicrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarLineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaInicioToolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridUsuarios = new MetroFramework.Controls.MetroGrid();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Micro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AsignarMicro = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtFiltroNombre = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnActualizar = new MetroFramework.Controls.MetroTile();
            this.btnCrearUsuario = new MetroFramework.Controls.MetroTile();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarMicrosToolStripMenuItem,
            this.administrarLineasToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.ventanaInicioToolstrip});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(909, 55);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrarMicrosToolStripMenuItem
            // 
            this.administrarMicrosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("administrarMicrosToolStripMenuItem.Image")));
            this.administrarMicrosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.administrarMicrosToolStripMenuItem.Name = "administrarMicrosToolStripMenuItem";
            this.administrarMicrosToolStripMenuItem.Size = new System.Drawing.Size(120, 51);
            this.administrarMicrosToolStripMenuItem.Text = "Administrar micros";
            this.administrarMicrosToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.administrarMicrosToolStripMenuItem.Click += new System.EventHandler(this.administrarMicrosToolStripMenuItem_Click);
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
            // dataGridUsuarios
            // 
            this.dataGridUsuarios.AllowUserToAddRows = false;
            this.dataGridUsuarios.AllowUserToDeleteRows = false;
            this.dataGridUsuarios.AllowUserToResizeRows = false;
            this.dataGridUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Email,
            this.Rol,
            this.Micro,
            this.AsignarMicro});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridUsuarios.EnableHeadersVisualStyles = false;
            this.dataGridUsuarios.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridUsuarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridUsuarios.Location = new System.Drawing.Point(23, 186);
            this.dataGridUsuarios.Name = "dataGridUsuarios";
            this.dataGridUsuarios.ReadOnly = true;
            this.dataGridUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridUsuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridUsuarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUsuarios.Size = new System.Drawing.Size(906, 360);
            this.dataGridUsuarios.Style = MetroFramework.MetroColorStyle.Green;
            this.dataGridUsuarios.TabIndex = 7;
            this.dataGridUsuarios.UseCustomBackColor = true;
            this.dataGridUsuarios.UseCustomForeColor = true;
            this.dataGridUsuarios.UseStyleColors = true;
            this.dataGridUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridUsuarios_CellContentClick);
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.HeaderText = "E-mail";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Rol
            // 
            this.Rol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.ReadOnly = true;
            // 
            // Micro
            // 
            this.Micro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Micro.HeaderText = "MicroAsignada";
            this.Micro.Name = "Micro";
            this.Micro.ReadOnly = true;
            // 
            // AsignarMicro
            // 
            this.AsignarMicro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AsignarMicro.HeaderText = "Asignar diferente micro";
            this.AsignarMicro.Name = "AsignarMicro";
            this.AsignarMicro.ReadOnly = true;
            // 
            // txtFiltroNombre
            // 
            // 
            // 
            // 
            this.txtFiltroNombre.CustomButton.Image = null;
            this.txtFiltroNombre.CustomButton.Location = new System.Drawing.Point(201, 1);
            this.txtFiltroNombre.CustomButton.Name = "";
            this.txtFiltroNombre.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFiltroNombre.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFiltroNombre.CustomButton.TabIndex = 1;
            this.txtFiltroNombre.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFiltroNombre.CustomButton.UseSelectable = true;
            this.txtFiltroNombre.CustomButton.Visible = false;
            this.txtFiltroNombre.Lines = new string[0];
            this.txtFiltroNombre.Location = new System.Drawing.Point(23, 157);
            this.txtFiltroNombre.MaxLength = 32767;
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.PasswordChar = '\0';
            this.txtFiltroNombre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFiltroNombre.SelectedText = "";
            this.txtFiltroNombre.SelectionLength = 0;
            this.txtFiltroNombre.SelectionStart = 0;
            this.txtFiltroNombre.ShortcutsEnabled = true;
            this.txtFiltroNombre.Size = new System.Drawing.Size(223, 23);
            this.txtFiltroNombre.TabIndex = 8;
            this.txtFiltroNombre.UseSelectable = true;
            this.txtFiltroNombre.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFiltroNombre.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtFiltroNombre.TextChanged += new System.EventHandler(this.txtFiltroNombre_TextChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 135);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(119, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Filtrar por nombre";
            // 
            // btnActualizar
            // 
            this.btnActualizar.ActiveControl = null;
            this.btnActualizar.Location = new System.Drawing.Point(252, 118);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(147, 62);
            this.btnActualizar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "Recargar lista";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar.TileImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar.TileImage")));
            this.btnActualizar.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizar.UseSelectable = true;
            this.btnActualizar.UseStyleColors = true;
            this.btnActualizar.UseTileImage = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.ActiveControl = null;
            this.btnCrearUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearUsuario.Location = new System.Drawing.Point(782, 118);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(147, 62);
            this.btnCrearUsuario.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCrearUsuario.TabIndex = 11;
            this.btnCrearUsuario.Text = "Crear nuevo usuario";
            this.btnCrearUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrearUsuario.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCrearUsuario.TileImage")));
            this.btnCrearUsuario.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrearUsuario.UseSelectable = true;
            this.btnCrearUsuario.UseStyleColors = true;
            this.btnCrearUsuario.UseTileImage = true;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // AdminUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 569);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtFiltroNombre);
            this.Controls.Add(this.dataGridUsuarios);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(657, 169);
            this.Name = "AdminUsuarios";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Administración de usuarios";
            this.Activated += new System.EventHandler(this.AdminUsuarios_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminUsuarios_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminUsuarios_FormClosed);
            this.Load += new System.EventHandler(this.AdminUsuarios_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarMicrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarLineasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventanaInicioToolstrip;
        private MetroFramework.Controls.MetroGrid dataGridUsuarios;
        private MetroFramework.Controls.MetroTextBox txtFiltroNombre;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile btnActualizar;
        private MetroFramework.Controls.MetroTile btnCrearUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewButtonColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Micro;
        private System.Windows.Forms.DataGridViewButtonColumn AsignarMicro;
    }
}