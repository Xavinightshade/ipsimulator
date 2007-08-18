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
		DispositivoPresenter _presenter;
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);


		}

		private void button1_Click(object sender, EventArgs e)
		{
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
			RemoteServerObject objetoRemoto = (RemoteServerObject)Activator.GetObject(typeofRI,
								 "tcp://localhost:6123/ParachuteExample");
			_presenter = objetoRemoto.Presenter;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			_presenter.AgregarVista(computador1);
		}
	}
}