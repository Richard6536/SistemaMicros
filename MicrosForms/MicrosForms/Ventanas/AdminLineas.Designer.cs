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
            this.cmbRutaIda = new System.Windows.Forms.ComboBox();
            this.cmbRutaVuelta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCrearIda = new System.Windows.Forms.Button();
            this.btnEliminarIda = new System.Windows.Forms.Button();
            this.btnEliminarVuelta = new System.Windows.Forms.Button();
            this.btnCrearVuelta = new System.Windows.Forms.Button();
            this.lblRutaIda = new System.Windows.Forms.Label();
            this.lblRutaVuelta = new System.Windows.Forms.Label();
            this.btnAsignarIda = new System.Windows.Forms.Button();
            this.btnAsignarVuelta = new System.Windows.Forms.Button();
            this.btnCambiarNombreLinea = new System.Windows.Forms.Button();
            this.btnVerMicros = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCrearLinea
            // 
            this.btnCrearLinea.Location = new System.Drawing.Point(763, 169);
            this.btnCrearLinea.Name = "btnCrearLinea";
            this.btnCrearLinea.Size = new System.Drawing.Size(234, 54);
            this.btnCrearLinea.TabIndex = 0;
            this.btnCrearLinea.Text = "Crear nueva linea";
            this.btnCrearLinea.UseVisualStyleBackColor = true;
            this.btnCrearLinea.Click += new System.EventHandler(this.btnCrearLinea_Click);
            // 
            // cmbLinea
            // 
            this.cmbLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLinea.FormattingEnabled = true;
            this.cmbLinea.Location = new System.Drawing.Point(760, 57);
            this.cmbLinea.Name = "cmbLinea";
            this.cmbLinea.Size = new System.Drawing.Size(234, 21);
            this.cmbLinea.TabIndex = 1;
            this.cmbLinea.SelectedIndexChanged += new System.EventHandler(this.cmbLinea_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(760, 41);
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
            this.btnBorrar.Location = new System.Drawing.Point(904, 119);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(90, 28);
            this.btnBorrar.TabIndex = 11;
            this.btnBorrar.Text = "Eliminar línea";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // cmbRutaIda
            // 
            this.cmbRutaIda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRutaIda.FormattingEnabled = true;
            this.cmbRutaIda.Location = new System.Drawing.Point(763, 282);
            this.cmbRutaIda.Name = "cmbRutaIda";
            this.cmbRutaIda.Size = new System.Drawing.Size(231, 21);
            this.cmbRutaIda.TabIndex = 14;
            this.cmbRutaIda.SelectedIndexChanged += new System.EventHandler(this.cmbRutaIda_SelectedIndexChanged);
            this.cmbRutaIda.Click += new System.EventHandler(this.cmbRutaIda_Click);
            // 
            // cmbRutaVuelta
            // 
            this.cmbRutaVuelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRutaVuelta.FormattingEnabled = true;
            this.cmbRutaVuelta.Location = new System.Drawing.Point(767, 435);
            this.cmbRutaVuelta.Name = "cmbRutaVuelta";
            this.cmbRutaVuelta.Size = new System.Drawing.Size(231, 21);
            this.cmbRutaVuelta.TabIndex = 15;
            this.cmbRutaVuelta.SelectedIndexChanged += new System.EventHandler(this.cmbRutaVuelta_SelectedIndexChanged);
            this.cmbRutaVuelta.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbRutaVuelta_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(763, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Ruta ida";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(767, 419);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ruta vuelta";
            // 
            // btnCrearIda
            // 
            this.btnCrearIda.Location = new System.Drawing.Point(763, 309);
            this.btnCrearIda.Name = "btnCrearIda";
            this.btnCrearIda.Size = new System.Drawing.Size(129, 28);
            this.btnCrearIda.TabIndex = 18;
            this.btnCrearIda.Text = "Crear nueva ruta ida";
            this.btnCrearIda.UseVisualStyleBackColor = true;
            this.btnCrearIda.Click += new System.EventHandler(this.btnCrearIda_Click);
            // 
            // btnEliminarIda
            // 
            this.btnEliminarIda.Location = new System.Drawing.Point(763, 343);
            this.btnEliminarIda.Name = "btnEliminarIda";
            this.btnEliminarIda.Size = new System.Drawing.Size(126, 28);
            this.btnEliminarIda.TabIndex = 19;
            this.btnEliminarIda.Text = "Eliminar ruta";
            this.btnEliminarIda.UseVisualStyleBackColor = true;
            this.btnEliminarIda.Click += new System.EventHandler(this.btnEliminarIda_Click);
            // 
            // btnEliminarVuelta
            // 
            this.btnEliminarVuelta.Location = new System.Drawing.Point(770, 496);
            this.btnEliminarVuelta.Name = "btnEliminarVuelta";
            this.btnEliminarVuelta.Size = new System.Drawing.Size(126, 28);
            this.btnEliminarVuelta.TabIndex = 21;
            this.btnEliminarVuelta.Text = "Eliminar ruta";
            this.btnEliminarVuelta.UseVisualStyleBackColor = true;
            this.btnEliminarVuelta.Click += new System.EventHandler(this.btnEliminarVuelta_Click);
            // 
            // btnCrearVuelta
            // 
            this.btnCrearVuelta.Location = new System.Drawing.Point(767, 462);
            this.btnCrearVuelta.Name = "btnCrearVuelta";
            this.btnCrearVuelta.Size = new System.Drawing.Size(129, 28);
            this.btnCrearVuelta.TabIndex = 20;
            this.btnCrearVuelta.Text = "Crear nueva ruta vuelta";
            this.btnCrearVuelta.UseVisualStyleBackColor = true;
            this.btnCrearVuelta.Click += new System.EventHandler(this.btnCrearVuelta_Click);
            // 
            // lblRutaIda
            // 
            this.lblRutaIda.AutoSize = true;
            this.lblRutaIda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRutaIda.Location = new System.Drawing.Point(763, 239);
            this.lblRutaIda.Name = "lblRutaIda";
            this.lblRutaIda.Size = new System.Drawing.Size(128, 15);
            this.lblRutaIda.TabIndex = 22;
            this.lblRutaIda.Text = "Ruta de ida actual:";
            // 
            // lblRutaVuelta
            // 
            this.lblRutaVuelta.AutoSize = true;
            this.lblRutaVuelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRutaVuelta.Location = new System.Drawing.Point(766, 391);
            this.lblRutaVuelta.Name = "lblRutaVuelta";
            this.lblRutaVuelta.Size = new System.Drawing.Size(146, 15);
            this.lblRutaVuelta.TabIndex = 23;
            this.lblRutaVuelta.Text = "Ruta de vuelta actual:";
            // 
            // btnAsignarIda
            // 
            this.btnAsignarIda.Location = new System.Drawing.Point(898, 309);
            this.btnAsignarIda.Name = "btnAsignarIda";
            this.btnAsignarIda.Size = new System.Drawing.Size(100, 28);
            this.btnAsignarIda.TabIndex = 24;
            this.btnAsignarIda.Text = "Asignar a la línea";
            this.btnAsignarIda.UseVisualStyleBackColor = true;
            this.btnAsignarIda.Click += new System.EventHandler(this.btnAsignarIda_Click);
            // 
            // btnAsignarVuelta
            // 
            this.btnAsignarVuelta.Location = new System.Drawing.Point(899, 462);
            this.btnAsignarVuelta.Name = "btnAsignarVuelta";
            this.btnAsignarVuelta.Size = new System.Drawing.Size(100, 28);
            this.btnAsignarVuelta.TabIndex = 25;
            this.btnAsignarVuelta.Text = "Asignar a la línea";
            this.btnAsignarVuelta.UseVisualStyleBackColor = true;
            this.btnAsignarVuelta.Click += new System.EventHandler(this.btnAsignarVuelta_Click);
            // 
            // btnCambiarNombreLinea
            // 
            this.btnCambiarNombreLinea.Location = new System.Drawing.Point(761, 119);
            this.btnCambiarNombreLinea.Name = "btnCambiarNombreLinea";
            this.btnCambiarNombreLinea.Size = new System.Drawing.Size(131, 28);
            this.btnCambiarNombreLinea.TabIndex = 26;
            this.btnCambiarNombreLinea.Text = "Cambiar nombre";
            this.btnCambiarNombreLinea.UseVisualStyleBackColor = true;
            this.btnCambiarNombreLinea.Click += new System.EventHandler(this.btnCambiarNombreLinea_Click);
            // 
            // btnVerMicros
            // 
            this.btnVerMicros.Location = new System.Drawing.Point(760, 84);
            this.btnVerMicros.Name = "btnVerMicros";
            this.btnVerMicros.Size = new System.Drawing.Size(234, 29);
            this.btnVerMicros.TabIndex = 27;
            this.btnVerMicros.Text = "Ver Micros";
            this.btnVerMicros.UseVisualStyleBackColor = true;
            this.btnVerMicros.Click += new System.EventHandler(this.btnVerMicros_Click_1);
            // 
            // AdminLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 539);
            this.Controls.Add(this.btnVerMicros);
            this.Controls.Add(this.btnCambiarNombreLinea);
            this.Controls.Add(this.btnAsignarVuelta);
            this.Controls.Add(this.btnAsignarIda);
            this.Controls.Add(this.lblRutaVuelta);
            this.Controls.Add(this.lblRutaIda);
            this.Controls.Add(this.btnEliminarVuelta);
            this.Controls.Add(this.btnCrearVuelta);
            this.Controls.Add(this.btnEliminarIda);
            this.Controls.Add(this.btnCrearIda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbRutaVuelta);
            this.Controls.Add(this.cmbRutaIda);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gmapController);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLinea);
            this.Controls.Add(this.btnCrearLinea);
            this.Name = "AdminLineas";
            this.Text = "AdminLineas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminLineas_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminLineas_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmbRutaIda;
        private System.Windows.Forms.ComboBox cmbRutaVuelta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCrearIda;
        private System.Windows.Forms.Button btnEliminarIda;
        private System.Windows.Forms.Button btnEliminarVuelta;
        private System.Windows.Forms.Button btnCrearVuelta;
        private System.Windows.Forms.Label lblRutaIda;
        private System.Windows.Forms.Label lblRutaVuelta;
        private System.Windows.Forms.Button btnAsignarIda;
        private System.Windows.Forms.Button btnAsignarVuelta;
        private System.Windows.Forms.Button btnCambiarNombreLinea;
        private System.Windows.Forms.Button btnVerMicros;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}