using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace RedesIP.Modelos
{
	public class EstacionModelo:MarshalByRefObject,IEnumerable<IDispositivoModelo>,IEstacionModelo
	{
		public event EventHandler<EventDispositivoArgs> DispositivoCreado;
		public event EventHandler<EventDispositivoArgs> DispositivoEliminado;


		private List<IDispositivoModelo> _listaDispositivos = new List<IDispositivoModelo>();

		public EstacionModelo()
		{

		}

		public void CrearDispositivo()
		{
			CrearDispositivo(0, 0);
		}

		public void CrearDispositivo(int x, int y)
		{
			IDispositivoModelo dispositivo = new DispositivoModelo(x, y);
			_listaDispositivos.Add(dispositivo);
			OnDispositivoCreado(dispositivo);
		}
		public ReadOnlyCollection<IDispositivoModelo> DispositivosActuales
		{
			get { return _listaDispositivos.AsReadOnly(); }
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
			if (DispositivoCreado != null)
			{
				DispositivoCreado(this, new EventDispositivoArgs(dispositivo));
			}

		}


		#region IEnumerable<IDispositivoModelo> Members

		public IEnumerator<IDispositivoModelo> GetEnumerator()
		{
			return _listaDispositivos.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return _listaDispositivos.GetEnumerator();
		}

		#endregion
	}



	[Serializable]
	public class EventDispositivoArgs : EventArgs
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
