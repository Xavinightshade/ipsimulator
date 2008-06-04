using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.ModelosLogicos.Datos;
using RedesIP.ModelosLogicos.Equipos.Componentes;

namespace RedesIP.ModelosLogicos.Equipos
{
	public class ComputadorLogico 
	{
		private PuertoEthernet _puertoEthernet;
		private string _nombreDelPc;
		/// <summary>
		/// Puerto Ethernet Del PC
		/// </summary>
		public PuertoEthernet PuertoEthernet
		{
			get { return _puertoEthernet; }
		}
		/// <summary>
		/// Nombre Del Pc
		/// </summary>
		public string Nombre
		{
			get { return _nombreDelPc; }
		}
		/// <summary>
		/// Crea un nuevo PC
		/// </summary>
		/// <param name="nombre"></param>
		public ComputadorLogico(string nombre, MACAddress MACAddress)
		{
			IniciarPuertoEthernet(MACAddress);
			_nombreDelPc = nombre;
		}
		/// <summary>
		/// Crea el Puerto Ethernet y esta atento a los frames recibidos de este
		/// </summary>
		private void IniciarPuertoEthernet(MACAddress MACAddress)
		{
			_puertoEthernet = new PuertoEthernet(MACAddress);
			_puertoEthernet.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
		}

		private void OnFrameRecibido(object sender, FrameRecibidoEventArgs e)
		{
			Frame frameRecibido = e.FrameRecibido;
			if (_puertoEthernet.MACAddress.EsIgual(frameRecibido.MACAddressDestino))
			{
				ReplyTestMessage replyTestMessage = frameRecibido.Informacion as ReplyTestMessage;
				if (replyTestMessage != null)
				{
					if (_mensajesDePrueba.Contains(replyTestMessage.MensajeOriginal))
					{
						_mensajesDePrueba.Remove(replyTestMessage.MensajeOriginal);
						Console.WriteLine(_puertoEthernet.MACAddress.ToString() + " confirmé un ping de " + frameRecibido.MACAddressOrigen.ToString());
					}
					return;
				}
				TestMessage testMessage = frameRecibido.Informacion as TestMessage;
				if (testMessage != null)
				{
					EnviarMensaje(new ReplyTestMessage(testMessage), frameRecibido.MACAddressOrigen);
					Console.WriteLine(_puertoEthernet.MACAddress.ToString() + " Me hicieron ping desde " + frameRecibido.MACAddressOrigen.ToString());
					return;
				}
			}

		}
		public void EnviarMensajeDeTexto(string datos, MACAddress MACAddressDestino)
		{
			EnviarMensaje(new TextMessage(datos), MACAddressDestino);
		}

		List<TestMessage> _mensajesDePrueba = new List<TestMessage>();

		public void Ping(MACAddress MACAddressDestino)
		{
			TestMessage mensajeDePrueba = new TestMessage();
			_mensajesDePrueba.Add(mensajeDePrueba);
			EnviarMensaje(mensajeDePrueba, MACAddressDestino);
			
		}

		private void EnviarMensaje(IMessage mensaje,MACAddress MACAddressDestino)

		{
			Frame frameATransmitir = new Frame(mensaje, _puertoEthernet.MACAddress, MACAddressDestino);
			((IEnvioReciboDatos)_puertoEthernet).TransmitirFrame(frameATransmitir);

		}

	}
}
