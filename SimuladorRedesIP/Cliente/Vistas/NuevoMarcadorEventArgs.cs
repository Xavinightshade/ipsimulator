using System;
using System.Collections.Generic;
using System.Text;

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
		private Guid _idConexion;
		public Guid IdConexion
		{
			get { return _idConexion; }
		}
		private string _mensaje;

		public string Mensaje
		{
			get { return _mensaje; }
		}

		public NuevoMensajeEventArgs(Guid idConexion, string mensaje)
		{
			_idConexion = idConexion;
			_mensaje = mensaje;
		}
	}
}
