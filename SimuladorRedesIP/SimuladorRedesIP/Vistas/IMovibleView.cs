using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Vistas
{

	

	public interface IMovibleView
	{
		int OrigenX { get;set;}
		int OrigenY { get;set;}
		event EventHandler<EventCambioEnPosicionArgs> CambioEnPosicion;
	}




	

}
