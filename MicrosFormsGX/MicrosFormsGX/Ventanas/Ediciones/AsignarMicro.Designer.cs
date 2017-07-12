namespace MicrosFormsGX.Ventanas.Ediciones
{
    partial class AsignarMicro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignarMicro));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnCancelar = new MetroFramework.Controls.MetroTile();
            this.btnAceptar = new MetroFramework.Controls.MetroTile();
            this.cmbMicros = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(116, 98);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(220, 19);
            this.metroLabel1.TabIndex = 26;
            this.metroLabel1.Text = "Patentes de micros disponibles:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ActiveControl = null;
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(23, 193);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(147, 84);
            this.btnCancelar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.TileImage")));
            this.btnCancelar.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.UseStyleColors = true;
            this.btnCancelar.UseTileImage = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ActiveControl = null;
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(401, 193);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(147, 84);
            this.btnAceptar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAceptar.TabIndex = 28;
            this.btnAceptar.Text = "Guardar datos";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.TileImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.TileImage")));
            this.btnAceptar.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAceptar.UseSelectable = true;
            this.btnAceptar.UseStyleColors = true;
            this.btnAceptar.UseTileImage = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cmbMicros
            // 
            this.cmbMicros.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMicros.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMicros.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMicros.FormattingEnabled = true;
            this.cmbMicros.Location = new System.Drawing.Point(116, 120);
            this.cmbMicros.Name = "cmbMicros";
            this.cmbMicros.Size = new System.Drawing.Size(326, 28);
            this.cmbMicros.TabIndex = 30;
            this.cmbMicros.SelectedIndexChanged += new System.EventHandler(this.cmbMicros_SelectedIndexChanged);
            this.cmbMicros.TextChanged += new System.EventHandler(this.cmbMicros_TextChanged);
            // 
            // AsignarMicro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 300);
            this.Controls.Add(this.cmbMicros);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.metroLabel1);
            this.MaximumSize = new System.Drawing.Size(571, 300);
            this.MinimumSize = new System.Drawing.Size(571, 300);
            this.Name = "AsignarMicro";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Asignar micro";
            this.Activated += new System.EventHandler(this.AsignarMicro_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile btnCancelar;
        private MetroFramework.Controls.MetroTile btnAceptar;
        private System.Windows.Forms.ComboBox cmbMicros;
    }
}