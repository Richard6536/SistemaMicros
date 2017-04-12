namespace MicrosForms.Ventanas
{
    partial class AdminUsuarios
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
            this.btnCrearAdmin = new System.Windows.Forms.Button();
            this.btnCrearChofer = new System.Windows.Forms.Button();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.VerMicro = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Email,
            this.Rol,
            this.VerMicro});
            this.dataGridView1.Location = new System.Drawing.Point(12, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(457, 290);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnCrearAdmin
            // 
            this.btnCrearAdmin.Location = new System.Drawing.Point(531, 71);
            this.btnCrearAdmin.Name = "btnCrearAdmin";
            this.btnCrearAdmin.Size = new System.Drawing.Size(163, 40);
            this.btnCrearAdmin.TabIndex = 1;
            this.btnCrearAdmin.Text = "Crear nuevo administrador";
            this.btnCrearAdmin.UseVisualStyleBackColor = true;
            // 
            // btnCrearChofer
            // 
            this.btnCrearChofer.Location = new System.Drawing.Point(531, 140);
            this.btnCrearChofer.Name = "btnCrearChofer";
            this.btnCrearChofer.Size = new System.Drawing.Size(163, 40);
            this.btnCrearChofer.TabIndex = 2;
            this.btnCrearChofer.Text = "Crear nuevo chofer";
            this.btnCrearChofer.UseVisualStyleBackColor = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Email
            // 
            this.Email.HeaderText = "E-Mail";
            this.Email.Name = "Email";
            // 
            // Rol
            // 
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // VerMicro
            // 
            this.VerMicro.HeaderText = "Ver micro";
            this.VerMicro.Name = "VerMicro";
            // 
            // AdminUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 373);
            this.Controls.Add(this.btnCrearChofer);
            this.Controls.Add(this.btnCrearAdmin);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AdminUsuarios";
            this.Text = "AdminUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewComboBoxColumn Rol;
        private System.Windows.Forms.DataGridViewButtonColumn VerMicro;
        private System.Windows.Forms.Button btnCrearAdmin;
        private System.Windows.Forms.Button btnCrearChofer;
    }
}