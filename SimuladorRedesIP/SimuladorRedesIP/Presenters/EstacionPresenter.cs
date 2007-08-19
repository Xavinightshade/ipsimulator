using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos;
using RedesIP.Vistas;

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
			_estacionModelo.DispositivoCreado += new EventHandler<EventDispositivoArgs>(HandlerDispositivoModeloCreado);
			_estacionVista.CreacionDispositivo += new EventHandler<EventNuevoDispositivoVistaArgs>(HandlerCrearDispositivoVista);
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
		}

	}
}