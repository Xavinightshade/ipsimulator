using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Utilidades;

namespace RedesIP.Modelos.Visualizacion
{
	public class EventNuevaConexionArgs : EventArgs
	{
		private Linea _linea;
		public Linea Linea
		{
			get { return _linea; }
		}
		public EventNuevaConexionArgs(Linea linea)
		{
			_linea = linea;
		}

	}
}
