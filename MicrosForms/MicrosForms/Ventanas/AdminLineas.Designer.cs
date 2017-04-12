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
            this.button1 = new System.Windows.Forms.Button();
            this.cmbLinea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRutaIda = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRutaVuelta = new System.Windows.Forms.ComboBox();
            this.gmapController = new GMap.NET.WindowsForms.GMapControl();
            this.btnVerMicros = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(409, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Crear nueva linea";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmbLinea
            // 
            this.cmbLinea.FormattingEnabled = true;
            this.cmbLinea.Location = new System.Drawing.Point(406, 149);
            this.cmbLinea.Name = "cmbLinea";
            this.cmbLinea.Size = new System.Drawing.Size(197, 21);
            this.cmbLinea.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar línea";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(406, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Asignación de rutas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ruta de ida";
            // 
            // cmbRutaIda
            // 
            this.cmbRutaIda.FormattingEnabled = true;
            this.cmbRutaIda.Location = new System.Drawing.Point(406, 262);
            this.cmbRutaIda.Name = "cmbRutaIda";
            this.cmbRutaIda.Size = new System.Drawing.Size(197, 21);
            this.cmbRutaIda.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ruta de vuelta";
            // 
            // cmbRutaVuelta
            // 
            this.cmbRutaVuelta.FormattingEnabled = true;
            this.cmbRutaVuelta.Location = new System.Drawing.Point(406, 311);
            this.cmbRutaVuelta.Name = "cmbRutaVuelta";
            this.cmbRutaVuelta.Size = new System.Drawing.Size(197, 21);
            this.cmbRutaVuelta.TabIndex = 6;
            // 
            // gmapController
            // 
            this.gmapController.Bearing = 0F;
            this.gmapController.CanDragMap = true;
            this.gmapController.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmapController.GrayScaleMode = false;
            this.gmapController.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmapController.LevelsKeepInMemmory = 5;
            this.gmapController.Location = new System.Drawing.Point(12, 22);
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
            this.gmapController.Size = new System.Drawing.Size(372, 326);
            this.gmapController.TabIndex = 8;
            this.gmapController.Zoom = 0D;
            // 
            // btnVerMicros
            // 
            this.btnVerMicros.Location = new System.Drawing.Point(406, 176);
            this.btnVerMicros.Name = "btnVerMicros";
            this.btnVerMicros.Size = new System.Drawing.Size(194, 28);
            this.btnVerMicros.TabIndex = 9;
            this.btnVerMicros.Text = "Ver micros";
            this.btnVerMicros.UseVisualStyleBackColor = true;
            // 
            // AdminLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 380);
            this.Controls.Add(this.btnVerMicros);
            this.Controls.Add(this.gmapController);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRutaVuelta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRutaIda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLinea);
            this.Controls.Add(this.button1);
            this.Name = "AdminLineas";
            this.Text = "AdminLineas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbLinea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRutaIda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRutaVuelta;
        private GMap.NET.WindowsForms.GMapControl gmapController;
        private System.Windows.Forms.Button btnVerMicros;
    }
}