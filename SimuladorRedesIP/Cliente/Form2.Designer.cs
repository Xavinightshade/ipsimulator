namespace SimuladorCliente
{
	partial class Form2
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
			this.estacionVista1 = new RedesIP.Vistas.EstacionVista();
			((System.ComponentModel.ISupportInitialize)(this.estacionVista1)).BeginInit();
			this.SuspendLayout();
			// 
			// estacionVista1
			// 
			this.estacionVista1.BackColor = System.Drawing.Color.Black;
			this.estacionVista1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.estacionVista1.Location = new System.Drawing.Point(0, 0);
			this.estacionVista1.Name = "estacionVista1";
			this.estacionVista1.Size = new System.Drawing.Size(1127, 571);
			this.estacionVista1.TabIndex = 0;
			this.estacionVista1.TabStop = false;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1127, 571);
			this.Controls.Add(this.estacionVista1);
			this.Name = "Form2";
			this.Text = "Form2";
			((System.ComponentModel.ISupportInitialize)(this.estacionVista1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RedesIP.Vistas.EstacionVista estacionVista1;
	}
}