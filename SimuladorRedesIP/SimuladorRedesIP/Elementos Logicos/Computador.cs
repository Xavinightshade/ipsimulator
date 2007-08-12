using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Datos;

namespace RedesIP.ElementosLogicos
{
	public class ComputadorLogico : IEthernetConnection
	{
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
				System.Windows.Forms.MessageBox.Show("yo : " + _nombreDelPc + "@@@ recibi frame: " + frameRecibido.Informacion);

		}
		public void EnviarMensaje(string mensaje, MACAddress MACAddressDestino)
		{
			Frame frameATransmitir = new Frame(mensaje, _puertoEthernet.MACAddress, MACAddressDestino);
			_puertoEthernet.TransmitirFrame(frameATransmitir);
		}

	}
}
