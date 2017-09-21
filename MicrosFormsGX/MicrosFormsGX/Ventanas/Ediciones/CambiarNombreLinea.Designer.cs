namespace MicrosFormsGX.Ventanas.Ediciones
{
    partial class CambiarNombreLinea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarNombreLinea));
            this.btnGuardar = new MetroFramework.Controls.MetroTile();
            this.btnCancelar = new MetroFramework.Controls.MetroTile();
            this.txtNombre = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtTarifa = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.ActiveControl = null;
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(401, 194);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 83);
            this.btnGuardar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar datos";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.TileImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.TileImage")));
            this.btnGuardar.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.UseSelectable = true;
            this.btnGuardar.UseStyleColors = true;
            this.btnGuardar.UseTileImage = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ActiveControl = null;
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(23, 194);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(147, 83);
            this.btnCancelar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.TileImage")));
            this.btnCancelar.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.UseStyleColors = true;
            this.btnCancelar.UseTileImage = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNombre
            // 
            // 
            // 
            // 
            this.txtNombre.CustomButton.Image = null;
            this.txtNombre.CustomButton.Location = new System.Drawing.Point(318, 1);
            this.txtNombre.CustomButton.Name = "";
            this.txtNombre.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtNombre.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNombre.CustomButton.TabIndex = 1;
            this.txtNombre.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNombre.CustomButton.UseSelectable = true;
            this.txtNombre.CustomButton.Visible = false;
            this.txtNombre.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNombre.Lines = new string[0];
            this.txtNombre.Location = new System.Drawing.Point(119, 93);
            this.txtNombre.MaxLength = 32767;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PasswordChar = '\0';
            this.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombre.SelectedText = "";
            this.txtNombre.SelectionLength = 0;
            this.txtNombre.SelectionStart = 0;
            this.txtNombre.ShortcutsEnabled = true;
            this.txtNombre.Size = new System.Drawing.Size(346, 29);
            this.txtNombre.Style = MetroFramework.MetroColorStyle.Green;
            this.txtNombre.TabIndex = 0;
            this.txtNombre.UseSelectable = true;
            this.txtNombre.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNombre.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(119, 71);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(171, 19);
            this.metroLabel1.TabIndex = 27;
            this.metroLabel1.Text = "Nuevo nombre de línea:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(119, 125);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(153, 19);
            this.metroLabel2.TabIndex = 32;
            this.metroLabel2.Text = "Nuevo valor de tarifa";
            // 
            // txtTarifa
            // 
            // 
            // 
            // 
            this.txtTarifa.CustomButton.Image = null;
            this.txtTarifa.CustomButton.Location = new System.Drawing.Point(318, 1);
            this.txtTarifa.CustomButton.Name = "";
            this.txtTarifa.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtTarifa.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTarifa.CustomButton.TabIndex = 1;
            this.txtTarifa.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTarifa.CustomButton.UseSelectable = true;
            this.txtTarifa.CustomButton.Visible = false;
            this.txtTarifa.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTarifa.Lines = new string[0];
            this.txtTarifa.Location = new System.Drawing.Point(119, 147);
            this.txtTarifa.MaxLength = 32767;
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.PasswordChar = '\0';
            this.txtTarifa.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTarifa.SelectedText = "";
            this.txtTarifa.SelectionLength = 0;
            this.txtTarifa.SelectionStart = 0;
            this.txtTarifa.ShortcutsEnabled = true;
            this.txtTarifa.Size = new System.Drawing.Size(346, 29);
            this.txtTarifa.Style = MetroFramework.MetroColorStyle.Green;
            this.txtTarifa.TabIndex = 1;
            this.txtTarifa.UseSelectable = true;
            this.txtTarifa.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTarifa.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtTarifa.TextChanged += new System.EventHandler(this.txtTarifa_TextChanged);
            // 
            // CambiarNombreLinea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 300);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtTarifa);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtNombre);
            this.MaximumSize = new System.Drawing.Size(571, 300);
            this.MinimumSize = new System.Drawing.Size(571, 300);
            this.Name = "CambiarNombreLinea";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Cambiar datos de línea";
            this.Activated += new System.EventHandler(this.CambiarNombreLinea_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile btnGuardar;
        private MetroFramework.Controls.MetroTile btnCancelar;
        private MetroFramework.Controls.MetroTextBox txtNombre;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtTarifa;
    }
}