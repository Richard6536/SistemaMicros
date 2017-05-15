namespace MicrosForms.Ventanas.Historiales
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
            this.lblPatente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datagridHistorial = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kilometros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalificacionesRecibidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalificacionDiaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroPasajeros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroIdaVueltas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HIstorialesIdaVuelta = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.datePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.datePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.btnMostrarTodas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(757, 39);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(50, 13);
            this.lblPatente.TabIndex = 9;
            this.lblPatente.Text = "asdf-asfd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(673, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Patente micro: ";
            // 
            // datagridHistorial
            // 
            this.datagridHistorial.AllowUserToAddRows = false;
            this.datagridHistorial.AllowUserToDeleteRows = false;
            this.datagridHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Chofer,
            this.HoraInicio,
            this.HoraFinal,
            this.Kilometros,
            this.CalificacionesRecibidas,
            this.CalificacionDiaria,
            this.NumeroPasajeros,
            this.NumeroIdaVueltas,
            this.HIstorialesIdaVuelta});
            this.datagridHistorial.Location = new System.Drawing.Point(12, 107);
            this.datagridHistorial.Name = "datagridHistorial";
            this.datagridHistorial.ReadOnly = true;
            this.datagridHistorial.Size = new System.Drawing.Size(851, 341);
            this.datagridHistorial.TabIndex = 5;
            this.datagridHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridHistorial_CellContentClick);
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Chofer
            // 
            this.Chofer.HeaderText = "Nombre Chofer";
            this.Chofer.Name = "Chofer";
            this.Chofer.ReadOnly = true;
            // 
            // HoraInicio
            // 
            this.HoraInicio.HeaderText = "Hora de inicio";
            this.HoraInicio.Name = "HoraInicio";
            this.HoraInicio.ReadOnly = true;
            this.HoraInicio.Width = 70;
            // 
            // HoraFinal
            // 
            this.HoraFinal.HeaderText = "Hora de final";
            this.HoraFinal.Name = "HoraFinal";
            this.HoraFinal.ReadOnly = true;
            this.HoraFinal.Width = 70;
            // 
            // Kilometros
            // 
            this.Kilometros.HeaderText = "Kilometros recorridos";
            this.Kilometros.Name = "Kilometros";
            this.Kilometros.ReadOnly = true;
            this.Kilometros.Width = 70;
            // 
            // CalificacionesRecibidas
            // 
            this.CalificacionesRecibidas.HeaderText = "Calificaciones recibidas";
            this.CalificacionesRecibidas.Name = "CalificacionesRecibidas";
            this.CalificacionesRecibidas.ReadOnly = true;
            this.CalificacionesRecibidas.Width = 70;
            // 
            // CalificacionDiaria
            // 
            this.CalificacionDiaria.HeaderText = "Calificación del día";
            this.CalificacionDiaria.Name = "CalificacionDiaria";
            this.CalificacionDiaria.ReadOnly = true;
            this.CalificacionDiaria.Width = 70;
            // 
            // NumeroPasajeros
            // 
            this.NumeroPasajeros.HeaderText = "Número de pasajeros";
            this.NumeroPasajeros.Name = "NumeroPasajeros";
            this.NumeroPasajeros.ReadOnly = true;
            this.NumeroPasajeros.Width = 70;
            // 
            // NumeroIdaVueltas
            // 
            this.NumeroIdaVueltas.HeaderText = "Número de recorridos hechos";
            this.NumeroIdaVueltas.Name = "NumeroIdaVueltas";
            this.NumeroIdaVueltas.ReadOnly = true;
            this.NumeroIdaVueltas.Width = 70;
            // 
            // HIstorialesIdaVuelta
            // 
            this.HIstorialesIdaVuelta.HeaderText = "Historiales de recorrido";
            this.HIstorialesIdaVuelta.Name = "HIstorialesIdaVuelta";
            this.HIstorialesIdaVuelta.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Historiales diarios";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(310, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 46;
            this.label5.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "Desde";
            // 
            // datePickerHasta
            // 
            this.datePickerHasta.Location = new System.Drawing.Point(357, 65);
            this.datePickerHasta.Name = "datePickerHasta";
            this.datePickerHasta.Size = new System.Drawing.Size(218, 20);
            this.datePickerHasta.TabIndex = 44;
            this.datePickerHasta.ValueChanged += new System.EventHandler(this.datePickerHasta_ValueChanged);
            // 
            // datePickerDesde
            // 
            this.datePickerDesde.Location = new System.Drawing.Point(68, 67);
            this.datePickerDesde.Name = "datePickerDesde";
            this.datePickerDesde.Size = new System.Drawing.Size(220, 20);
            this.datePickerDesde.TabIndex = 43;
            this.datePickerDesde.ValueChanged += new System.EventHandler(this.datePickerDesde_ValueChanged);
            // 
            // btnMostrarTodas
            // 
            this.btnMostrarTodas.Location = new System.Drawing.Point(229, 29);
            this.btnMostrarTodas.Name = "btnMostrarTodas";
            this.btnMostrarTodas.Size = new System.Drawing.Size(239, 23);
            this.btnMostrarTodas.TabIndex = 47;
            this.btnMostrarTodas.Text = "Actualizar/Mostrar todas";
            this.btnMostrarTodas.UseVisualStyleBackColor = true;
            this.btnMostrarTodas.Click += new System.EventHandler(this.btnMostrarTodas_Click);
            // 
            // HistorialDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 460);
            this.Controls.Add(this.btnMostrarTodas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.datePickerHasta);
            this.Controls.Add(this.datePickerDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPatente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datagridHistorial);
            this.Name = "HistorialDiario";
            this.Text = "HistorialDiario";
            ((System.ComponentModel.ISupportInitialize)(this.datagridHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView datagridHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chofer;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kilometros;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalificacionesRecibidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalificacionDiaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPasajeros;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroIdaVueltas;
        private System.Windows.Forms.DataGridViewButtonColumn HIstorialesIdaVuelta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker datePickerHasta;
        private System.Windows.Forms.DateTimePicker datePickerDesde;
        private System.Windows.Forms.Button btnMostrarTodas;
    }
}