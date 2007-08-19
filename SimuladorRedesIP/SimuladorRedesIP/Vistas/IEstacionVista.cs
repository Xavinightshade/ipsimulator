using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Vistas
{
	public interface IEstacionVista
	{
		IDispositivoVista CrearDispositivo();
		event EventHandler<EventDispositivoVistaArgs> DispositivoEliminado;
		event EventHandler<EventDispositivoVistaArgs> DispositivoDesAsociado;
		event EventHandler CreacionDispositivo;

	}
	public class EventDispositivoVistaArgs:EventArgs
	{
		private IDispositivoVista _dispositivoVista;
		public IDispositivoVista DispositivoVista
		{
			get { return _dispositivoVista; }
		}
	
		public EventDispositivoVistaArgs(IDispositivoVista vista)
		{
			_dispositivoVista = vista;
		}
	}
}
