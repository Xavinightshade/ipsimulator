using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using System.Collections.ObjectModel;

namespace RedesIP.Modelos.Logicos.Equipos
{
	 public abstract class EquipoLogico
	{
		 public abstract Guid Id { get; }
		 public abstract ReadOnlyCollection<PuertoEthernetLogico> PuertosEthernet { get; }
	}
}
