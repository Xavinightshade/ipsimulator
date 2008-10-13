using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using RedesIP.SOA;

namespace SOA.Datos
{
    [DataContract]
    public abstract class SegmentSOA
    {
        private int _sourcePort;
        [DataMember]
        public int SourcePort
        {
            get { return _sourcePort; }
            set { _sourcePort = value; }
        }
        private int _destinationPort;
        [DataMember]
        public int DestinationPort
        {
            get { return _destinationPort; }
            set { _destinationPort = value; }
        }
        private PacketSOA _paquete;

        public PacketSOA Paquete
        {
            get { return _paquete; }
            set { _paquete = value; }
        }
        private TimeSpan _fecha;
        [DataMember]
        public TimeSpan Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private bool _esEnviado;
        [DataMember]
        public bool EsEnviado
        {
            get { return _esEnviado; }
            set { _esEnviado = value; }
        }
        private int _dataLength;
        public int DataLength
        {
            get { return _dataLength; }
        }
        public SegmentSOA(int sourcePort, int destinationPort, PacketSOA paquete, TimeSpan fecha, bool esEnviado, int dataLength)
        {
            _dataLength = dataLength;
            _esEnviado = esEnviado;
            _fecha = fecha;
            _sourcePort = sourcePort;
            _destinationPort = destinationPort;
            _paquete = paquete;
        }
    }
}
