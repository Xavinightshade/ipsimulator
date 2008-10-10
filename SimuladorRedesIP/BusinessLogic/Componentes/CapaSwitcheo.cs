using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Modelos.Datos;
using RedesIP.Common;

namespace BusinessLogic.Componentes
{
    public class CapaSwitcheo
    {
        private SwitchTable _switchTable = new SwitchTable();

        public SwitchTable SwitchTable
        {
            get { return _switchTable; }
        }

        private List<PuertoEthernetLogicoBase> _puertosEthernet = new List<PuertoEthernetLogicoBase>();


        public void AgregarPuerto(PuertoEthernetLogicoBase puerto)
        {
            _puertosEthernet.Add(puerto);
            puerto.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibidoEnAlgunPuerto);
        }
        private void RegistrarFrame(PuertoEthernetLogicoBase puertoQueRecibioElFrame, Frame frameRecibido)
        {
            string direccionMacOrigen = frameRecibido.MACAddressOrigen;
            if (!_switchTable.YaEstaRegistradoDireccionMAC(direccionMacOrigen))
                _switchTable.RegistrarDireccionMAC(direccionMacOrigen, puertoQueRecibioElFrame);
        }

        private void OnFrameRecibidoEnAlgunPuerto(object sender, FrameRecibidoEventArgs e)
        {

            PuertoEthernetLogicoBase puertoQueRecibioElFrame = (PuertoEthernetLogicoBase)sender;
            Frame frameRecibido = e.FrameRecibido;

            ///Le aviso a la tabla del switch del nuevo Frame, para que lo guarde
            RegistrarFrame(puertoQueRecibioElFrame, frameRecibido);

            /// Si es Broadcast
            if (frameRecibido.MACAddressDestino == MACAddressFactory.BroadCast)
            {
                TransmitirFrameATodosLosPuertos(puertoQueRecibioElFrame, frameRecibido);
                return;
            }

            /// Le pregunto a la tabla del switch si conoce el puerto destino de este frame,
            /// si es asi solo envio el frame a ese puerto.
            string direccionMACDestino = frameRecibido.MACAddressDestino;
            if (_switchTable.YaEstaRegistradoDireccionMAC(direccionMACDestino))
            {
                PuertoEthernetLogicoBase puertoDestinoDelFrame = _switchTable.BuscarPuertoByDireccionMac(direccionMACDestino);
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
        public void Dispose()
        {
            foreach (PuertoEthernetLogicoBase puerto in _puertosEthernet)
            {
                puerto.FrameRecibido -= new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibidoEnAlgunPuerto);
            }
            _switchTable.BorrarTabla();
            _puertosEthernet.Clear();
        }

    }
}
