using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Modelos.Visualizacion
{
	public interface IMovible
	{
		 event EventHandler CambioEnPosicion;
		int OrigenX { get; }
		int OrigenY { get; }
	}
}
