using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimuladorCliente
{
	public partial class Ping : Form
	{
		public Ping()
		{
			InitializeComponent();
		}
		public string Mensaje { get { return textBox1.Text; } }
        public string DirMAC { get { return macTextBox1.Text; } }
        public int Numero { get { return int.Parse(textBox2.Text); } }
		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
