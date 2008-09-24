using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace  RedesIP.SOA
{
    [DataContract]
    public class PuertoCompletoSOA : PuertoBaseSOA
    {

        private string _direccionMAC;
        [DataMember]
        public string DireccionMAC
        {
            get { return _direccionMAC; }
            set { _direccionMAC = value; }
        }
        private string _IPAddress;
        [DataMember]
        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }
        [DataMember]
        public int? Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }
        private int? _mask;

        public PuertoCompletoSOA(Guid id, string direccionMAC,string nombre,string ipAddress,int? mask)
            : base(id,nombre)
        {
            _direccionMAC = direccionMAC;
            _IPAddress = ipAddress;
            _mask = mask;
        }
    }
}
