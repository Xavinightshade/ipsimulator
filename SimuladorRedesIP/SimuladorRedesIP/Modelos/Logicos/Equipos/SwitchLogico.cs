using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Equipos.Componentes;


namespace RedesIP.Modelos.Logicos.Equipos
{
	public class SwitchLogico:EquipoLogico
	{
		private Guid _id;

		public override Guid Id
		{
			get { return _id; }
		}
		private List<PuertoEthernetLogico> _puertosEthernet;
		private SwitchTable _switchTable = new SwitchTable();
		public override ReadOnlyCollection<PuertoEthernetLogico> PuertosEthernet
		{
			get { return _puertosEthernet.AsReadOnly(); }
		}
		public SwitchLogico(int numeroPuertos)
		{
			_id = Guid.NewGuid();
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

			///Le aviso a la tabla del switch del nuevo Frame, para que lo guarde
			RegistrarFrame(puertoQueRecibioElFrame, frameRecibido);		
	
			/// Le pregunto a la tabla del switch si conoce el puerto destino de este frame,
			/// si es asi solo envio el frame a ese puerto.
			MACAddress direccionMACDestino = frameRecibido.MACAddressDestino;
			if (_switchTable.YaEstaRegistradoDireccionMAC(direccionMACDestino))
			{
				PuertoEthernetLogico puertoDestinoDelFrame = _switchTable.BuscarPuertoByMacAddress(direccionMACDestino);
				((IEnvioReciboDatos)puertoDestinoDelFrame).TransmitirFrame(frameRecibido);
				return;
			}
			/// Si la tabla del switch no contiene informacion de esta direccion MAC, envio este frame
			/// por todos los puertos, menos por el puerto en donde se recibio el frame

			TransmitirFrameATodosLosPuertos(puertoQueRecibioElFrame, frameRecibido);


		}

		private void TransmitirFrameATodosLosPuertos(PuertoEthernetLogico puertoQueRecibioElFrame, Frame frameATransmitir)
		{
			foreach (PuertoEthernetLogico puertoEthernet in _puertosEthernet)
			{
				if (puertoEthernet == puertoQueRecibioElFrame)
					continue;

				((IEnvioReciboDatos)puertoEthernet).TransmitirFrame(frameATransmitir);
			}
		}

		private void RegistrarFrame(PuertoEthernetLogico puertoQueRecibioElFrame, Frame frameRecibido)
		{
			MACAddress direccionMacOrigen = frameRecibido.MACAddressOrigen;
			if (!_switchTable.YaEstaRegistradoDireccionMAC(direccionMacOrigen))
				_switchTable.RegistrarDireccionMAC(direccionMacOrigen, puertoQueRecibioElFrame);
		}


	}
}
