using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Equipos.Componentes;

namespace RedesIP.Modelos.Visualizacion.Equipos
{
	public abstract class Equipo:ComponenteMovible
	{
		public abstract Guid Id { get;  }
		public abstract ReadOnlyCollection<PuertoEthernetLogico> PuertosEthernet { get; }



		public Equipo(int posicionX, int posicionY):base(posicionX,posicionY)
		{

		}



	}
}
