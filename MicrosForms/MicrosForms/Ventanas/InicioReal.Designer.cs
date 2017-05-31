namespace MicrosForms.Ventanas
{
    partial class InicioReal
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
            this.components = new System.ComponentModel.Container();
            this.gmapController = new GMap.NET.WindowsForms.GMapControl();
            this.cmbLinea = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.líneasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.datagridMicros = new System.Windows.Forms.DataGridView();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreChofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridMicros)).BeginInit();
            this.SuspendLayout();
            // 
            // gmapController
            // 
            this.gmapController.Bearing = 0F;
            this.gmapController.CanDragMap = true;
            this.gmapController.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmapController.GrayScaleMode = false;
            this.gmapController.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmapController.LevelsKeepInMemmory = 5;
            this.gmapController.Location = new System.Drawing.Point(12, 51);
            this.gmapController.MarkersEnabled = true;
            this.gmapController.MaxZoom = 2;
            this.gmapController.MinZoom = 2;
            this.gmapController.MouseWheelZoomEnabled = true;
            this.gmapController.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmapController.Name = "gmapController";
            this.gmapController.NegativeMode = false;
            this.gmapController.PolygonsEnabled = true;
            this.gmapController.RetryLoadTile = 0;
            this.gmapController.RoutesEnabled = true;
            this.gmapController.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmapController.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmapController.ShowTileGridLines = false;
            this.gmapController.Size = new System.Drawing.Size(595, 365);
            this.gmapController.TabIndex = 0;
            this.gmapController.Zoom = 0D;
            // 
            // cmbLinea
            // 
            this.cmbLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLinea.FormattingEnabled = true;
            this.cmbLinea.Location = new System.Drawing.Point(643, 73);
            this.cmbLinea.Name = "cmbLinea";
            this.cmbLinea.Size = new System.Drawing.Size(258, 21);
            this.cmbLinea.TabIndex = 3;
            this.cmbLinea.SelectedIndexChanged += new System.EventHandler(this.cmbLinea_SelectedIndexChanged_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.líneasToolStripMenuItem,
            this.microsToolStripMenuItem,
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
            // microsToolStripMenuItem
            // 
            this.microsToolStripMenuItem.Name = "microsToolStripMenuItem";
            this.microsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.microsToolStripMenuItem.Text = "Micros";
            this.microsToolStripMenuItem.Click += new System.EventHandler(this.microsToolStripMenuItem_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(643, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Líneas";
            // 
            // datagridMicros
            // 
            this.datagridMicros.AllowUserToAddRows = false;
            this.datagridMicros.AllowUserToDeleteRows = false;
            this.datagridMicros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridMicros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Patente,
            this.NombreChofer});
            this.datagridMicros.Location = new System.Drawing.Point(643, 125);
            this.datagridMicros.Name = "datagridMicros";
            this.datagridMicros.ReadOnly = true;
            this.datagridMicros.Size = new System.Drawing.Size(258, 255);
            this.datagridMicros.TabIndex = 9;
            // 
            // Patente
            // 
            this.Patente.HeaderText = "Patente";
            this.Patente.Name = "Patente";
            this.Patente.ReadOnly = true;
            // 
            // NombreChofer
            // 
            this.NombreChofer.HeaderText = "Chofer";
            this.NombreChofer.Name = "NombreChofer";
            this.NombreChofer.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Micros activas";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // InicioReal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 428);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datagridMicros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLinea);
            this.Controls.Add(this.gmapController);
            this.Controls.Add(this.menuStrip1);
            this.Name = "InicioReal";
            this.Text = "InicioReal";
            this.Activated += new System.EventHandler(this.InicioReal_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InicioReal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InicioReal_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridMicros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmapController;
        private System.Windows.Forms.ComboBox cmbLinea;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem líneasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView datagridMicros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreChofer;
    }
}