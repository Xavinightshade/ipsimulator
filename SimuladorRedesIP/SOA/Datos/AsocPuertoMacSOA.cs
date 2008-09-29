using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using RedesIP.SOA;

namespace SOA.Datos
{
    [DataContract]
    public struct AsociacionPuertoMACAddressSOA
    {
        private PuertoBaseSOA _puerto;
        [DataMember]
        public PuertoBaseSOA Puerto
        {
            get { return _puerto; }
            set { _puerto = value; }
        }
        private string _macAddress;
        [DataMember]
        public string MacAddress
        {
            get { return _macAddress; }
            set { _macAddress = value; }
        }
    }

}
