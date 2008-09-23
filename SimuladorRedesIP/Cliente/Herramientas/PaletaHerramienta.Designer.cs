namespace SimuladorCliente.Herramientas
{
    partial class PaletaHerramienta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaletaHerramienta));
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this._mouse = new System.Windows.Forms.Button();
            this._punta = new System.Windows.Forms.Button();
            this._conexion = new System.Windows.Forms.Button();
            this._router = new System.Windows.Forms.Button();
            this._switch = new System.Windows.Forms.Button();
            this._pc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button8.FlatAppearance.BorderSize = 5;
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.Location = new System.Drawing.Point(7, 17);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(106, 84);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button7.FlatAppearance.BorderSize = 5;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(7, 107);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(106, 80);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // _mouse
            // 
            this._mouse.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._mouse.FlatAppearance.BorderSize = 5;
            this._mouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._mouse.Image = global::SimuladorCliente.Properties.Resources.mouse;
            this._mouse.Location = new System.Drawing.Point(12, 12);
            this._mouse.Name = "_mouse";
            this._mouse.Size = new System.Drawing.Size(106, 57);
            this._mouse.TabIndex = 5;
            this._mouse.UseVisualStyleBackColor = true;
            this._mouse.Click += new System.EventHandler(this._mouse_Click);
            // 
            // _punta
            // 
            this._punta.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._punta.FlatAppearance.BorderSize = 5;
            this._punta.Image = global::SimuladorCliente.Properties.Resources.sniffer;
            this._punta.Location = new System.Drawing.Point(6, 83);
            this._punta.Name = "_punta";
            this._punta.Size = new System.Drawing.Size(106, 67);
            this._punta.TabIndex = 4;
            this._punta.UseVisualStyleBackColor = true;
            this._punta.Click += new System.EventHandler(this._punta_Click);
            // 
            // _conexion
            // 
            this._conexion.BackColor = System.Drawing.Color.DarkRed;
            this._conexion.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._conexion.FlatAppearance.BorderSize = 5;
            this._conexion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this._conexion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._conexion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this._conexion.Image = global::SimuladorCliente.Properties.Resources.Cable;
            this._conexion.Location = new System.Drawing.Point(6, 19);
            this._conexion.Name = "_conexion";
            this._conexion.Size = new System.Drawing.Size(106, 58);
            this._conexion.TabIndex = 3;
            this._conexion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this._conexion.UseVisualStyleBackColor = false;
            this._conexion.Click += new System.EventHandler(this._conexion_Click);
            // 
            // _router
            // 
            this._router.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._router.FlatAppearance.BorderSize = 3;
            this._router.Image = global::SimuladorCliente.Properties.Resources.Router;
            this._router.Location = new System.Drawing.Point(6, 100);
            this._router.Name = "_router";
            this._router.Size = new System.Drawing.Size(110, 29);
            this._router.TabIndex = 2;
            this._router.UseVisualStyleBackColor = true;
            this._router.Click += new System.EventHandler(this._router_Click);
            // 
            // _switch
            // 
            this._switch.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._switch.FlatAppearance.BorderSize = 3;
            this._switch.Image = global::SimuladorCliente.Properties.Resources.Switch;
            this._switch.Location = new System.Drawing.Point(6, 65);
            this._switch.Name = "_switch";
            this._switch.Size = new System.Drawing.Size(110, 29);
            this._switch.TabIndex = 1;
            this._switch.UseVisualStyleBackColor = true;
            this._switch.Click += new System.EventHandler(this._switch_Click);
            // 
            // _pc
            // 
            this._pc.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._pc.FlatAppearance.BorderSize = 3;
            this._pc.Image = global::SimuladorCliente.Properties.Resources.Computador;
            this._pc.Location = new System.Drawing.Point(39, 19);
            this._pc.Name = "_pc";
            this._pc.Size = new System.Drawing.Size(45, 40);
            this._pc.TabIndex = 0;
            this._pc.UseVisualStyleBackColor = true;
            this._pc.Click += new System.EventHandler(this._pc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 382);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 195);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._conexion);
            this.groupBox2.Controls.Add(this._punta);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 158);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conexiones";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._pc);
            this.groupBox3.Controls.Add(this._switch);
            this.groupBox3.Controls.Add(this._router);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(123, 137);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Equipos";
            // 
            // PaletaHerramienta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(140, 609);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._mouse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaletaHerramienta";
            this.TabText = "Paleta";
            this.Text = "Paleta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _pc;
        private System.Windows.Forms.Button _switch;
        private System.Windows.Forms.Button _router;
        private System.Windows.Forms.Button _conexion;
        private System.Windows.Forms.Button _punta;
        private System.Windows.Forms.Button _mouse;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}