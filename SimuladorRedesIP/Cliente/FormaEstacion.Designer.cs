namespace SimuladorCliente
{
    partial class FormaEstacion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._estacionView = new RedesIP.Vistas.EstacionView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._estacionView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(44)))));
            this.panel1.Controls.Add(this._estacionView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 337);
            this.panel1.TabIndex = 8;
            // 
            // _estacionView
            // 
            this._estacionView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(44)))));
            this._estacionView.Cursor = System.Windows.Forms.Cursors.Default;
            this._estacionView.Location = new System.Drawing.Point(0, 0);
            this._estacionView.Name = "_estacionView";
            this._estacionView.Size = new System.Drawing.Size(10, 10);
            this._estacionView.TabIndex = 7;
            this._estacionView.TabStop = false;
            // 
            // FormaEstacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 337);
            this.Controls.Add(this.panel1);
            this.Name = "FormaEstacion";
            this.TabText = "FormaEstacion";
            this.Text = "FormaEstacion";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._estacionView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RedesIP.Vistas.EstacionView _estacionView;
        private System.Windows.Forms.Panel panel1;
    }
}