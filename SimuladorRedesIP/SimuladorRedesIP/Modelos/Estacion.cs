using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Equipos;

namespace RedesIP.Modelos
{
	public class Estacion:IEnumerable<IEquipo>,IEstacion
	{
		public event EventHandler<EventDispositivoArgs> DispositivoCreado;
		public event EventHandler<EventDispositivoArgs> DispositivoEliminado;
		public event EventHandler<EventNuevaConexionArgs> NuevaConexion;


        private List<IEquipo> _listaDispositivos = new List<IEquipo>();

		public Estacion()
		{

		}

		public void Conectar(int a, int b)
		{
			CrearConexion(_listaDispositivos[a], _listaDispositivos[b]);
		}
        public void CrearConexion(IEquipo dispositivo1, IEquipo dispositivo2)
		{
			Conexion conexion = new Conexion(dispositivo1, dispositivo2);
			OnConexionCreada(conexion);
		
		}

		public void CrearDispositivo()
		{
			CrearDispositivo(0, 0);
		}

		public void CrearDispositivo(int x, int y)
		{
            IEquipo dispositivo = new Equipo(x, y);
			_listaDispositivos.Add(dispositivo);
			OnDispositivoCreado(dispositivo);
		}
        public ReadOnlyCollection<IEquipo> DispositivosActuales
		{
			get { return _listaDispositivos.AsReadOnly(); }
		}
        private void OnDispositivoEliminado(IEquipo dispositivo)
		{
			if (DispositivoEliminado != null)
			{
				DispositivoEliminado(this, new EventDispositivoArgs(dispositivo));
			}
		}
        private void OnDispositivoCreado(IEquipo dispositivo)
		{
			if (DispositivoCreado != null)
			{
				DispositivoCreado(this, new EventDispositivoArgs(dispositivo));
			}

		}
		private void OnConexionCreada(Conexion conexion)
		{
			if (NuevaConexion != null)
			{
				NuevaConexion(this, new EventNuevaConexionArgs(conexion.Linea));
			}
		}


		#region IEnumerable<IDispositivoModelo> Members

        public IEnumerator<IEquipo> GetEnumerator()
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
        private IEquipo _dispositivo;
        public IEquipo Dispositivo
		{
			get { return _dispositivo; }
		}

        public EventDispositivoArgs(IEquipo dispositivo)
		{
			_dispositivo = dispositivo;
		}
	}
}
