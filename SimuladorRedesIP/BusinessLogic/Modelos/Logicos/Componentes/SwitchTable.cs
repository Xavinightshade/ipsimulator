using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Datos;
using RedesIP.Common;


namespace RedesIP.Modelos.Equipos.Componentes
{
	public class SwitchTable
	{

		private readonly Dictionary<string, PuertoEthernetLogico> _dicciostringPuertoEthernet=new Dictionary<string,PuertoEthernetLogico>();
		public SwitchTable()
		{

		}
		public void RegistrarDireccionMAC(string direccionMAC, PuertoEthernetLogico puertoEthenet)
		{

			System.Diagnostics.Debug.Assert(!(YaEstaRegistradoDireccionMAC(direccionMAC)), "Esta Direccion ya esta registrada");
			_dicciostringPuertoEthernet.Add(direccionMAC, puertoEthenet);
		}
		public bool YaEstaRegistradoDireccionMAC(string direccionMAC)
		{
			return _dicciostringPuertoEthernet.ContainsKey(direccionMAC);
		}
		public PuertoEthernetLogico BuscarPuertoBystring(string direccionMac)
		{
			PuertoEthernetLogico puertoEnMemoria = null;
			if (YaEstaRegistradoDireccionMAC(direccionMac))
				puertoEnMemoria = _dicciostringPuertoEthernet[direccionMac];
			return puertoEnMemoria;
		}
		public void BorrarTabla()
		{
			_dicciostringPuertoEthernet.Clear();
		}
	}
}
