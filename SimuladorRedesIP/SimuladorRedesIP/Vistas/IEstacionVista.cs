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
		event EventHandler<EventNuevoDispositivoVistaArgs> CreacionDispositivo;

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
	public class EventNuevoDispositivoVistaArgs : EventArgs
	{
		private int _x;
		public int X
		{
			get { return _x; }
		}
		private int _y;
		public int Y
		{
			get { return _y; }
		}
		public EventNuevoDispositivoVistaArgs(int x,int y)
		{
			_x = x;
			_y = y;
		}
	
	
	}
}
