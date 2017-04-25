namespace MicrosForms.Ventanas.Creaciones
{
    partial class CrearRutaVuelta
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
            this.lblLinea = new System.Windows.Forms.Label();
            this.gmapController = new GMap.NET.WindowsForms.GMapControl();
            this.btnGuardarDatos = new System.Windows.Forms.Button();
            this.panelEditCreate = new System.Windows.Forms.Panel();
            this.btnAceptarRuta = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnCrearRuta = new System.Windows.Forms.Button();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreLinea = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEditCreate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinea.Location = new System.Drawing.Point(615, 65);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(44, 13);
            this.lblLinea.TabIndex = 27;
            this.lblLinea.Text = "Línea:";
            // 
            // gmapController
            // 
            this.gmapController.Bearing = 0F;
            this.gmapController.CanDragMap = true;
            this.gmapController.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmapController.GrayScaleMode = false;
            this.gmapController.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmapController.LevelsKeepInMemmory = 5;
            this.gmapController.Location = new System.Drawing.Point(12, 26);
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
            this.gmapController.Size = new System.Drawing.Size(484, 429);
            this.gmapController.TabIndex = 26;
            this.gmapController.Zoom = 0D;
            this.gmapController.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gmapController_MouseClick);
            this.gmapController.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmapController_MouseDoubleClick);
            // 
            // btnGuardarDatos
            // 
            this.btnGuardarDatos.Location = new System.Drawing.Point(700, 339);
            this.btnGuardarDatos.Name = "btnGuardarDatos";
            this.btnGuardarDatos.Size = new System.Drawing.Size(161, 38);
            this.btnGuardarDatos.TabIndex = 25;
            this.btnGuardarDatos.Text = "Guardar datos";
            this.btnGuardarDatos.UseVisualStyleBackColor = true;
            this.btnGuardarDatos.Click += new System.EventHandler(this.btnGuardarDatos_Click);
            // 
            // panelEditCreate
            // 
            this.panelEditCreate.Controls.Add(this.btnAceptarRuta);
            this.panelEditCreate.Controls.Add(this.btnDeshacer);
            this.panelEditCreate.Controls.Add(this.btnCrearRuta);
            this.panelEditCreate.Controls.Add(this.lblTituloPanel);
            this.panelEditCreate.Location = new System.Drawing.Point(512, 140);
            this.panelEditCreate.Name = "panelEditCreate";
            this.panelEditCreate.Size = new System.Drawing.Size(349, 193);
            this.panelEditCreate.TabIndex = 24;
            // 
            // btnAceptarRuta
            // 
            this.btnAceptarRuta.Location = new System.Drawing.Point(243, 110);
            this.btnAceptarRuta.Name = "btnAceptarRuta";
            this.btnAceptarRuta.Size = new System.Drawing.Size(69, 64);
            this.btnAceptarRuta.TabIndex = 8;
            this.btnAceptarRuta.Text = "Aceptar";
            this.btnAceptarRuta.UseVisualStyleBackColor = true;
            this.btnAceptarRuta.Click += new System.EventHandler(this.btnAceptarRuta_Click);
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.Location = new System.Drawing.Point(243, 42);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(69, 64);
            this.btnDeshacer.TabIndex = 7;
            this.btnDeshacer.Text = "Deshacer";
            this.btnDeshacer.UseVisualStyleBackColor = true;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // btnCrearRuta
            // 
            this.btnCrearRuta.Location = new System.Drawing.Point(21, 42);
            this.btnCrearRuta.Name = "btnCrearRuta";
            this.btnCrearRuta.Size = new System.Drawing.Size(216, 132);
            this.btnCrearRuta.TabIndex = 6;
            this.btnCrearRuta.Text = "Comenzar ruta";
            this.btnCrearRuta.UseVisualStyleBackColor = true;
            this.btnCrearRuta.Click += new System.EventHandler(this.btnCrearRuta_Click);
            // 
            // lblTituloPanel
            // 
            this.lblTituloPanel.AutoSize = true;
            this.lblTituloPanel.Location = new System.Drawing.Point(84, 15);
            this.lblTituloPanel.Name = "lblTituloPanel";
            this.lblTituloPanel.Size = new System.Drawing.Size(85, 13);
            this.lblTituloPanel.TabIndex = 1;
            this.lblTituloPanel.Text = "Creación de ruta";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(513, 339);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(161, 38);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nombre de ruta";
            // 
            // txtNombreLinea
            // 
            this.txtNombreLinea.Location = new System.Drawing.Point(602, 105);
            this.txtNombreLinea.Name = "txtNombreLinea";
            this.txtNombreLinea.Size = new System.Drawing.Size(248, 20);
            this.txtNombreLinea.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(631, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Crear nueva ruta de vuelta";
            // 
            // CrearRutaVuelta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 529);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.gmapController);
            this.Controls.Add(this.btnGuardarDatos);
            this.Controls.Add(this.panelEditCreate);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreLinea);
            this.Controls.Add(this.label1);
            this.Name = "CrearRutaVuelta";
            this.Text = "CrearRutaVuelta";
            this.panelEditCreate.ResumeLayout(false);
            this.panelEditCreate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLinea;
        private GMap.NET.WindowsForms.GMapControl gmapController;
        private System.Windows.Forms.Button btnGuardarDatos;
        private System.Windows.Forms.Panel panelEditCreate;
        private System.Windows.Forms.Button btnAceptarRuta;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnCrearRuta;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreLinea;
        private System.Windows.Forms.Label label1;
    }
}