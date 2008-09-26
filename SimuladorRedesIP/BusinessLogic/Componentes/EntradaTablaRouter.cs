using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;

namespace BusinessLogic.Componentes
{
    public class EntradaTablaRouter
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
        }
        private string _red;

        public string Red
        {
            get { return _red; }
            set { _red = value; }
        }
        private PuertoEthernetCompleto _puerto;

        public PuertoEthernetCompleto Puerto
        {
            get { return _puerto; }
            set { _puerto = value; }
        }

        private int? _mask;

        public int? Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }

        private string _nextHopIP;

        public string NextHopIP
        {
            get { return _nextHopIP; }
            set { _nextHopIP = value; }
        }
        public EntradaTablaRouter(Guid id)
        {
            _id = id;
        }
    }
}
