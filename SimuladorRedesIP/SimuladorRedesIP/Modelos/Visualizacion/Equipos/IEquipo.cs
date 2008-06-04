using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.ModelosVisualizacion.Equipos
{
	public interface IEquipo
	{
		int OrigenX { get;}
		int OrigenY { get;}
		void CambiarPosicion(int deltaEnX, int deltaEnY);
		event EventHandler CambioEnPosicion;
	}
}
