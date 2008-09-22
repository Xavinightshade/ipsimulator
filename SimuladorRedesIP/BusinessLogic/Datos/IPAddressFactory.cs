using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public static class IPAddressFactory
    {
        public static uint GetValor(string ipAddress)
        {
            int longitud = ipAddress.Length;
            int primerPunto = ipAddress.IndexOf('.', 0);
            int segundoPunto = ipAddress.IndexOf('.', primerPunto+1);
            int tercerPunto = ipAddress.IndexOf('.', segundoPunto+1);
            uint parte1 = uint.Parse(ipAddress.Substring(0, primerPunto));
            uint parte2 = uint.Parse(ipAddress.Substring(primerPunto+1, segundoPunto-primerPunto-1));
            uint parte3 = uint.Parse(ipAddress.Substring(segundoPunto+1, tercerPunto-segundoPunto-1));
            uint parte4 = uint.Parse(ipAddress.Substring(tercerPunto+1, longitud-tercerPunto-1));
            uint total = parte4 + parte3 * 256 + parte2 * 256 * 256 + parte1 * 256 * 256 * 256;
            return total;


        }
        public static bool PerteneceAlaRed(string ipAddress, int numeroRed)
        {
            uint inicial = (uint)Math.Pow(2, numeroRed);
            uint tamano = (uint)Math.Pow(2, 32 - numeroRed);
            return true;


        }
    }
}
