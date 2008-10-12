using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Componentes
{
    public abstract class ControladorSesion
    {
        private uint _seqNumber;

        protected uint SeqNumber
        {
            get { return _seqNumber; }
            set { _seqNumber = value; }
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
        protected static Random R = new Random();

        public ControladorSesion(string ipOrigen,string ipDestino,int puertoOrigem,int PuertoDestino)
        {
            _ipOrigen = ipOrigen;
            _ipDestino = ipDestino;
            _puertoOrigen = puertoOrigem;
            _puertoDestino = PuertoDestino;
        }
        public static int GetHash(string ipOrigen, string ipDestino, int puertoOrigem, int PuertoDestino)
        {
            int hash = ipOrigen.GetHashCode();
            hash += ipDestino.GetHashCode();
            hash -= puertoOrigem;
            hash += PuertoDestino;
            return hash;
        }
    }
}
