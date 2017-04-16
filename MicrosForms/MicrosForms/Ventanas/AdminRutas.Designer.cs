namespace MicrosForms.Ventanas
{
    partial class AdminRutas
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
            this.gmapController = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbListaRutas = new System.Windows.Forms.ComboBox();
            this.btnEditarRuta = new System.Windows.Forms.Button();
            this.btnCrearNueva = new System.Windows.Forms.Button();
            this.panelEditCreate = new System.Windows.Forms.Panel();
            this.btnAceptarParaderos = new System.Windows.Forms.Button();
            this.btnCrearParaderos = new System.Windows.Forms.Button();
            this.btnCancelarRuta = new System.Windows.Forms.Button();
            this.btnAceptarRuta = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnCrearRuta = new System.Windows.Forms.Button();
            this.lblNombreRuta = new System.Windows.Forms.Label();
            this.txtNombreEditRuta = new System.Windows.Forms.TextBox();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.líneasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEditCreate.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.gmapController.Location = new System.Drawing.Point(12, 39);
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
            this.gmapController.Size = new System.Drawing.Size(409, 329);
            this.gmapController.TabIndex = 0;
            this.gmapController.Zoom = 0D;
            this.gmapController.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmapController_OnMarkerClick);
            this.gmapController.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.gmapController_OnMarkerEnter);
            this.gmapController.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.gmapController_OnMarkerLeave);
            this.gmapController.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmapController_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar ruta";
            // 
            // cmbListaRutas
            // 
            this.cmbListaRutas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaRutas.FormattingEnabled = true;
            this.cmbListaRutas.Location = new System.Drawing.Point(468, 71);
            this.cmbListaRutas.Name = "cmbListaRutas";
            this.cmbListaRutas.Size = new System.Drawing.Size(226, 21);
            this.cmbListaRutas.TabIndex = 2;
            this.cmbListaRutas.SelectedIndexChanged += new System.EventHandler(this.cmbListaRutas_SelectedIndexChanged);
            // 
            // btnEditarRuta
            // 
            this.btnEditarRuta.Location = new System.Drawing.Point(468, 98);
            this.btnEditarRuta.Name = "btnEditarRuta";
            this.btnEditarRuta.Size = new System.Drawing.Size(226, 27);
            this.btnEditarRuta.TabIndex = 3;
            this.btnEditarRuta.Text = "Editar ruta";
            this.btnEditarRuta.UseVisualStyleBackColor = true;
            this.btnEditarRuta.Click += new System.EventHandler(this.btnEditarRuta_Click);
            // 
            // btnCrearNueva
            // 
            this.btnCrearNueva.Location = new System.Drawing.Point(700, 71);
            this.btnCrearNueva.Name = "btnCrearNueva";
            this.btnCrearNueva.Size = new System.Drawing.Size(163, 54);
            this.btnCrearNueva.TabIndex = 4;
            this.btnCrearNueva.Text = "Crear nueva ruta";
            this.btnCrearNueva.UseVisualStyleBackColor = true;
            this.btnCrearNueva.Click += new System.EventHandler(this.btnCrearNueva_Click);
            // 
            // panelEditCreate
            // 
            this.panelEditCreate.Controls.Add(this.btnAceptarParaderos);
            this.panelEditCreate.Controls.Add(this.btnCrearParaderos);
            this.panelEditCreate.Controls.Add(this.btnCancelarRuta);
            this.panelEditCreate.Controls.Add(this.btnAceptarRuta);
            this.panelEditCreate.Controls.Add(this.btnDeshacer);
            this.panelEditCreate.Controls.Add(this.btnCrearRuta);
            this.panelEditCreate.Controls.Add(this.lblNombreRuta);
            this.panelEditCreate.Controls.Add(this.txtNombreEditRuta);
            this.panelEditCreate.Controls.Add(this.lblTituloPanel);
            this.panelEditCreate.Controls.Add(this.btnGuardarCambios);
            this.panelEditCreate.Location = new System.Drawing.Point(468, 131);
            this.panelEditCreate.Name = "panelEditCreate";
            this.panelEditCreate.Size = new System.Drawing.Size(384, 230);
            this.panelEditCreate.TabIndex = 5;
            // 
            // btnAceptarParaderos
            // 
            this.btnAceptarParaderos.Location = new System.Drawing.Point(297, 74);
            this.btnAceptarParaderos.Name = "btnAceptarParaderos";
            this.btnAceptarParaderos.Size = new System.Drawing.Size(67, 99);
            this.btnAceptarParaderos.TabIndex = 11;
            this.btnAceptarParaderos.Text = "Aceptar";
            this.btnAceptarParaderos.UseVisualStyleBackColor = true;
            this.btnAceptarParaderos.Click += new System.EventHandler(this.btnAceptarParaderos_Click);
            // 
            // btnCrearParaderos
            // 
            this.btnCrearParaderos.Location = new System.Drawing.Point(196, 74);
            this.btnCrearParaderos.Name = "btnCrearParaderos";
            this.btnCrearParaderos.Size = new System.Drawing.Size(95, 99);
            this.btnCrearParaderos.TabIndex = 10;
            this.btnCrearParaderos.Text = "Crear paraderos";
            this.btnCrearParaderos.UseVisualStyleBackColor = true;
            this.btnCrearParaderos.Click += new System.EventHandler(this.btnCrearParaderos_Click);
            // 
            // btnCancelarRuta
            // 
            this.btnCancelarRuta.Location = new System.Drawing.Point(16, 179);
            this.btnCancelarRuta.Name = "btnCancelarRuta";
            this.btnCancelarRuta.Size = new System.Drawing.Size(161, 38);
            this.btnCancelarRuta.TabIndex = 9;
            this.btnCancelarRuta.Text = "Cancelar";
            this.btnCancelarRuta.UseVisualStyleBackColor = true;
            this.btnCancelarRuta.Click += new System.EventHandler(this.btnCancelarRuta_Click);
            // 
            // btnAceptarRuta
            // 
            this.btnAceptarRuta.Location = new System.Drawing.Point(108, 126);
            this.btnAceptarRuta.Name = "btnAceptarRuta";
            this.btnAceptarRuta.Size = new System.Drawing.Size(69, 47);
            this.btnAceptarRuta.TabIndex = 8;
            this.btnAceptarRuta.Text = "Aceptar";
            this.btnAceptarRuta.UseVisualStyleBackColor = true;
            this.btnAceptarRuta.Click += new System.EventHandler(this.btnAceptarRuta_Click);
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.Location = new System.Drawing.Point(108, 74);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(69, 46);
            this.btnDeshacer.TabIndex = 7;
            this.btnDeshacer.Text = "Deshacer";
            this.btnDeshacer.UseVisualStyleBackColor = true;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // btnCrearRuta
            // 
            this.btnCrearRuta.Location = new System.Drawing.Point(16, 74);
            this.btnCrearRuta.Name = "btnCrearRuta";
            this.btnCrearRuta.Size = new System.Drawing.Size(86, 99);
            this.btnCrearRuta.TabIndex = 6;
            this.btnCrearRuta.Text = "Crear ruta";
            this.btnCrearRuta.UseVisualStyleBackColor = true;
            this.btnCrearRuta.Click += new System.EventHandler(this.btnCrearRuta_Click);
            // 
            // lblNombreRuta
            // 
            this.lblNombreRuta.AutoSize = true;
            this.lblNombreRuta.Location = new System.Drawing.Point(161, 16);
            this.lblNombreRuta.Name = "lblNombreRuta";
            this.lblNombreRuta.Size = new System.Drawing.Size(114, 13);
            this.lblNombreRuta.TabIndex = 3;
            this.lblNombreRuta.Text = "Nombre/Editar nombre";
            // 
            // txtNombreEditRuta
            // 
            this.txtNombreEditRuta.Location = new System.Drawing.Point(164, 32);
            this.txtNombreEditRuta.Name = "txtNombreEditRuta";
            this.txtNombreEditRuta.Size = new System.Drawing.Size(200, 20);
            this.txtNombreEditRuta.TabIndex = 2;
            // 
            // lblTituloPanel
            // 
            this.lblTituloPanel.AutoSize = true;
            this.lblTituloPanel.Location = new System.Drawing.Point(17, 13);
            this.lblTituloPanel.Name = "lblTituloPanel";
            this.lblTituloPanel.Size = new System.Drawing.Size(33, 13);
            this.lblTituloPanel.TabIndex = 1;
            this.lblTituloPanel.Text = "Titulo";
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(183, 179);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(181, 38);
            this.btnGuardarCambios.TabIndex = 0;
            this.btnGuardarCambios.Text = "Guardar cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.ventanaInicio});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 24);
            this.menuStrip1.TabIndex = 11;
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
            // ventanaInicio
            // 
            this.ventanaInicio.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ventanaInicio.Name = "ventanaInicio";
            this.ventanaInicio.Size = new System.Drawing.Size(109, 20);
            this.ventanaInicio.Text = "Ventana de inicio";
            this.ventanaInicio.Click += new System.EventHandler(this.ventanaInicio_Click);
            // 
            // AdminRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 606);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelEditCreate);
            this.Controls.Add(this.btnCrearNueva);
            this.Controls.Add(this.btnEditarRuta);
            this.Controls.Add(this.cmbListaRutas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gmapController);
            this.Name = "AdminRutas";
            this.Text = "AdminRutas";
            this.panelEditCreate.ResumeLayout(false);
            this.panelEditCreate.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmapController;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbListaRutas;
        private System.Windows.Forms.Button btnEditarRuta;
        private System.Windows.Forms.Button btnCrearNueva;
        private System.Windows.Forms.Panel panelEditCreate;
        private System.Windows.Forms.Button btnAceptarRuta;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnCrearRuta;
        private System.Windows.Forms.Label lblNombreRuta;
        private System.Windows.Forms.TextBox txtNombreEditRuta;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem líneasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventanaInicio;
        private System.Windows.Forms.Button btnCancelarRuta;
        private System.Windows.Forms.Button btnAceptarParaderos;
        private System.Windows.Forms.Button btnCrearParaderos;
    }
}