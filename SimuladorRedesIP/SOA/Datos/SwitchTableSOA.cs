using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;

namespace SOA.Datos
{
    public struct AsociacionPuertoMACAddressSOA
    {
        private PuertoBaseSOA _puerto;

        public PuertoBaseSOA Puerto
        {
            get { return _puerto; }
            set { _puerto = value; }
        }
        private string _macAddress;

        public string MacAddress
        {
            get { return _macAddress; }
            set { _macAddress = value; }
        }
    }
    public class SwitchTableSOA
    {
        private List<AsociacionPuertoMACAddressSOA> _asociaciones = new List<AsociacionPuertoMACAddressSOA>();

        public List<AsociacionPuertoMACAddressSOA> Asociaciones
        {
            get { return _asociaciones; }
            set { _asociaciones = value; }
        }
    }
}
