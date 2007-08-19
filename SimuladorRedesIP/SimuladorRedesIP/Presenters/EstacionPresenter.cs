using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos;
using RedesIP.Vistas;
using RedesIP.Vistas.Utilidades;

namespace RedesIP.Presenters
{
	public class EstacionPresenter:MarshalByRefObject
	{
		private IEstacionModelo _estacionModelo;
		private IEstacionVista _estacionVista;
		private List<DispositivoPresenter> _listaPresenters = new List<DispositivoPresenter>();
		private Dictionary<IDispositivoVista, DispositivoPresenter> _dicVistaPresenters = new Dictionary<IDispositivoVista, DispositivoPresenter>();
		public EstacionPresenter(IEstacionModelo estacionModelo,IEstacionVista estacionVista)
		{
			_estacionModelo = estacionModelo;
			_estacionVista = estacionVista;
			VistaInicial();
			_estacionModelo.DispositivoCreado += new EventHandler<EventDispositivoArgs>(HandlerDispositivoModeloCreado);
			_estacionModelo.NuevaConexion += new EventHandler<EventNuevaConexionArgs>(HandlerNuevaConexion);
			_estacionVista.CreacionDispositivo += new EventHandler<EventNuevoDispositivoVistaArgs>(HandlerCrearDispositivoVista);
		}

		public void HandlerNuevaConexion(object sender, EventNuevaConexionArgs e)
		{
			Linea lineaModelo = e.Linea;
			Linea lineaVista = _estacionVista.CrearLinea(lineaModelo.X1,lineaModelo.Y1,lineaModelo.X2,lineaModelo.Y2);
			ConexionPresenter conexionPresenter = new ConexionPresenter(lineaModelo, lineaVista);
			_estacionVista.RefrescarConexiones();
		}

		private void VistaInicial()
		{
			foreach (IDispositivoModelo modelo in _estacionModelo.DispositivosActuales)
			{
				DispositivoPresenter presenter = new DispositivoPresenter(modelo, _estacionVista.CrearDispositivo());
			}
		}

		private void HandlerCrearDispositivoVista(object sender, EventNuevoDispositivoVistaArgs e)
		{
			_estacionModelo.CrearDispositivo(e.X, e.Y);
		}

		public void HandlerDispositivoModeloCreado(object sender, EventDispositivoArgs e)
		{
			IDispositivoVista dispositivoVista = _estacionVista.CrearDispositivo();
			IDispositivoModelo dispositivoModelo = e.Dispositivo;
			DispositivoPresenter presenter = new DispositivoPresenter(dispositivoModelo, dispositivoVista);
			dispositivoModelo.CambioEnPosicion += new EventHandler(dispositivoModelo_CambioEnPosicion);
		}

		public void dispositivoModelo_CambioEnPosicion(object sender, EventArgs e)
		{
			_estacionVista.RefrescarConexiones();
		}

	}
}
