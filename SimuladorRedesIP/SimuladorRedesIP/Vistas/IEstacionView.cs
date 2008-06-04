using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Utilidades;

namespace RedesIP.Vistas
{
	public interface IEstacionView
	{
		IEquipoView CrearDispositivo();
		event EventHandler<EventDispositivoVistaArgs> DispositivoEliminado;
		event EventHandler<EventDispositivoVistaArgs> DispositivoDesAsociado;
		event EventHandler<EventNuevoDispositivoVistaArgs> CreacionDispositivo;
		void RefrescarConexiones();
		Linea CrearLinea(int x1, int y1, int x2, int y2);

	}
	public class EventDispositivoVistaArgs:EventArgs
	{
		private IEquipoView _dispositivoVista;
		public IEquipoView DispositivoVista
		{
			get { return _dispositivoVista; }
		}
	
		public EventDispositivoVistaArgs(IEquipoView vista)
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