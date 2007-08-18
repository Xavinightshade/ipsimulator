using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RedesIP.Modelos;
using RedesIP.Vistas;
using RedesIP.Presenters;

namespace SimuladorCliente
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			DispositivoModelo modelo = new DispositivoModelo(computador1.OrigenX, computador1.OrigenY);
			DispositivoPresenter presenter = new DispositivoPresenter(modelo, computador1);

		

			


		}
	}
}