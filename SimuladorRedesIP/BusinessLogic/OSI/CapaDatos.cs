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

        public PuertoEthernetCompleto Puerto
        {
            get { return _puerto; }
        }
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
            Packet paquete = e.FrameRecibido.Informacion as Packet;
            if (datosFrameEncontrada != null)
            {
                ProcesarIPEncontrada(datosFrameEncontrada);
            }
            if (datosFrameBuscando != null)
            {
                ProcesarBusquedaDeDireccionIP(datosFrameBuscando, e.FrameRecibido.MACAddressOrigen);
            }
            if (paquete != null)
                ProcesarPaquete(paquete);

        }

        private void ProcesarPaquete(Packet paquete)
        {
            if (PaqueteRecibido != null)
            {
                PaqueteRecibidoEventArgs evento = new PaqueteRecibidoEventArgs(paquete, DateTime.Now);
                PaqueteRecibido(this, evento);
            }
        }
        public event EventHandler<PaqueteRecibidoEventArgs> PaqueteRecibido;




        private void ProcesarBusquedaDeDireccionIP(DatosFrameArpBuscando datosFrameBuscando, string macOrigen)
        {
            if (_puerto.IPAddress == datosFrameBuscando.IpDestino)
            {
                DatosFrameArpIPEncontrada datosFrameEncontrada = new DatosFrameArpIPEncontrada(_puerto.IPAddress, _puerto.MACAddress);
                EnviarFrame(datosFrameEncontrada, macOrigen);
            }
        }

        private void ProcesarIPEncontrada(DatosFrameArpIPEncontrada datosFrame)
        {
            if (datosFrame.DireccionIP == _puerto.IPAddress)
                return;
            if (_protocoloArp.ContieneLaDireccionDe(datosFrame.DireccionIP))
                return;
            _protocoloArp.ActualizarARP(datosFrame);
            List<Packet> paqueteNoEnviados = _paquetesNoEnviadosConDestino[datosFrame.DireccionIP];
            List<Packet> temp = new List<Packet>();
            foreach (Packet paqueteNoEnviado in paqueteNoEnviados)
            {
                temp.Add(paqueteNoEnviado);
            }
            foreach (Packet item in temp)
            {
                EnviarPaquete(item,datosFrame.DireccionIP);
            }



        }
        private Dictionary<string, List<Packet>> _paquetesNoEnviadosConDestino = new Dictionary<string, List<Packet>>();
        public void EnviarPaquete(Packet paquete,string ipDestino)
        {
            if (_protocoloArp.ContieneLaDireccionDe(ipDestino))
            {
                string macDestino = _protocoloArp.GetMacAddressFromIPAddress(ipDestino);
                EnviarFrame(paquete, macDestino);
                if (_paquetesNoEnviadosConDestino.ContainsKey(ipDestino))
                {
                    List<Packet> paquetesNoEnviados = _paquetesNoEnviadosConDestino[ipDestino];
                    if (paquetesNoEnviados.Contains(paquete))
                    {
                        paquetesNoEnviados.Remove(paquete);
                    }
                    if (paquetesNoEnviados.Count == 0)
                        _paquetesNoEnviadosConDestino.Remove(ipDestino);
                }

                return;
            }
            else
            {
                PreguntarPorDireccion(ipDestino);
                List<Packet> paquetesNoEnviadosEnDir = null;
                if (!_paquetesNoEnviadosConDestino.ContainsKey(ipDestino))
                    _paquetesNoEnviadosConDestino.Add(ipDestino, new List<Packet>());
                paquetesNoEnviadosEnDir = _paquetesNoEnviadosConDestino[ipDestino];
                paquetesNoEnviadosEnDir.Add(paquete);

            }
        }

        private void PreguntarPorDireccion(string ipAddress)
        {
            if (!_paquetesNoEnviadosConDestino.ContainsKey(ipAddress))
            {
                IFrameMessage datoFrame = _protocoloArp.CrearFramePidiendoLaDireccion(_puerto.MACAddress, ipAddress);
                EnviarFrame(datoFrame, MACAddressFactory.BroadCast);

            }
        }
        private void EnviarFrame(IFrameMessage mensaje, string MACDestino)
        {
            Frame frameATransmitir = new Frame(mensaje, _puerto.MACAddress, MACDestino);
            ((IEnvioReciboDatos)_puerto).TransmitirFrame(frameATransmitir);

        }

    }
}
