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
		private Herramienta _herramientaActual;

		List<ComputadorView> _computadores = new List<ComputadorView>();
		List<SwitchView> _switches = new List<SwitchView>();
		public void InsertarComputador(int origenX, int origenY)
		{

			ComputadorView computador = new ComputadorView(origenX, origenY);
			computador.EstablecerContenedor(this);
			_computadores.Add(computador);
		}
		public void InsertarSwitch(int origenX, int origenY)
		{
			SwitchView swi = new SwitchView(origenX, origenY);
			swi.EstablecerContenedor(this);
			_switches.Add(swi);


		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (_herramientaActual==Herramienta.CreacionEquipos)
			{
				Cursor = Cursors.Cross;
			}
			else
			{
				Cursor = Cursors.Default;
			}
			
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			for (int i = 0; i < _computadores.Count; i++)
			{
				_computadores[i].DibujarElemento(g);
			}
			for (int i = 0; i < _switches.Count; i++)
			{
				_switches[i].DibujarElemento(g);
			}
			base.OnPaint(pe);
		}




		private TipoDeEquipo _tipoDeEquipo;
		public void CrearEquipo(TipoDeEquipo tipoDeEquipo)
		{
			_herramientaActual = Herramienta.CreacionEquipos;
			_tipoDeEquipo = tipoDeEquipo;
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (_herramientaActual == Herramienta.CreacionEquipos)
			{
				if (_tipoDeEquipo == TipoDeEquipo.Computador)
				{
					InsertarComputador(e.X, e.Y);
				}
				if (_tipoDeEquipo == TipoDeEquipo.Switch)
				{
					InsertarSwitch(e.X, e.Y);
				}
				Invalidate();
				_herramientaActual =Herramienta.Seleccion;
			}
			

		}


		public void CambiarHerramientaNada()
		{
			_herramientaActual = Herramienta.Seleccion;
		}
	}
}
