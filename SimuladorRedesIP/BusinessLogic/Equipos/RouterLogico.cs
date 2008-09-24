using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Common;
using RedesIP.SOA;
using BusinessLogic.OSI;
using BusinessLogic.Protocolos;

namespace RedesIP.Modelos.Logicos.Equipos
{
	public class RouterLogico:EquipoLogico
	{
        public static RouterSOA CrearRouterSOA(RouterLogico routerLogico)
        {
            RouterSOA rouRespuesta = new RouterSOA(routerLogico.TipoDeEquipo, routerLogico.Id, routerLogico.X, routerLogico.Y,routerLogico.Nombre);
            foreach (PuertoEthernetCompleto puerto in routerLogico.PuertosEthernet)
            {
                rouRespuesta.AgregarPuerto(new PuertoCompletoSOA(puerto.Id, puerto.MACAddress,puerto.Nombre,puerto.IPAddress));
            }
            return rouRespuesta;
        }


        private List<PuertoEthernetCompleto> _puertosEthernet = new List<PuertoEthernetCompleto>();

        public List<PuertoEthernetCompleto> PuertosEthernet
        {
            get { return _puertosEthernet; }
        }

		public RouterLogico(Guid id,int X,int Y,string nombre):base(id,TipoDeEquipo.Router,X,Y,nombre)
		{
			
		}


        public override void AgregarPuerto(Guid idPuerto,string nombre)
        {
            _puertosEthernet.Add(new PuertoEthernetCompleto(MACAddressFactory.NewMAC(), idPuerto,nombre));

        }
        private Dictionary<PuertoEthernetCompleto, CapaDatos> _puertoEthernetCapaDatos = new Dictionary<PuertoEthernetCompleto, CapaDatos>();
        public override void InicializarEquipo()
        {
            foreach (PuertoEthernetCompleto puerto in _puertosEthernet)
            {
                _puertoEthernetCapaDatos.Add(puerto, new CapaDatos(new ARP(), puerto));
            }
        }
    }
}
