﻿namespace SimuladorCliente.Herramientas
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
            this._PaletaMouse = new System.Windows.Forms.Button();
            this._PaletaPunta = new System.Windows.Forms.Button();
            this._PaletaConexion = new System.Windows.Forms.Button();
            this._PaletaRouter = new System.Windows.Forms.Button();
            this._PaletaSwitch = new System.Windows.Forms.Button();
            this._PaletaPc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._paletaValorLabel = new System.Windows.Forms.Label();
            this._paletaTrackBar = new System.Windows.Forms.TrackBar();
            this._paletaSwitchVLan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._paletaTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // button8
            // 
            this.button8.BackgroundImage = global::SimuladorCliente.Properties.Resources.DB;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button8.FlatAppearance.BorderSize = 5;
            this.button8.Location = new System.Drawing.Point(7, 19);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(106, 67);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::SimuladorCliente.Properties.Resources.SOA;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button7.FlatAppearance.BorderSize = 5;
            this.button7.Location = new System.Drawing.Point(6, 92);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(106, 67);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // _PaletaMouse
            // 
            this._PaletaMouse.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._PaletaMouse.FlatAppearance.BorderSize = 5;
            this._PaletaMouse.Image = global::SimuladorCliente.Properties.Resources.mouse;
            this._PaletaMouse.Location = new System.Drawing.Point(16, 83);
            this._PaletaMouse.Name = "_PaletaMouse";
            this._PaletaMouse.Size = new System.Drawing.Size(106, 57);
            this._PaletaMouse.TabIndex = 5;
            this._PaletaMouse.UseVisualStyleBackColor = true;
            // 
            // _PaletaPunta
            // 
            this._PaletaPunta.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._PaletaPunta.FlatAppearance.BorderSize = 5;
            this._PaletaPunta.Image = global::SimuladorCliente.Properties.Resources.sniffer;
            this._PaletaPunta.Location = new System.Drawing.Point(6, 83);
            this._PaletaPunta.Name = "_PaletaPunta";
            this._PaletaPunta.Size = new System.Drawing.Size(106, 67);
            this._PaletaPunta.TabIndex = 4;
            this._PaletaPunta.UseVisualStyleBackColor = true;
            // 
            // _PaletaConexion
            // 
            this._PaletaConexion.BackColor = System.Drawing.Color.DarkRed;
            this._PaletaConexion.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._PaletaConexion.FlatAppearance.BorderSize = 5;
            this._PaletaConexion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this._PaletaConexion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._PaletaConexion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this._PaletaConexion.Image = global::SimuladorCliente.Properties.Resources.Cable;
            this._PaletaConexion.Location = new System.Drawing.Point(6, 19);
            this._PaletaConexion.Name = "_PaletaConexion";
            this._PaletaConexion.Size = new System.Drawing.Size(106, 58);
            this._PaletaConexion.TabIndex = 3;
            this._PaletaConexion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this._PaletaConexion.UseVisualStyleBackColor = false;
            // 
            // _PaletaRouter
            // 
            this._PaletaRouter.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._PaletaRouter.FlatAppearance.BorderSize = 3;
            this._PaletaRouter.Image = global::SimuladorCliente.Properties.Resources.Router;
            this._PaletaRouter.Location = new System.Drawing.Point(6, 133);
            this._PaletaRouter.Name = "_PaletaRouter";
            this._PaletaRouter.Size = new System.Drawing.Size(110, 29);
            this._PaletaRouter.TabIndex = 2;
            this._PaletaRouter.UseVisualStyleBackColor = true;
            // 
            // _PaletaSwitch
            // 
            this._PaletaSwitch.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._PaletaSwitch.FlatAppearance.BorderSize = 3;
            this._PaletaSwitch.Image = global::SimuladorCliente.Properties.Resources.Switch;
            this._PaletaSwitch.Location = new System.Drawing.Point(6, 65);
            this._PaletaSwitch.Name = "_PaletaSwitch";
            this._PaletaSwitch.Size = new System.Drawing.Size(110, 29);
            this._PaletaSwitch.TabIndex = 1;
            this._PaletaSwitch.UseVisualStyleBackColor = true;
            // 
            // _PaletaPc
            // 
            this._PaletaPc.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._PaletaPc.FlatAppearance.BorderSize = 3;
            this._PaletaPc.Image = global::SimuladorCliente.Properties.Resources.Computador;
            this._PaletaPc.Location = new System.Drawing.Point(39, 19);
            this._PaletaPc.Name = "_PaletaPc";
            this._PaletaPc.Size = new System.Drawing.Size(45, 40);
            this._PaletaPc.TabIndex = 0;
            this._PaletaPc.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 487);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 167);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._PaletaConexion);
            this.groupBox2.Controls.Add(this._PaletaPunta);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 323);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 158);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conexiones";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._paletaSwitchVLan);
            this.groupBox3.Controls.Add(this._PaletaPc);
            this.groupBox3.Controls.Add(this._PaletaSwitch);
            this.groupBox3.Controls.Add(this._PaletaRouter);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(123, 171);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Equipos";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._paletaValorLabel);
            this.groupBox4.Controls.Add(this._paletaTrackBar);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(123, 65);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Velocidad simulación";
            // 
            // _paletaValorLabel
            // 
            this._paletaValorLabel.AutoSize = true;
            this._paletaValorLabel.Location = new System.Drawing.Point(17, 44);
            this._paletaValorLabel.Name = "_paletaValorLabel";
            this._paletaValorLabel.Size = new System.Drawing.Size(74, 13);
            this._paletaValorLabel.TabIndex = 19;
            this._paletaValorLabel.Text = "1 seg  :  1 seg";
            // 
            // _paletaTrackBar
            // 
            this._paletaTrackBar.LargeChange = 3;
            this._paletaTrackBar.Location = new System.Drawing.Point(6, 12);
            this._paletaTrackBar.Name = "_paletaTrackBar";
            this._paletaTrackBar.Size = new System.Drawing.Size(106, 45);
            this._paletaTrackBar.TabIndex = 18;
            this._paletaTrackBar.Value = 10;
            this._paletaTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // _paletaSwitchVLan
            // 
            this._paletaSwitchVLan.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this._paletaSwitchVLan.FlatAppearance.BorderSize = 3;
            this._paletaSwitchVLan.Image = ((System.Drawing.Image)(resources.GetObject("_paletaSwitchVLan.Image")));
            this._paletaSwitchVLan.Location = new System.Drawing.Point(6, 98);
            this._paletaSwitchVLan.Name = "_paletaSwitchVLan";
            this._paletaSwitchVLan.Size = new System.Drawing.Size(110, 29);
            this._paletaSwitchVLan.TabIndex = 3;
            this._paletaSwitchVLan.UseVisualStyleBackColor = true;
            // 
            // PaletaHerramienta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(135, 721);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._PaletaMouse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaletaHerramienta";
            this.TabText = "Paleta";
            this.Text = "Paleta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._paletaTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button _PaletaPc;
        public System.Windows.Forms.Button _PaletaSwitch;
        public System.Windows.Forms.Button _PaletaRouter;
        public System.Windows.Forms.Button _PaletaConexion;
        public System.Windows.Forms.Button _PaletaPunta;
        public System.Windows.Forms.Button _PaletaMouse;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label _paletaValorLabel;
        public System.Windows.Forms.TrackBar _paletaTrackBar;
        public System.Windows.Forms.Button _paletaSwitchVLan;
    }
}