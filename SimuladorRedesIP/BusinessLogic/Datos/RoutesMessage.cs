﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOA.Componentes;

namespace BusinessLogic.Datos
{
    public class RoutesMessage : IPacketMessage
    {
        List<RutaSOA> _rutasTotales;

        public List<RutaSOA> RutasTotales
        {
            get { return _rutasTotales; }
        }
        public RoutesMessage(List<RutaSOA> rutasTotales)
        {
            _rutasTotales = rutasTotales;
        }
        public override string ToString()
        {
            string mensaje = "Informando redes: @@ ";
            foreach (RutaSOA ruta in _rutasTotales)
            {
                mensaje += ruta.Red + "/" + ruta.Mask.Value.ToString() +" HC:"+ruta.HopCount.ToString()+ " @@ ";
            }
            return mensaje;
        }
    }
}
