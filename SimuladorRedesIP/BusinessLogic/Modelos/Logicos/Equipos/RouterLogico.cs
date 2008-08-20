using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Common;

namespace RedesIP.Modelos.Logicos.Equipos
{
	public class RouterLogico:EquipoLogico
	{
        private List<PuertoEthernetLogicoBase> _puertosEthernet = new List<PuertoEthernetLogicoBase>();

		public RouterLogico(Guid id,int X,int Y):base(id,TipoDeEquipo.Router,X,Y)
		{
			
		}

		public override System.Collections.ObjectModel.ReadOnlyCollection<RedesIP.Modelos.Equipos.Componentes.PuertoEthernetLogicoBase> PuertosEthernet
		{
            get { return _puertosEthernet.AsReadOnly(); }
		}
        public override void AgregarPuerto(Guid idPuerto)
        {
            _puertosEthernet.Add(new PuertoEthernetLogicoBase(MACAddressFactory.NewMAC(), idPuerto));

        }

        public override void InicializarEquipo()
        {
            //throw new NotImplementedException();
        }
    }
}
