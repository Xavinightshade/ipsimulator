using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;

namespace RedesIP.Modelos.Equipos
{
	public class Computador : IEthernetConnection
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
		public Computador(string nombre, MACAddress MACAddress)
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
			    
			}
                //Console.WriteLine("yo : " + _nombreDelPc + "@@@ recibi frame: " + frameRecibido.Informacion+ " a lassss "+DateTime.Now.ToString());
//				System.Windows.Forms.MessageBox.Show("yo : " + _nombreDelPc + "@@@ recibi frame: " + frameRecibido.Informacion);

		}
		public void EnviarMensaje(string mensaje, MACAddress MACAddressDestino)
		{
			Frame frameATransmitir = new Frame(mensaje, _puertoEthernet.MACAddress, MACAddressDestino);
			((IEnvioReciboDatos)_puertoEthernet).TransmitirFrame(frameATransmitir);
		}

	}
}
