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
            this._estacionView = new RedesIP.Vistas.EstacionView();
            ((System.ComponentModel.ISupportInitialize)(this._estacionView)).BeginInit();
            this.SuspendLayout();
            // 
            // _estacionView
            // 
            this._estacionView.BackColor = System.Drawing.Color.Black;
            this._estacionView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._estacionView.Location = new System.Drawing.Point(0, 0);
            this._estacionView.Name = "_estacionView";
            this._estacionView.Size = new System.Drawing.Size(292, 266);
            this._estacionView.TabIndex = 7;
            this._estacionView.TabStop = false;
            // 
            // FormaEstacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this._estacionView);
            this.Name = "FormaEstacion";
            this.TabText = "FormaEstacion";
            this.Text = "FormaEstacion";
            ((System.ComponentModel.ISupportInitialize)(this._estacionView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RedesIP.Vistas.EstacionView _estacionView;
    }
}