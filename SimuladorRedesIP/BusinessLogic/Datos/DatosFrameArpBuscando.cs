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
        Guid _idPacket;

        public Guid IdPacket
        {
            get { return _idPacket; }
        }
       public DatosFrameArpBuscando(string ipDestino,Guid idPacket)
       {
           _ipDestino=ipDestino;
           _idPacket = idPacket;
       }
       public override string ToString()
       {
           return "ARP: Cual dirección MAC le corresponde la dirección IP:" + _ipDestino;
       }
    }
}
