using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RedesIP.Vistas.Equipos.Componentes
{
	public class PuertoEthernetView:ElementoGraficoCuadrado
	{
		private bool _seleccionado;
		private bool _conectado;

		public bool Conectado
		{
			get { return _conectado; }
			set { _conectado = value; }
		}

		public bool Seleccionado
		{
			get { return _seleccionado; }
			set { _seleccionado = value; }
		}
		public PuertoEthernetView(Guid id,int origenX,int origenY,EquipoView equipoPadre)
			: base(id,origenX,origenY, 10, 10)
		{
			ElementoPadre = equipoPadre;
		}
		public override void DibujarElemento(System.Drawing.Graphics grafico)
		{
			Brush brush = Brushes.Black;
			if (_seleccionado)
			{
				brush = Brushes.GreenYellow;
			}
			if (_conectado)
			{
				brush = Brushes.Orange;
			}
			grafico.FillRectangle(brush, DimensionMundo.OrigenX, DimensionMundo.OrigenY, Dimension.Ancho, Dimension.Alto);
			Pen p = new Pen(Color.White);
			grafico.DrawRectangle(p, DimensionMundo.OrigenX, DimensionMundo.OrigenY, Dimension.Ancho, Dimension.Alto);
		//	brush.Dispose();
			p.Dispose();
		}


	}
}
