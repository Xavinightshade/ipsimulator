using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Vistas
{
	public class Rectangulo
	{
		private int _origenX;

		public int OrigenX
		{
			get { return _origenX; }
			 set { _origenX = value; }
		}
		private int _origenY;

		public int OrigenY
		{
			get { return _origenY; }
			 set { _origenY = value; }
		}
		private int _alto;

		public int Alto
		{
			get { return _alto; }
		}
		private int _ancho;

		public int Ancho
		{
			get { return _ancho; }
		}
		public Punto Centro
		{
			get { return new Punto(_origenX + _ancho / 2, _origenY + _alto / 2); }
		}
		public Rectangulo(int origenX, int origenY, int ancho, int alto)
		{

			_origenX = origenX;
			_origenY = origenY;
			_ancho = ancho;
			_alto = alto;
		}
	}
}
