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
		public byte P1 { get { return byte.Parse(textBox2.Text); } }
		public byte P2 { get { return byte.Parse(textBox3.Text); } }
		public byte P3 { get { return byte.Parse(textBox4.Text); } }
	}
}
