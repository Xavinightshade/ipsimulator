namespace SimuladorCliente.Formularios
{
    partial class DesEncapsulacion
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
            this.label1 = new System.Windows.Forms.Label();
            this._ipOrigen2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._datos2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._ipDestino2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._datos1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._ipDestino1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._ipOrigen1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._macDestino = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._macOrigen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this._fecha = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Origen:";
            // 
            // _ipOrigen2
            // 
            this._ipOrigen2.Location = new System.Drawing.Point(68, 19);
            this._ipOrigen2.Name = "_ipOrigen2";
            this._ipOrigen2.ReadOnly = true;
            this._ipOrigen2.Size = new System.Drawing.Size(105, 20);
            this._ipOrigen2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._datos2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._ipDestino2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._ipOrigen2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(309, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 244);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paquete IP";
            // 
            // _datos2
            // 
            this._datos2.Location = new System.Drawing.Point(6, 93);
            this._datos2.Multiline = true;
            this._datos2.Name = "_datos2";
            this._datos2.ReadOnly = true;
            this._datos2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._datos2.Size = new System.Drawing.Size(243, 145);
            this._datos2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dato:";
            // 
            // _ipDestino2
            // 
            this._ipDestino2.Location = new System.Drawing.Point(68, 45);
            this._ipDestino2.Name = "_ipDestino2";
            this._ipDestino2.ReadOnly = true;
            this._ipDestino2.Size = new System.Drawing.Size(106, 20);
            this._ipDestino2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP Destino:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this._macDestino);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this._macOrigen);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 315);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Frame";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._datos1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this._ipDestino1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this._ipOrigen1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(6, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 235);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dato";
            // 
            // _datos1
            // 
            this._datos1.Location = new System.Drawing.Point(10, 90);
            this._datos1.Multiline = true;
            this._datos1.Name = "_datos1";
            this._datos1.ReadOnly = true;
            this._datos1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._datos1.Size = new System.Drawing.Size(240, 139);
            this._datos1.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Dato:";
            // 
            // _ipDestino1
            // 
            this._ipDestino1.Location = new System.Drawing.Point(68, 45);
            this._ipDestino1.Name = "_ipDestino1";
            this._ipDestino1.ReadOnly = true;
            this._ipDestino1.Size = new System.Drawing.Size(106, 20);
            this._ipDestino1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "IP Destino:";
            // 
            // _ipOrigen1
            // 
            this._ipOrigen1.Location = new System.Drawing.Point(68, 19);
            this._ipOrigen1.Name = "_ipOrigen1";
            this._ipOrigen1.ReadOnly = true;
            this._ipOrigen1.Size = new System.Drawing.Size(105, 20);
            this._ipOrigen1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "IP Origen:";
            // 
            // _macDestino
            // 
            this._macDestino.Location = new System.Drawing.Point(82, 45);
            this._macDestino.Name = "_macDestino";
            this._macDestino.ReadOnly = true;
            this._macDestino.Size = new System.Drawing.Size(180, 20);
            this._macDestino.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "MAC Destino:";
            // 
            // _macOrigen
            // 
            this._macOrigen.Location = new System.Drawing.Point(82, 19);
            this._macOrigen.Name = "_macOrigen";
            this._macOrigen.ReadOnly = true;
            this._macOrigen.Size = new System.Drawing.Size(180, 20);
            this._macOrigen.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "MAC Origen:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(287, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "->";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _fecha
            // 
            this._fecha.Location = new System.Drawing.Point(12, 36);
            this._fecha.Name = "_fecha";
            this._fecha.ReadOnly = true;
            this._fecha.Size = new System.Drawing.Size(161, 20);
            this._fecha.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Hora de desencapsulación";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this._fecha);
            this.groupBox4.Location = new System.Drawing.Point(309, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(180, 63);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            // 
            // DesEncapsulacion
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 363);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "DesEncapsulacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desencapsulación";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _ipOrigen2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _datos2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _ipDestino2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox _datos1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _ipDestino1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _ipOrigen1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _macDestino;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _macOrigen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox _fecha;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}