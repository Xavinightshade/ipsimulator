using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Visualizacion.Equipos;
using RedesIP.Modelos.Visualizacion;
using RedesIP.Modelos.Datos;

namespace RedesIP.ModelosVisualizacion
{
	public class Estacion : IEnumerable<Equipo>
	{
		public event EventHandler<EventEquipoArgs> DispositivoCreado;
		public event EventHandler<EventEquipoArgs> DispositivoEliminado;
		public event EventHandler<EventNuevaConexionArgs> NuevaConexion;


		private List<Equipo> _listaDispositivos = new List<Equipo>();

		public Estacion()
		{

		}

		public void Conectar(PuertoEthernet puerto1, PuertoEthernet puerto2)
		{

			CableDeRed conexion = new CableDeRed(puerto1, puerto2);
			OnConexionCreada(conexion);

		}

		public void CrearDispositivo()
		{
			CrearDispositivo(0, 0);
		}

		public void CrearDispositivo(int x, int y)
		{
			Equipo dispositivo = new Computador("hola", MACAddress.New(), x, y);
			_listaDispositivos.Add(dispositivo);
			OnDispositivoCreado(dispositivo);
		}
		public ReadOnlyCollection<Equipo> DispositivosActuales
		{
			get { return _listaDispositivos.AsReadOnly(); }
		}
		private void OnDispositivoEliminado(Equipo dispositivo)
		{
			if (DispositivoEliminado != null)
			{
				DispositivoEliminado(this, new EventEquipoArgs(dispositivo));
			}
		}
		private void OnDispositivoCreado(Equipo dispositivo)
		{
			if (DispositivoCreado != null)
			{
				DispositivoCreado(this, new EventEquipoArgs(dispositivo));
			}

		}
		private void OnConexionCreada(CableDeRed conexion)
		{
			if (NuevaConexion != null)
			{
				NuevaConexion(this, new EventNuevaConexionArgs(conexion.Linea));
			}
		}


		#region IEnumerable<IDispositivoModelo> Members

		public IEnumerator<Equipo> GetEnumerator()
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





}
