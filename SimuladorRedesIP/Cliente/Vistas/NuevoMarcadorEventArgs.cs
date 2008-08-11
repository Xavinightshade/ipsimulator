using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.SOA.Elementos;
using RedesIP.Common;

namespace SimuladorCliente.Vistas
{
	public class NuevoMarcadorEventArgs : EventArgs
	{
		private Marcador _marcador;
		public Marcador Marcador
		{
			get { return _marcador; }
		}

		public NuevoMarcadorEventArgs(Marcador marcador)
		{
			_marcador = marcador;
		}
	}

	public class NuevoMensajeEventArgs : EventArgs
	{
        private Mensaje _mensaje;

        public Mensaje Mensaje
        {
            get { return _mensaje; }
        }
        public NuevoMensajeEventArgs(Mensaje mensaje)
        {
            _mensaje = mensaje;
        }
	}
}
