using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.SOA;
using BusinessLogic.Modelos.Logicos.Datos;
using SOA.Datos;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferPC : ModeloSnifferBase
    {
        private ComputadorLogico _pc;
        public ModeloSnifferPC(ComputadorLogico pc)
        {
           _pc=pc;
            EscucharEventos();
        }

        private void EscucharEventos()
        {
            _pc.CapaRed.CapaDatos.PaqueteEncapsulado += new EventHandler<BusinessLogic.Datos.PaqueteEncapsuladoEventArgs>(CapaDatos_PaqueteEncapsulado);
            _pc.CapaRed.CapaDatos.PaqueteDesEncapsulado += new EventHandler<BusinessLogic.Datos.PaqueteDesencapsuladoEventArgs>(CapaDatos_PaqueteDesEncapsulado);
            _pc.ControladorTCP.SegmentoEnviado += new EventHandler<BusinessLogic.Datos.TCPSegmentTransmitido>(ControladorTCP_SegmentoEnviado);
            _pc.ControladorTCP.SegmentoRecibido += new EventHandler<BusinessLogic.Datos.TCPSegmentRecibido>(ControladorTCP_SegmentoRecibido);
        }

        void ControladorTCP_SegmentoRecibido(object sender, BusinessLogic.Datos.TCPSegmentRecibido e)
        {
            PacketSOA paquete = new PacketSOA();
            paquete.IpOrigen = e.PacketRecibido.IpOrigen;
            paquete.IpDestino = e.PacketRecibido.IpDestino;
            TCPSegmentSOA segment = new TCPSegmentSOA(e.SegmentoTCPRecibido.SourcePort,
                e.SegmentoTCPRecibido.DestinationPort,
                paquete,
                e.SegmentoTCPRecibido.SYN_Flag,
                e.SegmentoTCPRecibido.ACK_Flag,
                e.SegmentoTCPRecibido.SEQ_Number,
                e.SegmentoTCPRecibido.ACK_Number,e.HoraDeTransmision,
                false,
                e.SegmentoTCPRecibido.DataLength,
                e.SegmentoTCPRecibido.FinFlag);
            foreach (IVisualizacion vist in Vistas)
            {
                vist.EnviarInformacionSegmentoRecibido(_pc.Id, segment);

            }
        }

        void ControladorTCP_SegmentoEnviado(object sender, BusinessLogic.Datos.TCPSegmentTransmitido e)
        {
            PacketSOA paquete = new PacketSOA();
            paquete.IpOrigen = e.PacketTransmitido.IpOrigen;
            paquete.IpDestino = e.PacketTransmitido.IpDestino;
            TCPSegmentSOA segment = new TCPSegmentSOA(e.SegmentoTCPTransmitido.SourcePort,
                e.SegmentoTCPTransmitido.DestinationPort,
                paquete,
                e.SegmentoTCPTransmitido.SYN_Flag,
                e.SegmentoTCPTransmitido.ACK_Flag,
                e.SegmentoTCPTransmitido.SEQ_Number,
                e.SegmentoTCPTransmitido.ACK_Number,
                e.HoraDeTransmision,
                true,
                e.SegmentoTCPTransmitido.DataLength,
                e.SegmentoTCPTransmitido.FinFlag);
            foreach (IVisualizacion vist in Vistas)
            {
                vist.EnviarInformacionSegmentoEnviados(_pc.Id, segment);

            }
        }

        void CapaDatos_PaqueteDesEncapsulado(object sender, BusinessLogic.Datos.PaqueteDesencapsuladoEventArgs e)
        {
            FrameSOA frameSOA = new FrameSOA();
            frameSOA.MACAddressOrigen = e.Frame.MACAddressOrigen;
            frameSOA.MACAddressDestino = e.Frame.MACAddressDestino;
            Packet paquete = e.Frame.Informacion as Packet;
            PacketSOA packSOA = new PacketSOA();
            packSOA.IpOrigen = paquete.IpOrigen;
            packSOA.IpDestino = paquete.IpDestino;
            packSOA.Datos = paquete.Datos.ToString();
            EncapsulacionSOA encapsulacion = new EncapsulacionSOA();
            encapsulacion.Fecha = e.HoraDeRecepcion;
            encapsulacion.Frame = frameSOA;
            encapsulacion.Paquete = packSOA;
            encapsulacion.IdEquipo = _pc.Id;
            encapsulacion.EsEncapsulacion = false;
            foreach (IVisualizacion vist in Vistas)
            {
                vist.EnviarInformacionEncapsulacionPC(encapsulacion);

            }
        }

        void CapaDatos_PaqueteEncapsulado(object sender, BusinessLogic.Datos.PaqueteEncapsuladoEventArgs e)
        {
            FrameSOA frameSOA = new FrameSOA();
            frameSOA.MACAddressOrigen = e.Frame.MACAddressOrigen;
            frameSOA.MACAddressDestino = e.Frame.MACAddressDestino;
            Packet paquete=e.Frame.Informacion as Packet;
            PacketSOA packSOA = new PacketSOA();
            packSOA.IpOrigen = paquete.IpOrigen;
            packSOA.IpDestino = paquete.IpDestino;
            packSOA.Datos = paquete.Datos.ToString();
            EncapsulacionSOA encapsulacion = new EncapsulacionSOA();
            encapsulacion.Fecha = e.HoraDeRecepcion;
            encapsulacion.Frame = frameSOA;
            encapsulacion.Paquete = packSOA;
            encapsulacion.IdEquipo = _pc.Id;
            encapsulacion.EsEncapsulacion = true;
            foreach (IVisualizacion vist in Vistas)
            {
                vist.EnviarInformacionEncapsulacionPC(encapsulacion);

            }
        }
        public override void Dispose()
        {
            base.Dispose();
            _pc.CapaRed.CapaDatos.PaqueteEncapsulado -= new EventHandler<BusinessLogic.Datos.PaqueteEncapsuladoEventArgs>(CapaDatos_PaqueteEncapsulado);
            _pc.CapaRed.CapaDatos.PaqueteDesEncapsulado -= new EventHandler<BusinessLogic.Datos.PaqueteDesencapsuladoEventArgs>(CapaDatos_PaqueteDesEncapsulado);

            _pc = null;
        }
        public override void EliminarVista(IVisualizacion vista)
        {
            base.EliminarVista(vista);
            vista.EliminarSnifferPC(_pc.Id);
        }
       

    }
}
