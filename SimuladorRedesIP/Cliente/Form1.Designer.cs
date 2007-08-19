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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.estacionVista1 = new RedesIP.Vistas.EstacionVista();
			((System.ComponentModel.ISupportInitialize)(this.estacionVista1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(2, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(103, 25);
			this.button1.TabIndex = 0;
			this.button1.Text = "Crear Dispo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(146, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 24);
			this.button2.TabIndex = 2;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// estacionVista1
			// 
			this.estacionVista1.BackColor = System.Drawing.Color.DarkBlue;
			this.estacionVista1.Location = new System.Drawing.Point(2, 39);
			this.estacionVista1.Name = "estacionVista1";
			this.estacionVista1.Size = new System.Drawing.Size(777, 470);
			this.estacionVista1.TabIndex = 1;
			this.estacionVista1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(791, 521);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.estacionVista1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.estacionVista1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private RedesIP.Vistas.EstacionVista estacionVista1;
		private System.Windows.Forms.Button button2;



	}
}

