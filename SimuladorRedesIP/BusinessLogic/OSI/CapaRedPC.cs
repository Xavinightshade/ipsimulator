using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Logicos.Equipos;
using BusinessLogic.Modelos.Logicos.Datos;

namespace BusinessLogic.OSI
{
   public class CapaRedPC:CapaRed
    {
       ComputadorLogico _pc;
       public CapaRedPC(CapaDatos capaDatos,ComputadorLogico pc)
           :base(capaDatos)
       {
           _pc = pc;
       }


       public void Ping(string ipDestino)
       {
           Packet paquete = new Packet(CapaDatos.Puerto.IPAddress, ipDestino, IPAddressFactory.EchoMessage);

           EnviarPaquete(ipDestino, paquete);






       }

       protected override void EnviarPaquete(string ipDestino, Packet paquete)
       {

           bool perteneceAlaRed = IPAddressFactory.PerteneceAlaRed(CapaDatos.Puerto.IPAddress, ipDestino, CapaDatos.Puerto.Mascara);
           if (perteneceAlaRed)
           {
           CapaDatos.EnviarPaquete(paquete, ipDestino);
           }
           else
           {
               CapaDatos.EnviarPaquete(paquete, _pc.DefaultGateWay);
           }
       }
    }
}
