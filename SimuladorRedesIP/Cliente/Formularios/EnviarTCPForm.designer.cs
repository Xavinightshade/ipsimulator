namespace SimuladorCliente.Formularios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._puertoDestino = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._puertoOrigen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._equipoInfo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this._sizeStream = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this._windowSize = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._escala = new System.Windows.Forms.DomainUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this._segmentSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ipTextBox1 = new SimuladorCliente.NewFolder1.IPTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this._Aceptar.Location = new System.Drawing.Point(12, 433);
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
            this._cancel.Location = new System.Drawing.Point(192, 433);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(85, 23);
            this._cancel.TabIndex = 7;
            this._cancel.Text = "Cancelar";
            this._cancel.UseVisualStyleBackColor = true;
            this._cancel.Click += new System.EventHandler(this._cancel_Click);
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
            this.groupBox1.Size = new System.Drawing.Size(265, 99);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Destino";
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
            // _puertoOrigen
            // 
            this._puertoOrigen.Location = new System.Drawing.Point(83, 45);
            this._puertoOrigen.Name = "_puertoOrigen";
            this._puertoOrigen.Size = new System.Drawing.Size(55, 20);
            this._puertoOrigen.TabIndex = 4;
            this._puertoOrigen.Text = "4000";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._equipoInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 316);
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
            this._equipoInfo.Size = new System.Drawing.Size(247, 86);
            this._equipoInfo.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this._sizeStream);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(265, 91);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stream";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "bytes";
            // 
            // _sizeStream
            // 
            this._sizeStream.Location = new System.Drawing.Point(99, 63);
            this._sizeStream.Name = "_sizeStream";
            this._sizeStream.ReadOnly = true;
            this._sizeStream.Size = new System.Drawing.Size(64, 20);
            this._sizeStream.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Tamaño Window";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(8, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Seleccione un archivo";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(48, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 22);
            this.button1.TabIndex = 11;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Archivo";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this._windowSize);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this._escala);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this._segmentSize);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(12, 214);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(212, 96);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Opciones";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(174, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "bytes";
            // 
            // _windowSize
            // 
            this._windowSize.Location = new System.Drawing.Point(108, 64);
            this._windowSize.Name = "_windowSize";
            this._windowSize.ReadOnly = true;
            this._windowSize.Size = new System.Drawing.Size(64, 20);
            this._windowSize.TabIndex = 14;
            this._windowSize.Text = "4000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tamaño Window";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(174, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "bytes";
            // 
            // _escala
            // 
            this._escala.Items.Add("32");
            this._escala.Items.Add("16");
            this._escala.Items.Add("8");
            this._escala.Items.Add("4");
            this._escala.Items.Add("2");
            this._escala.Items.Add("1");
            this._escala.Location = new System.Drawing.Point(108, 41);
            this._escala.Name = "_escala";
            this._escala.ReadOnly = true;
            this._escala.Size = new System.Drawing.Size(64, 20);
            this._escala.TabIndex = 11;
            this._escala.Text = "1";
            this._escala.SelectedItemChanged += new System.EventHandler(this._escala_SelectedItemChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Escala Window";
            // 
            // _segmentSize
            // 
            this._segmentSize.Location = new System.Drawing.Point(108, 17);
            this._segmentSize.Name = "_segmentSize";
            this._segmentSize.Size = new System.Drawing.Size(64, 20);
            this._segmentSize.TabIndex = 8;
            this._segmentSize.Text = "4000";
            this._segmentSize.TextChanged += new System.EventHandler(this._segmentSize_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tamaño Segmento";
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
            // EnviarTCPForm
            // 
            this.AcceptButton = this._Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 468);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._Aceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "EnviarTCPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enviar TCP Stream";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _segmentSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DomainUpDown _escala;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _windowSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _sizeStream;
        private System.Windows.Forms.Label label12;
    }
}