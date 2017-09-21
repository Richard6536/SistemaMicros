namespace MicrosFormsGX.Ventanas
{
    partial class AdminLineas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLineas));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarMicrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaInicioToolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.gmapController = new GMap.NET.WindowsForms.GMapControl();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cmbLinea = new MetroFramework.Controls.MetroComboBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.btnVerMicros = new MetroFramework.Controls.MetroTile();
            this.btnBorrar = new MetroFramework.Controls.MetroTile();
            this.btnCambiarNombreLinea = new MetroFramework.Controls.MetroTile();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.btnAsignarIda = new MetroFramework.Controls.MetroTile();
            this.btnEliminarIda = new MetroFramework.Controls.MetroTile();
            this.btnCrearIda = new MetroFramework.Controls.MetroTile();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRutaIda = new MetroFramework.Controls.MetroComboBox();
            this.lblRutaIda = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.btnAsignarVuelta = new MetroFramework.Controls.MetroTile();
            this.btnEliminarVuelta = new MetroFramework.Controls.MetroTile();
            this.btnCrearVuelta = new MetroFramework.Controls.MetroTile();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRutaVuelta = new MetroFramework.Controls.MetroComboBox();
            this.lblRutaVuelta = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCrearLinea = new MetroFramework.Controls.MetroTile();
            this.btnVerMenuLinea = new MetroFramework.Controls.MetroButton();
            this.asdf = new MetroFramework.Controls.MetroLabel();
            this.lblTarifa = new MetroFramework.Controls.MetroLabel();
            this.menuStrip1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarUsuariosToolStripMenuItem,
            this.administrarMicrosToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.ventanaInicioToolstrip});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1190, 55);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrarUsuariosToolStripMenuItem
            // 
            this.administrarUsuariosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("administrarUsuariosToolStripMenuItem.Image")));
            this.administrarUsuariosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.administrarUsuariosToolStripMenuItem.Name = "administrarUsuariosToolStripMenuItem";
            this.administrarUsuariosToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.administrarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(129, 51);
            this.administrarUsuariosToolStripMenuItem.Text = "Administrar Usuarios";
            this.administrarUsuariosToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.administrarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administrarUsuariosToolStripMenuItem_Click);
            // 
            // administrarMicrosToolStripMenuItem
            // 
            this.administrarMicrosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("administrarMicrosToolStripMenuItem.Image")));
            this.administrarMicrosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.administrarMicrosToolStripMenuItem.Name = "administrarMicrosToolStripMenuItem";
            this.administrarMicrosToolStripMenuItem.Size = new System.Drawing.Size(120, 51);
            this.administrarMicrosToolStripMenuItem.Text = "Administrar micros";
            this.administrarMicrosToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.administrarMicrosToolStripMenuItem.Click += new System.EventHandler(this.administrarMicrosToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cerrarSesiónToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarSesiónToolStripMenuItem.Image")));
            this.cerrarSesiónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(87, 51);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // ventanaInicioToolstrip
            // 
            this.ventanaInicioToolstrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ventanaInicioToolstrip.Image = ((System.Drawing.Image)(resources.GetObject("ventanaInicioToolstrip.Image")));
            this.ventanaInicioToolstrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ventanaInicioToolstrip.Name = "ventanaInicioToolstrip";
            this.ventanaInicioToolstrip.Size = new System.Drawing.Size(93, 51);
            this.ventanaInicioToolstrip.Text = "Ventana inicio";
            this.ventanaInicioToolstrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ventanaInicioToolstrip.Click += new System.EventHandler(this.ventanaInicioToolstrip_Click);
            // 
            // gmapController
            // 
            this.gmapController.Bearing = 0F;
            this.gmapController.CanDragMap = true;
            this.gmapController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmapController.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmapController.GrayScaleMode = false;
            this.gmapController.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmapController.LevelsKeepInMemmory = 5;
            this.gmapController.Location = new System.Drawing.Point(20, 115);
            this.gmapController.MarkersEnabled = true;
            this.gmapController.MaxZoom = 2;
            this.gmapController.MinZoom = 2;
            this.gmapController.MouseWheelZoomEnabled = true;
            this.gmapController.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmapController.Name = "gmapController";
            this.gmapController.NegativeMode = false;
            this.gmapController.PolygonsEnabled = true;
            this.gmapController.RetryLoadTile = 0;
            this.gmapController.RoutesEnabled = true;
            this.gmapController.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmapController.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmapController.ShowTileGridLines = false;
            this.gmapController.Size = new System.Drawing.Size(1190, 593);
            this.gmapController.TabIndex = 8;
            this.gmapController.Zoom = 0D;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(316, 60);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel1.MinimumSize = new System.Drawing.Size(129, 19);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(129, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 11;
            this.metroLabel1.Text = "Selección de línea";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.WrapToLine = true;
            // 
            // cmbLinea
            // 
            this.cmbLinea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbLinea.FormattingEnabled = true;
            this.cmbLinea.ItemHeight = 23;
            this.cmbLinea.Location = new System.Drawing.Point(316, 80);
            this.cmbLinea.MinimumSize = new System.Drawing.Size(218, 0);
            this.cmbLinea.Name = "cmbLinea";
            this.cmbLinea.Size = new System.Drawing.Size(218, 29);
            this.cmbLinea.Style = MetroFramework.MetroColorStyle.Green;
            this.cmbLinea.TabIndex = 9;
            this.cmbLinea.UseSelectable = true;
            this.cmbLinea.UseStyleColors = true;
            this.cmbLinea.SelectedIndexChanged += new System.EventHandler(this.cmbLinea_SelectedIndexChanged);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.metroTabControl1.ItemSize = new System.Drawing.Size(220, 45);
            this.metroTabControl1.Location = new System.Drawing.Point(316, 115);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(891, 225);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTabControl1.TabIndex = 1;
            this.metroTabControl1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.UseStyleColors = true;
            this.metroTabControl1.Visible = false;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(234)))), ((int)(((byte)(174)))));
            this.metroTabPage1.Controls.Add(this.btnVerMicros);
            this.metroTabPage1.Controls.Add(this.btnBorrar);
            this.metroTabPage1.Controls.Add(this.btnCambiarNombreLinea);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 49);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(883, 172);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Administrar línea";
            this.metroTabPage1.UseCustomBackColor = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // btnVerMicros
            // 
            this.btnVerMicros.ActiveControl = null;
            this.btnVerMicros.Location = new System.Drawing.Point(282, 79);
            this.btnVerMicros.Name = "btnVerMicros";
            this.btnVerMicros.Size = new System.Drawing.Size(134, 88);
            this.btnVerMicros.Style = MetroFramework.MetroColorStyle.Green;
            this.btnVerMicros.TabIndex = 16;
            this.btnVerMicros.Text = "Administrar micros";
            this.btnVerMicros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVerMicros.TileImage = ((System.Drawing.Image)(resources.GetObject("btnVerMicros.TileImage")));
            this.btnVerMicros.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVerMicros.UseSelectable = true;
            this.btnVerMicros.UseStyleColors = true;
            this.btnVerMicros.UseTileImage = true;
            this.btnVerMicros.Click += new System.EventHandler(this.btnVerMicros_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.ActiveControl = null;
            this.btnBorrar.Location = new System.Drawing.Point(151, 79);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(125, 88);
            this.btnBorrar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnBorrar.TabIndex = 15;
            this.btnBorrar.Text = "Eliminar línea";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBorrar.TileImage = ((System.Drawing.Image)(resources.GetObject("btnBorrar.TileImage")));
            this.btnBorrar.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBorrar.UseSelectable = true;
            this.btnBorrar.UseStyleColors = true;
            this.btnBorrar.UseTileImage = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnCambiarNombreLinea
            // 
            this.btnCambiarNombreLinea.ActiveControl = null;
            this.btnCambiarNombreLinea.Location = new System.Drawing.Point(6, 79);
            this.btnCambiarNombreLinea.Name = "btnCambiarNombreLinea";
            this.btnCambiarNombreLinea.Size = new System.Drawing.Size(139, 88);
            this.btnCambiarNombreLinea.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCambiarNombreLinea.TabIndex = 14;
            this.btnCambiarNombreLinea.Text = "Editar datos";
            this.btnCambiarNombreLinea.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCambiarNombreLinea.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCambiarNombreLinea.TileImage")));
            this.btnCambiarNombreLinea.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCambiarNombreLinea.UseSelectable = true;
            this.btnCambiarNombreLinea.UseStyleColors = true;
            this.btnCambiarNombreLinea.UseTileImage = true;
            this.btnCambiarNombreLinea.Click += new System.EventHandler(this.btnCambiarNombreLinea_Click);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(234)))), ((int)(((byte)(174)))));
            this.metroTabPage2.Controls.Add(this.btnAsignarIda);
            this.metroTabPage2.Controls.Add(this.btnEliminarIda);
            this.metroTabPage2.Controls.Add(this.btnCrearIda);
            this.metroTabPage2.Controls.Add(this.label3);
            this.metroTabPage2.Controls.Add(this.cmbRutaIda);
            this.metroTabPage2.Controls.Add(this.lblRutaIda);
            this.metroTabPage2.Controls.Add(this.label1);
            this.metroTabPage2.ForeColor = System.Drawing.Color.Transparent;
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 49);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(883, 172);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Administrar ruta de ida";
            this.metroTabPage2.UseCustomBackColor = true;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // btnAsignarIda
            // 
            this.btnAsignarIda.ActiveControl = null;
            this.btnAsignarIda.Location = new System.Drawing.Point(359, 79);
            this.btnAsignarIda.Name = "btnAsignarIda";
            this.btnAsignarIda.Size = new System.Drawing.Size(133, 88);
            this.btnAsignarIda.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAsignarIda.TabIndex = 17;
            this.btnAsignarIda.Text = "Asignar ruta a línea";
            this.btnAsignarIda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAsignarIda.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAsignarIda.UseSelectable = true;
            this.btnAsignarIda.UseStyleColors = true;
            this.btnAsignarIda.UseTileImage = true;
            this.btnAsignarIda.Click += new System.EventHandler(this.btnAsignarIda_Click);
            // 
            // btnEliminarIda
            // 
            this.btnEliminarIda.ActiveControl = null;
            this.btnEliminarIda.Location = new System.Drawing.Point(220, 79);
            this.btnEliminarIda.Name = "btnEliminarIda";
            this.btnEliminarIda.Size = new System.Drawing.Size(133, 88);
            this.btnEliminarIda.Style = MetroFramework.MetroColorStyle.Green;
            this.btnEliminarIda.TabIndex = 16;
            this.btnEliminarIda.Text = "Eliminar";
            this.btnEliminarIda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminarIda.TileImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarIda.TileImage")));
            this.btnEliminarIda.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminarIda.UseSelectable = true;
            this.btnEliminarIda.UseStyleColors = true;
            this.btnEliminarIda.UseTileImage = true;
            this.btnEliminarIda.Click += new System.EventHandler(this.btnEliminarIda_Click);
            // 
            // btnCrearIda
            // 
            this.btnCrearIda.ActiveControl = null;
            this.btnCrearIda.Location = new System.Drawing.Point(6, 79);
            this.btnCrearIda.Name = "btnCrearIda";
            this.btnCrearIda.Size = new System.Drawing.Size(139, 88);
            this.btnCrearIda.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCrearIda.TabIndex = 15;
            this.btnCrearIda.Text = "Crear ruta de ida";
            this.btnCrearIda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrearIda.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCrearIda.TileImage")));
            this.btnCrearIda.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrearIda.UseSelectable = true;
            this.btnCrearIda.UseStyleColors = true;
            this.btnCrearIda.UseTileImage = true;
            this.btnCrearIda.Click += new System.EventHandler(this.btnCrearIda_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(217, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rutas de ida:";
            // 
            // cmbRutaIda
            // 
            this.cmbRutaIda.FormattingEnabled = true;
            this.cmbRutaIda.ItemHeight = 23;
            this.cmbRutaIda.Location = new System.Drawing.Point(220, 44);
            this.cmbRutaIda.Name = "cmbRutaIda";
            this.cmbRutaIda.Size = new System.Drawing.Size(272, 29);
            this.cmbRutaIda.TabIndex = 4;
            this.cmbRutaIda.UseSelectable = true;
            this.cmbRutaIda.SelectedIndexChanged += new System.EventHandler(this.cmbRutaIda_SelectedIndexChanged);
            this.cmbRutaIda.Click += new System.EventHandler(this.cmbRutaIda_Click);
            // 
            // lblRutaIda
            // 
            this.lblRutaIda.AutoSize = true;
            this.lblRutaIda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRutaIda.ForeColor = System.Drawing.Color.Black;
            this.lblRutaIda.Location = new System.Drawing.Point(3, 45);
            this.lblRutaIda.Name = "lblRutaIda";
            this.lblRutaIda.Size = new System.Drawing.Size(85, 17);
            this.lblRutaIda.TabIndex = 3;
            this.lblRutaIda.Text = "nombre ruta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ruta de ida actual:";
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(234)))), ((int)(((byte)(174)))));
            this.metroTabPage3.Controls.Add(this.btnAsignarVuelta);
            this.metroTabPage3.Controls.Add(this.btnEliminarVuelta);
            this.metroTabPage3.Controls.Add(this.btnCrearVuelta);
            this.metroTabPage3.Controls.Add(this.label4);
            this.metroTabPage3.Controls.Add(this.cmbRutaVuelta);
            this.metroTabPage3.Controls.Add(this.lblRutaVuelta);
            this.metroTabPage3.Controls.Add(this.label6);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 49);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(883, 172);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Administrar ruta de vuelta";
            this.metroTabPage3.UseCustomBackColor = true;
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // btnAsignarVuelta
            // 
            this.btnAsignarVuelta.ActiveControl = null;
            this.btnAsignarVuelta.Location = new System.Drawing.Point(359, 79);
            this.btnAsignarVuelta.Name = "btnAsignarVuelta";
            this.btnAsignarVuelta.Size = new System.Drawing.Size(133, 88);
            this.btnAsignarVuelta.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAsignarVuelta.TabIndex = 24;
            this.btnAsignarVuelta.Text = "Asignar ruta a línea";
            this.btnAsignarVuelta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAsignarVuelta.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAsignarVuelta.UseSelectable = true;
            this.btnAsignarVuelta.UseStyleColors = true;
            this.btnAsignarVuelta.UseTileImage = true;
            this.btnAsignarVuelta.Click += new System.EventHandler(this.btnAsignarVuelta_Click);
            // 
            // btnEliminarVuelta
            // 
            this.btnEliminarVuelta.ActiveControl = null;
            this.btnEliminarVuelta.Location = new System.Drawing.Point(220, 79);
            this.btnEliminarVuelta.Name = "btnEliminarVuelta";
            this.btnEliminarVuelta.Size = new System.Drawing.Size(133, 88);
            this.btnEliminarVuelta.Style = MetroFramework.MetroColorStyle.Green;
            this.btnEliminarVuelta.TabIndex = 23;
            this.btnEliminarVuelta.Text = "Eliminar";
            this.btnEliminarVuelta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminarVuelta.TileImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarVuelta.TileImage")));
            this.btnEliminarVuelta.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminarVuelta.UseSelectable = true;
            this.btnEliminarVuelta.UseStyleColors = true;
            this.btnEliminarVuelta.UseTileImage = true;
            this.btnEliminarVuelta.Click += new System.EventHandler(this.btnEliminarVuelta_Click);
            // 
            // btnCrearVuelta
            // 
            this.btnCrearVuelta.ActiveControl = null;
            this.btnCrearVuelta.Location = new System.Drawing.Point(6, 79);
            this.btnCrearVuelta.Name = "btnCrearVuelta";
            this.btnCrearVuelta.Size = new System.Drawing.Size(139, 88);
            this.btnCrearVuelta.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCrearVuelta.TabIndex = 22;
            this.btnCrearVuelta.Text = "Crear ruta de vuelta";
            this.btnCrearVuelta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrearVuelta.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCrearVuelta.TileImage")));
            this.btnCrearVuelta.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrearVuelta.UseSelectable = true;
            this.btnCrearVuelta.UseStyleColors = true;
            this.btnCrearVuelta.UseTileImage = true;
            this.btnCrearVuelta.Click += new System.EventHandler(this.btnCrearVuelta_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(217, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Rutas de vuelta";
            // 
            // cmbRutaVuelta
            // 
            this.cmbRutaVuelta.FormattingEnabled = true;
            this.cmbRutaVuelta.ItemHeight = 23;
            this.cmbRutaVuelta.Location = new System.Drawing.Point(220, 44);
            this.cmbRutaVuelta.Name = "cmbRutaVuelta";
            this.cmbRutaVuelta.Size = new System.Drawing.Size(272, 29);
            this.cmbRutaVuelta.TabIndex = 20;
            this.cmbRutaVuelta.UseSelectable = true;
            this.cmbRutaVuelta.SelectedIndexChanged += new System.EventHandler(this.cmbRutaVuelta_SelectedIndexChanged);
            this.cmbRutaVuelta.Click += new System.EventHandler(this.cmbRutaVuelta_Click);
            // 
            // lblRutaVuelta
            // 
            this.lblRutaVuelta.AutoSize = true;
            this.lblRutaVuelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRutaVuelta.ForeColor = System.Drawing.Color.Black;
            this.lblRutaVuelta.Location = new System.Drawing.Point(3, 45);
            this.lblRutaVuelta.Name = "lblRutaVuelta";
            this.lblRutaVuelta.Size = new System.Drawing.Size(85, 17);
            this.lblRutaVuelta.TabIndex = 19;
            this.lblRutaVuelta.Text = "nombre ruta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Ruta de vuelta actual:";
            // 
            // btnCrearLinea
            // 
            this.btnCrearLinea.ActiveControl = null;
            this.btnCrearLinea.Location = new System.Drawing.Point(35, 134);
            this.btnCrearLinea.Name = "btnCrearLinea";
            this.btnCrearLinea.Size = new System.Drawing.Size(129, 88);
            this.btnCrearLinea.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCrearLinea.TabIndex = 13;
            this.btnCrearLinea.Text = "Crear nueva línea";
            this.btnCrearLinea.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrearLinea.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCrearLinea.TileImage")));
            this.btnCrearLinea.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrearLinea.UseSelectable = true;
            this.btnCrearLinea.UseStyleColors = true;
            this.btnCrearLinea.UseTileImage = true;
            this.btnCrearLinea.Click += new System.EventHandler(this.btnCrearLinea_Click);
            // 
            // btnVerMenuLinea
            // 
            this.btnVerMenuLinea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnVerMenuLinea.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnVerMenuLinea.Location = new System.Drawing.Point(540, 80);
            this.btnVerMenuLinea.Name = "btnVerMenuLinea";
            this.btnVerMenuLinea.Size = new System.Drawing.Size(112, 29);
            this.btnVerMenuLinea.TabIndex = 14;
            this.btnVerMenuLinea.Text = "Ver menú línea";
            this.btnVerMenuLinea.UseSelectable = true;
            this.btnVerMenuLinea.Click += new System.EventHandler(this.btnVerMenuLinea_Click);
            // 
            // asdf
            // 
            this.asdf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.asdf.AutoSize = true;
            this.asdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.asdf.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.asdf.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.asdf.ForeColor = System.Drawing.Color.White;
            this.asdf.Location = new System.Drawing.Point(671, 80);
            this.asdf.Margin = new System.Windows.Forms.Padding(0);
            this.asdf.Name = "asdf";
            this.asdf.Size = new System.Drawing.Size(65, 25);
            this.asdf.Style = MetroFramework.MetroColorStyle.Green;
            this.asdf.TabIndex = 15;
            this.asdf.Text = "Tarifa:";
            this.asdf.UseCustomBackColor = true;
            this.asdf.UseCustomForeColor = true;
            this.asdf.WrapToLine = true;
            // 
            // lblTarifa
            // 
            this.lblTarifa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTarifa.AutoSize = true;
            this.lblTarifa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.lblTarifa.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTarifa.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTarifa.ForeColor = System.Drawing.Color.White;
            this.lblTarifa.Location = new System.Drawing.Point(736, 80);
            this.lblTarifa.Margin = new System.Windows.Forms.Padding(0);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Size = new System.Drawing.Size(32, 25);
            this.lblTarifa.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTarifa.TabIndex = 16;
            this.lblTarifa.Text = "$0";
            this.lblTarifa.UseCustomBackColor = true;
            this.lblTarifa.UseCustomForeColor = true;
            this.lblTarifa.WrapToLine = true;
            // 
            // AdminLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 728);
            this.Controls.Add(this.lblTarifa);
            this.Controls.Add(this.asdf);
            this.Controls.Add(this.btnVerMenuLinea);
            this.Controls.Add(this.btnCrearLinea);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cmbLinea);
            this.Controls.Add(this.gmapController);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(1024, 351);
            this.Name = "AdminLineas";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Administración de líneas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.AdminLineas_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminLineas_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminLineas_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarMicrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventanaInicioToolstrip;
        private GMap.NET.WindowsForms.GMapControl gmapController;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cmbLinea;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTile btnCrearLinea;
        private MetroFramework.Controls.MetroButton btnVerMenuLinea;
        private MetroFramework.Controls.MetroTile btnVerMicros;
        private MetroFramework.Controls.MetroTile btnBorrar;
        private MetroFramework.Controls.MetroTile btnCambiarNombreLinea;
        private MetroFramework.Controls.MetroTile btnAsignarIda;
        private MetroFramework.Controls.MetroTile btnEliminarIda;
        private MetroFramework.Controls.MetroTile btnCrearIda;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroComboBox cmbRutaIda;
        private System.Windows.Forms.Label lblRutaIda;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTile btnAsignarVuelta;
        private MetroFramework.Controls.MetroTile btnEliminarVuelta;
        private MetroFramework.Controls.MetroTile btnCrearVuelta;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroComboBox cmbRutaVuelta;
        private System.Windows.Forms.Label lblRutaVuelta;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroLabel asdf;
        private MetroFramework.Controls.MetroLabel lblTarifa;
    }
}