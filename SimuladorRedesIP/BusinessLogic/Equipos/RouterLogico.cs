using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Common;
using RedesIP.SOA;
using BusinessLogic.OSI;
using BusinessLogic.Protocolos;
using BusinessLogic.Componentes;
using SOA.Componentes;
using BusinessLogic;

namespace RedesIP.Modelos.Logicos.Equipos
{
    public class RouterLogico : EquipoLogico
    {
        public static RouterSOA CrearRouterSOA(RouterLogico routerLogico)
        {
            RouterSOA rouRespuesta = new RouterSOA(routerLogico.TipoDeEquipo, routerLogico.Id, routerLogico.X, routerLogico.Y, routerLogico.Nombre);
            foreach (PuertoEthernetCompleto puerto in routerLogico.PuertosEthernet)
            {
                rouRespuesta.AgregarPuerto(new PuertoCompletoSOA(puerto.Id, puerto.MACAddress, puerto.Nombre, puerto.IPAddress, puerto.Mascara));
            }
            return rouRespuesta;
        }

        private RouteTable _tablaDeRutas = new RouteTable();

        public RouteTable TablaDeRutas
        {
            get { return _tablaDeRutas; }
        }
        private List<PuertoEthernetCompleto> _puertosEthernet = new List<PuertoEthernetCompleto>();

        public List<PuertoEthernetCompleto> PuertosEthernet
        {
            get { return _puertosEthernet; }
        }

        public RouterLogico(Guid id, int X, int Y, string nombre)
            : base(id, TipoDeEquipo.Router, X, Y, nombre)
        {

        }



        public void AgregarPuerto(Guid idPuerto, string nombre, string macAddress, string direccionIP, int? mask)
        {
            _puertosEthernet.Add(new PuertoEthernetCompleto(macAddress, idPuerto, nombre, mask, direccionIP));
        }
        private Dictionary<PuertoEthernetCompleto, CapaRedRouter> _puertoEthernetCapaRed = new Dictionary<PuertoEthernetCompleto, CapaRedRouter>();

        public Dictionary<PuertoEthernetCompleto, CapaRedRouter> PuertoEthernetCapaRed
        {
            get { return _puertoEthernetCapaRed; }
        }
        public override void InicializarEquipo()
        {
            foreach (PuertoEthernetCompleto puerto in _puertosEthernet)
            {
                CapaRedRouter capaRed = new CapaRedRouter(new CapaDatos(new ARP(),puerto), this);
                capaRed.Inicializar();
                _puertoEthernetCapaRed.Add(puerto, capaRed);
            }
        }
        public void CrearNuevaRuta(Guid idRuta, Guid idPuerto, uint red,int? mask, string nextHopIP)
        {
            foreach (PuertoEthernetCompleto puerto in _puertosEthernet)
            {
                if (puerto.Id == idPuerto)
                {
                    _tablaDeRutas.IngresarEntrada(idRuta, red,mask,nextHopIP,puerto);
                    return;
                }
            }
            throw new Exception();
        }

        internal List<RutaSOA> TraerRutas()
        {
            return _tablaDeRutas.GetRutas();
        }

        internal void ActualizarRutas(List<RutaSOA> rutas)
        {
            _tablaDeRutas.LimpiarRutas();
            Dictionary<Guid, PuertoEthernetCompleto> puertos = new Dictionary<Guid, PuertoEthernetCompleto>();
            foreach (PuertoEthernetCompleto puerto in _puertosEthernet)
            {
                puertos.Add(puerto.Id, puerto);
            }
            foreach (RutaSOA ruta in rutas)
            {
                _tablaDeRutas.IngresarEntrada(ruta.Id, IPAddressFactory.GetValor(ruta.Red),ruta.Mask,ruta.NextHopIP, puertos[ruta.IdPuerto]);
            }

        }

        public List<RutaSOA> TraerRutasRouter()
        {
            return CalcularRutasInternas();
        }

        private List<RutaSOA> CalcularRutasInternas()
        {
            List<RutaSOA> rutasInternas = new List<RutaSOA>();
            foreach (PuertoEthernetCompleto puerto in _puertosEthernet)
            {
                RutaSOA ruta = new RutaSOA(Guid.Empty);
                ruta.Mask = puerto.Mascara;
                ruta.NombrePuerto = puerto.Nombre;
                if (!puerto.Mascara.HasValue)
                    continue;
                ruta.Red=IPAddressFactory.GetRedRep(puerto.IPAddress,puerto.Mascara.Value);
                rutasInternas.Add(ruta);
            }            
            return rutasInternas;
        }
    }
}
