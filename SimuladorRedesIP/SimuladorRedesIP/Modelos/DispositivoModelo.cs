using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIp.Modelos
{
	public class DispositivoModelo:IDispositivoModelo
	{
		#region IDispositivoModelo Members
		private int _origenX;

		public int OrigenX
		{
			get { return _origenX; }
		}
	
		private int _origenY;

		public int OrigenY
		{
			get { return _origenY; }			
		}

		public DispositivoModelo(int posicionX,int posicionY)
		{
			_origenX = posicionX;
			_origenY = posicionY;
		}


		public event EventHandler CambioEnModelo;
		private void OnCambioEnModelo()
		{
			if (CambioEnModelo != null)
				CambioEnModelo(this, new EventArgs());
		}
		public void CambiarPosicion(int deltaEnX, int deltaEnY)
		{
			_origenX += deltaEnX;
			_origenY += deltaEnY;
			OnCambioEnModelo();
		}

		#endregion


	}
}
