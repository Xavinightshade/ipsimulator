using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Common;
using RedesIP.SOA;
using BusinessLogic.Modelos.Logicos.Datos;


namespace RedesIP.Modelos.Datos
{



	public class Frame
	{
        public static FrameSOA ConvertirFrame(Frame frameLogico)
        {
            FrameSOA frameSOA = new FrameSOA();
            frameSOA.MACAddressOrigen = frameLogico.MACAddressOrigen;
            frameSOA.MACAddressDestino = frameLogico.MACAddressDestino;
            PacketSOA paqueteSOA = new PacketSOA();
            Packet paqueteLogico = frameLogico.Informacion as Packet;
            paqueteSOA.IpOrigen = paqueteLogico.IpOrigen;
            paqueteSOA.IpDestino = paqueteLogico.IpDestino;
            paqueteSOA.Datos = paqueteLogico.Datos;
            frameSOA.Paquete = paqueteSOA;
            return frameSOA;
        }
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
