using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOA;

namespace BusinessLogic.Componentes
{
    public abstract class ControladorSesion
    {
        private uint _seqNumber;
        private byte[] _data;

        public byte[] Data
        {
            get { return _data; }
        protected    set { _data = value; }
        }

        protected uint SeqNumber
        {
            get { return _seqNumber; }
            set { _seqNumber = value; }
        }
        private uint _ackNumber;

        protected uint ACKNumber
        {
            get { return _ackNumber; }
            set { _ackNumber = value; }
        }
        private string _ipOrigen;

        public string IpOrigen
        {
            get { return _ipOrigen; }
        }
        private string _ipDestino;

        public string IpDestino
        {
            get { return _ipDestino; }
        }
        private int _puertoOrigen;

        public int PuertoOrigen
        {
            get { return _puertoOrigen; }
        }
        private int _puertoDestino;

        public int PuertoDestino
        {
            get { return _puertoDestino; }
        }
        private int _segmentSize;

        public int SegmentSize
        {
            get { return _segmentSize; }
            set { _segmentSize = value; }
        }      
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        protected static Random R = new Random();

        public ControladorSesion(string ipOrigen, string ipDestino, int puertoOrigem, int PuertoDestino,
            int segmentSize, byte[] data, string fileName)
        {
            _ipOrigen = ipOrigen;
            _ipDestino = ipDestino;
            _puertoOrigen = puertoOrigem;
            _puertoDestino = PuertoDestino;
            _segmentSize = segmentSize;
            _fileName = fileName;
        }
        public static int GetHash(string ipOrigen, string ipDestino, int puertoOrigem, int PuertoDestino)
        {
            int hash = ipOrigen.GetHashCode();
            hash += ipDestino.GetHashCode();
            hash -= puertoOrigem;
            hash += PuertoDestino;
            return hash;
        }
        internal int GetHash()
        {
            return ControladorSesion.GetHash(IpOrigen, IpDestino, PuertoOrigen, PuertoDestino);
        }
    }
}
