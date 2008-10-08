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
            packSOA.Datos = paquete.Datos;
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
       
    }
}
