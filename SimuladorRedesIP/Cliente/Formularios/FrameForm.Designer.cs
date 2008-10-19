namespace SimuladorCliente.Formularios
{
    partial class FrameForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._datos = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._hora = new System.Windows.Forms.TextBox();
            this._macOrigen = new SimuladorCliente.Formularios.MACTextBox();
            this._macDestino = new SimuladorCliente.Formularios.MACTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "MAC Origen:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "MAC Destino:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Dato:";
            // 
            // _datos
            // 
            this._datos.Location = new System.Drawing.Point(9, 93);
            this._datos.Multiline = true;
            this._datos.Name = "_datos";
            this._datos.ReadOnly = true;
            this._datos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._datos.Size = new System.Drawing.Size(245, 133);
            this._datos.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._datos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._macOrigen);
            this.groupBox1.Controls.Add(this._macDestino);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 232);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información del Frame";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 25);
            this.button1.TabIndex = 13;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Hora de recepción";
            // 
            // _hora
            // 
            this._hora.Location = new System.Drawing.Point(113, 250);
            this._hora.Name = "_hora";
            this._hora.ReadOnly = true;
            this._hora.Size = new System.Drawing.Size(153, 20);
            this._hora.TabIndex = 15;
            // 
            // _macOrigen
            // 
            this._macOrigen.BackColor = System.Drawing.SystemColors.Window;
            this._macOrigen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._macOrigen.Location = new System.Drawing.Point(81, 19);
            this._macOrigen.Name = "_macOrigen";
            this._macOrigen.Size = new System.Drawing.Size(173, 20);
            this._macOrigen.TabIndex = 7;
            // 
            // _macDestino
            // 
            this._macDestino.BackColor = System.Drawing.SystemColors.Window;
            this._macDestino.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._macDestino.Location = new System.Drawing.Point(81, 45);
            this._macDestino.Name = "_macDestino";
            this._macDestino.Size = new System.Drawing.Size(173, 20);
            this._macDestino.TabIndex = 9;
            // 
            // FrameForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 308);
            this.Controls.Add(this._hora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frame";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MACTextBox _macOrigen;
        private System.Windows.Forms.Label label2;
        private MACTextBox _macDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _datos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _hora;
    }
}