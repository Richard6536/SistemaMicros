namespace MicrosForms.Ventanas
{
    partial class Inicio
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
            this.gMapControllador = new GMap.NET.WindowsForms.GMapControl();
            this.txtLatitud = new System.Windows.Forms.TextBox();
            this.txtLongitud = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnComoLlegar = new System.Windows.Forms.Button();
            this.btnCrearRuta = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gMapControllador
            // 
            this.gMapControllador.Bearing = 0F;
            this.gMapControllador.CanDragMap = true;
            this.gMapControllador.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControllador.GrayScaleMode = false;
            this.gMapControllador.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControllador.LevelsKeepInMemmory = 5;
            this.gMapControllador.Location = new System.Drawing.Point(12, 41);
            this.gMapControllador.MarkersEnabled = true;
            this.gMapControllador.MaxZoom = 2;
            this.gMapControllador.MinZoom = 2;
            this.gMapControllador.MouseWheelZoomEnabled = true;
            this.gMapControllador.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControllador.Name = "gMapControllador";
            this.gMapControllador.NegativeMode = false;
            this.gMapControllador.PolygonsEnabled = true;
            this.gMapControllador.RetryLoadTile = 0;
            this.gMapControllador.RoutesEnabled = true;
            this.gMapControllador.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControllador.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControllador.ShowTileGridLines = false;
            this.gMapControllador.Size = new System.Drawing.Size(566, 358);
            this.gMapControllador.TabIndex = 0;
            this.gMapControllador.Zoom = 0D;
            this.gMapControllador.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControllador_MouseDoubleClick);
            // 
            // txtLatitud
            // 
            this.txtLatitud.Location = new System.Drawing.Point(598, 72);
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.Size = new System.Drawing.Size(100, 20);
            this.txtLatitud.TabIndex = 1;
            // 
            // txtLongitud
            // 
            this.txtLongitud.Location = new System.Drawing.Point(598, 120);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(100, 20);
            this.txtLongitud.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(611, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Latitud";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Longitud";
            // 
            // btnComoLlegar
            // 
            this.btnComoLlegar.Location = new System.Drawing.Point(614, 202);
            this.btnComoLlegar.Name = "btnComoLlegar";
            this.btnComoLlegar.Size = new System.Drawing.Size(123, 38);
            this.btnComoLlegar.TabIndex = 5;
            this.btnComoLlegar.Text = "Como llegar";
            this.btnComoLlegar.UseVisualStyleBackColor = true;
            this.btnComoLlegar.Click += new System.EventHandler(this.btnComoLlegar_Click);
            // 
            // btnCrearRuta
            // 
            this.btnCrearRuta.Location = new System.Drawing.Point(614, 266);
            this.btnCrearRuta.Name = "btnCrearRuta";
            this.btnCrearRuta.Size = new System.Drawing.Size(123, 33);
            this.btnCrearRuta.TabIndex = 6;
            this.btnCrearRuta.Text = "Crear ruta";
            this.btnCrearRuta.UseVisualStyleBackColor = true;
            this.btnCrearRuta.Click += new System.EventHandler(this.btnCrearRuta_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(743, 266);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(73, 33);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 450);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCrearRuta);
            this.Controls.Add(this.btnComoLlegar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLongitud);
            this.Controls.Add(this.txtLatitud);
            this.Controls.Add(this.gMapControllador);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControllador;
        private System.Windows.Forms.TextBox txtLatitud;
        private System.Windows.Forms.TextBox txtLongitud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnComoLlegar;
        private System.Windows.Forms.Button btnCrearRuta;
        private System.Windows.Forms.Button btnConfirmar;
    }
}