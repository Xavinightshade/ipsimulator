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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.progressBar2 = new System.Windows.Forms.ProgressBar();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.estacionVista1 = new RedesIP.Vistas.EstacionView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.comboBoxEx1 = new RedesIP.Vistas.ComboBoxEx();
			((System.ComponentModel.ISupportInitialize)(this.estacionVista1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(103, 25);
			this.button1.TabIndex = 0;
			this.button1.Text = "Crear Dispo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(772, 578);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(103, 25);
			this.button2.TabIndex = 2;
			this.button2.Text = "Crear Dispo";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 519);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(737, 271);
			this.textBox1.TabIndex = 3;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(12, 465);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(79, 20);
			this.textBox2.TabIndex = 4;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(12, 491);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(79, 20);
			this.textBox3.TabIndex = 5;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(97, 465);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(652, 21);
			this.progressBar1.TabIndex = 6;
			// 
			// progressBar2
			// 
			this.progressBar2.Location = new System.Drawing.Point(97, 492);
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Size = new System.Drawing.Size(652, 21);
			this.progressBar2.TabIndex = 7;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(12, 70);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox4.Size = new System.Drawing.Size(737, 332);
			this.textBox4.TabIndex = 8;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "gh",
            "gfh"});
			this.comboBox1.Location = new System.Drawing.Point(272, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(347, 21);
			this.comboBox1.TabIndex = 9;
			// 
			// estacionVista1
			// 
			this.estacionVista1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.estacionVista1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.estacionVista1.Location = new System.Drawing.Point(0, 0);
			this.estacionVista1.Name = "estacionVista1";
			this.estacionVista1.Size = new System.Drawing.Size(1189, 802);
			this.estacionVista1.TabIndex = 1;
			this.estacionVista1.TabStop = false;
			this.estacionVista1.Click += new System.EventHandler(this.estacionVista1_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "n522141547_792059_3954.jpg");
			this.imageList1.Images.SetKeyName(1, "n522141547_792062_4931.jpg");
			this.imageList1.Images.SetKeyName(2, "n562445883_376642_1243.jpg");
			this.imageList1.Images.SetKeyName(3, "n562445883_376652_4537.jpg");
			this.imageList1.Images.SetKeyName(4, "n562445883_376653_4864.jpg");
			this.imageList1.Images.SetKeyName(5, "n562445883_376668_9795.jpg");
			// 
			// comboBoxEx1
			// 
			this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboBoxEx1.FormattingEnabled = true;
			this.comboBoxEx1.Location = new System.Drawing.Point(272, 4);
			this.comboBoxEx1.Name = "comboBoxEx1";
			this.comboBoxEx1.Size = new System.Drawing.Size(520, 21);
			this.comboBoxEx1.TabIndex = 10;
			// 
			// MainFrame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1189, 802);
			this.Controls.Add(this.comboBoxEx1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.progressBar2);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.estacionVista1);
			this.Name = "MainFrame";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.estacionVista1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private RedesIP.Vistas.EstacionView estacionVista1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
		  private System.Windows.Forms.TextBox textBox4;
		  private System.Windows.Forms.ComboBox comboBox1;
		  private RedesIP.Vistas.ComboBoxEx comboBoxEx1;
		  private System.Windows.Forms.ImageList imageList1;



	}
}

