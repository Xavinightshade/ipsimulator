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
			//_estacionModelo = _objetoRemoto.EstacionModelo;
			_estacionModelo = new EstacionModelo();
			EstacionPresenter _estacionPresenter = new EstacionPresenter(_estacionModelo, estacionVista1);



		}

		private void button1_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 8; i++)
			{
				estacionVista1.NewDispositivo();
			}
			_estacionModelo.Conectar(0, 1);
			_estacionModelo.Conectar(0, 2);
			_estacionModelo.Conectar(0, 3);
			_estacionModelo.Conectar(0, 4);
			_estacionModelo.Conectar(0, 5);
			_estacionModelo.Conectar(0, 6);
			_estacionModelo.Conectar(0, 7);
			_estacionModelo.Conectar(1, 2);
			_estacionModelo.Conectar(1, 3);
			_estacionModelo.Conectar(1, 4);
			_estacionModelo.Conectar(1, 5);
			_estacionModelo.Conectar(1, 6);
			_estacionModelo.Conectar(1, 7);
			_estacionModelo.Conectar(2, 3);
			_estacionModelo.Conectar(2, 4);
			_estacionModelo.Conectar(2, 5);
			_estacionModelo.Conectar(2, 6);
			_estacionModelo.Conectar(2, 7);
			_estacionModelo.Conectar(3, 4);
			_estacionModelo.Conectar(3, 5);
			_estacionModelo.Conectar(3, 6);
			_estacionModelo.Conectar(3, 7);
			_estacionModelo.Conectar(4, 5);
			_estacionModelo.Conectar(4, 6);
			_estacionModelo.Conectar(4, 7);
			_estacionModelo.Conectar(5, 6);
			_estacionModelo.Conectar(5, 7);
		}
		IEstacionModelo _estacionModelo;

















	}
}