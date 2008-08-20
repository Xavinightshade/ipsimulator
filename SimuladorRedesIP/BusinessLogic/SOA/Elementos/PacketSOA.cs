using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using BusinessLogic.Modelos.Logicos.Datos;

namespace RedesIP.SOA
{
    [DataContract]
    public class PacketSOA
    {
        private string _ipOrigen;
        [DataMember]
        public string IpOrigen
        {
            get { return _ipOrigen; }
            set { _ipOrigen = value; }
        }
        private string _ipDestino;
        [DataMember]
        public string IpDestino
        {
            get { return _ipDestino; }
            set { _ipDestino = value; }
        }
        private string _datos;
        [DataMember]
        public string Datos
        {
            get { return _datos; }
            set { _datos = value; }
        }

        public PacketSOA(Packet paquete)
        {
            _datos = paquete.Datos;
            _ipOrigen = paquete.IpOrigen;
            _ipDestino = paquete.IpDestino;
        }
        public PacketSOA()
        {

        }
    }
}
