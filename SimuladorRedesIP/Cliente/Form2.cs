using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RedesIP.Vistas;

namespace SimuladorCliente
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();

		}
		public IEstacionVista Estacion
		{
			get { return estacionVista1; }
		}
	
	}
}