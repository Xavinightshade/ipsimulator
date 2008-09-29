namespace SimuladorCliente.Formularios
{
    partial class FilterTableForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._grid = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._puerto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this._hora = new System.Windows.Forms.TextBox();
            this._direccionMAC = new System.Windows.Forms.TextBox();
            this._asociacionesBS = new System.Windows.Forms.BindingSource(this.components);
            this.DescPuerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.macAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._asociacionesBS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._grid);
            this.groupBox2.Location = new System.Drawing.Point(6, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 180);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tabla";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.AutoGenerateColumns = false;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DescPuerto,
            this.macAddressDataGridViewTextBoxColumn});
            this._grid.DataSource = this._asociacionesBS;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle2;
            this._grid.GridColor = System.Drawing.SystemColors.ControlLight;
            this._grid.Location = new System.Drawing.Point(7, 19);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this._grid.RowHeadersVisible = false;
            this._grid.RowHeadersWidth = 20;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.ShowEditingIcon = false;
            this._grid.Size = new System.Drawing.Size(255, 152);
            this._grid.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(201, 334);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 25);
            this.button4.TabIndex = 17;
            this.button4.Text = "Aceptar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._direccionMAC);
            this.groupBox1.Controls.Add(this._puerto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 75);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrada";
            // 
            // _puerto
            // 
            this._puerto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._asociacionesBS, "DescPuerto", true));
            this._puerto.Location = new System.Drawing.Point(90, 15);
            this._puerto.Name = "_puerto";
            this._puerto.ReadOnly = true;
            this._puerto.Size = new System.Drawing.Size(170, 20);
            this._puerto.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Puerto Ethernet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dirección MAC";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 290);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Hora de Modificación";
            // 
            // _hora
            // 
            this._hora.Location = new System.Drawing.Point(143, 308);
            this._hora.Name = "_hora";
            this._hora.ReadOnly = true;
            this._hora.Size = new System.Drawing.Size(147, 20);
            this._hora.TabIndex = 27;
            // 
            // _direccionMAC
            // 
            this._direccionMAC.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._asociacionesBS, "MacAddress", true));
            this._direccionMAC.Location = new System.Drawing.Point(92, 46);
            this._direccionMAC.Name = "_direccionMAC";
            this._direccionMAC.ReadOnly = true;
            this._direccionMAC.Size = new System.Drawing.Size(170, 20);
            this._direccionMAC.TabIndex = 7;
            // 
            // _asociacionesBS
            // 
            this._asociacionesBS.DataSource = typeof(SOA.Datos.AsociacionPuertoMACAddressSOA);
            // 
            // DescPuerto
            // 
            this.DescPuerto.DataPropertyName = "DescPuerto";
            this.DescPuerto.HeaderText = "DescPuerto";
            this.DescPuerto.Name = "DescPuerto";
            this.DescPuerto.ReadOnly = true;
            // 
            // macAddressDataGridViewTextBoxColumn
            // 
            this.macAddressDataGridViewTextBoxColumn.DataPropertyName = "MacAddress";
            this.macAddressDataGridViewTextBoxColumn.HeaderText = "MacAddress";
            this.macAddressDataGridViewTextBoxColumn.Name = "macAddressDataGridViewTextBoxColumn";
            this.macAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FilterTableForm
            // 
            this.AcceptButton = this.button4;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 366);
            this.Controls.Add(this._hora);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button4);
            this.Name = "FilterTableForm";
            this.Text = "Tabla de Filtro de Switch";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._asociacionesBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _hora;
        private System.Windows.Forms.TextBox _puerto;
        private System.Windows.Forms.BindingSource _asociacionesBS;
        private System.Windows.Forms.TextBox _direccionMAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescPuerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn macAddressDataGridViewTextBoxColumn;
    }
}