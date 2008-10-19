using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.OSI;
using BusinessLogic.Datos;
using BusinessLogic.Modelos.Logicos.Datos;
using BusinessLogic.Threads;
using SOA;

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
            {
                ControladorSesionServer controladorServer = new ControladorSesionServer(paquete.IpDestino, paquete.IpOrigen, tcpSegment.DestinationPort, tcpSegment.SourcePort);
                _sesionesServer.Add(hash, controladorServer);
               controladorServer.ArchivoRecibido+=new EventHandler<EventArgs>(controladorServer_ArchivoRecibido);

            }
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

        void controladorServer_ArchivoRecibido(object sender, EventArgs e)
        {
            ControladorSesionServer controladorServer = (ControladorSesionServer)sender;
            controladorServer.ArchivoRecibido -= new EventHandler<EventArgs>(controladorServer_ArchivoRecibido);
            _sesionesServer.Remove(controladorServer.GetHash());

            if (ArchivoRecibido != null)
                ArchivoRecibido(sender, e);
        }
        public event EventHandler<EventArgs> ArchivoRecibido;

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
            int segmentSize,string fileName)
        {
            ControladorSesionHost controladorHost = new ControladorSesionHost(_capaRed.CapaDatos.Puerto.IPAddress, ipAddressDestino, sourcePort, destinationPort, datos, segmentSize,fileName);
            controladorHost.FinComunicacion += new EventHandler(controladorHost_FinComunicacion);
            int hashControlador = controladorHost.GetHash();
            if (_sesionesHost.ContainsKey(hashControlador))
                return;
            _sesionesHost.Add(hashControlador, controladorHost);
            TCPSegment tcpSyncSegment = controladorHost.GetTCPSyncSegment();
            List<TCPSegment> segmentos = new List<TCPSegment>();
            segmentos.Add(tcpSyncSegment);
            EnviarSegmentos(segmentos,controladorHost);

        }

        void controladorHost_FinComunicacion(object sender, EventArgs e)
        {
            ControladorSesionHost controladorHost=(ControladorSesionHost)sender;
            controladorHost.FinComunicacion -= new EventHandler(controladorHost_FinComunicacion);
            _sesionesHost.Remove(controladorHost.GetHash());
        }

        public event EventHandler<TCPSegmentRecibido> SegmentoRecibido;
        public event EventHandler<TCPSegmentTransmitido> SegmentoEnviado;



        internal void Dispose()
        {
            _capaRed.CapaDatos.PaqueteRecibido -= new EventHandler<PaqueteRecibidoEventArgs>(CapaDatos_PaqueteRecibido);
            _sesionesHost.Clear();
            _sesionesServer.Clear();

        }
    }
}
