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
using RedesIP.Vistas.ElementosVisuales;

namespace SimuladorCliente
{
	public partial class Form1 : Form
	{
		RemoteServerObject _objetoRemoto;
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			BinaryClientFormatterSinkProvider clientProvider =
			new BinaryClientFormatterSinkProvider();
			BinaryServerFormatterSinkProvider serverProvider =
				new BinaryServerFormatterSinkProvider();
			serverProvider.TypeFilterLevel =

			System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

			IDictionary props = new Hashtable();
			props["port"] = 0;
			string s = System.Guid.NewGuid().ToString();
			props["name"] = s;
			props["typeFilterLevel"] = TypeFilterLevel.Full;
			TcpChannel chan = new TcpChannel(
			props, clientProvider, serverProvider);

			ChannelServices.RegisterChannel(chan);


			Type typeofRI = typeof(RemoteServerObject);
			_objetoRemoto = (RemoteServerObject)Activator.GetObject(typeofRI,
								 "tcp://jaus.selfip.net:6123/ParachuteExample");
		//	_estacionModelo = _objetoRemoto.EstacionModelo;
		_estacionModelo = new EstacionModelo();
		Form2 forma = new Form2();
		forma.Show();
			EstacionPresenter _estacionPresente2r = new EstacionPresenter(_estacionModelo, forma.Estacion);

			EstacionPresenter _estacionPresenter = new EstacionPresenter(_estacionModelo, estacionVista1);



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
				estacionVista1.NewDispositivo(posX,80);
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
		IEstacionModelo _estacionModelo;

















	}
}