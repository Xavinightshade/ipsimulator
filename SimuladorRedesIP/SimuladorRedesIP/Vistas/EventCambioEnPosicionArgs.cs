using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Vistas
{
	public class EventCambioEnPosicionArgs : EventArgs
	{
		private int _deltaEnX;
		public int DeltaEnX
		{
			get { return _deltaEnX; }
		}
		private int _deltaEnY;
		public int DeltaEnY
		{
			get { return _deltaEnY; }
		}

		public EventCambioEnPosicionArgs(int deltaEnX, int deltaEnY)
		{
			_deltaEnX = deltaEnX;
			_deltaEnY = deltaEnY;
		}
	}
}
