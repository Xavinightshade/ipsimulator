using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;
using RedesIP.Modelos.Equipos.Componentes;
using System.Collections.ObjectModel;

namespace RedesIP.Modelos.Logicos.Equipos
{
	public class ComputadorLogico : EquipoLogico
	{
		private Guid _id;

		public override Guid Id
		{
			get { return _id; }
		}
		private PuertoEthernetLogico _puertoEthernet;
		private string _nombreDelPc;
		/// <summary>
		/// Puerto Ethernet Del PC
		/// </summary>
		public PuertoEthernetLogico PuertoEthernet
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
			_id = Guid.NewGuid();
		}
		/// <summary>
		/// Crea el Puerto Ethernet y esta atento a los frames recibidos de este
		/// </summary>
		private void IniciarPuertoEthernet(MACAddress MACAddress)
		{
			_puertoEthernet = new PuertoEthernetLogico(MACAddress);
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
					}
					return;
				}
				TestMessage testMessage = frameRecibido.Informacion as TestMessage;
				if (testMessage != null)
				{
					EnviarMensaje(new ReplyTestMessage(testMessage), frameRecibido.MACAddressOrigen);
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

		private void EnviarMensaje(IMessage mensaje, MACAddress MACAddressDestino)
		{
			Frame frameATransmitir = new Frame(mensaje, _puertoEthernet.MACAddress, MACAddressDestino);
			((IEnvioReciboDatos)_puertoEthernet).TransmitirFrame(frameATransmitir);

		}




		public override ReadOnlyCollection<PuertoEthernetLogico> PuertosEthernet
		{
			get {
			Collection<PuertoEthernetLogico> puertos=	new Collection<PuertoEthernetLogico>();
				puertos.Add(_puertoEthernet);

				return new ReadOnlyCollection<PuertoEthernetLogico>(puertos);
			}
		}
	}
}
