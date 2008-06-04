using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Visualizacion.Equipos;

namespace RedesIP.Modelos.Visualizacion
{
	public class EventEquipoArgs : EventArgs
	{
		private Equipo _dispositivo;
		public Equipo Dispositivo
		{
			get { return _dispositivo; }
		}

		public EventEquipoArgs(Equipo dispositivo)
		{
			_dispositivo = dispositivo;
		}
	}
}
