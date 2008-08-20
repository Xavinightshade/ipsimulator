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

        public PuertoCompletoSOA(Guid id, string direccionMAC)
            : base(id)
        {
            _direccionMAC = direccionMAC;
        }
    }
}
