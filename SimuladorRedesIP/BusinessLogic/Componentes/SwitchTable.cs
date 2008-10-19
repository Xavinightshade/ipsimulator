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

        private readonly Dictionary<string, PuertoEthernetLogicoBase> _tablaDeFiltro = new Dictionary<string, PuertoEthernetLogicoBase>();

        public Dictionary<string, PuertoEthernetLogicoBase> TablaDeFiltro
        {
            get { return _tablaDeFiltro; }
        } 

		public SwitchTable()
		{

		}
        public event EventHandler<TiempoEventArgs> CambioDeTablaDeFiltro;
        private void OnCambioDeTablaDeFiltro()
        {
            if (CambioDeTablaDeFiltro != null)
                CambioDeTablaDeFiltro(this, new TiempoEventArgs(BusinessLogic.Threads.ThreadManager.HoraActual));
        }
		public void RegistrarDireccionMAC(string direccionMAC, PuertoEthernetLogicoBase puertoEthenet)
        {

            System.Diagnostics.Debug.Assert(!(YaEstaRegistradoDireccionMAC(direccionMAC)), "Esta Direccion ya esta registrada");
            
                _tablaDeFiltro.Add(direccionMAC, puertoEthenet);
                OnCambioDeTablaDeFiltro();
            
        }
		public bool YaEstaRegistradoDireccionMAC(string direccionMAC)
		{
			return _tablaDeFiltro.ContainsKey(direccionMAC);
		}
		public PuertoEthernetLogicoBase BuscarPuertoByDireccionMac(string direccionMac)
		{
			PuertoEthernetLogicoBase puertoEnMemoria = null;
			if (YaEstaRegistradoDireccionMAC(direccionMac))
				puertoEnMemoria = _tablaDeFiltro[direccionMac];
			return puertoEnMemoria;
		}
		public void BorrarTabla()
		{
          
			_tablaDeFiltro.Clear();
		}

	}
}
