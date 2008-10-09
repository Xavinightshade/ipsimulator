namespace SOA
{
    partial class CustomConnectionForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this._txtBoxPuerto = new System.Windows.Forms.TextBox();
            this._bsConfiguracion = new System.Windows.Forms.BindingSource(this.components);
            this._btnConectar = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.direccionesIpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._bsConfiguracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.direccionesIpBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puerto de Conexión:";
            // 
            // _txtBoxPuerto
            // 
            this._txtBoxPuerto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsConfiguracion, "Puerto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._txtBoxPuerto.Location = new System.Drawing.Point(121, 23);
            this._txtBoxPuerto.Name = "_txtBoxPuerto";
            this._txtBoxPuerto.Size = new System.Drawing.Size(38, 20);
            this._txtBoxPuerto.TabIndex = 1;
            this._txtBoxPuerto.Text = "8000";
            // 
            // _bsConfiguracion
            // 
            this._bsConfiguracion.DataSource = typeof(SOA.CustomConnectionModel);
            // 
            // _btnConectar
            // 
            this._btnConectar.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._bsConfiguracion, "IsValid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._btnConectar.Location = new System.Drawing.Point(38, 101);
            this._btnConectar.Name = "_btnConectar";
            this._btnConectar.Size = new System.Drawing.Size(65, 23);
            this._btnConectar.TabIndex = 2;
            this._btnConectar.Text = "Conectar";
            this._btnConectar.UseVisualStyleBackColor = true;
            this._btnConectar.Click += new System.EventHandler(this.button1_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancelar.Location = new System.Drawing.Point(144, 101);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(67, 23);
            this._btnCancelar.TabIndex = 3;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this._bsConfiguracion;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Direccion Ip:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this._bsConfiguracion, "DireccionIp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox1.DataSource = this.direccionesIpBindingSource;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(121, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // direccionesIpBindingSource
            // 
            this.direccionesIpBindingSource.DataMember = "DireccionesIp";
            this.direccionesIpBindingSource.DataSource = this._bsConfiguracion;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this._bsConfiguracion;
            // 
            // CustomConnectionForm
            // 
            this.AcceptButton = this._btnConectar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(267, 140);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnConectar);
            this.Controls.Add(this._txtBoxPuerto);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomConnectionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración Servidor Remoto";
            ((System.ComponentModel.ISupportInitialize)(this._bsConfiguracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.direccionesIpBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtBoxPuerto;
        private System.Windows.Forms.Button _btnConectar;
        private System.Windows.Forms.Button _btnCancelar;
        private System.Windows.Forms.BindingSource _bsConfiguracion;
        private System.Windows.Forms.ErrorProvider errorProvider1;
		  private System.Windows.Forms.Label label2;
		  private System.Windows.Forms.ComboBox comboBox1;
		  private System.Windows.Forms.ErrorProvider errorProvider2;
		  private System.Windows.Forms.BindingSource direccionesIpBindingSource;
    }
}