using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Datos;

namespace RedesIP.Modelos.Equipos.Componentes
{
	public class SwitchTable
	{

		private readonly Dictionary<MACAddress, PuertoEthernet> _diccioMacAddressPuertoEthernet=new Dictionary<MACAddress,PuertoEthernet>();
		public SwitchTable()
		{

		}
		public void RegistrarDireccionMAC(MACAddress direccionMAC, PuertoEthernet puertoEthenet)
		{

			System.Diagnostics.Debug.Assert(!(YaEstaRegistradoDireccionMAC(direccionMAC)), "Esta Direccion ya esta registrada");
			_diccioMacAddressPuertoEthernet.Add(direccionMAC, puertoEthenet);
		}
		public bool YaEstaRegistradoDireccionMAC(MACAddress direccionMAC)
		{
			return _diccioMacAddressPuertoEthernet.ContainsKey(direccionMAC);
		}
		public PuertoEthernet BuscarPuertoByMacAddress(MACAddress direccionMac)
		{
			PuertoEthernet puertoEnMemoria = null;
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
