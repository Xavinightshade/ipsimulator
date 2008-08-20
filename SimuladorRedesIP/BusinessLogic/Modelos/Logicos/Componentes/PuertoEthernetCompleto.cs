using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesIP.Modelos.Equipos.Componentes
{
   public class PuertoEthernetCompleto:PuertoEthernetLogicoBase
    {
       		private string _MACAddress;

		public string MACAddress
		{
			get { return _MACAddress; }
		}
       public PuertoEthernetCompleto(string MACAddress,Guid id)
           :base(id)
       {
           _MACAddress = MACAddress;
       }
    }
}
