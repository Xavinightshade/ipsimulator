﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.SOA;
using RedesIP.Modelos.Equipos.Componentes;
using BusinessLogic.OSI;
using SOA.Datos;
using BusinessLogic.Modelos.Logicos.Datos;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferRouter
    {
        private RouterLogico _router;
        private List<IVisualizacion> _vistas=new List<IVisualizacion>();
        public ModeloSnifferRouter(RouterLogico router)
        {
          _router=router;
            EscucharEventos();
        }
        public void AgregarVista(IVisualizacion vista)
        {
            _vistas.Add(vista);
        }
        public void EliminarVista(IVisualizacion vista)
        {
            if (_vistas.Contains(vista))
                _vistas.Remove(vista);
        }
        private void EscucharEventos()
        {
            foreach (KeyValuePair<PuertoEthernetCompleto, CapaRedRouter> item in _router.PuertoEthernetCapaRed)
            {
                item.Value.CapaDatos.PaqueteDesEncapsulado += new EventHandler<BusinessLogic.Datos.PaqueteDesencapsuladoEventArgs>(CapaDatos_PaqueteDesEncapsulado);
                item.Value.CapaDatos.PaqueteEncapsulado += new EventHandler<BusinessLogic.Datos.PaqueteEncapsuladoEventArgs>(CapaDatos_PaqueteEncapsulado);
            }
        }

        void CapaDatos_PaqueteEncapsulado(object sender, BusinessLogic.Datos.PaqueteEncapsuladoEventArgs e)
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
            encapsulacion.IdEquipo = _router.Id;
            encapsulacion.EsEncapsulacion = true;
            foreach (IVisualizacion vist in _vistas)
            {
                vist.EnviarInformacionEncapsulacionRouter(encapsulacion);

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
            packSOA.Datos = paquete.Datos;
            EncapsulacionSOA encapsulacion = new EncapsulacionSOA();
            encapsulacion.Fecha = e.HoraDeRecepcion;
            encapsulacion.Frame = frameSOA;
            encapsulacion.Paquete = packSOA;
            encapsulacion.IdEquipo = _router.Id;
            encapsulacion.EsEncapsulacion = false;
            foreach (IVisualizacion vist in _vistas)
            {
                vist.EnviarInformacionEncapsulacionRouter(encapsulacion);

            }
        }
    }
}
