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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.button1 = new System.Windows.Forms.Button();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this._estacionView = new RedesIP.Vistas.EstacionView();
			this.sniffer1 = new SimuladorCliente.Sniffer();
			this.sniffer2 = new SimuladorCliente.Sniffer();
			this.toolStrip1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._estacionView)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(659, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.AutoScroll = true;
			this.splitContainer1.Panel1.Controls.Add(this._estacionView);
			this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.AutoScroll = true;
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.Size = new System.Drawing.Size(659, 419);
			this.splitContainer1.SplitterDistance = 338;
			this.splitContainer1.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(140, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(113, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Conectar al Servidor";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = global::SimuladorCliente.Properties.Resources.pointer;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "Puntero";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Enabled = false;
			this.toolStripButton2.Image = global::SimuladorCliente.Properties.Resources.Computador;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "Crear Computador";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Enabled = false;
			this.toolStripButton3.Image = global::SimuladorCliente.Properties.Resources.Switch;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton3.Text = "Crear Switch";
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Enabled = false;
			this.toolStripButton4.Image = global::SimuladorCliente.Properties.Resources.PuertoEthernet;
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton4.Text = "Conectar Equipos";
			this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton5.Text = "toolStripButton5";
			this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
			// 
			// splitContainer2
			// 
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.sniffer1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.sniffer2);
			this.splitContainer2.Size = new System.Drawing.Size(659, 77);
			this.splitContainer2.SplitterDistance = 280;
			this.splitContainer2.TabIndex = 0;
			// 
			// _estacionView
			// 
			this._estacionView.BackColor = System.Drawing.Color.Black;
			this._estacionView.Dock = System.Windows.Forms.DockStyle.Fill;
			this._estacionView.Location = new System.Drawing.Point(0, 0);
			this._estacionView.Name = "_estacionView";
			this._estacionView.Size = new System.Drawing.Size(655, 334);
			this._estacionView.TabIndex = 0;
			this._estacionView.TabStop = false;
			// 
			// sniffer1
			// 
			this.sniffer1.Dock = System.Windows.Forms.DockStyle.Top;
			this.sniffer1.Location = new System.Drawing.Point(0, 0);
			this.sniffer1.Name = "sniffer1";
			this.sniffer1.Size = new System.Drawing.Size(276, 421);
			this.sniffer1.TabIndex = 0;
			// 
			// sniffer2
			// 
			this.sniffer2.Dock = System.Windows.Forms.DockStyle.Top;
			this.sniffer2.Location = new System.Drawing.Point(0, 0);
			this.sniffer2.Name = "sniffer2";
			this.sniffer2.Size = new System.Drawing.Size(371, 421);
			this.sniffer2.TabIndex = 1;
			// 
			// MainFrame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(659, 444);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainFrame";
			this.Text = "Simulador";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrame_FormClosing);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._estacionView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RedesIP.Vistas.EstacionView _estacionView;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private Sniffer sniffer1;
		private Sniffer sniffer2;



	}
}

