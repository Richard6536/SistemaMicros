namespace PositionTester
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gmapController = new GMap.NET.WindowsForms.GMapControl();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTomarControl = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLineas = new System.Windows.Forms.ComboBox();
            this.btnBorrarLinea = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserMoviendo = new System.Windows.Forms.Label();
            this.btnDetenerTodo = new System.Windows.Forms.Button();
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
            this.gmapController.Size = new System.Drawing.Size(671, 456);
            this.gmapController.TabIndex = 9;
            this.gmapController.Zoom = 0D;
            this.gmapController.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmapController_OnMarkerClick);
            this.gmapController.MouseLeave += new System.EventHandler(this.gmapController_MouseLeave);
            this.gmapController.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gmapController_MouseMove);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(713, 158);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(154, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(710, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Email";
            // 
            // btnTomarControl
            // 
            this.btnTomarControl.Location = new System.Drawing.Point(713, 184);
            this.btnTomarControl.Name = "btnTomarControl";
            this.btnTomarControl.Size = new System.Drawing.Size(154, 23);
            this.btnTomarControl.TabIndex = 12;
            this.btnTomarControl.Text = "Añadir al mapa";
            this.btnTomarControl.UseVisualStyleBackColor = true;
            this.btnTomarControl.Click += new System.EventHandler(this.btnTomarControl_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(710, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Linea a mostrar";
            // 
            // cmbLineas
            // 
            this.cmbLineas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLineas.FormattingEnabled = true;
            this.cmbLineas.Location = new System.Drawing.Point(713, 54);
            this.cmbLineas.Name = "cmbLineas";
            this.cmbLineas.Size = new System.Drawing.Size(154, 21);
            this.cmbLineas.TabIndex = 15;
            this.cmbLineas.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnBorrarLinea
            // 
            this.btnBorrarLinea.Location = new System.Drawing.Point(713, 82);
            this.btnBorrarLinea.Name = "btnBorrarLinea";
            this.btnBorrarLinea.Size = new System.Drawing.Size(154, 23);
            this.btnBorrarLinea.TabIndex = 16;
            this.btnBorrarLinea.Text = "Borrar linea";
            this.btnBorrarLinea.UseVisualStyleBackColor = true;
            this.btnBorrarLinea.Click += new System.EventHandler(this.btnBorrarLinea_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Moviendo a: ";
            // 
            // lblUserMoviendo
            // 
            this.lblUserMoviendo.AutoSize = true;
            this.lblUserMoviendo.Location = new System.Drawing.Point(327, 7);
            this.lblUserMoviendo.Name = "lblUserMoviendo";
            this.lblUserMoviendo.Size = new System.Drawing.Size(29, 13);
            this.lblUserMoviendo.TabIndex = 18;
            this.lblUserMoviendo.Text = "User";
            // 
            // btnDetenerTodo
            // 
            this.btnDetenerTodo.Location = new System.Drawing.Point(713, 451);
            this.btnDetenerTodo.Name = "btnDetenerTodo";
            this.btnDetenerTodo.Size = new System.Drawing.Size(154, 37);
            this.btnDetenerTodo.TabIndex = 19;
            this.btnDetenerTodo.Text = "Detener Todos los usuarios";
            this.btnDetenerTodo.UseVisualStyleBackColor = true;
            this.btnDetenerTodo.Click += new System.EventHandler(this.btnDetenerTodo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 500);
            this.Controls.Add(this.btnDetenerTodo);
            this.Controls.Add(this.lblUserMoviendo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBorrarLinea);
            this.Controls.Add(this.cmbLineas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTomarControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.gmapController);
            this.Name = "Form1";
            this.Text = "Position tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmapController;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTomarControl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLineas;
        private System.Windows.Forms.Button btnBorrarLinea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserMoviendo;
        private System.Windows.Forms.Button btnDetenerTodo;
    }
}

