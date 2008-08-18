using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Common;


namespace RedesIP.Modelos.Datos
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
        private MACAddress _direccionPuerto;

        public MACAddress DireccionPuerto
        {
            get { return _direccionPuerto; }
        }
		private Frame _frameRecibido;
		public Frame FrameRecibido
		{
			get { return _frameRecibido; }
		}
        private DateTime _horaRecepcion;


		public FrameRecibidoEventArgs(Frame frame,MACAddress direccionPuerto)
		{
			_frameRecibido = frame;
            _direccionPuerto = direccionPuerto;

		}
	}

	public class Frame
	{
        private DateTime _horaTransmision;

        public DateTime HoraTransmision
        {
            get { return _horaTransmision; }
            set { _horaTransmision = value; }
        }
        private DateTime _horaRecepcion;

        public DateTime HoraRecepcion
        {
            get { return _horaRecepcion; }
            set { _horaRecepcion = value; }
        }
		private IMessage _informacion;

		public IMessage Informacion
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

		public Frame(IMessage informacion, MACAddress MACAddressOrigen, MACAddress MACAddressDestino)
		{
			_informacion = informacion;
			_MACAddressDestino = MACAddressDestino;
			_MACAddressOrigen = MACAddressOrigen;
		}
		public override string ToString()
		{
			return "MAC origen: " + _MACAddressOrigen.ToString() + ",       MAC Destino: " + _MACAddressDestino.ToString() + "      Info: " + _informacion.ToString();
		}
	}
}
