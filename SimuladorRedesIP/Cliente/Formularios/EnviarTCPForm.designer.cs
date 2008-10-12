﻿namespace SimuladorCliente.Formularios
{
    partial class EnviarTCPForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._equipoInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._puertoOrigen = new System.Windows.Forms.TextBox();
            this._puertoDestino = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this._Aceptar.Location = new System.Drawing.Point(12, 258);
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
            this._cancel.Location = new System.Drawing.Point(192, 258);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._puertoDestino);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._puertoOrigen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ipTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 114);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Destino";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._equipoInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 132);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Puerto Origen";
            // 
            // _puertoOrigen
            // 
            this._puertoOrigen.Location = new System.Drawing.Point(83, 45);
            this._puertoOrigen.Name = "_puertoOrigen";
            this._puertoOrigen.Size = new System.Drawing.Size(55, 20);
            this._puertoOrigen.TabIndex = 4;
            this._puertoOrigen.Text = "4000";
            // 
            // _puertoDestino
            // 
            this._puertoDestino.Location = new System.Drawing.Point(83, 71);
            this._puertoDestino.Name = "_puertoDestino";
            this._puertoDestino.Size = new System.Drawing.Size(55, 20);
            this._puertoDestino.TabIndex = 6;
            this._puertoDestino.Text = "5000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Puerto Destino";
            // 
            // EnviarTCPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 293);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._Aceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "EnviarTCPForm";
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _equipoInfo;
        private System.Windows.Forms.TextBox _puertoDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _puertoOrigen;
        private System.Windows.Forms.Label label2;
    }
}