using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Common;
using RedesIP.SOA.Elementos;

namespace SimuladorCliente
{
   public class Mensaje
    {
        private Guid _idConexion;
		public Guid IdConexion
		{
			get { return _idConexion; }
		}
		private string _mensaje;

		public string Datos
		{
			get { return _mensaje; }
		}
        private MACAddress _macOrigen;

        public MACAddress MacOrigen
        {
            get { return _macOrigen; }
        }
        private MACAddress _macPuerto;
        public MACAddress MacPuerto
        {
            get { return _macPuerto; }
        }
        private MACAddress _macDestino;

        public MACAddress MacDestino
        {
            get { return _macDestino; }
        }
        private DateTime _horaTransmision;
        public DateTime HoraTransmision
        {
            get { return _horaTransmision; }

        }
        DateTime _horaRecepcion;

        public DateTime HoraRecepcion
        {
            get { return _horaRecepcion; }

        }

		public Mensaje(MensajeSOA mensajeSOA)
		{
            MACAddressSOA macPuerto=mensajeSOA.MacPuerto;
            MACAddressSOA macOrigen=mensajeSOA.MacOrigen;
            MACAddressSOA macDestion=mensajeSOA.MacDestino;
            _macPuerto = MACAddress.Direccion(macPuerto.Parte1,macPuerto.Parte2,macPuerto.Parte3);
            _idConexion = mensajeSOA.IdConexion;
            _mensaje = mensajeSOA.Datos;
            _macOrigen = MACAddress.Direccion(macOrigen.Parte1, macOrigen.Parte2, macOrigen.Parte3);
            _macDestino = MACAddress.Direccion(macDestion.Parte1, macDestion.Parte2, macDestion.Parte3);
            _horaRecepcion = mensajeSOA.HoraRecepcion;
            _horaTransmision = mensajeSOA.HoraTransmision;
		}
    }
}
