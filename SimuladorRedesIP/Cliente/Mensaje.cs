using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Common;
using RedesIP.SOA.Elementos;
using RedesIP.SOA;

namespace SimuladorCliente
{
   public class Mensaje
    {
        private Guid _idConexion;
		public Guid IdConexion
		{
			get { return _idConexion; }
		}
        private FrameSOA _frame;

        public FrameSOA Frame
        {
            get { return _frame; }
        }

        DateTime _horaRecepcion;

        public DateTime HoraRecepcion
        {
            get { return _horaRecepcion; }

        }

		public Mensaje(MensajeSOA mensajeSOA)
		{
            _frame = mensajeSOA.Frame;
            _idConexion = mensajeSOA.IdConexion;
            _horaRecepcion = mensajeSOA.HoraRecepcion;
		}
    }
}
