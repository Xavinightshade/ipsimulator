using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Modelos.Equipos
{
	public class Equipo:IEquipo
	{
		#region IDispositivoModelo Members
		private int _origenX;

		public int OrigenX
		{
			get { return _origenX; }
			set { _origenX = value;
			OnCambioEnModelo();
			}
		}
	
		private int _origenY;

		public int OrigenY
		{
			get { return _origenY; }
			set{_origenY=value;
			OnCambioEnModelo();
			}			
		}

		public Equipo(int posicionX,int posicionY)
		{
			_origenX = posicionX;
			_origenY = posicionY;
		}


		public event EventHandler CambioEnPosicion;
		private void OnCambioEnModelo()
		{
			if (CambioEnPosicion != null)
				CambioEnPosicion(this, new EventArgs());
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
