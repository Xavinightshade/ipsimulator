using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos;
using RedesIP.Presenters;
using System.Collections.ObjectModel;

namespace RedesIP.Remoting
{
	public class RemoteServerObject:MarshalByRefObject
	{
		private List<IDispositivoModelo> _listaEquipos=new List<IDispositivoModelo>();
		public event EventHandler<EventDispositivoArgs> DispositivoCreado;
		public event EventHandler<EventDispositivoArgs> DispositivoEliminado;
		
	
		public RemoteServerObject()
		{
			Console.WriteLine("nuevo objeto remoto");
		}

		public IDispositivoModelo CrearDispositivo()
		{
			return CrearDispositivo(0, 0);
		}
		
		public IDispositivoModelo CrearDispositivo(int x, int y)
		{
			IDispositivoModelo dispositivo = new DispositivoModelo(x,y);
			_listaEquipos.Add(dispositivo);
			return dispositivo;
		}
		public ReadOnlyCollection<IDispositivoModelo> DispositivosActuales
		{
			get { return _listaEquipos.AsReadOnly(); }
		}
		private void OnDispositivoEliminado(IDispositivoModelo dispositivo)
		{
			if (DispositivoEliminado != null)
			{
				DispositivoEliminado(this, new EventDispositivoArgs(dispositivo));
			}
		}
		private void OnDispositivoCreado(IDispositivoModelo dispositivo)
		{
			if (DispositivoCreado!=null)
			{
				DispositivoCreado(this, new EventDispositivoArgs(dispositivo));
			}

		}


	}
	[Serializable]
	public class EventDispositivoArgs:EventArgs
	{
		private IDispositivoModelo _dispositivo;
		public IDispositivoModelo Dispositivo
		{
			get { return _dispositivo; }
		}
	
		public EventDispositivoArgs(IDispositivoModelo dispositivo)
		{
			_dispositivo = dispositivo;
		}
	}
}
