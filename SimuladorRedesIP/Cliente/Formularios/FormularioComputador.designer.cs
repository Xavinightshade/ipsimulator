namespace SimuladorCliente.Formularios
{
    partial class FormularioComputador
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._nombrePuerto = new System.Windows.Forms.TextBox();
            this._Aceptar = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this.ipTextBox1 = new SimuladorCliente.NewFolder1.IPTextBox();
            this.macTextBox1 = new SimuladorCliente.Formularios.MACTextBox();
            this._nombrePc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._defaultGW = new SimuladorCliente.NewFolder1.IPTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dirección IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dirección MAC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre Equipo";
            // 
            // _nombrePuerto
            // 
            this._nombrePuerto.Location = new System.Drawing.Point(107, 107);
            this._nombrePuerto.Name = "_nombrePuerto";
            this._nombrePuerto.Size = new System.Drawing.Size(47, 20);
            this._nombrePuerto.TabIndex = 5;
            // 
            // _Aceptar
            // 
            this._Aceptar.Location = new System.Drawing.Point(15, 183);
            this._Aceptar.Name = "_Aceptar";
            this._Aceptar.Size = new System.Drawing.Size(85, 23);
            this._Aceptar.TabIndex = 6;
            this._Aceptar.Text = "Aceptar";
            this._Aceptar.UseVisualStyleBackColor = true;
            this._Aceptar.Click += new System.EventHandler(this._Aceptar_Click);
            // 
            // _cancel
            // 
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(195, 183);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(85, 23);
            this._cancel.TabIndex = 7;
            this._cancel.Text = "Cancelar";
            this._cancel.UseVisualStyleBackColor = true;
            this._cancel.Click += new System.EventHandler(this._cancel_Click);
            // 
            // ipTextBox1
            // 
            this.ipTextBox1.AllowInternalTab = false;
            this.ipTextBox1.AutoHeight = true;
            this.ipTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.ipTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipTextBox1.Location = new System.Drawing.Point(107, 51);
            this.ipTextBox1.Name = "ipTextBox1";
            this.ipTextBox1.ReadOnly = false;
            this.ipTextBox1.Size = new System.Drawing.Size(173, 20);
            this.ipTextBox1.TabIndex = 1;
            this.ipTextBox1.Text = "...";
            // 
            // macTextBox1
            // 
            this.macTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.macTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.macTextBox1.Location = new System.Drawing.Point(107, 133);
            this.macTextBox1.Name = "macTextBox1";
            this.macTextBox1.Size = new System.Drawing.Size(173, 20);
            this.macTextBox1.TabIndex = 0;
            // 
            // _nombrePc
            // 
            this._nombrePc.Location = new System.Drawing.Point(107, 25);
            this._nombrePc.Name = "_nombrePc";
            this._nombrePc.Size = new System.Drawing.Size(131, 20);
            this._nombrePc.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nombre Puerto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Default GateWay";
            // 
            // _defaultGW
            // 
            this._defaultGW.AllowInternalTab = false;
            this._defaultGW.AutoHeight = true;
            this._defaultGW.BackColor = System.Drawing.SystemColors.Window;
            this._defaultGW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._defaultGW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._defaultGW.Location = new System.Drawing.Point(106, 81);
            this._defaultGW.Name = "_defaultGW";
            this._defaultGW.ReadOnly = false;
            this._defaultGW.Size = new System.Drawing.Size(173, 20);
            this._defaultGW.TabIndex = 10;
            this._defaultGW.Text = "...";
            // 
            // FormularioComputador
            // 
            this.AcceptButton = this._Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(302, 230);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._defaultGW);
            this.Controls.Add(this._nombrePc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._Aceptar);
            this.Controls.Add(this._nombrePuerto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipTextBox1);
            this.Controls.Add(this.macTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormularioComputador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Computador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MACTextBox macTextBox1;
        private SimuladorCliente.NewFolder1.IPTextBox ipTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _nombrePuerto;
        private System.Windows.Forms.Button _Aceptar;
        private System.Windows.Forms.Button _cancel;
        private System.Windows.Forms.TextBox _nombrePc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private SimuladorCliente.NewFolder1.IPTextBox _defaultGW;
    }
}