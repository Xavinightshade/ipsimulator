using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.Vistas.Equipos;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RedesIP.Vistas
{
	public class CableView:ElementoGrafico
	{
		private PuertoEthernetViewBase _puerto1;

		public PuertoEthernetViewBase Puerto1
		{
			get { return _puerto1; }
		}
		private PuertoEthernetViewBase _puerto2;

		public PuertoEthernetViewBase Puerto2
		{
			get { return _puerto2; }
		}
		public Punto PosicionMundoPuerto1
		{
			get { return new Punto(_puerto1.DimensionMundo.Centro.X, _puerto1.DimensionMundo.Centro.Y); }
		}
		public Punto PosicionMundoPuerto2
		{
			get { return new Punto(_puerto2.DimensionMundo.Centro.X, _puerto2.DimensionMundo.Centro.Y); }
		}
		private bool _seleccionado;

		public bool Seleccionado
		{
			get { return _seleccionado; }
			set { _seleccionado = value;
			if (_seleccionado)
			{
				_anchoPen = 3;
			}
			else
			{
				_anchoPen = 1;
			}
			}
		}


		public CableView(Guid id,PuertoEthernetViewBase puerto1,PuertoEthernetViewBase puerto2)
			:base(id)
		{
 
			_puerto1 = puerto1;
			_puerto2 = puerto2;
			_puerto1.Conectado = true;
			_puerto2.Conectado = true;
		}
		float _anchoPen = 1;
		public override void DibujarElemento(System.Drawing.Graphics grafico)
		{
			Pen p=new Pen(Brushes.Yellow,_anchoPen);
			grafico.DrawLine(p,
				PosicionMundoPuerto1.X,
				PosicionMundoPuerto1.Y,
				PosicionMundoPuerto2.X,
				PosicionMundoPuerto2.Y);
			p.Dispose();

		}
		public override bool HitTest(int x, int y)
		{
			Pen p = new Pen(Color.Black, _anchoPen+3);
			GraphicsPath pth = new GraphicsPath();
			pth.AddLine(_puerto1.DimensionMundo.Centro.X, _puerto1.DimensionMundo.Centro.Y, _puerto2.DimensionMundo.Centro.X, _puerto2.DimensionMundo.Centro.Y);
			pth.Widen(p);
			p.Dispose();
			if (pth.IsVisible(x, y))
			{
				pth.Dispose();
				return true;
			}
			pth.Dispose();
			return false;
		}
	}
}
