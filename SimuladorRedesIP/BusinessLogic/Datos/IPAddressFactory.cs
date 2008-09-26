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
            if (!EsValidaLaDireccion(ipAddress))
            {
                throw new Exception("DireccionIP no valida");
            }
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
        public static bool EsValidaLaDireccion(string ipAddress)
        {
            int longitud = ipAddress.Length;
            int primerPunto = ipAddress.IndexOf('.', 0);
            int segundoPunto = ipAddress.IndexOf('.', primerPunto + 1);
            int tercerPunto = ipAddress.IndexOf('.', segundoPunto + 1);
            bool esDireccionValida = true;
            uint parte1;
            uint parte2;
            uint parte3;
            uint parte4;
            esDireccionValida = uint.TryParse(ipAddress.Substring(0, primerPunto), out parte1);
            esDireccionValida = ((0 <= parte1) && (parte1 <= 255));
            esDireccionValida = uint.TryParse(ipAddress.Substring(primerPunto + 1, segundoPunto - primerPunto - 1), out parte2);
            esDireccionValida = ((0 <= parte2) && (parte2 <= 255));
            esDireccionValida = uint.TryParse(ipAddress.Substring(segundoPunto + 1, tercerPunto - segundoPunto - 1), out parte3);
            esDireccionValida = ((0 <= parte3) && (parte3 <= 255));
            esDireccionValida = uint.TryParse(ipAddress.Substring(tercerPunto + 1, longitud - tercerPunto - 1), out parte4);
            esDireccionValida = ((0 <= parte4) && (parte4 <= 255));

            return esDireccionValida;


        }
        public static bool PerteneceAlaRed(string ipAddressOrigen,string ipAddressDestino, int mascara)
        {
            uint red = GetRed(ipAddressOrigen, mascara);
            uint valorIpDestino=GetValor(ipAddressDestino);
            uint sizeRed = (uint)Math.Pow(2, 32 - mascara);
            return (red < valorIpDestino) && (valorIpDestino < red + sizeRed);


        }
        public static uint GetValorRed(int mask)
        {
            uint valorTotalRed=0;
            for (int i = 0; i < mask; i++)
            {
                valorTotalRed += (uint)Math.Pow(2, 31 - i);
            }
            return valorTotalRed;
 
        }
        public static uint GetRed(string ipAddress, int mask)
        {
            uint valorIp = GetValor(ipAddress);
            uint cociente = valorIp;
            List<byte> valoresIP = new List<byte>();
            for (int i = 0; i < 32; i++)
			{		 

                byte residuo = (byte)(cociente % 2);
                valoresIP.Add(residuo);
                cociente = (uint)(cociente / 2);
            }
            List<byte> valoresMASK = new List<byte>();
            uint cocienteMASK = GetValorRed(mask);
            for (int i = 0; i < 32; i++)
            {

                byte residuoMASK = (byte)(cocienteMASK % 2);
                valoresMASK.Add(residuoMASK);
                cocienteMASK = (uint)(cocienteMASK / 2);
            }

            uint red=0;
            for (int i = 0; i < 32; i++)
            {
                red += (uint)(Math.Pow(2, i) * valoresIP[i] * valoresMASK[i]);
            }
            return red;
        }

        public static string GetIpRep(uint ipValor)
        {
                        List<uint> valores = new List<uint>();
            uint cociente = ipValor;
            for (int i = 0; i < 4; i++)
			{

                uint residuo = (uint)(cociente %256);
                valores.Add(residuo);
                cociente = (uint)(cociente / 256);
            }
            string red = string.Empty;
            for (int i = 0; i < valores.Count; i++)
            {
                red += valores[valores.Count - 1 - i].ToString() + ".";
            }
            red = red.Substring(0, red.Length - 1);
            return red;

        }


        public static string GetRedRep(string ipAddress, int mascara)
        {
            return GetIpRep(GetRed(ipAddress, mascara));
        }

        internal static bool PerteneceAlaRed(uint redPuerto, string ipAddress)
        {

            uint sizeRed = GetTamanoDeREd(redPuerto);
            uint valorIp = GetValor(ipAddress);
            string gg = GetIpRep(redPuerto);
            return (redPuerto < valorIp) && (valorIp < redPuerto + sizeRed);

        }

        private static uint GetTamanoDeREd(uint redPuerto)
        {
            uint cociente = redPuerto;
            List<byte> valoresIP = new List<byte>();
            for (int i = 0; i < 32; i++)
            {

                byte residuo = (byte)(cociente % 2);
                valoresIP.Add(residuo);
                cociente = (uint)(cociente / 2);
            }
            uint size = 0;
            for (int i = 0; i < 32; i++)
            {
                if (valoresIP[i] == 0)
                {
                    size += (uint)(Math.Pow(2, i));
                }

            }
            return size;
        }
    }
}
