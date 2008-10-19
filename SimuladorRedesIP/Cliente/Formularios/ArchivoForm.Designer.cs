namespace SimuladorCliente.Formularios
{
    partial class ArchivoForm
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
            System.Windows.Forms.Label destinationPortLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label fileNameLabel;
            System.Windows.Forms.Label lengthLabel;
            System.Windows.Forms.Label sourcePortLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.archivoSOABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.destinationPortTextBox = new System.Windows.Forms.TextBox();
            this.fechaTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.sourcePortTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourcePortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationPortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            destinationPortLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            fileNameLabel = new System.Windows.Forms.Label();
            lengthLabel = new System.Windows.Forms.Label();
            sourcePortLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.archivoSOABindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // destinationPortLabel
            // 
            destinationPortLabel.AutoSize = true;
            destinationPortLabel.Location = new System.Drawing.Point(6, 126);
            destinationPortLabel.Name = "destinationPortLabel";
            destinationPortLabel.Size = new System.Drawing.Size(80, 13);
            destinationPortLabel.TabIndex = 1;
            destinationPortLabel.Text = "Puerto Destino:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(6, 48);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(98, 13);
            fechaLabel.TabIndex = 3;
            fechaLabel.Text = "Hora de recepción:";
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new System.Drawing.Point(6, 22);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new System.Drawing.Size(47, 13);
            fileNameLabel.TabIndex = 5;
            fileNameLabel.Text = "Nombre:";
            // 
            // lengthLabel
            // 
            lengthLabel.AutoSize = true;
            lengthLabel.Location = new System.Drawing.Point(6, 74);
            lengthLabel.Name = "lengthLabel";
            lengthLabel.Size = new System.Drawing.Size(49, 13);
            lengthLabel.TabIndex = 9;
            lengthLabel.Text = "Tamaño:";
            // 
            // sourcePortLabel
            // 
            sourcePortLabel.AutoSize = true;
            sourcePortLabel.Location = new System.Drawing.Point(6, 100);
            sourcePortLabel.Name = "sourcePortLabel";
            sourcePortLabel.Size = new System.Drawing.Size(75, 13);
            sourcePortLabel.TabIndex = 11;
            sourcePortLabel.Text = "Puerto Origen:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(197, 78);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 13);
            label1.TabIndex = 14;
            label1.Text = "bytes";
            // 
            // archivoSOABindingSource
            // 
            this.archivoSOABindingSource.DataSource = typeof(SOA.ArchivoSOA);
            // 
            // destinationPortTextBox
            // 
            this.destinationPortTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.archivoSOABindingSource, "DestinationPort", true));
            this.destinationPortTextBox.Location = new System.Drawing.Point(107, 123);
            this.destinationPortTextBox.Name = "destinationPortTextBox";
            this.destinationPortTextBox.ReadOnly = true;
            this.destinationPortTextBox.Size = new System.Drawing.Size(65, 20);
            this.destinationPortTextBox.TabIndex = 2;
            // 
            // fechaTextBox
            // 
            this.fechaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.archivoSOABindingSource, "Fecha", true));
            this.fechaTextBox.Location = new System.Drawing.Point(107, 45);
            this.fechaTextBox.Name = "fechaTextBox";
            this.fechaTextBox.ReadOnly = true;
            this.fechaTextBox.Size = new System.Drawing.Size(122, 20);
            this.fechaTextBox.TabIndex = 4;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.archivoSOABindingSource, "FileName", true));
            this.fileNameTextBox.Location = new System.Drawing.Point(107, 19);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            this.fileNameTextBox.Size = new System.Drawing.Size(122, 20);
            this.fileNameTextBox.TabIndex = 6;
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.archivoSOABindingSource, "Length", true));
            this.lengthTextBox.Location = new System.Drawing.Point(107, 71);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.ReadOnly = true;
            this.lengthTextBox.Size = new System.Drawing.Size(84, 20);
            this.lengthTextBox.TabIndex = 10;
            // 
            // sourcePortTextBox
            // 
            this.sourcePortTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.archivoSOABindingSource, "SourcePort", true));
            this.sourcePortTextBox.Location = new System.Drawing.Point(107, 97);
            this.sourcePortTextBox.Name = "sourcePortTextBox";
            this.sourcePortTextBox.ReadOnly = true;
            this.sourcePortTextBox.Size = new System.Drawing.Size(65, 20);
            this.sourcePortTextBox.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.destinationPortTextBox);
            this.groupBox1.Controls.Add(destinationPortLabel);
            this.groupBox1.Controls.Add(this.sourcePortTextBox);
            this.groupBox1.Controls.Add(sourcePortLabel);
            this.groupBox1.Controls.Add(fechaLabel);
            this.groupBox1.Controls.Add(this.lengthTextBox);
            this.groupBox1.Controls.Add(this.fechaTextBox);
            this.groupBox1.Controls.Add(lengthLabel);
            this.groupBox1.Controls.Add(fileNameLabel);
            this.groupBox1.Controls.Add(this.fileNameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 178);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del archivo recibido";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 150);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 22);
            this.button3.TabIndex = 13;
            this.button3.Text = "Guardar archivo como...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameDataGridViewTextBoxColumn,
            this.lengthDataGridViewTextBoxColumn,
            this.sourcePortDataGridViewTextBoxColumn,
            this.destinationPortDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.archivoSOABindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(515, 121);
            this.dataGridView1.TabIndex = 13;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lengthDataGridViewTextBoxColumn
            // 
            this.lengthDataGridViewTextBoxColumn.DataPropertyName = "Length";
            this.lengthDataGridViewTextBoxColumn.HeaderText = "Tamaño";
            this.lengthDataGridViewTextBoxColumn.Name = "lengthDataGridViewTextBoxColumn";
            this.lengthDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sourcePortDataGridViewTextBoxColumn
            // 
            this.sourcePortDataGridViewTextBoxColumn.DataPropertyName = "SourcePort";
            this.sourcePortDataGridViewTextBoxColumn.HeaderText = "Puerto Origen";
            this.sourcePortDataGridViewTextBoxColumn.Name = "sourcePortDataGridViewTextBoxColumn";
            this.sourcePortDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // destinationPortDataGridViewTextBoxColumn
            // 
            this.destinationPortDataGridViewTextBoxColumn.DataPropertyName = "DestinationPort";
            this.destinationPortDataGridViewTextBoxColumn.HeaderText = "Puerto Destino";
            this.destinationPortDataGridViewTextBoxColumn.Name = "destinationPortDataGridViewTextBoxColumn";
            this.destinationPortDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Hora";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(527, 148);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Archivos recibidos";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 26);
            this.button1.TabIndex = 15;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ArchivoForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ArchivoForm";
            this.Text = "Archivos Recibidos";
            ((System.ComponentModel.ISupportInitialize)(this.archivoSOABindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource archivoSOABindingSource;
        private System.Windows.Forms.TextBox destinationPortTextBox;
        private System.Windows.Forms.TextBox fechaTextBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.TextBox sourcePortTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcePortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationPortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
    }
}