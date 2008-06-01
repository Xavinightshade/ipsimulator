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
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using RedesIP.Remoting;

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

		_estacionModelo = new Estacion();
 



		new EstacionPresenter(_estacionModelo, estacionVista1);


		    



		}

		private void button1_Click(object sender, EventArgs e)
		
		{
			int numeroDispo = 20;
			int deltax=1000/numeroDispo;
			int deltay = 1000 / numeroDispo;
			int posX = 0;
			int posY = 0;
			for (int i = 0; i < numeroDispo; i++)
			{
				posX += deltax;
				posY += deltay;
				_estacionModelo.CrearDispositivo(posX, 80);
			}
			int length = 0;
			for (int i = 0; i < numeroDispo; i++)
			{
				length += 1;
				for (int j = length; j < numeroDispo; j++)
				{
					_estacionModelo.Conectar(i, j);
				}


			}

		}
		IEstacion _estacionModelo;

















	}
}