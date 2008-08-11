using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Modelos.Logicos.Equipos
{
	class RouterLogico:EquipoLogico
	{
		private Guid _id;

		public override Guid Id
		{
			get { return _id; }
		}
		public RouterLogico(int X,int Y):base(TipoDeEquipo.Router,X,Y)
		{
			_id = Guid.NewGuid();
		}

		public override System.Collections.ObjectModel.ReadOnlyCollection<RedesIP.Modelos.Equipos.Componentes.PuertoEthernetLogico> PuertosEthernet
		{
			get { throw new NotImplementedException(); }
		}
	}
}
