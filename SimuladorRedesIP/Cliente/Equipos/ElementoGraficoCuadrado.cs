using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RedesIP.Vistas.Equipos
{
	public abstract class ElementoGraficoCuadrado : ElementoGrafico
	{


		private Rectangulo _dimension;

		public Rectangulo Dimension
		{
			get { return _dimension; }
		}
		public Rectangulo DimensionMundo
		{
			get { return CalcularDimensionMundo(); }
		}

		private Rectangulo CalcularDimensionMundo()
		{
			int origenXMundo = 0;
			int origenYMundo = 0;
			if (_elementoPadre != null)
			{
				origenXMundo = _elementoPadre.Dimension.OrigenX;
				origenYMundo = _elementoPadre.Dimension.OrigenY;
			}

			return new Rectangulo(origenXMundo+ _dimension.OrigenX,origenYMundo + _dimension.OrigenY, _dimension.Ancho, _dimension.Alto);
		}

		private ElementoGraficoCuadrado _elementoPadre;

		public ElementoGraficoCuadrado ElementoPadre
		{
			get { return _elementoPadre; }
			set { _elementoPadre = value; }
		}
		public ElementoGraficoCuadrado(Guid id,int origenX,int origenY,int ancho,int alto)
			:base(id)
		{

			_dimension = new Rectangulo(origenX, origenY, ancho, alto);
		}
		public override bool HitTest(int x, int y)
		{

			bool estaEntreX = (DimensionMundo.OrigenX < x) && (x < DimensionMundo.OrigenX + _dimension.Ancho);
			if (!estaEntreX)
				return false;
			return (DimensionMundo.OrigenY < y) && (y < DimensionMundo.OrigenY + _dimension.Alto);
		}
	}
}
