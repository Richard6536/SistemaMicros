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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnEditarRuta = new System.Windows.Forms.Button();
            this.btnCrearNueva = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirmarEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreEditRuta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRehacerRuta = new System.Windows.Forms.Button();
            this.btnDeshacerEdit = new System.Windows.Forms.Button();
            this.btnAceptarRutaEdit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAceptarRutaNueva = new System.Windows.Forms.Button();
            this.btnDeshacerRutaNueva = new System.Windows.Forms.Button();
            this.btnCrearRuta = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreNuevaRuta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConfirmarNuevaRuta = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(468, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(226, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // btnEditarRuta
            // 
            this.btnEditarRuta.Location = new System.Drawing.Point(468, 98);
            this.btnEditarRuta.Name = "btnEditarRuta";
            this.btnEditarRuta.Size = new System.Drawing.Size(226, 27);
            this.btnEditarRuta.TabIndex = 3;
            this.btnEditarRuta.Text = "Editar ruta";
            this.btnEditarRuta.UseVisualStyleBackColor = true;
            // 
            // btnCrearNueva
            // 
            this.btnCrearNueva.Location = new System.Drawing.Point(700, 71);
            this.btnCrearNueva.Name = "btnCrearNueva";
            this.btnCrearNueva.Size = new System.Drawing.Size(163, 54);
            this.btnCrearNueva.TabIndex = 4;
            this.btnCrearNueva.Text = "Crear nueva ruta";
            this.btnCrearNueva.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAceptarRutaEdit);
            this.panel1.Controls.Add(this.btnDeshacerEdit);
            this.panel1.Controls.Add(this.btnRehacerRuta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNombreEditRuta);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnConfirmarEdit);
            this.panel1.Location = new System.Drawing.Point(468, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 230);
            this.panel1.TabIndex = 5;
            // 
            // btnConfirmarEdit
            // 
            this.btnConfirmarEdit.Location = new System.Drawing.Point(20, 179);
            this.btnConfirmarEdit.Name = "btnConfirmarEdit";
            this.btnConfirmarEdit.Size = new System.Drawing.Size(344, 38);
            this.btnConfirmarEdit.TabIndex = 0;
            this.btnConfirmarEdit.Text = "Confirmar";
            this.btnConfirmarEdit.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Edición";
            // 
            // txtNombreEditRuta
            // 
            this.txtNombreEditRuta.Location = new System.Drawing.Point(164, 32);
            this.txtNombreEditRuta.Name = "txtNombreEditRuta";
            this.txtNombreEditRuta.Size = new System.Drawing.Size(200, 20);
            this.txtNombreEditRuta.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Editar nombre";
            // 
            // btnRehacerRuta
            // 
            this.btnRehacerRuta.Location = new System.Drawing.Point(20, 74);
            this.btnRehacerRuta.Name = "btnRehacerRuta";
            this.btnRehacerRuta.Size = new System.Drawing.Size(157, 99);
            this.btnRehacerRuta.TabIndex = 6;
            this.btnRehacerRuta.Text = "Rehacer ruta";
            this.btnRehacerRuta.UseVisualStyleBackColor = true;
            // 
            // btnDeshacerEdit
            // 
            this.btnDeshacerEdit.Location = new System.Drawing.Point(183, 74);
            this.btnDeshacerEdit.Name = "btnDeshacerEdit";
            this.btnDeshacerEdit.Size = new System.Drawing.Size(71, 46);
            this.btnDeshacerEdit.TabIndex = 7;
            this.btnDeshacerEdit.Text = "Deshacer";
            this.btnDeshacerEdit.UseVisualStyleBackColor = true;
            // 
            // btnAceptarRutaEdit
            // 
            this.btnAceptarRutaEdit.Location = new System.Drawing.Point(183, 126);
            this.btnAceptarRutaEdit.Name = "btnAceptarRutaEdit";
            this.btnAceptarRutaEdit.Size = new System.Drawing.Size(71, 47);
            this.btnAceptarRutaEdit.TabIndex = 8;
            this.btnAceptarRutaEdit.Text = "Aceptar";
            this.btnAceptarRutaEdit.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAceptarRutaNueva);
            this.panel2.Controls.Add(this.btnDeshacerRutaNueva);
            this.panel2.Controls.Add(this.btnCrearRuta);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtNombreNuevaRuta);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnConfirmarNuevaRuta);
            this.panel2.Location = new System.Drawing.Point(470, 364);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 230);
            this.panel2.TabIndex = 9;
            // 
            // btnAceptarRutaNueva
            // 
            this.btnAceptarRutaNueva.Location = new System.Drawing.Point(183, 126);
            this.btnAceptarRutaNueva.Name = "btnAceptarRutaNueva";
            this.btnAceptarRutaNueva.Size = new System.Drawing.Size(71, 47);
            this.btnAceptarRutaNueva.TabIndex = 8;
            this.btnAceptarRutaNueva.Text = "Aceptar";
            this.btnAceptarRutaNueva.UseVisualStyleBackColor = true;
            // 
            // btnDeshacerRutaNueva
            // 
            this.btnDeshacerRutaNueva.Location = new System.Drawing.Point(183, 74);
            this.btnDeshacerRutaNueva.Name = "btnDeshacerRutaNueva";
            this.btnDeshacerRutaNueva.Size = new System.Drawing.Size(71, 46);
            this.btnDeshacerRutaNueva.TabIndex = 7;
            this.btnDeshacerRutaNueva.Text = "Deshacer";
            this.btnDeshacerRutaNueva.UseVisualStyleBackColor = true;
            // 
            // btnCrearRuta
            // 
            this.btnCrearRuta.Location = new System.Drawing.Point(20, 74);
            this.btnCrearRuta.Name = "btnCrearRuta";
            this.btnCrearRuta.Size = new System.Drawing.Size(157, 99);
            this.btnCrearRuta.TabIndex = 6;
            this.btnCrearRuta.Text = "Crear/Rehacer ruta";
            this.btnCrearRuta.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre de ruta";
            // 
            // txtNombreNuevaRuta
            // 
            this.txtNombreNuevaRuta.Location = new System.Drawing.Point(164, 32);
            this.txtNombreNuevaRuta.Name = "txtNombreNuevaRuta";
            this.txtNombreNuevaRuta.Size = new System.Drawing.Size(200, 20);
            this.txtNombreNuevaRuta.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nueva ruta";
            // 
            // btnConfirmarNuevaRuta
            // 
            this.btnConfirmarNuevaRuta.Location = new System.Drawing.Point(20, 179);
            this.btnConfirmarNuevaRuta.Name = "btnConfirmarNuevaRuta";
            this.btnConfirmarNuevaRuta.Size = new System.Drawing.Size(344, 38);
            this.btnConfirmarNuevaRuta.TabIndex = 0;
            this.btnConfirmarNuevaRuta.Text = "Confirmar";
            this.btnConfirmarNuevaRuta.UseVisualStyleBackColor = true;
            // 
            // AdminRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 606);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCrearNueva);
            this.Controls.Add(this.btnEditarRuta);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gmapController);
            this.Name = "AdminRutas";
            this.Text = "AdminRutas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmapController;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnEditarRuta;
        private System.Windows.Forms.Button btnCrearNueva;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAceptarRutaEdit;
        private System.Windows.Forms.Button btnDeshacerEdit;
        private System.Windows.Forms.Button btnRehacerRuta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreEditRuta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirmarEdit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAceptarRutaNueva;
        private System.Windows.Forms.Button btnDeshacerRutaNueva;
        private System.Windows.Forms.Button btnCrearRuta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreNuevaRuta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConfirmarNuevaRuta;
    }
}