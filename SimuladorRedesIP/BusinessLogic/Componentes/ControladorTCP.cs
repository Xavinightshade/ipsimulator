using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.OSI;
using BusinessLogic.Datos;
using BusinessLogic.Modelos.Logicos.Datos;
using BusinessLogic.Threads;

namespace BusinessLogic.Componentes
{
    public class ControladorTCP
    {
        private CapaRed _capaRed;
        public ControladorTCP(CapaRed capaRed)
        {
            _capaRed = capaRed;
            _capaRed.CapaDatos.PaqueteRecibido += new EventHandler<PaqueteRecibidoEventArgs>(CapaDatos_PaqueteRecibido);
        }

        private void CapaDatos_PaqueteRecibido(object sender, PaqueteRecibidoEventArgs e)
        {
            Packet paquete = e.PaqueteRecibido;
            TCPSegment tcpSegment = paquete.Datos as TCPSegment;
            if (tcpSegment == null)
                return;
            EnviarNotifacionSegmentoRecibido(paquete);
            int hash = ControladorSesion.GetHash(paquete.IpDestino, paquete.IpOrigen, tcpSegment.DestinationPort, tcpSegment.SourcePort);
            if (tcpSegment.SYN_Flag && !tcpSegment.ACK_Flag)
                _sesionesServer.Add(hash, new ControladorSesionServer(paquete.IpDestino, paquete.IpOrigen, tcpSegment.DestinationPort, tcpSegment.SourcePort));
            if (_sesionesServer.ContainsKey(hash))
            {
                ControladorSesionServer controladorServer = _sesionesServer[hash];
                List<TCPSegment> segmentos = controladorServer.ProcesarSegmento(tcpSegment);
                EnviarSegmentos(segmentos, controladorServer);
            }
            if (_sesionesHost.ContainsKey(hash))
            {
                ControladorSesionHost controladorHost = _sesionesHost[hash];
                List<TCPSegment> segmentos = controladorHost.ProcesarSegmento(tcpSegment);
                EnviarSegmentos(segmentos, controladorHost);
            }



        }

        private void EnviarSegmentos(List<TCPSegment> segmentos, ControladorSesion controlador)
        {
            foreach (TCPSegment segmento in segmentos)
            {
                Packet paquete = new Packet(controlador.IpOrigen, controlador.IpDestino, segmento);
                _capaRed.EnviarPaquete(controlador.IpDestino, paquete);
                EnviarNotifacionSegmentoEnviado(paquete);
            }
        }

        private void EnviarNotifacionSegmentoRecibido(Packet paquete)
        {
            if (SegmentoRecibido != null)
            {
                TCPSegmentRecibido evento = new TCPSegmentRecibido(paquete, ThreadManager.HoraActual);
                SegmentoRecibido(this, evento);
            }
        }

        private void EnviarNotifacionSegmentoEnviado(Packet paquete)
        {
            if (SegmentoEnviado != null)
            {
                TCPSegmentTransmitido evento = new TCPSegmentTransmitido(paquete, ThreadManager.HoraActual);
                SegmentoEnviado(this, evento);
            }
        }

        Dictionary<int, ControladorSesionHost> _sesionesHost = new Dictionary<int, ControladorSesionHost>();
        Dictionary<int, ControladorSesionServer> _sesionesServer = new Dictionary<int, ControladorSesionServer>();
        public void EnviarStream(string ipAddressDestino, int sourcePort, int destinationPort, byte[] datos,
            int segmentSize)
        {
            ControladorSesionHost controladorHost = new ControladorSesionHost(_capaRed.CapaDatos.Puerto.IPAddress, ipAddressDestino, sourcePort, destinationPort, datos, segmentSize);
            int hashControlador = ControladorSesion.GetHash(_capaRed.CapaDatos.Puerto.IPAddress, ipAddressDestino, sourcePort, destinationPort);
            _sesionesHost.Add(hashControlador, controladorHost);
            TCPSegment tcpSyncSegment = controladorHost.GetTCPSyncSegment();
            List<TCPSegment> segmentos = new List<TCPSegment>();
            segmentos.Add(tcpSyncSegment);
            EnviarSegmentos(segmentos,controladorHost);

        }

        public event EventHandler<TCPSegmentRecibido> SegmentoRecibido;
        public event EventHandler<TCPSegmentTransmitido> SegmentoEnviado;


    }
}
