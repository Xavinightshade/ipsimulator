using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Datos;

namespace RedesIP.Modelos.Equipos.Componentes
{
	public class SwitchTable
	{

		private readonly Dictionary<MACAddress, PuertoEthernetLogico> _diccioMacAddressPuertoEthernet=new Dictionary<MACAddress,PuertoEthernetLogico>();
		public SwitchTable()
		{

		}
		public void RegistrarDireccionMAC(MACAddress direccionMAC, PuertoEthernetLogico puertoEthenet)
		{

			System.Diagnostics.Debug.Assert(!(YaEstaRegistradoDireccionMAC(direccionMAC)), "Esta Direccion ya esta registrada");
			_diccioMacAddressPuertoEthernet.Add(direccionMAC, puertoEthenet);
		}
		public bool YaEstaRegistradoDireccionMAC(MACAddress direccionMAC)
		{
			return _diccioMacAddressPuertoEthernet.ContainsKey(direccionMAC);
		}
		public PuertoEthernetLogico BuscarPuertoByMacAddress(MACAddress direccionMac)
		{
			PuertoEthernetLogico puertoEnMemoria = null;
			if (YaEstaRegistradoDireccionMAC(direccionMac))
				puertoEnMemoria = _diccioMacAddressPuertoEthernet[direccionMac];
			return puertoEnMemoria;
		}
		public void BorrarTabla()
		{
			_diccioMacAddressPuertoEthernet.Clear();
		}
	}
}
