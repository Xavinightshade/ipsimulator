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
            _puerto.Arp = protocoloArp;
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
            {
                EventPaqueteDesencapsulador(e.FrameRecibido);
                ProcesarPaquete(paquete);
            }

        }

        private void EventPaqueteDesencapsulador(Frame frame)
        {
            PaqueteDesencapsuladoEventArgs evento = new PaqueteDesencapsuladoEventArgs(frame, BusinessLogic.Threads.ThreadManager.HoraActual);
            if (PaqueteDesEncapsulado != null)
                PaqueteDesEncapsulado(this, evento);
        }

        private void ProcesarPaquete(Packet paquete)
        {
            if (PaqueteRecibido != null)
            {
                PaqueteRecibidoEventArgs evento = new PaqueteRecibidoEventArgs(paquete, BusinessLogic.Threads.ThreadManager.HoraActual);
                PaqueteRecibido(this, evento);
            }
        }
        public event EventHandler<PaqueteRecibidoEventArgs> PaqueteRecibido;
        public event EventHandler<PaqueteEncapsuladoEventArgs> PaqueteEncapsulado;
        public event EventHandler<PaqueteDesencapsuladoEventArgs> PaqueteDesEncapsulado;



        private void ProcesarBusquedaDeDireccionIP(DatosFrameArpBuscando datosFrameBuscando, string macOrigen)
        {
            if (_puerto.IPAddress == datosFrameBuscando.IpDestino)
            {
                DatosFrameArpIPEncontrada datosFrameEncontrada = new DatosFrameArpIPEncontrada(_puerto.IPAddress, _puerto.MACAddress,datosFrameBuscando.IdPacket);
                EnviarFrame(datosFrameEncontrada, macOrigen);
            }
        }

        private void ProcesarIPEncontrada(DatosFrameArpIPEncontrada datosFrame)
        {

            if (datosFrame.DireccionIP == _puerto.IPAddress)
                return;
            if (_protocoloArp.ContieneLaDireccionDe(datosFrame.DireccionIP))
                return;
            if (!_paquetesNoEnviadosConDestino.ContainsKey(datosFrame.DireccionIP))
                return;
            _protocoloArp.ActualizarARP(datosFrame);
            Dictionary<Guid, Packet> paqueteNoEnviados = _paquetesNoEnviadosConDestino[datosFrame.DireccionIP];
            EnviarPaquete(paqueteNoEnviados[datosFrame.IdPacketOriginal], datosFrame.DireccionIP);



        }
        private Dictionary<string, Dictionary<Guid, Packet>> _paquetesNoEnviadosConDestino = new Dictionary<string, Dictionary<Guid, Packet>>();
        public void EnviarPaquete(Packet paquete, string ipDestino)
        {
            string broadCastAddress = IPAddressFactory.GetBroadCastAddress(_puerto.IPAddress, _puerto.Mascara);
            if (ipDestino == broadCastAddress)
            {
                EnviarFrame(paquete, MACAddressFactory.BroadCast);
                return;
            }
            if (_protocoloArp.ContieneLaDireccionDe(ipDestino))
            {
                string macDestino = _protocoloArp.GetMacAddressFromIPAddress(ipDestino);
                EnviarFrame(paquete, macDestino);
                if (_paquetesNoEnviadosConDestino.ContainsKey(ipDestino))
                {
                    Dictionary<Guid, Packet> paquetesNoEnviados = _paquetesNoEnviadosConDestino[ipDestino];
                    if (paquetesNoEnviados.ContainsValue(paquete))
                    {
                        RemoverValor(paquete, paquetesNoEnviados);
                    }
                    if (paquetesNoEnviados.Count == 0)
                        _paquetesNoEnviadosConDestino.Remove(ipDestino);
                }

                return;
            }
            else
            {
                Guid idPacket = Guid.NewGuid();
                PreguntarPorDireccion(ipDestino,idPacket);
                Dictionary<Guid, Packet> paquetesNoEnviadosEnDir = null;
                if (!_paquetesNoEnviadosConDestino.ContainsKey(ipDestino))
                    _paquetesNoEnviadosConDestino.Add(ipDestino,new Dictionary<Guid,Packet>());
                paquetesNoEnviadosEnDir = _paquetesNoEnviadosConDestino[ipDestino];
                paquetesNoEnviadosEnDir.Add(idPacket,paquete);

            }
        }

        private void RemoverValor(Packet paquete, Dictionary<Guid, Packet> paquetesNoEnviados)
        {
            Guid idPacket = Guid.Empty;
            foreach (KeyValuePair<Guid, Packet> item in paquetesNoEnviados)
            {
                if (item.Value == paquete)
                {
                    idPacket = item.Key;
                    break;
                }
            }
            if (idPacket == Guid.Empty)
            {
                throw new Exception();
            }
            paquetesNoEnviados.Remove(idPacket);
        }




        private void PreguntarPorDireccion(string ipAddress, Guid idPacket)
        {

            IFrameMessage datoFrame = _protocoloArp.CrearFramePidiendoLaDireccion(_puerto.MACAddress, ipAddress,idPacket);
            EnviarFrame(datoFrame, MACAddressFactory.BroadCast);


        }
        private void EnviarFrame(IFrameMessage mensaje, string MACDestino)
        {
            Frame frameATransmitir = new Frame(mensaje, _puerto.MACAddress, MACDestino);
            if (mensaje is Packet)
                EventPaqueteEncapsulado(frameATransmitir);
            ((IEnvioReciboDatos)_puerto).TransmitirFrame(frameATransmitir);

        }

        private void EventPaqueteEncapsulado(Frame frameATransmitir)
        {
            PaqueteEncapsuladoEventArgs evento = new PaqueteEncapsuladoEventArgs(frameATransmitir, BusinessLogic.Threads.ThreadManager.HoraActual);
            if (PaqueteEncapsulado != null)
                PaqueteEncapsulado(this, evento);
        }

    }
}
