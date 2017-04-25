namespace MicrosForms.Ventanas.Ediciones
{
    partial class EditarMicrosDeLinea
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
            this.datagridMicros = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMicros = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreChofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Historial = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Remover = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLinea = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridMicros)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridMicros
            // 
            this.datagridMicros.AllowUserToAddRows = false;
            this.datagridMicros.AllowUserToDeleteRows = false;
            this.datagridMicros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridMicros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Patente,
            this.Calificacion,
            this.NombreChofer,
            this.Historial,
            this.Remover});
            this.datagridMicros.Location = new System.Drawing.Point(28, 157);
            this.datagridMicros.Name = "datagridMicros";
            this.datagridMicros.ReadOnly = true;
            this.datagridMicros.Size = new System.Drawing.Size(570, 212);
            this.datagridMicros.TabIndex = 0;
            this.datagridMicros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridMicros_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agregar nueva micro a la línea";
            // 
            // cmbMicros
            // 
            this.cmbMicros.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMicros.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMicros.FormattingEnabled = true;
            this.cmbMicros.Location = new System.Drawing.Point(28, 114);
            this.cmbMicros.Name = "cmbMicros";
            this.cmbMicros.Size = new System.Drawing.Size(149, 21);
            this.cmbMicros.TabIndex = 2;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(183, 114);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(89, 21);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // Patente
            // 
            this.Patente.HeaderText = "Patente";
            this.Patente.Name = "Patente";
            this.Patente.ReadOnly = true;
            // 
            // Calificacion
            // 
            this.Calificacion.HeaderText = "Calificación";
            this.Calificacion.Name = "Calificacion";
            this.Calificacion.ReadOnly = true;
            // 
            // NombreChofer
            // 
            this.NombreChofer.HeaderText = "Nombre de chofer";
            this.NombreChofer.Name = "NombreChofer";
            this.NombreChofer.ReadOnly = true;
            // 
            // Historial
            // 
            this.Historial.HeaderText = "Historial";
            this.Historial.Name = "Historial";
            this.Historial.ReadOnly = true;
            this.Historial.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Historial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Remover
            // 
            this.Remover.HeaderText = "Desligar de línea";
            this.Remover.Name = "Remover";
            this.Remover.ReadOnly = true;
            this.Remover.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remover.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(249, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Línea:";
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinea.Location = new System.Drawing.Point(322, 26);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(47, 24);
            this.lblLinea.TabIndex = 5;
            this.lblLinea.Text = "Asdf";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(439, 107);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(159, 35);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // EditarMicrosDeLinea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 418);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cmbMicros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagridMicros);
            this.Name = "EditarMicrosDeLinea";
            this.Text = "EditarMicrosDeLinea";
            ((System.ComponentModel.ISupportInitialize)(this.datagridMicros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridMicros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreChofer;
        private System.Windows.Forms.DataGridViewButtonColumn Historial;
        private System.Windows.Forms.DataGridViewButtonColumn Remover;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMicros;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.Button btnVolver;
    }
}