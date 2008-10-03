using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.SOA;
using BusinessLogic.Modelos.Logicos.Datos;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferPC
    {
        private ComputadorLogico _pc;
        private List<IVisualizacion> _vistas;
        public ModeloSnifferPC(ComputadorLogico pc, List<IVisualizacion> vistas)
        {
           _pc=pc;
            _vistas = vistas;
            EscucharEventos();
        }
        private void EscucharEventos()
        {
            _pc.CapaRed.CapaDatos.PaqueteEncapsulado += new EventHandler<BusinessLogic.Datos.PaqueteEncapsuladoEventArgs>(CapaDatos_PaqueteEncapsulado);
            _pc.CapaRed.CapaDatos.PaqueteDesEncapsulado += new EventHandler<BusinessLogic.Datos.PaqueteDesencapsuladoEventArgs>(CapaDatos_PaqueteDesEncapsulado);
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
            packSOA.Datos = paquete.Datos;
            foreach (IVisualizacion vist in _vistas)
            {
                vist.EnviarInformacionDesEncapsulacionPC(_pc.Id, frameSOA, packSOA, e.HoraDeRecepcion);

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
            packSOA.Datos = paquete.Datos;
            foreach (IVisualizacion vist in _vistas)
            {
                vist.EnviarInformacionEncapsulacionPC(_pc.Id, frameSOA, packSOA, e.HoraDeRecepcion);

            }
        }
    }
}
