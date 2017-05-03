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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
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
            ((System.ComponentModel.ISupportInitialize)(this.datagridHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(415, 69);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(50, 13);
            this.lblPatente.TabIndex = 9;
            this.lblPatente.Text = "asdf-asfd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Patente micro: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filtrar por fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 69);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
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
            this.datagridHistorial.Size = new System.Drawing.Size(851, 257);
            this.datagridHistorial.TabIndex = 5;
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
            this.label3.Location = new System.Drawing.Point(334, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Historiales diarios";
            // 
            // HistorialDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 387);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPatente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
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
    }
}