namespace MicrosForms.Ventanas.Historiales
{
    partial class HistorialesIdaVuelta
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
            this.datagridHistorial = new System.Windows.Forms.DataGridView();
            this.lblPatente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumeroRecorrido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuracionRecorrido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroPasajeros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistorialParaderos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridHistorial
            // 
            this.datagridHistorial.AllowUserToAddRows = false;
            this.datagridHistorial.AllowUserToDeleteRows = false;
            this.datagridHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroRecorrido,
            this.HoraInicio,
            this.HoraFin,
            this.DuracionRecorrido,
            this.NumeroPasajeros,
            this.HistorialParaderos});
            this.datagridHistorial.Location = new System.Drawing.Point(24, 123);
            this.datagridHistorial.Name = "datagridHistorial";
            this.datagridHistorial.ReadOnly = true;
            this.datagridHistorial.Size = new System.Drawing.Size(638, 242);
            this.datagridHistorial.TabIndex = 0;
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(127, 64);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(50, 13);
            this.lblPatente.TabIndex = 11;
            this.lblPatente.Text = "asdf-asfd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Patente micro: ";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(127, 92);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(65, 13);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "20/12/2020";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fecha";
            // 
            // NumeroRecorrido
            // 
            this.NumeroRecorrido.HeaderText = "Órden de recorridos hechos";
            this.NumeroRecorrido.Name = "NumeroRecorrido";
            this.NumeroRecorrido.ReadOnly = true;
            this.NumeroRecorrido.Width = 70;
            // 
            // HoraInicio
            // 
            this.HoraInicio.HeaderText = "Hora de inicio";
            this.HoraInicio.Name = "HoraInicio";
            this.HoraInicio.ReadOnly = true;
            // 
            // HoraFin
            // 
            this.HoraFin.HeaderText = "Hora de término";
            this.HoraFin.Name = "HoraFin";
            this.HoraFin.ReadOnly = true;
            // 
            // DuracionRecorrido
            // 
            this.DuracionRecorrido.HeaderText = "Duración del recorrido";
            this.DuracionRecorrido.Name = "DuracionRecorrido";
            this.DuracionRecorrido.ReadOnly = true;
            // 
            // NumeroPasajeros
            // 
            this.NumeroPasajeros.HeaderText = "Pasajeros transportados";
            this.NumeroPasajeros.Name = "NumeroPasajeros";
            this.NumeroPasajeros.ReadOnly = true;
            // 
            // HistorialParaderos
            // 
            this.HistorialParaderos.HeaderText = "Ver historial de paraderos";
            this.HistorialParaderos.Name = "HistorialParaderos";
            this.HistorialParaderos.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Historial de recorridos completados en el día";
            // 
            // HistorialesIdaVuelta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 413);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPatente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datagridHistorial);
            this.Name = "HistorialesIdaVuelta";
            this.Text = "HistorialesIdaVuelta";
            ((System.ComponentModel.ISupportInitialize)(this.datagridHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridHistorial;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroRecorrido;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuracionRecorrido;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPasajeros;
        private System.Windows.Forms.DataGridViewButtonColumn HistorialParaderos;
        private System.Windows.Forms.Label label1;
    }
}