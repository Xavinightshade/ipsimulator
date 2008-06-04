using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Visualizacion.Equipos;

namespace RedesIP.Modelos.Visualizacion
{
	public class EventEquipoArgs : EventArgs
	{
		private IEquipo _dispositivo;
		public IEquipo Dispositivo
		{
			get { return _dispositivo; }
		}

		public EventEquipoArgs(IEquipo dispositivo)
		{
			_dispositivo = dispositivo;
		}
	}
}
