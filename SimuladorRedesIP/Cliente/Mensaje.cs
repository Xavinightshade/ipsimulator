using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Common;
using RedesIP.SOA;
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

		public Mensaje(MensajeCableSOA mensajeSOA)
		{
            _frame = mensajeSOA.Frame;
            _idConexion = mensajeSOA.IdConexion;
            _horaRecepcion = mensajeSOA.HoraRecepcion;
		}
    }
}
