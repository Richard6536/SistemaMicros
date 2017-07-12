namespace MicrosFormsGX.Ventanas.Creaciones
{
    partial class CrearMicro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearMicro));
            this.btnCancelar = new MetroFramework.Controls.MetroTile();
            this.btnCrear = new MetroFramework.Controls.MetroTile();
            this.txtPatente = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cmbChofer = new System.Windows.Forms.ComboBox();
            this.cmbLinea = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.ActiveControl = null;
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(23, 226);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(147, 85);
            this.btnCancelar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.TileImage")));
            this.btnCancelar.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.UseStyleColors = true;
            this.btnCancelar.UseTileImage = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.ActiveControl = null;
            this.btnCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrear.Location = new System.Drawing.Point(454, 226);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(147, 85);
            this.btnCrear.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCrear.TabIndex = 3;
            this.btnCrear.Text = "Crear";
            this.btnCrear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrear.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCrear.TileImage")));
            this.btnCrear.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrear.UseSelectable = true;
            this.btnCrear.UseStyleColors = true;
            this.btnCrear.UseTileImage = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtPatente
            // 
            // 
            // 
            // 
            this.txtPatente.CustomButton.Image = null;
            this.txtPatente.CustomButton.Location = new System.Drawing.Point(318, 1);
            this.txtPatente.CustomButton.Name = "";
            this.txtPatente.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtPatente.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPatente.CustomButton.TabIndex = 1;
            this.txtPatente.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPatente.CustomButton.UseSelectable = true;
            this.txtPatente.CustomButton.Visible = false;
            this.txtPatente.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPatente.Lines = new string[0];
            this.txtPatente.Location = new System.Drawing.Point(138, 82);
            this.txtPatente.MaxLength = 32767;
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.PasswordChar = '\0';
            this.txtPatente.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPatente.SelectedText = "";
            this.txtPatente.SelectionLength = 0;
            this.txtPatente.SelectionStart = 0;
            this.txtPatente.ShortcutsEnabled = true;
            this.txtPatente.Size = new System.Drawing.Size(346, 29);
            this.txtPatente.Style = MetroFramework.MetroColorStyle.Green;
            this.txtPatente.TabIndex = 0;
            this.txtPatente.UseSelectable = true;
            this.txtPatente.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPatente.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(138, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(64, 19);
            this.metroLabel1.TabIndex = 17;
            this.metroLabel1.Text = "Patente:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(138, 114);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(132, 19);
            this.metroLabel2.TabIndex = 19;
            this.metroLabel2.Text = "Chofer (Opcional):";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(138, 168);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(122, 19);
            this.metroLabel3.TabIndex = 20;
            this.metroLabel3.Text = "Línea (Opcional):";
            // 
            // cmbChofer
            // 
            this.cmbChofer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbChofer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbChofer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChofer.FormattingEnabled = true;
            this.cmbChofer.ItemHeight = 22;
            this.cmbChofer.Location = new System.Drawing.Point(138, 135);
            this.cmbChofer.MaxDropDownItems = 12;
            this.cmbChofer.Name = "cmbChofer";
            this.cmbChofer.Size = new System.Drawing.Size(346, 30);
            this.cmbChofer.TabIndex = 1;
            // 
            // cmbLinea
            // 
            this.cmbLinea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLinea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLinea.FormattingEnabled = true;
            this.cmbLinea.Location = new System.Drawing.Point(138, 190);
            this.cmbLinea.MaxDropDownItems = 12;
            this.cmbLinea.Name = "cmbLinea";
            this.cmbLinea.Size = new System.Drawing.Size(346, 30);
            this.cmbLinea.TabIndex = 2;
            // 
            // CrearMicro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 334);
            this.Controls.Add(this.cmbLinea);
            this.Controls.Add(this.cmbChofer);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtPatente);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnCancelar);
            this.MaximumSize = new System.Drawing.Size(624, 334);
            this.MinimumSize = new System.Drawing.Size(624, 334);
            this.Name = "CrearMicro";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Crear nueva micro";
            this.Activated += new System.EventHandler(this.CrearMicro_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnCancelar;
        private MetroFramework.Controls.MetroTile btnCrear;
        private MetroFramework.Controls.MetroTextBox txtPatente;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.ComboBox cmbChofer;
        private System.Windows.Forms.ComboBox cmbLinea;
    }
}