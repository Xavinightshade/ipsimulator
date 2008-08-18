using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Modelos.Logicos.Equipos
{
	class RouterLogico:EquipoLogico
	{

		public RouterLogico(Guid id,int X,int Y):base(id,TipoDeEquipo.Router,X,Y)
		{
			
		}

		public override System.Collections.ObjectModel.ReadOnlyCollection<RedesIP.Modelos.Equipos.Componentes.PuertoEthernetLogico> PuertosEthernet
		{
			get { throw new NotImplementedException(); }
		}
        public override void AgregarPuerto(Guid idPuerto)
        {
            throw new NotImplementedException();
        }

        public override void InicializarEquipo()
        {
            throw new NotImplementedException();
        }
    }
}
