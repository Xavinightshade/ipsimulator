﻿namespace SimuladorCliente.Formularios
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
            this.label3 = new System.Windows.Forms.Label();
            this._numero = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dirección IP";
            // 
            // _Aceptar
            // 
            this._Aceptar.Location = new System.Drawing.Point(12, 162);
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
            this._cancel.Location = new System.Drawing.Point(183, 162);
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
            this.ipTextBox1.Location = new System.Drawing.Point(95, 24);
            this.ipTextBox1.Name = "ipTextBox1";
            this.ipTextBox1.ReadOnly = false;
            this.ipTextBox1.Size = new System.Drawing.Size(173, 20);
            this.ipTextBox1.TabIndex = 1;
            this.ipTextBox1.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dato:";
            // 
            // _dato
            // 
            this._dato.Location = new System.Drawing.Point(95, 56);
            this._dato.Multiline = true;
            this._dato.Name = "_dato";
            this._dato.Size = new System.Drawing.Size(173, 43);
            this._dato.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Numero";
            // 
            // _numero
            // 
            this._numero.Location = new System.Drawing.Point(95, 113);
            this._numero.Name = "_numero";
            this._numero.Size = new System.Drawing.Size(62, 20);
            this._numero.TabIndex = 11;
            // 
            // PingForm
            // 
            this.AcceptButton = this._Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(285, 197);
            this.Controls.Add(this._numero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._dato);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._Aceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Computador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SimuladorCliente.NewFolder1.IPTextBox ipTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _Aceptar;
        private System.Windows.Forms.Button _cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _dato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _numero;
    }
}