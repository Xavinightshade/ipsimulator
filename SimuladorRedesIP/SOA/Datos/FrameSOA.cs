using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA
{
    [DataContract]
    public class FrameSOA
    {
        private PacketSOA _paquete;
        [DataMember]
        public PacketSOA Paquete
        {
            get { return _paquete; }
            set { _paquete = value; }
        }
        private string _info;
        [DataMember]
        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }

        private string _MACAddressDestino;
        [DataMember]
        public string MACAddressDestino
        {
            get { return _MACAddressDestino; }
            set { _MACAddressDestino = value; }
        }
        private string _MACAddressOrigen;
        [DataMember]
        public string MACAddressOrigen
        {
            get { return _MACAddressOrigen; }
            set { _MACAddressOrigen = value; }
        }



        public FrameSOA()
        {

        }
 
    }
}
