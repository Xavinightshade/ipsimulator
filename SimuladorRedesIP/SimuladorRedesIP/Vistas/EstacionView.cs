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
		List<PuertoEthernetView> _puertos = new List<PuertoEthernetView>();
		List<ComputadorView> _computadores = new List<ComputadorView>();
		List<SwitchView> _switches = new List<SwitchView>();
		List<Conexion> _conexiones = new List<Conexion>();
		public void InsertarComputador(int origenX, int origenY)
		{

			ComputadorView computador = new ComputadorView(origenX, origenY);
			computador.EstablecerContenedor(this);
			_computadores.Add(computador);
			_puertos.Add(computador.Puerto);
		}
		public void InsertarSwitch(int origenX, int origenY)
		{
			SwitchView swi = new SwitchView(origenX, origenY);
			swi.EstablecerContenedor(this);
			_switches.Add(swi);
			foreach (PuertoEthernetView puerto in swi.PuertosEthernet)
			{
				_puertos.Add(puerto);
			}


		}
		private PuertoEthernetView _puerto1;
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			switch (_herramientaActual)
			{

				case Herramienta.CreacionEquipos:
					Cursor = Cursors.Cross;
					break;
				case Herramienta.Conectar:
					Cursor = Cursors.Cross;
					for (int i = 0; i < _puertos.Count; i++)
					{
						if (_puertos[i].HitTest(e.X, e.Y))
						{

							_puertos[i].Seleccionado = true;


						}
						else
						{
							if (_puertos[i]!=_puerto1)
							_puertos[i].Seleccionado = false;
						}
						Invalidate();

					}
					break;


				default:
					Cursor = Cursors.Default;
					break;
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
			for (int i = 0; i < _conexiones.Count; i++)
			{
				_conexiones[i].DibujarElemento(g);
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
			if (_herramientaActual == Herramienta.Conectar)
			{
				for (int i = 0; i < _puertos.Count; i++)
				{
					if (_puertos[i].HitTest(e.X, e.Y))
					{
						if (_puerto1 == null)
						{
							_puertos[i].Seleccionado = true;
							_puerto1 = _puertos[i];
							Invalidate();
						}
						else
						{
							_conexiones.Add(new Conexion(_puerto1, _puertos[i]));
							_puerto1=null;							
						}
						break;
					}
				}

			}
			

		}


		public void CambiarHerramienta(Herramienta herramienta)
		{
			_herramientaActual = herramienta;
		}
	}
}
