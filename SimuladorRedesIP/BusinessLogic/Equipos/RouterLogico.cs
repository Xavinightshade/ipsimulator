using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Common;
using RedesIP.SOA;
using BusinessLogic.OSI;
using BusinessLogic.Protocolos;
using BusinessLogic.Componentes;

namespace RedesIP.Modelos.Logicos.Equipos
{
	public class RouterLogico:EquipoLogico
	{
        public static RouterSOA CrearRouterSOA(RouterLogico routerLogico)
        {
            RouterSOA rouRespuesta = new RouterSOA(routerLogico.TipoDeEquipo, routerLogico.Id, routerLogico.X, routerLogico.Y,routerLogico.Nombre);
            foreach (PuertoEthernetCompleto puerto in routerLogico.PuertosEthernet)
            {
                rouRespuesta.AgregarPuerto(new PuertoCompletoSOA(puerto.Id, puerto.MACAddress,puerto.Nombre,puerto.IPAddress,puerto.Mascara));
            }
            return rouRespuesta;
        }

        private RouteTable tablaDeRutas = new RouteTable();
        private List<PuertoEthernetCompleto> _puertosEthernet = new List<PuertoEthernetCompleto>();

        public List<PuertoEthernetCompleto> PuertosEthernet
        {
            get { return _puertosEthernet; }
        }

		public RouterLogico(Guid id,int X,int Y,string nombre):base(id,TipoDeEquipo.Router,X,Y,nombre)
		{
			
		}



        public void AgregarPuerto(Guid idPuerto, string nombre, string macAddress, string direccionIP,int? mask)
        {
            _puertosEthernet.Add(new PuertoEthernetCompleto(macAddress, idPuerto, nombre,mask,direccionIP));
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
