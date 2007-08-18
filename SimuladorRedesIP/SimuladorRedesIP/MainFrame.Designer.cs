namespace RedesIP
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
			  this.button1 = new System.Windows.Forms.Button();
			  this.switch2 = new RedesIP.Vistas.ElementosVisuales.Switch();
			  this.computador2 = new RedesIP.Vistas.ElementosVisuales.Computador();
			  this.switch1 = new RedesIP.Vistas.ElementosVisuales.Switch();
			  this.computador1 = new RedesIP.Vistas.ElementosVisuales.Computador();
			  this.button2 = new System.Windows.Forms.Button();
			  ((System.ComponentModel.ISupportInitialize)(this.switch2)).BeginInit();
			  ((System.ComponentModel.ISupportInitialize)(this.computador2)).BeginInit();
			  ((System.ComponentModel.ISupportInitialize)(this.switch1)).BeginInit();
			  ((System.ComponentModel.ISupportInitialize)(this.computador1)).BeginInit();
			  this.SuspendLayout();
			  // 
			  // button1
			  // 
			  this.button1.Location = new System.Drawing.Point(552, 304);
			  this.button1.Name = "button1";
			  this.button1.Size = new System.Drawing.Size(169, 46);
			  this.button1.TabIndex = 4;
			  this.button1.Text = "button1";
			  this.button1.UseVisualStyleBackColor = true;
			  this.button1.Click += new System.EventHandler(this.button1_Click);
			  // 
			  // switch2
			  // 
			  this.switch2.Image = ((System.Drawing.Image)(resources.GetObject("switch2.Image")));
			  this.switch2.Location = new System.Drawing.Point(439, 145);
			  this.switch2.Name = "switch2";
			  this.switch2.OrigenX = 439;
			  this.switch2.OrigenY = 145;
			  this.switch2.Size = new System.Drawing.Size(139, 29);
			  this.switch2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			  this.switch2.TabIndex = 3;
			  this.switch2.TabStop = false;
			  // 
			  // computador2
			  // 
			  this.computador2.Image = ((System.Drawing.Image)(resources.GetObject("computador2.Image")));
			  this.computador2.Location = new System.Drawing.Point(179, 105);
			  this.computador2.Name = "computador2";
			  this.computador2.OrigenX = 179;
			  this.computador2.OrigenY = 105;
			  this.computador2.Size = new System.Drawing.Size(48, 43);
			  this.computador2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			  this.computador2.TabIndex = 2;
			  this.computador2.TabStop = false;
			  // 
			  // switch1
			  // 
			  this.switch1.Image = ((System.Drawing.Image)(resources.GetObject("switch1.Image")));
			  this.switch1.Location = new System.Drawing.Point(229, 287);
			  this.switch1.Name = "switch1";
			  this.switch1.OrigenX = 229;
			  this.switch1.OrigenY = 287;
			  this.switch1.Size = new System.Drawing.Size(139, 29);
			  this.switch1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			  this.switch1.TabIndex = 1;
			  this.switch1.TabStop = false;
			  // 
			  // computador1
			  // 
			  this.computador1.Image = ((System.Drawing.Image)(resources.GetObject("computador1.Image")));
			  this.computador1.Location = new System.Drawing.Point(336, 87);
			  this.computador1.Name = "computador1";
			  this.computador1.OrigenX = 336;
			  this.computador1.OrigenY = 87;
			  this.computador1.Size = new System.Drawing.Size(48, 43);
			  this.computador1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			  this.computador1.TabIndex = 0;
			  this.computador1.TabStop = false;
			  // 
			  // button2
			  // 
			  this.button2.Location = new System.Drawing.Point(337, 385);
			  this.button2.Name = "button2";
			  this.button2.Size = new System.Drawing.Size(111, 47);
			  this.button2.TabIndex = 5;
			  this.button2.Text = "button2";
			  this.button2.UseVisualStyleBackColor = true;
			  this.button2.Click += new System.EventHandler(this.button2_Click);
			  // 
			  // MainFrame
			  // 
			  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			  this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			  this.ClientSize = new System.Drawing.Size(805, 622);
			  this.Controls.Add(this.button2);
			  this.Controls.Add(this.button1);
			  this.Controls.Add(this.switch2);
			  this.Controls.Add(this.computador2);
			  this.Controls.Add(this.switch1);
			  this.Controls.Add(this.computador1);
			  this.Name = "MainFrame";
			  this.Text = "Form1";
			  ((System.ComponentModel.ISupportInitialize)(this.switch2)).EndInit();
			  ((System.ComponentModel.ISupportInitialize)(this.computador2)).EndInit();
			  ((System.ComponentModel.ISupportInitialize)(this.switch1)).EndInit();
			  ((System.ComponentModel.ISupportInitialize)(this.computador1)).EndInit();
			  this.ResumeLayout(false);
			  this.PerformLayout();

        }

        #endregion

		 private RedesIP.Vistas.ElementosVisuales.Computador computador1;
		 private RedesIP.Vistas.ElementosVisuales.Switch switch1;
		 private RedesIP.Vistas.ElementosVisuales.Computador computador2;
		 private RedesIP.Vistas.ElementosVisuales.Switch switch2;
		 private System.Windows.Forms.Button button1;
		 private System.Windows.Forms.Button button2;




	  }
}

