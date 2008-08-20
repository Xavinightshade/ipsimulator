using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using RedesIP.Modelos.Datos;
using BusinessLogic.Modelos.Logicos.Datos;

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


        public FrameSOA(Frame frameLogico)
        {
            _MACAddressDestino=frameLogico.MACAddressDestino;
            _MACAddressOrigen = frameLogico.MACAddressOrigen;
            _paquete = new PacketSOA(frameLogico.Informacion as Packet);
        }
        public FrameSOA()
        {

        }
 
    }
}
