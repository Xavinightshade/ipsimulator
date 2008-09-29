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

        private List<AsociacionIpMacSOA> _asociacionesAntes = new List<AsociacionIpMacSOA>();
        [DataMember]
        public List<AsociacionIpMacSOA> AsociacionesAntes
        {
            get { return _asociacionesAntes; }
            set { _asociacionesAntes = value; }
        }
        private List<AsociacionIpMacSOA> _asociacionesDespues = new List<AsociacionIpMacSOA>();
        [DataMember]
        public List<AsociacionIpMacSOA> AsociacionesDespues
        {
            get { return _asociacionesDespues; }
            set { _asociacionesDespues = value; }
        }

    }
}
