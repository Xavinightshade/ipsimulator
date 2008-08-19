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
        private string _direccionPuerto;

        public string DireccionPuerto
        {
            get { return _direccionPuerto; }
        }
		private Frame _frameRecibido;
		public Frame FrameRecibido
		{
			get { return _frameRecibido; }
		}
        private DateTime _horaRecepcion;


		public FrameRecibidoEventArgs(Frame frame,string direccionPuerto)
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
        private string _MACAddressDestino;
        public string MACAddressDestino
		{
            get { return _MACAddressDestino; }
		}
        private string _MACAddressOrigen;
        public string MACAddressOrigen
		{
            get { return _MACAddressOrigen; }
		}

        public Frame(IMessage informacion, string MACAddressOrigen, string MACAddressDestino)
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
