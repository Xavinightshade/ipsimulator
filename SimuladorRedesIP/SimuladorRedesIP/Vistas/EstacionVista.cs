using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Vistas
{
	public class EstacionVista:IEstacionVista
	{
		#region IEstacion Members

		public IDispositivoVista CrearDispositivo()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public event EventHandler<EventDispositivoVistaArgs> DispositivoEliminado;

		public event EventHandler<EventDispositivoVistaArgs> DispositivoDesAsociado;

		public event EventHandler CreacionDispositivo;

		#endregion
	}
}
