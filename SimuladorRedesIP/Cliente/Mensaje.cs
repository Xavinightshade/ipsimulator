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
        private string _macOrigen;

        public string MacOrigen
        {
            get { return _macOrigen; }
        }
        private string _macDestino;

        public string MacDestino
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
              _macOrigen = mensajeSOA.MacOrigen;
               _macDestino = mensajeSOA.MacDestino;
            _idConexion = mensajeSOA.IdConexion;
            _mensaje = mensajeSOA.Datos;
            _horaRecepcion = mensajeSOA.HoraRecepcion;
            _horaTransmision = mensajeSOA.HoraTransmision;
		}
    }
}
