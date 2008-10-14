using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Datos;

namespace BusinessLogic.Datos
{
   public class DatosFrameArpBuscando:IFrameMessage
    {
        string _ipDestino;

        public string IpDestino
        {
            get { return _ipDestino; }
        }
       public DatosFrameArpBuscando(string ipDestino)
       {
           _ipDestino=ipDestino;
       }
       public override string ToString()
       {
           return "ARP: Cual dirección MAC le corresponde la dirección IP:" + _ipDestino;
       }
    }
}
