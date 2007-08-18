namespace SimuladorCliente
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.switch1 = new RedesIP.Vistas.ElementosVisuales.Switch();
			this.computador1 = new RedesIP.Vistas.ElementosVisuales.Computador();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.switch1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.computador1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(127, 31);
			this.button1.TabIndex = 2;
			this.button1.Text = "Conectar Servidor";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// switch1
			// 
			this.switch1.Image = ((System.Drawing.Image)(resources.GetObject("switch1.Image")));
			this.switch1.Location = new System.Drawing.Point(461, 65);
			this.switch1.Name = "switch1";
			this.switch1.OrigenX = 461;
			this.switch1.OrigenY = 65;
			this.switch1.Size = new System.Drawing.Size(139, 31);
			this.switch1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.switch1.TabIndex = 1;
			this.switch1.TabStop = false;
			// 
			// computador1
			// 
			this.computador1.Image = ((System.Drawing.Image)(resources.GetObject("computador1.Image")));
			this.computador1.Location = new System.Drawing.Point(251, 54);
			this.computador1.Name = "computador1";
			this.computador1.OrigenX = 251;
			this.computador1.OrigenY = 54;
			this.computador1.Size = new System.Drawing.Size(48, 43);
			this.computador1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.computador1.TabIndex = 0;
			this.computador1.TabStop = false;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 54);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(127, 30);
			this.button2.TabIndex = 3;
			this.button2.Text = "Registrarme";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(776, 468);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.switch1);
			this.Controls.Add(this.computador1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.switch1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.computador1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RedesIP.Vistas.ElementosVisuales.Computador computador1;
		private RedesIP.Vistas.ElementosVisuales.Switch switch1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}

