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
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this._estacionView = new RedesIP.Vistas.EstacionView();
			((System.ComponentModel.ISupportInitialize)(this._estacionView)).BeginInit();
			this.SuspendLayout();
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
			// _estacionView
			// 
			this._estacionView.BackColor = System.Drawing.Color.MidnightBlue;
			this._estacionView.Location = new System.Drawing.Point(12, 12);
			this._estacionView.Name = "_estacionView";
			this._estacionView.Size = new System.Drawing.Size(1165, 778);
			this._estacionView.TabIndex = 0;
			this._estacionView.TabStop = false;
			// 
			// MainFrame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1189, 802);
			this.Controls.Add(this._estacionView);
			this.Name = "MainFrame";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this._estacionView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList imageList1;
		private RedesIP.Vistas.EstacionView _estacionView;



	}
}

