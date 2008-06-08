using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using RedesIP.Vistas.Utilidades;
using RedesIP.Vistas.Equipos;
using RedesIP.Vistas.Equipos.Componentes;

namespace RedesIP.Vistas
{
	public class EstacionView : PictureBox,IRegistroMovimientosMouse
	{

		List<ComputadorView> _computadores = new List<ComputadorView>();
		List<PuertoEthernetView> _puertos = new List<PuertoEthernetView>();
		public void InsertarComputador(int origenX, int origenY)
		{

			ComputadorView computador = new ComputadorView(origenX, origenY);
			computador.EstablecerContenedor(this);
			_computadores.Add(computador);
			_puertos.Add(computador.Puerto);
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			for (int i = 0; i < _computadores.Count; i++)
			{
				_computadores[i].DibujarElemento(pe.Graphics);
			}
			for (int i = 0; i < _puertos.Count; i++)
			{
				_puertos[i].DibujarElemento(pe.Graphics);
			}
			base.OnPaint(pe);
		}


	}
}
