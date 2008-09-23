namespace SimuladorCliente
{
	partial class MainFrame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._mouse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._pc = new System.Windows.Forms.ToolStripButton();
            this._switch = new System.Windows.Forms.ToolStripButton();
            this._router = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._conexion = new System.Windows.Forms.ToolStripButton();
            this._punta = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.inicializarServidorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cargarDesdeBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarEnBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.predeterminadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desdeArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._dockMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mouse,
            this.toolStripSeparator5,
            this.toolStripSeparator6,
            this.toolStripSeparator1,
            this._pc,
            this._switch,
            this._router,
            this.toolStripSeparator7,
            this.toolStripSeparator4,
            this.toolStripSeparator2,
            this._conexion,
            this._punta,
            this.toolStripSeparator9,
            this.toolStripSeparator8,
            this.toolStripSeparator3,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(895, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _mouse
            // 
            this._mouse.Checked = true;
            this._mouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this._mouse.Image = global::SimuladorCliente.Properties.Resources.pointer;
            this._mouse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._mouse.Name = "_mouse";
            this._mouse.Size = new System.Drawing.Size(65, 22);
            this._mouse.Text = "Puntero";
            this._mouse.Click += new System.EventHandler(this.Nouse_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _pc
            // 
            this._pc.Image = global::SimuladorCliente.Properties.Resources.Computador;
            this._pc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._pc.Name = "_pc";
            this._pc.Size = new System.Drawing.Size(116, 22);
            this._pc.Text = "Crear Computador";
            this._pc.Click += new System.EventHandler(this.pc_Click);
            // 
            // _switch
            // 
            this._switch.Image = global::SimuladorCliente.Properties.Resources.Switch;
            this._switch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._switch.Name = "_switch";
            this._switch.Size = new System.Drawing.Size(88, 22);
            this._switch.Text = "Crear Switch";
            this._switch.Click += new System.EventHandler(this.Switch_Click);
            // 
            // _router
            // 
            this._router.Image = global::SimuladorCliente.Properties.Resources.Router;
            this._router.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._router.Name = "_router";
            this._router.Size = new System.Drawing.Size(90, 22);
            this._router.Text = "Crear Router";
            this._router.Click += new System.EventHandler(this.Router_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _conexion
            // 
            this._conexion.Image = global::SimuladorCliente.Properties.Resources.Cable;
            this._conexion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._conexion.Name = "_conexion";
            this._conexion.Size = new System.Drawing.Size(111, 22);
            this._conexion.Text = "Conectar Equipos";
            this._conexion.Click += new System.EventHandler(this.Conexion_Click);
            // 
            // _punta
            // 
            this._punta.Image = global::SimuladorCliente.Properties.Resources.sniffer;
            this._punta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._punta.Name = "_punta";
            this._punta.Size = new System.Drawing.Size(114, 22);
            this._punta.Text = "Punta de Medicion";
            this._punta.Click += new System.EventHandler(this.Punta_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripSeparator10,
            this.inicializarServidorToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::SimuladorCliente.Properties.Resources.SOA;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(110, 22);
            this.toolStripDropDownButton2.Text = "Acceso Remoto";
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.cToolStripMenuItem.Text = "Conectar a servidor";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(204, 22);
            this.toolStripMenuItem2.Text = "Desconectar del servidor";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(201, 6);
            // 
            // inicializarServidorToolStripMenuItem
            // 
            this.inicializarServidorToolStripMenuItem.Name = "inicializarServidorToolStripMenuItem";
            this.inicializarServidorToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.inicializarServidorToolStripMenuItem.Text = "Inicializar servidor";
            this.inicializarServidorToolStripMenuItem.Click += new System.EventHandler(this.inicializarServidorToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarDesdeBDToolStripMenuItem,
            this.guardarEnBDToolStripMenuItem,
            this.toolStripMenuItem4,
            this.toolStripSeparator11,
            this.toolStripSeparator12,
            this.toolStripMenuItem3});
            this.toolStripDropDownButton1.Image = global::SimuladorCliente.Properties.Resources.DB;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(105, 22);
            this.toolStripDropDownButton1.Text = "Base de Datos";
            // 
            // cargarDesdeBDToolStripMenuItem
            // 
            this.cargarDesdeBDToolStripMenuItem.Image = global::SimuladorCliente.Properties.Resources.AlarmaLiquidacion;
            this.cargarDesdeBDToolStripMenuItem.Name = "cargarDesdeBDToolStripMenuItem";
            this.cargarDesdeBDToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.cargarDesdeBDToolStripMenuItem.Text = "Abrir Topologia";
            this.cargarDesdeBDToolStripMenuItem.Click += new System.EventHandler(this.CargarDesdeBD);
            // 
            // guardarEnBDToolStripMenuItem
            // 
            this.guardarEnBDToolStripMenuItem.Image = global::SimuladorCliente.Properties.Resources.Guardar;
            this.guardarEnBDToolStripMenuItem.Name = "guardarEnBDToolStripMenuItem";
            this.guardarEnBDToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.guardarEnBDToolStripMenuItem.Text = "Guardar Topologia";
            this.guardarEnBDToolStripMenuItem.Click += new System.EventHandler(this.guardarEnBDToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::SimuladorCliente.Properties.Resources.Delete;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(211, 22);
            this.toolStripMenuItem4.Text = "Eliminar Topologia";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(208, 6);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(208, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.predeterminadaToolStripMenuItem,
            this.desdeArchivoToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(211, 22);
            this.toolStripMenuItem3.Text = "Seleccionar Base de Datos";
            // 
            // predeterminadaToolStripMenuItem
            // 
            this.predeterminadaToolStripMenuItem.Name = "predeterminadaToolStripMenuItem";
            this.predeterminadaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.predeterminadaToolStripMenuItem.Text = "Predeterminada";
            // 
            // desdeArchivoToolStripMenuItem
            // 
            this.desdeArchivoToolStripMenuItem.Name = "desdeArchivoToolStripMenuItem";
            this.desdeArchivoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.desdeArchivoToolStripMenuItem.Text = "Desde Archivo";
            // 
            // _dockMain
            // 
            this._dockMain.ActiveAutoHideContent = null;
            this._dockMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dockMain.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingSdi;
            this._dockMain.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this._dockMain.Location = new System.Drawing.Point(0, 52);
            this._dockMain.Name = "_dockMain";
            this._dockMain.Size = new System.Drawing.Size(895, 605);
            this._dockMain.TabIndex = 10;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(895, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.herramientasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(895, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fToolStripMenuItem,
            this.fToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(55, 20);
            this.toolStripMenuItem1.Text = "Archivo";
            // 
            // fToolStripMenuItem
            // 
            this.fToolStripMenuItem.Name = "fToolStripMenuItem";
            this.fToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.fToolStripMenuItem.Text = "f";
            // 
            // fToolStripMenuItem1
            // 
            this.fToolStripMenuItem1.Name = "fToolStripMenuItem1";
            this.fToolStripMenuItem1.Size = new System.Drawing.Size(89, 22);
            this.fToolStripMenuItem1.Text = "f";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "_notifyIcon";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(895, 682);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._dockMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrame";
            this.Text = "Simulador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrame_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion


		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton _mouse;
		private System.Windows.Forms.ToolStripButton _pc;
		private System.Windows.Forms.ToolStripButton _switch;
        private System.Windows.Forms.ToolStripButton _conexion;
        private System.Windows.Forms.ToolStripButton _punta;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem guardarEnBDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarDesdeBDToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel _dockMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton _router;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inicializarServidorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem predeterminadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desdeArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;



	}
}

