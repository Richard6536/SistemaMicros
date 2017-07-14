namespace MicrosFormsGX.Ventanas.Creaciones
{
    partial class CrearRutaIda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearRutaIda));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtNombreRuta = new MetroFramework.Controls.MetroTextBox();
            this.btnDeshacer = new MetroFramework.Controls.MetroTile();
            this.btnAceptarRuta = new MetroFramework.Controls.MetroTile();
            this.btnCrearRuta = new MetroFramework.Controls.MetroTile();
            this.btnGuardarDatos = new MetroFramework.Controls.MetroTile();
            this.btnCancelar = new MetroFramework.Controls.MetroTile();
            this.gmapController = new GMap.NET.WindowsForms.GMapControl();
            this.lblLinea = new MetroFramework.Controls.MetroLabel();
            this.panelIda = new System.Windows.Forms.Panel();
            this.lblIda = new System.Windows.Forms.Label();
            this.panelIda.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(333, 106);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(133, 19);
            this.metroLabel1.TabIndex = 39;
            this.metroLabel1.Text = "Nombre de la ruta";
            // 
            // txtNombreRuta
            // 
            this.txtNombreRuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtNombreRuta.CustomButton.Image = null;
            this.txtNombreRuta.CustomButton.Location = new System.Drawing.Point(581, 1);
            this.txtNombreRuta.CustomButton.Name = "";
            this.txtNombreRuta.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNombreRuta.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNombreRuta.CustomButton.TabIndex = 1;
            this.txtNombreRuta.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNombreRuta.CustomButton.UseSelectable = true;
            this.txtNombreRuta.CustomButton.Visible = false;
            this.txtNombreRuta.Lines = new string[0];
            this.txtNombreRuta.Location = new System.Drawing.Point(333, 128);
            this.txtNombreRuta.MaxLength = 32767;
            this.txtNombreRuta.Name = "txtNombreRuta";
            this.txtNombreRuta.PasswordChar = '\0';
            this.txtNombreRuta.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombreRuta.SelectedText = "";
            this.txtNombreRuta.SelectionLength = 0;
            this.txtNombreRuta.SelectionStart = 0;
            this.txtNombreRuta.ShortcutsEnabled = true;
            this.txtNombreRuta.Size = new System.Drawing.Size(603, 23);
            this.txtNombreRuta.TabIndex = 38;
            this.txtNombreRuta.UseSelectable = true;
            this.txtNombreRuta.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNombreRuta.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.ActiveControl = null;
            this.btnDeshacer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeshacer.Location = new System.Drawing.Point(942, 63);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(149, 88);
            this.btnDeshacer.Style = MetroFramework.MetroColorStyle.Green;
            this.btnDeshacer.TabIndex = 37;
            this.btnDeshacer.Text = "Deshacer";
            this.btnDeshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeshacer.TileImage = ((System.Drawing.Image)(resources.GetObject("btnDeshacer.TileImage")));
            this.btnDeshacer.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeshacer.UseSelectable = true;
            this.btnDeshacer.UseStyleColors = true;
            this.btnDeshacer.UseTileImage = true;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // btnAceptarRuta
            // 
            this.btnAceptarRuta.ActiveControl = null;
            this.btnAceptarRuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptarRuta.Location = new System.Drawing.Point(1097, 63);
            this.btnAceptarRuta.Name = "btnAceptarRuta";
            this.btnAceptarRuta.Size = new System.Drawing.Size(149, 88);
            this.btnAceptarRuta.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAceptarRuta.TabIndex = 36;
            this.btnAceptarRuta.Text = "Confirmar ruta";
            this.btnAceptarRuta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptarRuta.TileImage = ((System.Drawing.Image)(resources.GetObject("btnAceptarRuta.TileImage")));
            this.btnAceptarRuta.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAceptarRuta.UseSelectable = true;
            this.btnAceptarRuta.UseStyleColors = true;
            this.btnAceptarRuta.UseTileImage = true;
            this.btnAceptarRuta.Click += new System.EventHandler(this.btnAceptarRuta_Click);
            // 
            // btnCrearRuta
            // 
            this.btnCrearRuta.ActiveControl = null;
            this.btnCrearRuta.Location = new System.Drawing.Point(23, 63);
            this.btnCrearRuta.Name = "btnCrearRuta";
            this.btnCrearRuta.Size = new System.Drawing.Size(149, 88);
            this.btnCrearRuta.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCrearRuta.TabIndex = 35;
            this.btnCrearRuta.Text = "Comenzar ruta ida";
            this.btnCrearRuta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrearRuta.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrearRuta.UseSelectable = true;
            this.btnCrearRuta.UseStyleColors = true;
            this.btnCrearRuta.UseTileImage = true;
            this.btnCrearRuta.Click += new System.EventHandler(this.btnCrearRuta_Click);
            // 
            // btnGuardarDatos
            // 
            this.btnGuardarDatos.ActiveControl = null;
            this.btnGuardarDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarDatos.Location = new System.Drawing.Point(1097, 521);
            this.btnGuardarDatos.Name = "btnGuardarDatos";
            this.btnGuardarDatos.Size = new System.Drawing.Size(149, 88);
            this.btnGuardarDatos.Style = MetroFramework.MetroColorStyle.Green;
            this.btnGuardarDatos.TabIndex = 34;
            this.btnGuardarDatos.Text = "Guardar";
            this.btnGuardarDatos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarDatos.TileImage = ((System.Drawing.Image)(resources.GetObject("btnGuardarDatos.TileImage")));
            this.btnGuardarDatos.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarDatos.UseSelectable = true;
            this.btnGuardarDatos.UseStyleColors = true;
            this.btnGuardarDatos.UseTileImage = true;
            this.btnGuardarDatos.Click += new System.EventHandler(this.btnGuardarDatos_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ActiveControl = null;
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(23, 521);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(149, 88);
            this.btnCancelar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.TileImage")));
            this.btnCancelar.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.UseStyleColors = true;
            this.btnCancelar.UseTileImage = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gmapController
            // 
            this.gmapController.Bearing = 0F;
            this.gmapController.CanDragMap = true;
            this.gmapController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmapController.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmapController.GrayScaleMode = false;
            this.gmapController.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmapController.LevelsKeepInMemmory = 5;
            this.gmapController.Location = new System.Drawing.Point(20, 60);
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
            this.gmapController.Size = new System.Drawing.Size(1229, 552);
            this.gmapController.TabIndex = 31;
            this.gmapController.Zoom = 0D;
            this.gmapController.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmapController_OnMarkerClick);
            this.gmapController.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.gmapController_OnMarkerEnter);
            this.gmapController.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.gmapController_OnMarkerLeave);
            this.gmapController.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gmapController_MouseClick);
            this.gmapController.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmapController_MouseDoubleClick);
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblLinea.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblLinea.Location = new System.Drawing.Point(333, 63);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(179, 25);
            this.lblLinea.TabIndex = 40;
            this.lblLinea.Text = "Línea: nombre linea";
            // 
            // panelIda
            // 
            this.panelIda.Controls.Add(this.lblIda);
            this.panelIda.Location = new System.Drawing.Point(23, 157);
            this.panelIda.Name = "panelIda";
            this.panelIda.Size = new System.Drawing.Size(304, 44);
            this.panelIda.TabIndex = 41;
            this.panelIda.Visible = false;
            // 
            // lblIda
            // 
            this.lblIda.AutoSize = true;
            this.lblIda.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIda.ForeColor = System.Drawing.Color.Red;
            this.lblIda.Location = new System.Drawing.Point(33, 10);
            this.lblIda.Name = "lblIda";
            this.lblIda.Size = new System.Drawing.Size(227, 24);
            this.lblIda.TabIndex = 0;
            this.lblIda.Text = "Creando ruta de ida...";
            // 
            // CrearRutaIda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 632);
            this.Controls.Add(this.panelIda);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtNombreRuta);
            this.Controls.Add(this.btnDeshacer);
            this.Controls.Add(this.btnAceptarRuta);
            this.Controls.Add(this.btnCrearRuta);
            this.Controls.Add(this.btnGuardarDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gmapController);
            this.MinimumSize = new System.Drawing.Size(889, 319);
            this.Name = "CrearRutaIda";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Crear ruta de ida";
            this.Activated += new System.EventHandler(this.CrearRutaIda_Activated);
            this.panelIda.ResumeLayout(false);
            this.panelIda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtNombreRuta;
        private MetroFramework.Controls.MetroTile btnDeshacer;
        private MetroFramework.Controls.MetroTile btnAceptarRuta;
        private MetroFramework.Controls.MetroTile btnCrearRuta;
        private MetroFramework.Controls.MetroTile btnGuardarDatos;
        private MetroFramework.Controls.MetroTile btnCancelar;
        private GMap.NET.WindowsForms.GMapControl gmapController;
        private MetroFramework.Controls.MetroLabel lblLinea;
        private System.Windows.Forms.Panel panelIda;
        private System.Windows.Forms.Label lblIda;
    }
}