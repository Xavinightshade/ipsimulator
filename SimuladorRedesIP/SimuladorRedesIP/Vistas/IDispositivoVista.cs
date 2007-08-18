using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIp.Vistas
{




	public interface IDispositivoVista
	{
		int OrigenX { get;set;}
		int OrigenY { get;set;}
		event EventHandler CambioEnVista;
	}

	

}
