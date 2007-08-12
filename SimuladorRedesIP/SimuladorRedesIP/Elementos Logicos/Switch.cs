using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Datos;
using System.Collections.ObjectModel;


namespace RedesIP.ElementosLogicos
{
	public class SwitchLogico
	{
		private List<PuertoEthernetLogico> _puertosEthernet;
		public ReadOnlyCollection<PuertoEthernetLogico> PuertosEthernet
		{
			get { return _puertosEthernet.AsReadOnly(); }
		}
		public SwitchLogico(int numeroPuertos)
		{
			_puertosEthernet = new List<PuertoEthernetLogico>(numeroPuertos);
			CrearPuertos(numeroPuertos);
			InicializarPuertos();
		}

		private void CrearPuertos(int numeroDePuertos)
		{
			for (int i = 0; i < numeroDePuertos; i++)
			{
				MACAddress macAddress = MACAddress.New();
				_puertosEthernet.Add(new PuertoEthernetLogico(macAddress));
			}
		}

		private void InicializarPuertos()
		{
			foreach (PuertoEthernetLogico puertoEthernet in _puertosEthernet)
			{
				puertoEthernet.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibidoEnAlgunPuerto);
			}
		}

		private void OnFrameRecibidoEnAlgunPuerto(object sender, FrameRecibidoEventArgs e)
		{

			PuertoEthernetLogico puertoQueRecibioElFrame = (PuertoEthernetLogico)sender;
			Frame frameRecibido = e.FrameRecibido;
			Console.WriteLine(frameRecibido.MACAddressOrigen);
			foreach (PuertoEthernetLogico puertoEthernet in _puertosEthernet)
			{
				if (puertoEthernet == puertoQueRecibioElFrame)
					continue;
				puertoEthernet.TransmitirFrame(frameRecibido);
			}


		}
	}
}
