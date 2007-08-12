using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Datos;

namespace RedesIP.ElementosLogicos
{
	public interface IEthernetConnection
	{
		PuertoEthernetLogico PuertoEthernet { get;}
	}
	public class CableDeRedLogico
	{
		private static List<PuertoEthernetLogico> _listaPuertos = new List<PuertoEthernetLogico>();
		private PuertoEthernetLogico _puerto1;
		private PuertoEthernetLogico _puerto2;

		public CableDeRedLogico(PuertoEthernetLogico puerto1, PuertoEthernetLogico puerto2)
		{
			_puerto1 = puerto1;
			_puerto2 = puerto2;
			ConectarPuertos();
		}
		public CableDeRedLogico(IEthernetConnection device1, IEthernetConnection device2)
			: this(device1.PuertoEthernet, device2.PuertoEthernet) { }
		public CableDeRedLogico(IEthernetConnection device, PuertoEthernetLogico puerto)
			: this(device.PuertoEthernet, puerto) { }
		public CableDeRedLogico(PuertoEthernetLogico puerto, IEthernetConnection device)
			: this(puerto, device.PuertoEthernet) { }

		private void ConectarPuertos()
		{
			if (_puerto1 == _puerto2)
				System.Diagnostics.Debug.Assert(false, "no me puedo conectar a mi mismo");
			if (_listaPuertos.Contains(_puerto1) || _listaPuertos.Contains(_puerto2))
				System.Diagnostics.Debug.Assert(false, "este puerto ya fue conectado");
			_puerto1.FrameTransmitido += new EventHandler<FrameTransmitidoEventArgs>(OnFrameTransmitidoDelPuerto1);
			_puerto2.FrameTransmitido += new EventHandler<FrameTransmitidoEventArgs>(OnFrameTransmitidoDelPuerto2);
			_listaPuertos.Add(_puerto1);
			_listaPuertos.Add(_puerto2);
		}
		public void DesconectarPuertos()
		{
			_puerto1.FrameTransmitido -= new EventHandler<FrameTransmitidoEventArgs>(OnFrameTransmitidoDelPuerto1);
			_puerto2.FrameTransmitido -= new EventHandler<FrameTransmitidoEventArgs>(OnFrameTransmitidoDelPuerto2);
			_listaPuertos.Remove(_puerto1);
			_listaPuertos.Remove(_puerto2);

		}


		private void OnFrameTransmitidoDelPuerto2(object sender, FrameTransmitidoEventArgs e)
		{
			_puerto1.RecibirFrame(e.FrameTransmitido);
		}

		private void OnFrameTransmitidoDelPuerto1(object sender, FrameTransmitidoEventArgs e)
		{
			_puerto2.RecibirFrame(e.FrameTransmitido);
		}


	}
}
