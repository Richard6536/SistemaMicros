namespace MicrosFormsGX.Ventanas.Historiales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialesParaderos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnVolver = new MetroFramework.Controls.MetroTile();
            this.datagridHistorial = new MetroFramework.Controls.MetroGrid();
            this.NumeroParadero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiempoDetenido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PasajerosRecibidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFecha = new MetroFramework.Controls.MetroLabel();
            this.lblPatente = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblNumeroRecorrido = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.datagridHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.ActiveControl = null;
            this.btnVolver.Location = new System.Drawing.Point(23, 63);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(120, 67);
            this.btnVolver.Style = MetroFramework.MetroColorStyle.Green;
            this.btnVolver.TabIndex = 45;
            this.btnVolver.Text = "Volver atrás";
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVolver.TileImage = ((System.Drawing.Image)(resources.GetObject("btnVolver.TileImage")));
            this.btnVolver.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVolver.UseSelectable = true;
            this.btnVolver.UseStyleColors = true;
            this.btnVolver.UseTileImage = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // datagridHistorial
            // 
            this.datagridHistorial.AllowUserToAddRows = false;
            this.datagridHistorial.AllowUserToDeleteRows = false;
            this.datagridHistorial.AllowUserToResizeRows = false;
            this.datagridHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridHistorial.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.datagridHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridHistorial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datagridHistorial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroParadero,
            this.HoraLlegada,
            this.TiempoDetenido,
            this.PasajerosRecibidos});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridHistorial.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagridHistorial.EnableHeadersVisualStyles = false;
            this.datagridHistorial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.datagridHistorial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.datagridHistorial.Location = new System.Drawing.Point(23, 136);
            this.datagridHistorial.Name = "datagridHistorial";
            this.datagridHistorial.ReadOnly = true;
            this.datagridHistorial.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridHistorial.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datagridHistorial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagridHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridHistorial.Size = new System.Drawing.Size(744, 445);
            this.datagridHistorial.Style = MetroFramework.MetroColorStyle.Green;
            this.datagridHistorial.TabIndex = 46;
            this.datagridHistorial.UseStyleColors = true;
            // 
            // NumeroParadero
            // 
            this.NumeroParadero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumeroParadero.HeaderText = "Número de paradero";
            this.NumeroParadero.Name = "NumeroParadero";
            this.NumeroParadero.ReadOnly = true;
            // 
            // HoraLlegada
            // 
            this.HoraLlegada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoraLlegada.HeaderText = "Hora de llegada";
            this.HoraLlegada.Name = "HoraLlegada";
            this.HoraLlegada.ReadOnly = true;
            // 
            // TiempoDetenido
            // 
            this.TiempoDetenido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TiempoDetenido.HeaderText = "Tiempo detenido";
            this.TiempoDetenido.Name = "TiempoDetenido";
            this.TiempoDetenido.ReadOnly = true;
            // 
            // PasajerosRecibidos
            // 
            this.PasajerosRecibidos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PasajerosRecibidos.HeaderText = "PasajerosRecibidos";
            this.PasajerosRecibidos.Name = "PasajerosRecibidos";
            this.PasajerosRecibidos.ReadOnly = true;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblFecha.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblFecha.Location = new System.Drawing.Point(420, 85);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(106, 25);
            this.lblFecha.TabIndex = 50;
            this.lblFecha.Text = "10/10/2040";
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPatente.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPatente.Location = new System.Drawing.Point(420, 60);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(72, 25);
            this.lblPatente.TabIndex = 49;
            this.lblPatente.Text = "111222";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(293, 85);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 25);
            this.metroLabel1.TabIndex = 48;
            this.metroLabel1.Text = "Fecha:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(293, 60);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(83, 25);
            this.metroLabel3.TabIndex = 47;
            this.metroLabel3.Text = "Patente:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(293, 110);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(121, 25);
            this.metroLabel2.TabIndex = 51;
            this.metroLabel2.Text = "N° recorrido:";
            // 
            // lblNumeroRecorrido
            // 
            this.lblNumeroRecorrido.AutoSize = true;
            this.lblNumeroRecorrido.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblNumeroRecorrido.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblNumeroRecorrido.Location = new System.Drawing.Point(420, 110);
            this.lblNumeroRecorrido.Name = "lblNumeroRecorrido";
            this.lblNumeroRecorrido.Size = new System.Drawing.Size(22, 25);
            this.lblNumeroRecorrido.TabIndex = 52;
            this.lblNumeroRecorrido.Text = "2";
            // 
            // HistorialesParaderos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 604);
            this.Controls.Add(this.lblNumeroRecorrido);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblPatente);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.datagridHistorial);
            this.Controls.Add(this.btnVolver);
            this.MinimumSize = new System.Drawing.Size(610, 275);
            this.Name = "HistorialesParaderos";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Historiales de paraderos en el recorrido";
            this.Activated += new System.EventHandler(this.HistorialesParaderos_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.datagridHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnVolver;
        private MetroFramework.Controls.MetroGrid datagridHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroParadero;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiempoDetenido;
        private System.Windows.Forms.DataGridViewTextBoxColumn PasajerosRecibidos;
        private MetroFramework.Controls.MetroLabel lblFecha;
        private MetroFramework.Controls.MetroLabel lblPatente;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblNumeroRecorrido;
    }
}