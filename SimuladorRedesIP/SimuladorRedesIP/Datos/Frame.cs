using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Datos
{

	public class FrameTransmitidoEventArgs : EventArgs
	{
		private Frame _frameTransmitido;
		public Frame FrameTransmitido
		{
			get { return _frameTransmitido; }
		}

		public FrameTransmitidoEventArgs(Frame frame)
		{
			_frameTransmitido = frame;
		}
	}
	public class FrameRecibidoEventArgs : EventArgs
	{
		private Frame _frameRecibido;
		public Frame FrameRecibido
		{
			get { return _frameRecibido; }
		}

		public FrameRecibidoEventArgs(Frame frame)
		{
			_frameRecibido = frame;
		}
	}

	public class Frame
	{
		private string _informacion;

		public string Informacion
		{
			get { return _informacion; }
		}
		private MACAddress _MACAddressDestino;
		public MACAddress MACAddressDestino
		{
			get { return _MACAddressDestino; }
		}
		private MACAddress _MACAddressOrigen;
		public MACAddress MACAddressOrigen
		{
			get { return _MACAddressOrigen; }
		}

		public Frame(string informacion, MACAddress MACAddressOrigen, MACAddress MACAddressDestino)
		{
			_informacion = informacion;
			_MACAddressDestino = MACAddressDestino;
			_MACAddressOrigen = MACAddressOrigen;
		}
	}
}
