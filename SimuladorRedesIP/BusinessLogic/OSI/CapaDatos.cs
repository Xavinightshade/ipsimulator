using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Protocolos;
using BusinessLogic.Modelos.Logicos.Datos;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Modelos.Datos;
using RedesIP.Common;
using BusinessLogic.Datos;

namespace BusinessLogic.OSI
{
    public class CapaDatos
    {
        private ARP _protocoloArp;
        private PuertoEthernetCompleto _puerto;
        public CapaDatos(ARP protocoloArp, PuertoEthernetCompleto puerto)
        {
            _protocoloArp = protocoloArp;
            _puerto = puerto;
            _puerto.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
        }

        private void OnFrameRecibido(object sender, FrameRecibidoEventArgs e)
        {
            DatosFrameArpIPEncontrada datosFrameEncontrada = e.FrameRecibido.Informacion as DatosFrameArpIPEncontrada;
            DatosFrameArpBuscando datosFrameBuscando = e.FrameRecibido.Informacion as DatosFrameArpBuscando;
            if (datosFrameEncontrada != null)
            {
                ProcesarIPEncontrada(datosFrameEncontrada);
            }
            if (datosFrameBuscando!=null)
            {
                ProcesarBusquedaDeDireccionIP(datosFrameBuscando,e.FrameRecibido.MACAddressOrigen);
            }
            
        }

        private void ProcesarBusquedaDeDireccionIP(DatosFrameArpBuscando datosFrameBuscando,string macOrigen)
        {
            if (_puerto.IPAddress==datosFrameBuscando.IpDestino)
            {
                DatosFrameArpIPEncontrada datosFrameEncontrada = new DatosFrameArpIPEncontrada(_puerto.IPAddress, _puerto.MACAddress);
                EnviarFrame(datosFrameEncontrada, macOrigen);
            }
        }

        private void ProcesarIPEncontrada(DatosFrameArpIPEncontrada datosFrame)
        {

                _protocoloArp.ActualizarARP(datosFrame);
                List<Packet> paqueteNoEnviados = _paquetesNoEnviadosConDestino[datosFrame.DireccionIP];
                List<Packet> temp = new List<Packet>();
                    foreach (Packet paqueteNoEnviado in paqueteNoEnviados)
                    {
                        temp.Add(paqueteNoEnviado);                       
                    }
                    foreach (Packet item in temp)
                    {
                        EnviarPaquete(item);
                    }



        }
        private Dictionary<string, List<Packet>> _paquetesNoEnviadosConDestino = new Dictionary<string, List<Packet>>();
        public void EnviarPaquete(Packet paquete)
        {
            if (_protocoloArp.ContieneLaDireccionDe(paquete.IpDestino))
            {
                string macDestino = _protocoloArp.GetMacAddressFromIPAddress(paquete.IpDestino);
                EnviarFrame(paquete, macDestino);
                if (_paquetesNoEnviadosConDestino.ContainsKey(paquete.IpDestino))
                {
                    List<Packet> paquetesNoEnviados = _paquetesNoEnviadosConDestino[paquete.IpDestino];
                    if (paquetesNoEnviados.Contains(paquete))
                    {
                        paquetesNoEnviados.Remove(paquete);
                    }
                    if (paquetesNoEnviados.Count == 0)
                        _paquetesNoEnviadosConDestino.Remove(paquete.IpDestino);
                }

                return;
            }
            else
            {
                List<Packet> paquetesNoEnviadosEnDir = null;
                if (!_paquetesNoEnviadosConDestino.ContainsKey(paquete.IpDestino))
                    _paquetesNoEnviadosConDestino.Add(paquete.IpDestino, new List<Packet>());
                paquetesNoEnviadosEnDir = _paquetesNoEnviadosConDestino[paquete.IpDestino];
                paquetesNoEnviadosEnDir.Add(paquete);
                PreguntarPorDireccion(paquete.IpDestino);
            }
        }

        private void PreguntarPorDireccion(string ipAddress)
        {
            IFrameMessage datoFrame = _protocoloArp.CrearFramePidiendoLaDireccion(_puerto.MACAddress, ipAddress);
            EnviarFrame(datoFrame, MACAddressFactory.BroadCast);
        }
        private void EnviarFrame(IFrameMessage mensaje, string MACDestino)
        {
            Frame frameATransmitir = new Frame(mensaje, _puerto.MACAddress, MACDestino);
            ((IEnvioReciboDatos)_puerto).TransmitirFrame(frameATransmitir);

        }
    }
}
