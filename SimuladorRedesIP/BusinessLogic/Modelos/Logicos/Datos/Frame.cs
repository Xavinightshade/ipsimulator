using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Common;


namespace RedesIP.Modelos.Datos
{



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
