using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIp.Modelos
{
	public class DispositivoModelo:IDispositivoModelo
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



	}
}
