using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SOA.Datos
{
    [DataContract]
    public class ARP_SOA
	{

        private List<AsociacionIpMacSOA> _asociaciones = new List<AsociacionIpMacSOA>();
        [DataMember]
        public List<AsociacionIpMacSOA> Asociaciones
        {
            get { return _asociaciones; }
            set { _asociaciones = value; }
        }
        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

    }
}
