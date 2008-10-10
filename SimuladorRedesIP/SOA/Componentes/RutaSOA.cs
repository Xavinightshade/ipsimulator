using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SOA.Componentes
{
    [DataContract]
    public class RutaSOA
    {
                private Guid _id;

                [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _red;
        [DataMember]
        public string Red
        {
            get { return _red; }
            set { _red = value; }
        }
        private Guid _idPuerto;
        [DataMember]
        public Guid IdPuerto
        {
            get { return _idPuerto; }
            set { _idPuerto = value; }
        }
        private string _nombrePuerto;
        [DataMember]
        public string NombrePuerto
        {
            get { return _nombrePuerto; }
            set { _nombrePuerto = value; }
        }
        public RutaSOA(Guid id)
        {
            _id = id;
        }
        private int? _mask;
        [DataMember]
        public int? Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }

        private string _nextHopIP;
        [DataMember]
        public string NextHopIP
        {
            get { return _nextHopIP; }
            set { _nextHopIP = value; }
        }
        private int hopCount;
        [DataMember]
        public int HopCount
        {
            get { return hopCount; }
            set { hopCount = value; }
        }

    }
}
