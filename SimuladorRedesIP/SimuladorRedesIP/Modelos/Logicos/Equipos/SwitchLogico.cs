using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.ModelosLogicos.Datos;
using System.Collections.ObjectModel;
using RedesIP.ModelosLogicos.Equipos.Componentes;


namespace RedesIP.ModelosLogicos.Equipos
{
	public class SwitchLogico
	{
		private List<PuertoEthernet> _puertosEthernet;
		private SwitchTable _switchTable = new SwitchTable();
		public ReadOnlyCollection<PuertoEthernet> PuertosEthernet
		{
			get { return _puertosEthernet.AsReadOnly(); }
		}
		public SwitchLogico(int numeroPuertos)
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

			///Le aviso a la tabla del switch del nuevo Frame, para que lo guarde
			RegistrarFrame(puertoQueRecibioElFrame, frameRecibido);		
	
			/// Le pregunto a la tabla del switch si conoce el puerto destino de este frame,
			/// si es asi solo envio el frame a ese puerto.
			MACAddress direccionMACDestino = frameRecibido.MACAddressDestino;
			if (_switchTable.YaEstaRegistradoDireccionMAC(direccionMACDestino))
			{
				PuertoEthernet puertoDestinoDelFrame = _switchTable.BuscarPuertoByMacAddress(direccionMACDestino);
				((IEnvioReciboDatos)puertoDestinoDelFrame).TransmitirFrame(frameRecibido);
				return;
			}
			/// Si la tabla del switch no contiene informacion de esta direccion MAC, envio este frame
			/// por todos los puertos, menos por el puerto en donde se recibio el frame

			TransmitirFrameATodosLosPuertos(puertoQueRecibioElFrame, frameRecibido);


		}

		private void TransmitirFrameATodosLosPuertos(PuertoEthernet puertoQueRecibioElFrame, Frame frameATransmitir)
		{
			foreach (PuertoEthernet puertoEthernet in _puertosEthernet)
			{
				if (puertoEthernet == puertoQueRecibioElFrame)
					continue;

				((IEnvioReciboDatos)puertoEthernet).TransmitirFrame(frameATransmitir);
			}
		}

		private void RegistrarFrame(PuertoEthernet puertoQueRecibioElFrame, Frame frameRecibido)
		{
			MACAddress direccionMacOrigen = frameRecibido.MACAddressOrigen;
			if (!_switchTable.YaEstaRegistradoDireccionMAC(direccionMacOrigen))
				_switchTable.RegistrarDireccionMAC(direccionMacOrigen, puertoQueRecibioElFrame);
		}
	}
}
