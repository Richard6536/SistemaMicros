namespace MicrosFormsGX.Ventanas.Ediciones
{
    partial class EditarMicro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarMicro));
            this.txtPatente = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnCrear = new MetroFramework.Controls.MetroTile();
            this.btnCancelar = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cmbLinea = new System.Windows.Forms.ComboBox();
            this.cmbChofer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            this.txtPatente.Location = new System.Drawing.Point(106, 82);
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
            this.txtPatente.TabIndex = 33;
            this.txtPatente.UseSelectable = true;
            this.txtPatente.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPatente.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(106, 114);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(112, 19);
            this.metroLabel3.TabIndex = 32;
            this.metroLabel3.Text = "Línea asignada:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(106, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(64, 19);
            this.metroLabel2.TabIndex = 31;
            this.metroLabel2.Text = "Patente:";
            // 
            // btnCrear
            // 
            this.btnCrear.ActiveControl = null;
            this.btnCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrear.Location = new System.Drawing.Point(398, 252);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(150, 85);
            this.btnCrear.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCrear.TabIndex = 35;
            this.btnCrear.Text = "Guardar datos";
            this.btnCrear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrear.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCrear.TileImage")));
            this.btnCrear.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrear.UseSelectable = true;
            this.btnCrear.UseStyleColors = true;
            this.btnCrear.UseTileImage = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ActiveControl = null;
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(23, 252);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(147, 85);
            this.btnCancelar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.TileImage")));
            this.btnCancelar.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.UseStyleColors = true;
            this.btnCancelar.UseTileImage = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(106, 168);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(206, 19);
            this.metroLabel1.TabIndex = 37;
            this.metroLabel1.Text = "Chofer asignado/Disponibles:";
            // 
            // cmbLinea
            // 
            this.cmbLinea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLinea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLinea.FormattingEnabled = true;
            this.cmbLinea.Location = new System.Drawing.Point(106, 135);
            this.cmbLinea.MaxDropDownItems = 12;
            this.cmbLinea.Name = "cmbLinea";
            this.cmbLinea.Size = new System.Drawing.Size(346, 30);
            this.cmbLinea.TabIndex = 38;
            // 
            // cmbChofer
            // 
            this.cmbChofer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbChofer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbChofer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChofer.FormattingEnabled = true;
            this.cmbChofer.ItemHeight = 22;
            this.cmbChofer.Location = new System.Drawing.Point(106, 190);
            this.cmbChofer.MaxDropDownItems = 12;
            this.cmbChofer.Name = "cmbChofer";
            this.cmbChofer.Size = new System.Drawing.Size(346, 30);
            this.cmbChofer.TabIndex = 39;
            // 
            // EditarMicro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 360);
            this.Controls.Add(this.cmbChofer);
            this.Controls.Add(this.cmbLinea);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtPatente);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.MaximumSize = new System.Drawing.Size(571, 360);
            this.MinimumSize = new System.Drawing.Size(571, 360);
            this.Name = "EditarMicro";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Editar micro";
            this.Activated += new System.EventHandler(this.EditarMicro_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtPatente;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile btnCrear;
        private MetroFramework.Controls.MetroTile btnCancelar;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ComboBox cmbLinea;
        private System.Windows.Forms.ComboBox cmbChofer;
    }
}