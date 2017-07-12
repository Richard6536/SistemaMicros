namespace MicrosFormsGX.Ventanas.Historiales
{
    partial class HistorialDiario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialDiario));
            this.datagridHistorial = new MetroFramework.Controls.MetroGrid();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreChofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kilometros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calificaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalificacionDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pasajeros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroRecorridos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistorialesRecorrido = new System.Windows.Forms.DataGridViewButtonColumn();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.datePickerDesde = new MetroFramework.Controls.MetroDateTime();
            this.datePickerHasta = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnMostrarTodas = new MetroFramework.Controls.MetroTile();
            this.btnVolver = new MetroFramework.Controls.MetroTile();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lblPatente = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.datagridHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridHistorial
            // 
            this.datagridHistorial.AllowUserToAddRows = false;
            this.datagridHistorial.AllowUserToDeleteRows = false;
            this.datagridHistorial.AllowUserToResizeRows = false;
            this.datagridHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridHistorial.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.datagridHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridHistorial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datagridHistorial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.NombreChofer,
            this.HoraInicio,
            this.HoraFin,
            this.Kilometros,
            this.Calificaciones,
            this.CalificacionDia,
            this.Pasajeros,
            this.NumeroRecorridos,
            this.HistorialesRecorrido});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridHistorial.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagridHistorial.EnableHeadersVisualStyles = false;
            this.datagridHistorial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.datagridHistorial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.datagridHistorial.Location = new System.Drawing.Point(23, 136);
            this.datagridHistorial.Name = "datagridHistorial";
            this.datagridHistorial.ReadOnly = true;
            this.datagridHistorial.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridHistorial.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datagridHistorial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagridHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridHistorial.Size = new System.Drawing.Size(922, 481);
            this.datagridHistorial.Style = MetroFramework.MetroColorStyle.Green;
            this.datagridHistorial.TabIndex = 0;
            this.datagridHistorial.UseStyleColors = true;
            this.datagridHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridHistorial_CellContentClick);
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // NombreChofer
            // 
            this.NombreChofer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreChofer.HeaderText = "Nombre de chofer";
            this.NombreChofer.Name = "NombreChofer";
            this.NombreChofer.ReadOnly = true;
            // 
            // HoraInicio
            // 
            this.HoraInicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoraInicio.HeaderText = "Hora de inicio";
            this.HoraInicio.Name = "HoraInicio";
            this.HoraInicio.ReadOnly = true;
            // 
            // HoraFin
            // 
            this.HoraFin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoraFin.HeaderText = "Hora de término";
            this.HoraFin.Name = "HoraFin";
            this.HoraFin.ReadOnly = true;
            // 
            // Kilometros
            // 
            this.Kilometros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kilometros.HeaderText = "Kilometros recorridos";
            this.Kilometros.Name = "Kilometros";
            this.Kilometros.ReadOnly = true;
            // 
            // Calificaciones
            // 
            this.Calificaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Calificaciones.HeaderText = "Calificaciones recibidas";
            this.Calificaciones.Name = "Calificaciones";
            this.Calificaciones.ReadOnly = true;
            // 
            // CalificacionDia
            // 
            this.CalificacionDia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CalificacionDia.HeaderText = "Calificación del día";
            this.CalificacionDia.Name = "CalificacionDia";
            this.CalificacionDia.ReadOnly = true;
            // 
            // Pasajeros
            // 
            this.Pasajeros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pasajeros.HeaderText = "Número de pasajeros";
            this.Pasajeros.Name = "Pasajeros";
            this.Pasajeros.ReadOnly = true;
            // 
            // NumeroRecorridos
            // 
            this.NumeroRecorridos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumeroRecorridos.HeaderText = "Número de recorridos hechos";
            this.NumeroRecorridos.Name = "NumeroRecorridos";
            this.NumeroRecorridos.ReadOnly = true;
            // 
            // HistorialesRecorrido
            // 
            this.HistorialesRecorrido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HistorialesRecorrido.HeaderText = "Historiales de recorrido";
            this.HistorialesRecorrido.Name = "HistorialesRecorrido";
            this.HistorialesRecorrido.ReadOnly = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(296, 111);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(54, 19);
            this.metroLabel1.TabIndex = 32;
            this.metroLabel1.Text = "Desde:";
            // 
            // datePickerDesde
            // 
            this.datePickerDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerDesde.Location = new System.Drawing.Point(356, 101);
            this.datePickerDesde.MinimumSize = new System.Drawing.Size(0, 29);
            this.datePickerDesde.Name = "datePickerDesde";
            this.datePickerDesde.Size = new System.Drawing.Size(200, 29);
            this.datePickerDesde.Style = MetroFramework.MetroColorStyle.Green;
            this.datePickerDesde.TabIndex = 33;
            this.datePickerDesde.UseStyleColors = true;
            this.datePickerDesde.ValueChanged += new System.EventHandler(this.datePickerDesde_ValueChanged);
            // 
            // datePickerHasta
            // 
            this.datePickerHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerHasta.Location = new System.Drawing.Point(619, 101);
            this.datePickerHasta.MinimumSize = new System.Drawing.Size(0, 29);
            this.datePickerHasta.Name = "datePickerHasta";
            this.datePickerHasta.Size = new System.Drawing.Size(200, 29);
            this.datePickerHasta.Style = MetroFramework.MetroColorStyle.Green;
            this.datePickerHasta.TabIndex = 34;
            this.datePickerHasta.UseStyleColors = true;
            this.datePickerHasta.ValueChanged += new System.EventHandler(this.datePickerHasta_ValueChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(562, 111);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(51, 19);
            this.metroLabel2.TabIndex = 35;
            this.metroLabel2.Text = "Hasta:";
            // 
            // btnMostrarTodas
            // 
            this.btnMostrarTodas.ActiveControl = null;
            this.btnMostrarTodas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMostrarTodas.Location = new System.Drawing.Point(825, 63);
            this.btnMostrarTodas.Name = "btnMostrarTodas";
            this.btnMostrarTodas.Size = new System.Drawing.Size(120, 67);
            this.btnMostrarTodas.Style = MetroFramework.MetroColorStyle.Green;
            this.btnMostrarTodas.TabIndex = 37;
            this.btnMostrarTodas.Text = "Recargar";
            this.btnMostrarTodas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMostrarTodas.TileImage = ((System.Drawing.Image)(resources.GetObject("btnMostrarTodas.TileImage")));
            this.btnMostrarTodas.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMostrarTodas.UseSelectable = true;
            this.btnMostrarTodas.UseStyleColors = true;
            this.btnMostrarTodas.UseTileImage = true;
            this.btnMostrarTodas.Click += new System.EventHandler(this.btnMostrarTodas_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.ActiveControl = null;
            this.btnVolver.Location = new System.Drawing.Point(23, 63);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(120, 67);
            this.btnVolver.Style = MetroFramework.MetroColorStyle.Green;
            this.btnVolver.TabIndex = 38;
            this.btnVolver.Text = "Volver atrás";
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVolver.TileImage = ((System.Drawing.Image)(resources.GetObject("btnVolver.TileImage")));
            this.btnVolver.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVolver.UseSelectable = true;
            this.btnVolver.UseStyleColors = true;
            this.btnVolver.UseTileImage = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(356, 60);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(83, 25);
            this.metroLabel3.TabIndex = 39;
            this.metroLabel3.Text = "Patente:";
            // 
            // lblPatente
            // 
            this.lblPatente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatente.AutoSize = true;
            this.lblPatente.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPatente.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPatente.Location = new System.Drawing.Point(445, 60);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(72, 25);
            this.lblPatente.TabIndex = 40;
            this.lblPatente.Text = "111222";
            // 
            // HistorialDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 640);
            this.Controls.Add(this.lblPatente);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnMostrarTodas);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.datePickerHasta);
            this.Controls.Add(this.datePickerDesde);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.datagridHistorial);
            this.MinimumSize = new System.Drawing.Size(824, 364);
            this.Name = "HistorialDiario";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Historiales diarios";
            this.Activated += new System.EventHandler(this.HistorialDiario_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.datagridHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid datagridHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreChofer;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kilometros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calificaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalificacionDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pasajeros;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroRecorridos;
        private System.Windows.Forms.DataGridViewButtonColumn HistorialesRecorrido;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime datePickerDesde;
        private MetroFramework.Controls.MetroDateTime datePickerHasta;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile btnMostrarTodas;
        private MetroFramework.Controls.MetroTile btnVolver;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lblPatente;
    }
}