using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas;
using RedesIP.Modelos.Visualizacion.Equipos;
using RedesIP.Vistas.Equipos;

namespace RedesIP.Presenters
{
	public class EquipoPresenter
	{
        private List<EquipoView> _listaDispositivosVistas = new List<EquipoView>();
        private Equipo _dispositivoModelo;	

		#region Constructores
        public EquipoPresenter(Equipo dispositivoModelo, EquipoView dispositivoVista)
		{
			_dispositivoModelo = dispositivoModelo;
			_listaDispositivosVistas.Add(dispositivoVista);

		}
		  public void Inicializar()
	{
		RegistrarModelo();
		RegistrarVistas(_listaDispositivosVistas);
		EstablecerValoresEnVista();
	}

		private void EstablecerValoresEnVista()
		{
            foreach (EquipoView vista in _listaDispositivosVistas)
			{
				vista.OrigenX = _dispositivoModelo.OrigenX;
				vista.OrigenY = _dispositivoModelo.OrigenY;
			}
		}
		public EquipoPresenter(Equipo dispositivoModelo)
		{
			_dispositivoModelo = dispositivoModelo;
			RegistrarModelo();
		}
        public EquipoPresenter(Equipo dispositivoModelo, IList<EquipoView> listaDispositivosVistas)
			: this(dispositivoModelo)
		{
			_listaDispositivosVistas.AddRange(listaDispositivosVistas);
			RegistrarVistas(_listaDispositivosVistas);
		} 
		#endregion

        public void AgregarVista(EquipoView dispositivoVista)
		{
			_listaDispositivosVistas.Add(dispositivoVista);
			RegistrarVista(dispositivoVista);
		}

        public void EliminarVista(EquipoView dispositivoVista)
		{
			dispositivoVista.CambioEnPosicion -= new EventHandler<EventCambioEnPosicionArgs>(HandlerCambioEnPosicionVista);
			_listaDispositivosVistas.Remove(dispositivoVista);
		}
		public void EliminarVistasActuales()
		{
            foreach (EquipoView vista in _listaDispositivosVistas)
			{
				vista.CambioEnPosicion -= new EventHandler<EventCambioEnPosicionArgs>(HandlerCambioEnPosicionVista);

			}
		}

		private void RegistrarModelo()
		{
			_dispositivoModelo.CambioEnPosicion += new EventHandler(HandlerCambioEnModelo);
		}

        private void RegistrarVista(EquipoView dispositivoVista)
		{
			dispositivoVista.CambioEnPosicion += new EventHandler<EventCambioEnPosicionArgs>(HandlerCambioEnPosicionVista);
		}

        private void RegistrarVistas(IList<EquipoView> listaDispositivosVistas)
		{
            foreach (EquipoView vista in listaDispositivosVistas)
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
            EquipoView vistaQueCambio = (EquipoView)sender;
			_dispositivoModelo.CambiarPosicion(e.DeltaEnX, e.DeltaEnY);
		} 
		#endregion
	}
}
