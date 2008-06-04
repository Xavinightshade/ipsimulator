using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Visualizacion.Equipos;
using RedesIP.Vistas.Equipos;

namespace RedesIP.Presenters
{
	public class ComputadorPresenter
	{
		private Computador _modeloComputador;
		private ComputadorView _vistaComputador;
		public ComputadorPresenter(Computador modeloComputador,ComputadorView vistaComputador)
		{
			_modeloComputador = modeloComputador;
			_vistaComputador = vistaComputador;
		}
		public void Inicializar()
		{
			EquipoPresenter equipoPresenter = new EquipoPresenter(_modeloComputador, _vistaComputador);
			equipoPresenter.Inicializar();
		}
	}
}
