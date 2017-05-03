namespace MicrosForms.Ventanas.Historiales
{
    partial class HistorialesParaderos
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
            this.NumeroParadero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiempoDetenido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDePasajeros = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.NumeroParadero,
            this.HoraLlegada,
            this.TiempoDetenido,
            this.NumeroDePasajeros});
            this.datagridHistorial.Location = new System.Drawing.Point(33, 74);
            this.datagridHistorial.Name = "datagridHistorial";
            this.datagridHistorial.ReadOnly = true;
            this.datagridHistorial.Size = new System.Drawing.Size(455, 278);
            this.datagridHistorial.TabIndex = 0;
            // 
            // NumeroParadero
            // 
            this.NumeroParadero.HeaderText = "Órden de paraderos";
            this.NumeroParadero.Name = "NumeroParadero";
            this.NumeroParadero.ReadOnly = true;
            // 
            // HoraLlegada
            // 
            this.HoraLlegada.HeaderText = "Hora de llegada";
            this.HoraLlegada.Name = "HoraLlegada";
            this.HoraLlegada.ReadOnly = true;
            // 
            // TiempoDetenido
            // 
            this.TiempoDetenido.HeaderText = "Tiempo detenido";
            this.TiempoDetenido.Name = "TiempoDetenido";
            this.TiempoDetenido.ReadOnly = true;
            // 
            // NumeroDePasajeros
            // 
            this.NumeroDePasajeros.HeaderText = "Pasajeros recibidos";
            this.NumeroDePasajeros.Name = "NumeroDePasajeros";
            this.NumeroDePasajeros.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Historiales de paraderos durante el recorrido";
            // 
            // HistorialesParaderos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 385);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagridHistorial);
            this.Name = "HistorialesParaderos";
            this.Text = "HistorialesParaderos";
            ((System.ComponentModel.ISupportInitialize)(this.datagridHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroParadero;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiempoDetenido;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDePasajeros;
        private System.Windows.Forms.Label label1;
    }
}