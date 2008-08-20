using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Common;


namespace RedesIP.Modelos.Datos
{



	public class Frame
	{

		private IFrameMessage _informacion;

		public IFrameMessage Informacion
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

        public Frame(IFrameMessage informacion, string MACAddressOrigen, string MACAddressDestino)
		{
			_informacion = informacion;
            _MACAddressDestino = MACAddressDestino;
            _MACAddressOrigen = MACAddressOrigen;
		}
		public override string ToString()
		{
            return "MAC origen: " + _MACAddressOrigen+ ",       MAC Destino: " + _MACAddressDestino + "      Info: " + _informacion.ToString();
		}
	}
}
