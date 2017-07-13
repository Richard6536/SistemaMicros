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
            this.btnIniciarRecorrido = new System.Windows.Forms.Button();
            this.btnDetenerRecorrido = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSigVertice = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSigParadero = new System.Windows.Forms.Label();
            this.lblMicroPatente = new System.Windows.Forms.Label();
            this.lblMicroId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gmapController
            // 
            this.gmapController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.gmapController.Size = new System.Drawing.Size(692, 503);
            this.gmapController.TabIndex = 9;
            this.gmapController.Zoom = 0D;
            this.gmapController.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmapController_OnMarkerClick);
            this.gmapController.MouseLeave += new System.EventHandler(this.gmapController_MouseLeave);
            this.gmapController.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gmapController_MouseMove);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(730, 158);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(154, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(727, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "E-mail";
            // 
            // btnTomarControl
            // 
            this.btnTomarControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTomarControl.Location = new System.Drawing.Point(730, 184);
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
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(727, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Linea a mostrar";
            // 
            // cmbLineas
            // 
            this.cmbLineas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLineas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLineas.FormattingEnabled = true;
            this.cmbLineas.Location = new System.Drawing.Point(730, 54);
            this.cmbLineas.Name = "cmbLineas";
            this.cmbLineas.Size = new System.Drawing.Size(154, 21);
            this.cmbLineas.TabIndex = 15;
            this.cmbLineas.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnBorrarLinea
            // 
            this.btnBorrarLinea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrarLinea.Location = new System.Drawing.Point(730, 82);
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
            this.label3.Location = new System.Drawing.Point(21, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Moviendo a: ";
            // 
            // lblUserMoviendo
            // 
            this.lblUserMoviendo.AutoSize = true;
            this.lblUserMoviendo.Location = new System.Drawing.Point(96, 16);
            this.lblUserMoviendo.Name = "lblUserMoviendo";
            this.lblUserMoviendo.Size = new System.Drawing.Size(29, 13);
            this.lblUserMoviendo.TabIndex = 18;
            this.lblUserMoviendo.Text = "User";
            // 
            // btnDetenerTodo
            // 
            this.btnDetenerTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetenerTodo.Location = new System.Drawing.Point(730, 451);
            this.btnDetenerTodo.Name = "btnDetenerTodo";
            this.btnDetenerTodo.Size = new System.Drawing.Size(154, 37);
            this.btnDetenerTodo.TabIndex = 19;
            this.btnDetenerTodo.Text = "Detener Todos los usuarios";
            this.btnDetenerTodo.UseVisualStyleBackColor = true;
            this.btnDetenerTodo.Click += new System.EventHandler(this.btnDetenerTodo_Click);
            // 
            // btnIniciarRecorrido
            // 
            this.btnIniciarRecorrido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIniciarRecorrido.Location = new System.Drawing.Point(730, 213);
            this.btnIniciarRecorrido.Name = "btnIniciarRecorrido";
            this.btnIniciarRecorrido.Size = new System.Drawing.Size(154, 23);
            this.btnIniciarRecorrido.TabIndex = 20;
            this.btnIniciarRecorrido.Text = "Transmitir Posicion";
            this.btnIniciarRecorrido.UseVisualStyleBackColor = true;
            this.btnIniciarRecorrido.Click += new System.EventHandler(this.btnIniciarRecorrido_Click);
            // 
            // btnDetenerRecorrido
            // 
            this.btnDetenerRecorrido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetenerRecorrido.Location = new System.Drawing.Point(730, 242);
            this.btnDetenerRecorrido.Name = "btnDetenerRecorrido";
            this.btnDetenerRecorrido.Size = new System.Drawing.Size(154, 23);
            this.btnDetenerRecorrido.TabIndex = 21;
            this.btnDetenerRecorrido.Text = "Detener transmisión";
            this.btnDetenerRecorrido.UseVisualStyleBackColor = true;
            this.btnDetenerRecorrido.Click += new System.EventHandler(this.btnDetenerRecorrido_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblSigVertice);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblSigParadero);
            this.panel1.Controls.Add(this.lblMicroPatente);
            this.panel1.Controls.Add(this.lblMicroId);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblUserMoviendo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(731, 286);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 138);
            this.panel1.TabIndex = 22;
            // 
            // lblSigVertice
            // 
            this.lblSigVertice.AutoSize = true;
            this.lblSigVertice.Location = new System.Drawing.Point(95, 111);
            this.lblSigVertice.Name = "lblSigVertice";
            this.lblSigVertice.Size = new System.Drawing.Size(16, 13);
            this.lblSigVertice.TabIndex = 26;
            this.lblSigVertice.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Sig. Vertice:";
            // 
            // lblSigParadero
            // 
            this.lblSigParadero.AutoSize = true;
            this.lblSigParadero.Location = new System.Drawing.Point(95, 88);
            this.lblSigParadero.Name = "lblSigParadero";
            this.lblSigParadero.Size = new System.Drawing.Size(16, 13);
            this.lblSigParadero.TabIndex = 24;
            this.lblSigParadero.Text = "---";
            // 
            // lblMicroPatente
            // 
            this.lblMicroPatente.AutoSize = true;
            this.lblMicroPatente.Location = new System.Drawing.Point(96, 66);
            this.lblMicroPatente.Name = "lblMicroPatente";
            this.lblMicroPatente.Size = new System.Drawing.Size(16, 13);
            this.lblMicroPatente.TabIndex = 23;
            this.lblMicroPatente.Text = "---";
            // 
            // lblMicroId
            // 
            this.lblMicroId.AutoSize = true;
            this.lblMicroId.Location = new System.Drawing.Point(96, 44);
            this.lblMicroId.Name = "lblMicroId";
            this.lblMicroId.Size = new System.Drawing.Size(16, 13);
            this.lblMicroId.TabIndex = 22;
            this.lblMicroId.Text = "---";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Sig. Paradero:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Micro patente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Micro id:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 547);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDetenerRecorrido);
            this.Controls.Add(this.btnIniciarRecorrido);
            this.Controls.Add(this.btnDetenerTodo);
            this.Controls.Add(this.btnBorrarLinea);
            this.Controls.Add(this.cmbLineas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTomarControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.gmapController);
            this.Name = "Form1";
            this.Text = "Position tester";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button btnIniciarRecorrido;
        private System.Windows.Forms.Button btnDetenerRecorrido;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSigParadero;
        private System.Windows.Forms.Label lblMicroPatente;
        private System.Windows.Forms.Label lblMicroId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSigVertice;
        private System.Windows.Forms.Label label7;
    }
}

