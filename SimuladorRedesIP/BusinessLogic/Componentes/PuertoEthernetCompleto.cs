using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesIP.Modelos.Equipos.Componentes
{
    public class PuertoEthernetCompleto : PuertoEthernetLogicoBase
    {
        private string _MACAddress;

        public string MACAddress
        {
            get { return _MACAddress; }
        }
        private string _IPAddress;

        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }
        public PuertoEthernetCompleto(string MACAddress, Guid id)
            : base(id)
        {
            _MACAddress = MACAddress;
        }
    }
}
