using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SOA.Datos
{
    [DataContract]
    public struct AsociacionIpMacSOA
    {
        private string _ip;
        [DataMember]
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
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
