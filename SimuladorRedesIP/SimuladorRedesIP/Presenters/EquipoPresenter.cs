using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas;
using RedesIP.ModelosVisualizacion.Equipos;

namespace RedesIP.Presenters
{
	public class EquipoPresenter
	{
        private List<IEquipoView> _listaDispositivosVistas = new List<IEquipoView>();
        private IEquipo _dispositivoModelo;	

		#region Constructores
        public EquipoPresenter(IEquipo dispositivoModelo, IEquipoView dispositivoVista)
		{
			_dispositivoModelo = dispositivoModelo;
			_listaDispositivosVistas.Add(dispositivoVista);
			RegistrarModelo();
			RegistrarVistas(_listaDispositivosVistas);
			EstablecerValoresEnVista();
		}

		private void EstablecerValoresEnVista()
		{
            foreach (IEquipoView vista in _listaDispositivosVistas)
			{
				vista.OrigenX = _dispositivoModelo.OrigenX;
				vista.OrigenY = _dispositivoModelo.OrigenY;
			}
		}
		public EquipoPresenter(IEquipo dispositivoModelo)
		{
			_dispositivoModelo = dispositivoModelo;
			RegistrarModelo();
		}
        public EquipoPresenter(IEquipo dispositivoModelo, IList<IEquipoView> listaDispositivosVistas)
			: this(dispositivoModelo)
		{
			_listaDispositivosVistas.AddRange(listaDispositivosVistas);
			RegistrarVistas(_listaDispositivosVistas);
		} 
		#endregion

        public void AgregarVista(IEquipoView dispositivoVista)
		{
			_listaDispositivosVistas.Add(dispositivoVista);
			RegistrarVista(dispositivoVista);
		}

        public void EliminarVista(IEquipoView dispositivoVista)
		{
			dispositivoVista.CambioEnPosicion -= new EventHandler<EventCambioEnPosicionArgs>(HandlerCambioEnPosicionVista);
			_listaDispositivosVistas.Remove(dispositivoVista);
		}
		public void EliminarVistasActuales()
		{
            foreach (IEquipoView vista in _listaDispositivosVistas)
			{
				vista.CambioEnPosicion -= new EventHandler<EventCambioEnPosicionArgs>(HandlerCambioEnPosicionVista);

			}
		}

		private void RegistrarModelo()
		{
			_dispositivoModelo.CambioEnPosicion += new EventHandler(HandlerCambioEnModelo);
		}

        private void RegistrarVista(IEquipoView dispositivoVista)
		{
			dispositivoVista.CambioEnPosicion += new EventHandler<EventCambioEnPosicionArgs>(HandlerCambioEnPosicionVista);
		}

        private void RegistrarVistas(IList<IEquipoView> listaDispositivosVistas)
		{
            foreach (IEquipoView vista in listaDispositivosVistas)
			{
				RegistrarVista(vista);
			}
		}

		#region HandlerEventosVistaYModelos
		public void HandlerCambioEnModelo(object sender, EventArgs e)
		{
			EstablecerValoresEnVista();
		}
		private void HandlerCambioEnPosicionVista(object sender, EventCambioEnPosicionArgs e)
		{
            IEquipoView vistaQueCambio = (IEquipoView)sender;
			_dispositivoModelo.CambiarPosicion(e.DeltaEnX, e.DeltaEnY);
		} 
		#endregion
	}
}
