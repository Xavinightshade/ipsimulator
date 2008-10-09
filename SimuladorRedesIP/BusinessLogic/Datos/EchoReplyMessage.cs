using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Datos
{
    public class EchoReplyMessage:IPacketMessage
    {
        public EchoReplyMessage()
       {

       }
       public string Dato
       {
           get { return IPAddressFactory.EchoMessage; }
       }
       public override string ToString()
       {
           return "Respuesta: " + Dato;
       }
    }
}
