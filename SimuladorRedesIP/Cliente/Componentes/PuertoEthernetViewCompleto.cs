﻿using System;
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
        private int? _mask;

        public int? Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }
        private string _direccionIP;

        public string DireccionIP
        {
            get { return _direccionIP; }
            set { _direccionIP = value; }
        }

        public PuertoEthernetViewCompleto(Guid id, string direccionMAC,string direccionIp,int? mask, int origenX, int origenY, EquipoView equipoPadre,string nombre)
            :base(id,origenX,origenY,equipoPadre,nombre)
        {
            _direccionMAC = direccionMAC;
            _direccionIP = direccionIp;
            _mask = mask;
        }
    }
}
