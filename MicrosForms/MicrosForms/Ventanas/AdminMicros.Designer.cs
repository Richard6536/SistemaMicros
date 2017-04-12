namespace MicrosForms.Ventanas
{
    partial class AdminMicros
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCrearMicro = new System.Windows.Forms.Button();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HayChofer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VerChofer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.VerHistorial = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Patente,
            this.Linea,
            this.Clasificacion,
            this.HayChofer,
            this.VerChofer,
            this.VerHistorial,
            this.Editar});
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(670, 301);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnCrearMicro
            // 
            this.btnCrearMicro.Location = new System.Drawing.Point(710, 59);
            this.btnCrearMicro.Name = "btnCrearMicro";
            this.btnCrearMicro.Size = new System.Drawing.Size(150, 54);
            this.btnCrearMicro.TabIndex = 1;
            this.btnCrearMicro.Text = "Crear nueva micro";
            this.btnCrearMicro.UseVisualStyleBackColor = true;
            // 
            // Patente
            // 
            this.Patente.HeaderText = "Patente";
            this.Patente.Name = "Patente";
            this.Patente.Width = 70;
            // 
            // Linea
            // 
            this.Linea.HeaderText = "Linea";
            this.Linea.Name = "Linea";
            this.Linea.Width = 70;
            // 
            // Clasificacion
            // 
            this.Clasificacion.HeaderText = "Clasificacion";
            this.Clasificacion.Name = "Clasificacion";
            this.Clasificacion.Width = 70;
            // 
            // HayChofer
            // 
            this.HayChofer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.HayChofer.HeaderText = "¿Chofer asignado?";
            this.HayChofer.Name = "HayChofer";
            this.HayChofer.Width = 92;
            // 
            // VerChofer
            // 
            this.VerChofer.HeaderText = "Chofer";
            this.VerChofer.Name = "VerChofer";
            this.VerChofer.Text = "Ver chofer";
            // 
            // VerHistorial
            // 
            this.VerHistorial.HeaderText = "Historial";
            this.VerHistorial.Name = "VerHistorial";
            this.VerHistorial.Text = "Ver historial";
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.Text = "Editar datos";
            // 
            // AdminMicros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 392);
            this.Controls.Add(this.btnCrearMicro);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AdminMicros";
            this.Text = "AdminMicros";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clasificacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HayChofer;
        private System.Windows.Forms.DataGridViewButtonColumn VerChofer;
        private System.Windows.Forms.DataGridViewButtonColumn VerHistorial;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.Button btnCrearMicro;
    }
}