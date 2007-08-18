using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Datos;

namespace RedesIP.ElementosLogicos
{

	public class PuertoEthernetLogico
	{
		private MACAddress _MACAddress;

		public MACAddress MACAddress
		{
			get { return _MACAddress; }
		}
		public event EventHandler<FrameTransmitidoEventArgs> FrameTransmitido;
		public event EventHandler<FrameRecibidoEventArgs> FrameRecibido;
		public PuertoEthernetLogico(MACAddress MACAddress)
		{
			_MACAddress = MACAddress;
		}
		private void OnFrameTransmitido(Frame frame)
		{
			if (FrameTransmitido != null)
				FrameTransmitido(this, new FrameTransmitidoEventArgs(frame));
		}
		private void OnFrameRecibido(Frame frame)
		{
			if (FrameRecibido != null)
				FrameRecibido(this, new FrameRecibidoEventArgs(frame));
		}

		public void TransmitirFrame(Frame frame)
		{
			OnFrameTransmitido(frame);
		}

		public void RecibirFrame(Frame frame)
		{
			OnFrameRecibido(frame);
		}
	}
}
