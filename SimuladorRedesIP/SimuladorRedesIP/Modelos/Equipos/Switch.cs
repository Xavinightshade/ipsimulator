using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;
using System.Collections.ObjectModel;


namespace RedesIP.Modelos.Equipos
{
	public class Switch
	{
		private List<PuertoEthernet> _puertosEthernet;
		public ReadOnlyCollection<PuertoEthernet> PuertosEthernet
		{
			get { return _puertosEthernet.AsReadOnly(); }
		}
		public Switch(int numeroPuertos)
		{
			_puertosEthernet = new List<PuertoEthernet>(numeroPuertos);
			CrearPuertos(numeroPuertos);
			InicializarPuertos();
		}

		private void CrearPuertos(int numeroDePuertos)
		{
			for (int i = 0; i < numeroDePuertos; i++)
			{
				MACAddress macAddress = MACAddress.New();
				_puertosEthernet.Add(new PuertoEthernet(macAddress));
			}
		}

		private void InicializarPuertos()
		{
			foreach (PuertoEthernet puertoEthernet in _puertosEthernet)
			{
				puertoEthernet.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibidoEnAlgunPuerto);
			}
		}

		private void OnFrameRecibidoEnAlgunPuerto(object sender, FrameRecibidoEventArgs e)
		{

			PuertoEthernet puertoQueRecibioElFrame = (PuertoEthernet)sender;
			Frame frameRecibido = e.FrameRecibido;
			
			foreach (PuertoEthernet puertoEthernet in _puertosEthernet)
			{
				if (puertoEthernet == puertoQueRecibioElFrame)
					continue;
			  
				((IEnvioReciboDatos)puertoEthernet).TransmitirFrame(frameRecibido);
			}


		}
	}
}
