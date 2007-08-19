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

			PintarDispositivosIniciales();
//			_objetoRemoto.ListaDispositivos.DispositivoCreado += new EventHandler<EventDispositivoArgs>(ListaDispositivos_DispositivoCreado);
	
		}

		void ListaDispositivos_DispositivoCreado(object sender, EventDispositivoArgs e)
		{
			MessageBox.Show("Test");
		}


		private List<IDispositivoModelo> _dispositivos = new List<IDispositivoModelo>();

		private void PintarDispositivosIniciales()
		{
			foreach (IDispositivoModelo dispositivo in _objetoRemoto.ListaDispositivos)
			{
				_dispositivos.Add(dispositivo);
				Computador newPc = new Computador();
				this.Controls.Add(newPc);
				DispositivoPresenter presenter = new DispositivoPresenter(dispositivo, newPc);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			_objetoRemoto.ListaDispositivos.CrearDispositivo(60, 80);
			_objetoRemoto.ListaDispositivos.CrearDispositivo(500, 70);
			_objetoRemoto.ListaDispositivos.CrearDispositivo(100, 170);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PintarDispositivosIniciales();
		}




	
	}
}