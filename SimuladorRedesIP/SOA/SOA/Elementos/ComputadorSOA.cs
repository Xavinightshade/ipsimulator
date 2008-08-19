using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using RedesIP;

namespace SOA.SOA.Elementos
{
    public class ComputadorSOA:EquipoSOA
    {
        public ComputadorSOA(TipoDeEquipo tipoEquipo, Guid id, int x, int y)
            :base(tipoEquipo,id,x,y)
        {

        }
        private string _direccionIP;
        public string DireccionIP
        {
            get { return _direccionIP; }
            set { _direccionIP = value; }
        }
    }
}
