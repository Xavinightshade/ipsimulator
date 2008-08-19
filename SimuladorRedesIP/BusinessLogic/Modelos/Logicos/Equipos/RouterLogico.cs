using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Common;

namespace RedesIP.Modelos.Logicos.Equipos
{
	public class RouterLogico:EquipoLogico
	{
        private List<PuertoEthernetLogico> _puertosEthernet = new List<PuertoEthernetLogico>();

		public RouterLogico(Guid id,int X,int Y):base(id,TipoDeEquipo.Router,X,Y)
		{
			
		}

		public override System.Collections.ObjectModel.ReadOnlyCollection<RedesIP.Modelos.Equipos.Componentes.PuertoEthernetLogico> PuertosEthernet
		{
            get { return _puertosEthernet.AsReadOnly(); }
		}
        public override void AgregarPuerto(Guid idPuerto)
        {
            _puertosEthernet.Add(new PuertoEthernetLogico(MACAddressFactory.NewMAC(), idPuerto));

        }

        public override void InicializarEquipo()
        {
            //throw new NotImplementedException();
        }
    }
}
