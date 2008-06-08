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
		List<SwitchView> _switches = new List<SwitchView>();
		List<PuertoEthernetView> _puertos = new List<PuertoEthernetView>();
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
			for (int i = 0; i < _puertos.Count; i++)
			{
				_puertos[i].DibujarElemento(g);
			}
			base.OnPaint(pe);
		}


	}
}
