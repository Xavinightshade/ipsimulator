using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using System.Runtime.Serialization;

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
    [DataContract]
    public class SwitchTableSOA
    {
        private List<AsociacionPuertoMACAddressSOA> _asociaciones = new List<AsociacionPuertoMACAddressSOA>();
        [DataMember]
        public List<AsociacionPuertoMACAddressSOA> Asociaciones
        {
            get { return _asociaciones; }
            set { _asociaciones = value; }
        }
    }
}
