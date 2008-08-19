using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Common
{
    public static class MACAddressFactory
	{
        private static char[] _caracteres = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a','b','c','d','e','f' };



		private static Random random = new Random();
		public static string NewMAC()
		{
            string result = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                result += _caracteres[random.Next(16)].ToString() +_caracteres[random.Next(16)].ToString() +":";
            }
            result += _caracteres[random.Next(16)] + _caracteres[random.Next(16)].ToString(); ;
            string f = _caracteres[13].ToString();
            return result;
		}



	}
}
