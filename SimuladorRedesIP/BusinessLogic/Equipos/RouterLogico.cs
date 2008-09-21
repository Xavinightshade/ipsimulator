using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Common;
using RedesIP.SOA;

namespace RedesIP.Modelos.Logicos.Equipos
{
	public class RouterLogico:EquipoLogico
	{
        public static RouterSOA CrearRouterSOA(RouterLogico routerLogico)
        {
            RouterSOA rouRespuesta = new RouterSOA(routerLogico.TipoDeEquipo, routerLogico.Id, routerLogico.X, routerLogico.Y);
            foreach (PuertoEthernetCompleto puerto in routerLogico.PuertosEthernet)
            {
                rouRespuesta.AgregarPuerto(new PuertoCompletoSOA(puerto.Id, puerto.MACAddress,puerto.Nombre,puerto.IPAddress));
            }
            return rouRespuesta;
        }


        private List<PuertoEthernetLogicoBase> _puertosEthernet = new List<PuertoEthernetLogicoBase>();

		public RouterLogico(Guid id,int X,int Y):base(id,TipoDeEquipo.Router,X,Y)
		{
			
		}

		public override System.Collections.ObjectModel.ReadOnlyCollection<RedesIP.Modelos.Equipos.Componentes.PuertoEthernetLogicoBase> PuertosEthernet
		{
            get { return _puertosEthernet.AsReadOnly(); }
		}
        public override void AgregarPuerto(Guid idPuerto,string nombre)
        {
            _puertosEthernet.Add(new PuertoEthernetCompleto(MACAddressFactory.NewMAC(), idPuerto,nombre));

        }

        public override void InicializarEquipo()
        {
            //throw new NotImplementedException();
        }
    }
}
