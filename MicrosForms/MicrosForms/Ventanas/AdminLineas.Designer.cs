namespace MicrosForms.Ventanas
{
    partial class AdminLineas
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
            this.btnCrearLinea = new System.Windows.Forms.Button();
            this.cmbLinea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gmapController = new GMap.NET.WindowsForms.GMapControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTransferirMicros = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrearLinea
            // 
            this.btnCrearLinea.Location = new System.Drawing.Point(760, 432);
            this.btnCrearLinea.Name = "btnCrearLinea";
            this.btnCrearLinea.Size = new System.Drawing.Size(214, 64);
            this.btnCrearLinea.TabIndex = 0;
            this.btnCrearLinea.Text = "Crear nueva linea";
            this.btnCrearLinea.UseVisualStyleBackColor = true;
            this.btnCrearLinea.Click += new System.EventHandler(this.btnCrearLinea_Click);
            // 
            // cmbLinea
            // 
            this.cmbLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLinea.FormattingEnabled = true;
            this.cmbLinea.Location = new System.Drawing.Point(760, 83);
            this.cmbLinea.Name = "cmbLinea";
            this.cmbLinea.Size = new System.Drawing.Size(214, 21);
            this.cmbLinea.TabIndex = 1;
            this.cmbLinea.SelectedIndexChanged += new System.EventHandler(this.cmbLinea_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(760, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar línea";
            // 
            // gmapController
            // 
            this.gmapController.Bearing = 0F;
            this.gmapController.CanDragMap = true;
            this.gmapController.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmapController.GrayScaleMode = false;
            this.gmapController.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmapController.LevelsKeepInMemmory = 5;
            this.gmapController.Location = new System.Drawing.Point(12, 33);
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
            this.gmapController.Size = new System.Drawing.Size(717, 474);
            this.gmapController.TabIndex = 8;
            this.gmapController.Zoom = 0D;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1035, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.microsToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.administrarToolStripMenuItem.Text = "Administrar";
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 20);
            this.toolStripMenuItem1.Text = "Ventana de inicio";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.VentanaInicioMenuItem1_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(884, 110);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(90, 28);
            this.btnBorrar.TabIndex = 11;
            this.btnBorrar.Text = "Borrar línea";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(760, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(214, 199);
            this.dataGridView1.TabIndex = 12;
            // 
            // btnTransferirMicros
            // 
            this.btnTransferirMicros.Location = new System.Drawing.Point(763, 368);
            this.btnTransferirMicros.Name = "btnTransferirMicros";
            this.btnTransferirMicros.Size = new System.Drawing.Size(211, 31);
            this.btnTransferirMicros.TabIndex = 13;
            this.btnTransferirMicros.Text = "Transferir micros";
            this.btnTransferirMicros.UseVisualStyleBackColor = true;
            // 
            // AdminLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 539);
            this.Controls.Add(this.btnTransferirMicros);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gmapController);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLinea);
            this.Controls.Add(this.btnCrearLinea);
            this.Name = "AdminLineas";
            this.Text = "AdminLineas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearLinea;
        private System.Windows.Forms.ComboBox cmbLinea;
        private System.Windows.Forms.Label label1;
        private GMap.NET.WindowsForms.GMapControl gmapController;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTransferirMicros;
    }
}