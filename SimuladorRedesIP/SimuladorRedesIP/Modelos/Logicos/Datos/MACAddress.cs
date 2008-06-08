using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Modelos.Datos
{
	public struct MACAddress
	{
		private byte _parte1;
		public byte Parte1
		{
			get { return _parte1; }
		}
		private byte _parte2;
		public byte Parte2
		{
			get { return _parte2; }
		}
		private byte _parte3;
		public byte Parte3
		{
			get { return _parte3; }
		}
		private MACAddress(byte parte1, byte parte2, byte parte3)
		{
			_parte1 = parte1;
			_parte2 = parte2;
			_parte3 = parte3;

		}

		public static MACAddress Direccion(byte parte1, byte parte2, byte parte3)
		{
			return new MACAddress(parte1, parte2, parte3);
		}
		private static Random random = new Random();
		public static MACAddress New()
		{
			return Direccion((byte)random.Next(), (byte)random.Next(), (byte)random.Next());
		}

		public bool EsIgual(MACAddress macaddress)
		{
			return (_parte1 == macaddress._parte1) && (_parte2 == macaddress._parte2) && (_parte3 == macaddress._parte3);
		}
		public override string ToString()
		{

			return _parte1.ToString()+ ":" + _parte2.ToString() + ":" + _parte3.ToString();
		}

	}
}
