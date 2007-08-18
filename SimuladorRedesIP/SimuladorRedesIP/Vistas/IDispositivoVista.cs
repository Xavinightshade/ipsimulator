using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIp.Vistas
{

	

	public interface IDispositivoVista
	{
		int OrigenX { get;set;}
		int OrigenY { get;set;}
		event EventHandler<EventPosicionArgs> CambioEnPosicion;
	}


	public class EventPosicionArgs:EventArgs
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

		public EventPosicionArgs(int deltaEnX,int deltaEnY)
		{
			_deltaEnX = deltaEnX;
			_deltaEnY = deltaEnY;
		}
	}

	

}
