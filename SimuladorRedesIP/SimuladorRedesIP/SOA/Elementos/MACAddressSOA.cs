using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using RedesIP.Modelos.Datos;
using RedesIP.Common;

namespace RedesIP.SOA.Elementos
{
    [DataContract]
    public class MACAddressSOA
    {
        		private byte _parte1;
                [DataMember]
		public byte Parte1
		{
			get { return _parte1; }
            set {_parte1=value; }
		}
		private byte _parte2;
        [DataMember]
		public byte Parte2
		{
			get { return _parte2; }
            set { _parte2 = value; }
		}
		private byte _parte3;
        [DataMember]
		public byte Parte3
		{
			get { return _parte3; }
            set { _parte3 = value; }
		}
		public MACAddressSOA(MACAddress macAddress)
		{
            _parte1 = macAddress.Parte1;
            _parte2 = macAddress.Parte2;
            _parte3 = macAddress.Parte3;

		}
    }
}
