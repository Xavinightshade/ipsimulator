namespace Cliente
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
			this.computador1 = new RedesIP.Vistas.ElementosVisuales.Computador();
			this.switch1 = new RedesIP.Vistas.ElementosVisuales.Switch();
			((System.ComponentModel.ISupportInitialize)(this.computador1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.switch1)).BeginInit();
			this.SuspendLayout();
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(776, 468);
			this.Controls.Add(this.switch1);
			this.Controls.Add(this.computador1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.computador1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.switch1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RedesIP.Vistas.ElementosVisuales.Computador computador1;
		private RedesIP.Vistas.ElementosVisuales.Switch switch1;
	}
}

