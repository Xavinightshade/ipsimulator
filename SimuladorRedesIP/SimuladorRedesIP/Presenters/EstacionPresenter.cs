using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.ModelosLogicos;
using RedesIP.Vistas;
using RedesIP.Vistas.Utilidades;
using RedesIP.Modelos.Visualizacion.Equipos;
using RedesIP.ModelosVisualizacion;
using RedesIP.Modelos.Visualizacion;

namespace RedesIP.Presenters
{
	public class EstacionPresenter
	{
		private IEstacion _estacionModelo;
		private IEstacionView _estacionVista;
		private List<EquipoPresenter> _listaPresenters = new List<EquipoPresenter>();
		private Dictionary<IEquipoView, EquipoPresenter> _dicVistaPresenters = new Dictionary<IEquipoView, EquipoPresenter>();
		public EstacionPresenter(IEstacion estacionModelo,IEstacionView estacionVista)
		{
			_estacionModelo = estacionModelo;
			_estacionVista = estacionVista;
			VistaInicial();
			_estacionModelo.DispositivoCreado += new EventHandler<EventEquipoArgs>(HandlerDispositivoModeloCreado);
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
            foreach (IEquipo modelo in _estacionModelo.DispositivosActuales)
			{
				EquipoPresenter presenter = new EquipoPresenter(modelo, _estacionVista.CrearDispositivo());
				presenter.Inicializar();
			}
		}

		private void HandlerCrearDispositivoVista(object sender, EventNuevoDispositivoVistaArgs e)
		{
			_estacionModelo.CrearDispositivo(e.X, e.Y);
		}

		public void HandlerDispositivoModeloCreado(object sender, EventEquipoArgs e)
		{
			IEquipoView dispositivoVista = _estacionVista.CrearDispositivo();
            IEquipo dispositivoModelo = e.Dispositivo;
			EquipoPresenter presenter = new EquipoPresenter(dispositivoModelo, dispositivoVista);
			presenter.Inicializar();
			dispositivoModelo.CambioEnPosicion += new EventHandler(dispositivoModelo_CambioEnPosicion);
		}

		public void dispositivoModelo_CambioEnPosicion(object sender, EventArgs e)
		{
			_estacionVista.RefrescarConexiones();
		}

	}
}
