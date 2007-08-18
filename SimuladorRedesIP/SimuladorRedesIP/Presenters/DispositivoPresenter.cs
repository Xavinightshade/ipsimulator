using System;
using System.Collections.Generic;
using System.Text;
using RedesIp.Vistas;
using RedesIp.Modelos;

namespace RedesIp.Presenters
{
	public class DispositivoPresenter
	{
		private List<IDispositivoVista> _listaDispositivosVistas=new List<IDispositivoVista>();
		private IDispositivoModelo _dispositivoModelo;
		public DispositivoPresenter(IDispositivoModelo dispositivoModelo,IDispositivoVista dispositivoVista)
		{
			_dispositivoModelo = dispositivoModelo;
			_listaDispositivosVistas.Add(dispositivoVista);
			RegistrarModelo();
			RegistrarVistas(_listaDispositivosVistas);
		}
		public DispositivoPresenter(IDispositivoModelo dispositivoModelo)
		{
			_dispositivoModelo = dispositivoModelo;
			RegistrarModelo();
		}
		public DispositivoPresenter(IDispositivoModelo dispositivoModelo, IList<IDispositivoVista> listaDispositivosVistas)
			: this(dispositivoModelo)
		{
			_listaDispositivosVistas.AddRange(listaDispositivosVistas);
			RegistrarVistas(_listaDispositivosVistas);
		}

		public void AgregarVista(IDispositivoVista dispositivoVista)
		{
			_listaDispositivosVistas.Add(dispositivoVista);
			RegistrarVista(dispositivoVista);
		}

		private void RegistrarModelo()
		{
			_dispositivoModelo.CambioEnModelo += new EventHandler(HandlerCambioEnModelo);
		}

	

		private void RegistrarVista(IDispositivoVista dispositivoVista)
		{
			dispositivoVista.CambioEnPosicion += new EventHandler<EventPosicionArgs>(HandlerCambioEnPosicionVista);
		}



		private void RegistrarVistas(IList<IDispositivoVista> listaDispositivosVistas)
		{
			foreach (IDispositivoVista vista in listaDispositivosVistas)
			{
				RegistrarVista(vista);
			}
		}

		private void HandlerCambioEnModelo(object sender, EventArgs e)
		{
			foreach (IDispositivoVista vista in _listaDispositivosVistas)
			{
				vista.OrigenX = _dispositivoModelo.OrigenX;
				vista.OrigenY = _dispositivoModelo.OrigenY;
			}
		}


		private void HandlerCambioEnPosicionVista(object sender, EventPosicionArgs e)
		{
			IDispositivoVista vistaQueCambio = (IDispositivoVista)sender;
			_dispositivoModelo.CambiarPosicion(e.DeltaEnX, e.DeltaEnY);
		}
	}
}
