using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesIP.Vistas.Equipos.Componentes
{
   public class PuertoEthernetViewCompleto:PuertoEthernetViewBase
    {
        private string _direccionMAC;

        public string DireccionMAC
        {
            get { return _direccionMAC; }
        }
        private string _IPAddress;
        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }

        public PuertoEthernetViewCompleto(Guid id, string direccionMAC, int origenX, int origenY, EquipoView equipoPadre)
            :base(id,origenX,origenY,equipoPadre)
        {
            _direccionMAC = direccionMAC;
        }
    }
}
