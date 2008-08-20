using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Common;



namespace RedesIP.Modelos.Logicos.Equipos
{
	public class SwitchLogico:EquipoLogico
	{

		private List<PuertoEthernetLogicoBase> _puertosEthernet=new List<PuertoEthernetLogicoBase>();
		private SwitchTable _switchTable = new SwitchTable();
		public override ReadOnlyCollection<PuertoEthernetLogicoBase> PuertosEthernet
		{
			get { return _puertosEthernet.AsReadOnly(); }
		}
		public SwitchLogico(Guid id,int X,int Y):base(id,TipoDeEquipo.Switch,X,Y)
		{


		}



		private void InicializarPuertos()
		{
			foreach (PuertoEthernetLogicoBase puertoEthernet in _puertosEthernet)
			{
				puertoEthernet.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibidoEnAlgunPuerto);
			}
		}

		private void OnFrameRecibidoEnAlgunPuerto(object sender, FrameRecibidoEventArgs e)
		{

			PuertoEthernetLogicoBase puertoQueRecibioElFrame = (PuertoEthernetLogicoBase)sender;
			Frame frameRecibido = e.FrameRecibido;

			///Le aviso a la tabla del switch del nuevo Frame, para que lo guarde
			RegistrarFrame(puertoQueRecibioElFrame, frameRecibido);		
	
			/// Le pregunto a la tabla del switch si conoce el puerto destino de este frame,
			/// si es asi solo envio el frame a ese puerto.
            string direccionMACDestino = frameRecibido.MACAddressDestino;
			if (_switchTable.YaEstaRegistradoDireccionMAC(direccionMACDestino))
			{
				PuertoEthernetLogicoBase puertoDestinoDelFrame = _switchTable.BuscarPuertoBystring(direccionMACDestino);
				((IEnvioReciboDatos)puertoDestinoDelFrame).TransmitirFrame(frameRecibido);
				return;
			}
			/// Si la tabla del switch no contiene informacion de esta direccion MAC, envio este frame
			/// por todos los puertos, menos por el puerto en donde se recibio el frame

			TransmitirFrameATodosLosPuertos(puertoQueRecibioElFrame, frameRecibido);


		}

		private void TransmitirFrameATodosLosPuertos(PuertoEthernetLogicoBase puertoQueRecibioElFrame, Frame frameATransmitir)
		{
			foreach (PuertoEthernetLogicoBase puertoEthernet in _puertosEthernet)
			{
				if (puertoEthernet == puertoQueRecibioElFrame)
					continue;

				((IEnvioReciboDatos)puertoEthernet).TransmitirFrame(frameATransmitir);
			}
		}

		private void RegistrarFrame(PuertoEthernetLogicoBase puertoQueRecibioElFrame, Frame frameRecibido)
		{
            string direccionMacOrigen = frameRecibido.MACAddressOrigen;
			if (!_switchTable.YaEstaRegistradoDireccionMAC(direccionMacOrigen))
				_switchTable.RegistrarDireccionMAC(direccionMacOrigen, puertoQueRecibioElFrame);
		}
        public override void AgregarPuerto(Guid idPuerto)
        {
            _puertosEthernet.Add(new PuertoEthernetLogicoBase(idPuerto));
        }


        public override void InicializarEquipo()
        {
            InicializarPuertos();
        }
    }
}
