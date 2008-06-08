using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Vistas
{
	public struct  Punto
	{
		int _x;

		public int X
		{
			get { return _x; }
		}
		int _y;

		public int Y
		{
			get { return _y; }
		}
		public Punto(int x,int y)
		{
			_x = x;
			_y = y;
		}
	}
}
