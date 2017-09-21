namespace MicrosFormsGX.Ventanas.Creaciones
{
    partial class CrearLineaV2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearLineaV2));
            this.gmapController = new GMap.NET.WindowsForms.GMapControl();
            this.btnComenzarVuelta = new MetroFramework.Controls.MetroTile();
            this.btnCancelar = new MetroFramework.Controls.MetroTile();
            this.btnGuardarDatos = new MetroFramework.Controls.MetroTile();
            this.btnCrearRuta = new MetroFramework.Controls.MetroTile();
            this.btnAceptarRuta = new MetroFramework.Controls.MetroTile();
            this.btnDeshacer = new MetroFramework.Controls.MetroTile();
            this.panelIda = new System.Windows.Forms.Panel();
            this.lblVuelta = new System.Windows.Forms.Label();
            this.lblIda = new System.Windows.Forms.Label();
            this.panelIda.SuspendLayout();
            this.SuspendLayout();
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
            this.gmapController.Size = new System.Drawing.Size(1111, 574);
            this.gmapController.TabIndex = 9;
            this.gmapController.Zoom = 0D;
            this.gmapController.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gmapController_MouseClick);
            this.gmapController.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmapController_MouseDoubleClick);
            // 
            // btnComenzarVuelta
            // 
            this.btnComenzarVuelta.ActiveControl = null;
            this.btnComenzarVuelta.Location = new System.Drawing.Point(178, 63);
            this.btnComenzarVuelta.Name = "btnComenzarVuelta";
            this.btnComenzarVuelta.Size = new System.Drawing.Size(149, 88);
            this.btnComenzarVuelta.Style = MetroFramework.MetroColorStyle.Green;
            this.btnComenzarVuelta.TabIndex = 14;
            this.btnComenzarVuelta.Text = "Comenzar ruta vuelta";
            this.btnComenzarVuelta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnComenzarVuelta.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnComenzarVuelta.UseSelectable = true;
            this.btnComenzarVuelta.UseStyleColors = true;
            this.btnComenzarVuelta.UseTileImage = true;
            this.btnComenzarVuelta.Click += new System.EventHandler(this.btnComenzarVuelta_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ActiveControl = null;
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(23, 543);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(149, 88);
            this.btnCancelar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.TileImage")));
            this.btnCancelar.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.UseStyleColors = true;
            this.btnCancelar.UseTileImage = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardarDatos
            // 
            this.btnGuardarDatos.ActiveControl = null;
            this.btnGuardarDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarDatos.Location = new System.Drawing.Point(979, 543);
            this.btnGuardarDatos.Name = "btnGuardarDatos";
            this.btnGuardarDatos.Size = new System.Drawing.Size(149, 88);
            this.btnGuardarDatos.Style = MetroFramework.MetroColorStyle.Green;
            this.btnGuardarDatos.TabIndex = 16;
            this.btnGuardarDatos.Text = "Guardar";
            this.btnGuardarDatos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarDatos.TileImage = ((System.Drawing.Image)(resources.GetObject("btnGuardarDatos.TileImage")));
            this.btnGuardarDatos.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarDatos.UseSelectable = true;
            this.btnGuardarDatos.UseStyleColors = true;
            this.btnGuardarDatos.UseTileImage = true;
            this.btnGuardarDatos.Click += new System.EventHandler(this.btnGuardarDatos_Click);
            // 
            // btnCrearRuta
            // 
            this.btnCrearRuta.ActiveControl = null;
            this.btnCrearRuta.Location = new System.Drawing.Point(23, 63);
            this.btnCrearRuta.Name = "btnCrearRuta";
            this.btnCrearRuta.Size = new System.Drawing.Size(149, 88);
            this.btnCrearRuta.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCrearRuta.TabIndex = 17;
            this.btnCrearRuta.Text = "Comenzar ruta ida";
            this.btnCrearRuta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrearRuta.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrearRuta.UseSelectable = true;
            this.btnCrearRuta.UseStyleColors = true;
            this.btnCrearRuta.UseTileImage = true;
            this.btnCrearRuta.Click += new System.EventHandler(this.btnCrearRuta_Click);
            // 
            // btnAceptarRuta
            // 
            this.btnAceptarRuta.ActiveControl = null;
            this.btnAceptarRuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptarRuta.Location = new System.Drawing.Point(979, 63);
            this.btnAceptarRuta.Name = "btnAceptarRuta";
            this.btnAceptarRuta.Size = new System.Drawing.Size(149, 88);
            this.btnAceptarRuta.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAceptarRuta.TabIndex = 18;
            this.btnAceptarRuta.Text = "Confirmar ruta";
            this.btnAceptarRuta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptarRuta.TileImage = ((System.Drawing.Image)(resources.GetObject("btnAceptarRuta.TileImage")));
            this.btnAceptarRuta.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAceptarRuta.UseSelectable = true;
            this.btnAceptarRuta.UseStyleColors = true;
            this.btnAceptarRuta.UseTileImage = true;
            this.btnAceptarRuta.Click += new System.EventHandler(this.btnAceptarRuta_Click);
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.ActiveControl = null;
            this.btnDeshacer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeshacer.Location = new System.Drawing.Point(824, 63);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(149, 88);
            this.btnDeshacer.Style = MetroFramework.MetroColorStyle.Green;
            this.btnDeshacer.TabIndex = 19;
            this.btnDeshacer.Text = "Deshacer";
            this.btnDeshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeshacer.TileImage = ((System.Drawing.Image)(resources.GetObject("btnDeshacer.TileImage")));
            this.btnDeshacer.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeshacer.UseSelectable = true;
            this.btnDeshacer.UseStyleColors = true;
            this.btnDeshacer.UseTileImage = true;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // panelIda
            // 
            this.panelIda.Controls.Add(this.lblVuelta);
            this.panelIda.Controls.Add(this.lblIda);
            this.panelIda.Location = new System.Drawing.Point(23, 157);
            this.panelIda.Name = "panelIda";
            this.panelIda.Size = new System.Drawing.Size(304, 44);
            this.panelIda.TabIndex = 22;
            this.panelIda.Visible = false;
            // 
            // lblVuelta
            // 
            this.lblVuelta.AutoSize = true;
            this.lblVuelta.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelta.ForeColor = System.Drawing.Color.Blue;
            this.lblVuelta.Location = new System.Drawing.Point(33, 10);
            this.lblVuelta.Name = "lblVuelta";
            this.lblVuelta.Size = new System.Drawing.Size(259, 24);
            this.lblVuelta.TabIndex = 0;
            this.lblVuelta.Text = "Creando ruta de vuelta...";
            this.lblVuelta.Visible = false;
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
            this.lblIda.Visible = false;
            // 
            // CrearLineaV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 654);
            this.Controls.Add(this.panelIda);
            this.Controls.Add(this.btnDeshacer);
            this.Controls.Add(this.btnAceptarRuta);
            this.Controls.Add(this.btnCrearRuta);
            this.Controls.Add(this.btnGuardarDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnComenzarVuelta);
            this.Controls.Add(this.gmapController);
            this.MinimumSize = new System.Drawing.Size(889, 319);
            this.Name = "CrearLineaV2";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Crear nueva línea";
            this.Activated += new System.EventHandler(this.CrearLineaV2_Activated);
            this.panelIda.ResumeLayout(false);
            this.panelIda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmapController;
        private MetroFramework.Controls.MetroTile btnComenzarVuelta;
        private MetroFramework.Controls.MetroTile btnCancelar;
        private MetroFramework.Controls.MetroTile btnGuardarDatos;
        private MetroFramework.Controls.MetroTile btnCrearRuta;
        private MetroFramework.Controls.MetroTile btnAceptarRuta;
        private MetroFramework.Controls.MetroTile btnDeshacer;
        private System.Windows.Forms.Panel panelIda;
        private System.Windows.Forms.Label lblVuelta;
        private System.Windows.Forms.Label lblIda;
    }
}