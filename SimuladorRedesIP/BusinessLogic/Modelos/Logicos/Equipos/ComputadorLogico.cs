using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;
using RedesIP.Modelos.Equipos.Componentes;
using System.Collections.ObjectModel;
using RedesIP.Common;


namespace RedesIP.Modelos.Logicos.Equipos
{
	public class ComputadorLogico : EquipoLogico
	{
        private string _direccionIP;

        public string DireccionIP
        {
            get { return _direccionIP; }
            set { _direccionIP = value; }
        }

		private PuertoEthernetLogicoBase _puertoEthernet;
		private string _nombreDelPc;
		/// <summary>
		/// Puerto Ethernet Del PC
		/// </summary>
		public PuertoEthernetLogicoBase PuertoEthernet
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
		public ComputadorLogico(Guid id, int X,int Y):base(id, TipoDeEquipo.Computador,X,Y)
		{

			_nombreDelPc = "PC_"+GetHashCode().ToString();

		}


		private void OnFrameRecibido(object sender, FrameRecibidoEventArgs e)
		{
			Frame frameRecibido = e.FrameRecibido;
            if (_puertoEthernet.MACAddress == frameRecibido.MACAddressDestino)
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
		public void EnviarMensajeDeTexto(string datos, string stringDestino)
		{
			EnviarMensaje(new TextMessage(datos), stringDestino);
		}

		List<TestMessage> _mensajesDePrueba = new List<TestMessage>();

		public void Ping(string stringDestino)
		{
			TestMessage mensajeDePrueba = new TestMessage();
			_mensajesDePrueba.Add(mensajeDePrueba);
			EnviarMensaje(mensajeDePrueba, stringDestino);

		}

		private void EnviarMensaje(IMessage mensaje, string stringDestino)
		{
            Frame frameATransmitir = new Frame(mensaje, _puertoEthernet.MACAddress, stringDestino);
			((IEnvioReciboDatos)_puertoEthernet).TransmitirFrame(frameATransmitir);

		}




		public override ReadOnlyCollection<PuertoEthernetLogicoBase> PuertosEthernet
		{
			get {
			Collection<PuertoEthernetLogicoBase> puertos=	new Collection<PuertoEthernetLogicoBase>();
				puertos.Add(_puertoEthernet);

				return new ReadOnlyCollection<PuertoEthernetLogicoBase>(puertos);
			}
		}
        public override void AgregarPuerto(Guid idPuerto)
        {
            _puertoEthernet = new PuertoEthernetLogicoBase(MACAddressFactory.NewMAC(), idPuerto);
        }

        public override void InicializarEquipo()
        {
            _puertoEthernet.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);

        }
    }
}
