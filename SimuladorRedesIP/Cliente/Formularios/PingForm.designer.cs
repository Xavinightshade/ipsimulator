namespace SimuladorCliente.Formularios
{
    partial class PingForm
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
            this._Aceptar = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this.ipTextBox1 = new SimuladorCliente.NewFolder1.IPTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._dato = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._equipoInfo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dirección IP";
            // 
            // _Aceptar
            // 
            this._Aceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Aceptar.Location = new System.Drawing.Point(12, 243);
            this._Aceptar.Name = "_Aceptar";
            this._Aceptar.Size = new System.Drawing.Size(85, 23);
            this._Aceptar.TabIndex = 6;
            this._Aceptar.Text = "Enviar";
            this._Aceptar.UseVisualStyleBackColor = true;
            this._Aceptar.Click += new System.EventHandler(this._Aceptar_Click);
            // 
            // _cancel
            // 
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(192, 243);
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
            this.ipTextBox1.Location = new System.Drawing.Point(83, 19);
            this.ipTextBox1.Name = "ipTextBox1";
            this.ipTextBox1.ReadOnly = false;
            this.ipTextBox1.Size = new System.Drawing.Size(173, 20);
            this.ipTextBox1.TabIndex = 1;
            this.ipTextBox1.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dato:";
            // 
            // _dato
            // 
            this._dato.Location = new System.Drawing.Point(83, 47);
            this._dato.Multiline = true;
            this._dato.Name = "_dato";
            this._dato.Size = new System.Drawing.Size(173, 43);
            this._dato.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ipTextBox1);
            this.groupBox1.Controls.Add(this._dato);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 99);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Destino";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._equipoInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 111);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información Equipo Actual";
            // 
            // _equipoInfo
            // 
            this._equipoInfo.Location = new System.Drawing.Point(9, 19);
            this._equipoInfo.Multiline = true;
            this._equipoInfo.Name = "_equipoInfo";
            this._equipoInfo.ReadOnly = true;
            this._equipoInfo.Size = new System.Drawing.Size(247, 77);
            this._equipoInfo.TabIndex = 3;
            // 
            // PingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 280);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._Aceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "PingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Computador";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SimuladorCliente.NewFolder1.IPTextBox ipTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _Aceptar;
        private System.Windows.Forms.Button _cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _dato;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _equipoInfo;
    }
}