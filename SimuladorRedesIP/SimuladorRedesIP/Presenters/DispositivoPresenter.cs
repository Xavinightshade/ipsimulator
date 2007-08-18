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
		}
		public DispositivoPresenter(IDispositivoModelo dispositivoModelo)
		{
			_dispositivoModelo = dispositivoModelo;
		}
		public DispositivoPresenter(IDispositivoModelo dispositivoModelo, IList<IDispositivoVista> listaDispositivosVistas)
			: this(dispositivoModelo)
		{
			_listaDispositivosVistas.AddRange(listaDispositivosVistas);
		}

		public void AgregarVista(IDispositivoVista dispositivoVista)
		{
			_listaDispositivosVistas.Add(dispositivoVista);
		}

	}
}
