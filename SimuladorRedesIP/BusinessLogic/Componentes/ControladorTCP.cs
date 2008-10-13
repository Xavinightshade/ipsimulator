using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.OSI;
using BusinessLogic.Datos;
using BusinessLogic.Modelos.Logicos.Datos;

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
            int hash = ControladorSesion.GetHash(paquete.IpDestino, paquete.IpOrigen, tcpSegment.DestinationPort, tcpSegment.SourcePort);
            if (tcpSegment.SYN_Flag)
                _sesionesServer.Add(hash, new ControladorSesionServer(paquete.IpDestino, paquete.IpOrigen, tcpSegment.DestinationPort, tcpSegment.SourcePort));
            Packet paqueteRetorno = null;
            string ipDestino = string.Empty;
            if (_sesionesServer.ContainsKey(hash))
            {
                ControladorSesionServer controladorServer = _sesionesServer[hash];
                TCPSegment tcpSegmentRetorno = controladorServer.ProcesarSegmento(tcpSegment);
                paqueteRetorno = new Packet(controladorServer.IpOrigen, controladorServer.IpDestino, tcpSegmentRetorno);
            }
            if (_sesionesHost.ContainsKey(hash))
            {
                ControladorSesionHost controladorHost = _sesionesHost[hash];
                TCPSegment tcpSegmentRetorno = controladorHost.ProcesarSegmento(tcpSegment);
                paqueteRetorno = new Packet(controladorHost.IpOrigen, controladorHost.IpDestino, tcpSegmentRetorno);
            }
            if (paqueteRetorno.Datos == null)
                return;
            _capaRed.EnviarPaquete(paqueteRetorno.IpDestino, paqueteRetorno);


        }

        Dictionary<int, ControladorSesionHost> _sesionesHost = new Dictionary<int, ControladorSesionHost>();
        Dictionary<int, ControladorSesionServer> _sesionesServer = new Dictionary<int, ControladorSesionServer>();
        public void EnviarStream(string ipAddressDestino, int sourcePort, int destinationPort, byte[] datos)
        {
            ControladorSesionHost controladorHost = new ControladorSesionHost(_capaRed.CapaDatos.Puerto.IPAddress, ipAddressDestino, sourcePort, destinationPort, datos);
            int hashControlador = ControladorSesion.GetHash(_capaRed.CapaDatos.Puerto.IPAddress, ipAddressDestino, sourcePort, destinationPort);
            _sesionesHost.Add(hashControlador, controladorHost);
            TCPSegment tcpSyncSegment = controladorHost.GetTCPSyncSegment();
            Packet paquete = new Packet(controladorHost.IpOrigen, controladorHost.IpDestino, tcpSyncSegment);
            _capaRed.EnviarPaquete(controladorHost.IpDestino, paquete);


        }

    }
}
