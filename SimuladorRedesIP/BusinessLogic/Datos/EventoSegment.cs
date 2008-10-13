using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Modelos.Logicos.Datos;
using SOA;

namespace BusinessLogic.Datos
{
    public class TCPSegmentTransmitido : EventArgs
    {
        private Packet _TCPTransmitido;

        public Packet PacketTransmitido
        {
            get { return _TCPTransmitido; }
        }
        public TCPSegment SegmentoTCPTransmitido
        {
            get { return _TCPTransmitido.Datos as TCPSegment; }
        }
        private TimeSpan _horaDeTransmision;

        public TimeSpan HoraDeTransmision
        {
            get { return _horaDeTransmision; }
        }

        public TCPSegmentTransmitido(Packet segmento, TimeSpan horaTransmision)
        {
            _TCPTransmitido = segmento;
            _horaDeTransmision = horaTransmision;
        }
    }
    public class TCPSegmentRecibido : EventArgs
    {
        private Packet _TCPRecibido;

        public Packet PacketRecibido
        {
            get { return _TCPRecibido; }
        }
        public TCPSegment SegmentoTCPRecibido
        {
            get { return _TCPRecibido.Datos as TCPSegment; }
        }
        private TimeSpan _horaDeTransmision;

        public TimeSpan HoraDeTransmision
        {
            get { return _horaDeTransmision; }
        }

        public TCPSegmentRecibido(Packet paquete, TimeSpan horaTransmision)
        {
            _TCPRecibido = paquete;
            _horaDeTransmision = horaTransmision;
        }
    }
    public class ArchivoRecibido : EventArgs
    {
        private ArchivoSOA _archivo;

        public ArchivoSOA Archivo
        {
            get { return _archivo; }
        }
        private Guid _idPC;

        public Guid IdPC
        {
            get { return _idPC; }
        }

        private TimeSpan _horaDeTransmision;

        public TimeSpan HoraDeTransmision
        {
            get { return _horaDeTransmision; }
        }

        public ArchivoRecibido(ArchivoSOA archivo, TimeSpan horaTransmision,Guid idPc)
        {
            _idPC = idPc;
            _archivo = archivo;
            _horaDeTransmision = horaTransmision;
        }
    }
}
