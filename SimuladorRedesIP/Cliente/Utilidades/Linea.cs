using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Vistas.Utilidades
{
	public class Linea
	{
		private int _x1;

		public int X1
		{
			get { return _x1; }
			set
			{
				_x1 = value;
				OnCambioPosicion();
			}
		}
		private int _y1;

		public int Y1
		{
			get { return _y1; }
			set
			{
				_y1 = value;
				OnCambioPosicion();
			}
		}
		private int _x2;

		public int X2
		{
			get { return _x2; }
			set
			{
				_x2 = value;
				OnCambioPosicion();
			}
		}
		private int _y2;

		public int Y2
		{
			get { return _y2; }
			set
			{
				_y2 = value;
				OnCambioPosicion();
			}
		}
		public Linea(int x1, int y1, int x2, int y2)
		{
			_x1 = x1; _y1 = y1; _x2 = x2; _y2 = y2;
		}

		public event EventHandler CambioDePosicion;

		private void OnCambioPosicion()
		{
			if (CambioDePosicion != null)
				CambioDePosicion(this, new EventArgs());
		}
	}
}
