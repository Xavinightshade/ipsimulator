using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;

namespace BusinessLogic.Componentes
{
    public class EntradaTablaRouter
    {
        private uint _red;

        public uint Red
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
    }
}
