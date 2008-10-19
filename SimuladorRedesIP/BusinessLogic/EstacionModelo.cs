using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Modelos;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Modelos.Datos;
using RedesIP.Common;
using RedesIP.SOA;
using BusinessLogic.Modelos.Logicos.Datos;
using BusinessLogic.Sniffer;
using BusinessLogic.Threads;
using BusinessLogic.Equipos;

namespace RedesIP
{
    public class EstacionModelo
    {
        private byte[] _imagen;

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public byte[] Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        private Guid _id;

        public Guid Id
        {
            get { return _id; }
        }
        public EstacionModelo(Guid id)
        {
            _id = id;
        }

        public static int PorcentajeDeVelocidadSimulacion
        {
            get { return ThreadManager.Constante; }
            set { ThreadManager.Constante = value; }
        }

        /// <summary>
        /// Computadores de la red
        /// </summary>
        private Dictionary<Guid, ComputadorLogico> _computadores = new Dictionary<Guid, ComputadorLogico>();

        public Dictionary<Guid, ComputadorLogico> Computadores
        {
            get { return _computadores; }
        }



        private Dictionary<Guid, RouterLogico> _routers = new Dictionary<Guid, RouterLogico>();

        public Dictionary<Guid, RouterLogico> Routers
        {
            get { return _routers; }
        }


        /// <summary>
        /// Switches de la red
        /// </summary>
        private Dictionary<Guid, SwitchLogico> _switches = new Dictionary<Guid, SwitchLogico>();
        private Dictionary<Guid, HUBLogico> _hubs = new Dictionary<Guid, HUBLogico>();

        private Dictionary<Guid, SwitchVLAN> _switchesVLan = new Dictionary<Guid, SwitchVLAN>();

        public Dictionary<Guid, SwitchVLAN> SwitchesVLan
        {
            get { return _switchesVLan; }
        }

        public Dictionary<Guid, SwitchLogico> Switches
        {
            get { return _switches; }
        }
        public Dictionary<Guid, HUBLogico> HUBS
        {
            get { return _hubs; }
        }
        /// <summary>
        /// Cables de la red
        /// </summary>
        private Dictionary<Guid, CableDeRedLogico> _diccioCables = new Dictionary<Guid, CableDeRedLogico>();

        public Dictionary<Guid, CableDeRedLogico> Cables
        {
            get { return _diccioCables; }
        }
        /// <summary>
        /// Puertos Logicos de la red
        /// </summary>
        private Dictionary<Guid, PuertoEthernetLogicoBase> _puertos = new Dictionary<Guid, PuertoEthernetLogicoBase>();

        public Dictionary<Guid, PuertoEthernetLogicoBase> Puertos
        {
            get { return _puertos; }
        }





        /// <summary>
        /// Lista de clientes de la red
        /// </summary>
        /// 
        public void CrearComputador(ComputadorLogico pc)
        {
            _computadores.Add(pc.Id, pc);
            _puertos.Add(pc.PuertoEthernet.Id, pc.PuertoEthernet);
            pc.InicializarEquipo();
        }
        public void CrearSwitch(SwitchLogico swi)
        {

            _switches.Add(swi.Id, swi);
            LLenarPuertos(_puertos, swi.PuertosEthernet);
            swi.InicializarEquipo();
        }
        public void CrearHUB(HUBLogico hubLogico)
        {
            _hubs.Add(hubLogico.Id, hubLogico);
            LLenarPuertos(_puertos, hubLogico.PuertosEthernet);
            hubLogico.InicializarEquipo();
        }
        public void CrearSwitchVLan(SwitchVLAN swiVLANLogico)
        {
            _switchesVLan.Add(swiVLANLogico.Id, swiVLANLogico);
            LLenarPuertos(_puertos, swiVLANLogico.PuertosEthernet);
            swiVLANLogico.InicializarEquipo();

        }
        public void MoverPosicionElemento(Guid id, int x, int y)
        {
            IPosisionable elemento = null;
            if (_computadores.ContainsKey(id))
            {
                elemento = _computadores[id];
            }
            else if (_switches.ContainsKey(id))
            {
                elemento = _switches[id];
            }
            else if (_switchesVLan.ContainsKey(id))
            {
                elemento = _switchesVLan[id];
            }
            else if (_routers.ContainsKey(id))
            {
                elemento = _routers[id];
            }
            else if (_hubs.ContainsKey(id))
            {
                elemento = _hubs[id];
            }
            if (elemento == null)
                throw new NotSupportedException();
            elemento.X = x;
            elemento.Y = y;
        }

        public CableDeRedLogico ConectarPuertos(Guid idPuertoA, Guid idPuertoB)
        {
            CableDeRedLogico cable = new CableDeRedLogico(_puertos[idPuertoA], _puertos[idPuertoB]);
            _diccioCables.Add(cable.Id, cable);
            return cable;
        }


        private static void LLenarPuertos(Dictionary<Guid, PuertoEthernetLogicoBase> diccionarioPuertos, IEnumerable<PuertoEthernetLogicoBase> puertos)
        {
            foreach (PuertoEthernetLogicoBase puerto in puertos)
            {
                diccionarioPuertos.Add(puerto.Id, puerto);
            }
        }
        private static void LLenarPuertos(Dictionary<Guid, PuertoEthernetLogicoBase> diccionarioPuertos, IEnumerable<PuertoEthernetCompleto> puertos)
        {
            foreach (PuertoEthernetLogicoBase puerto in puertos)
            {
                diccionarioPuertos.Add(puerto.Id, puerto);
            }
        }









        public void CrearRouter(RouterLogico router)
        {
            _routers.Add(router.Id, router);
            LLenarPuertos(_puertos, router.PuertosEthernet);
            router.InicializarEquipo();

        }




        public void Ping(Guid idEquipo, string ipDestino)
        {
            _computadores[idEquipo].Ping(ipDestino);
        }
        internal void EnviarStream(Guid idEquipo, string ipDestino, int puertoOrigen, int puertoDestino, byte[] stream,
            int segmentSize,string fileName)
        {
            _computadores[idEquipo].EnviarStream(ipDestino, puertoOrigen, puertoDestino, stream,segmentSize,fileName);
        }

        public void EstablecerDatosPueroBase(PuertoBaseSOA puerto)
        {
            PuertoEthernetLogicoBase puertoLogico = _puertos[puerto.Id];
            puertoLogico.Nombre = puerto.Nombre;
            puertoLogico.Habilitado = puerto.Habilitado;
        }
        public void EstablecerDatosPuertoCompleto(PuertoCompletoSOA puerto)
        {
            PuertoEthernetCompleto puertoLogico = _puertos[puerto.Id] as PuertoEthernetCompleto;
            puertoLogico.Nombre = puerto.Nombre;
            puertoLogico.Habilitado = puerto.Habilitado;
            puertoLogico.IPAddress = puerto.IPAddress;
            puertoLogico.Mascara = puerto.Mask;
        }

        internal void EstablecerDatosComputador(ComputadorSOA pcSOA)
        {
            ComputadorLogico pcLogico = _computadores[pcSOA.Id];
            pcLogico.Nombre = pcSOA.Nombre;
            pcLogico.DefaultGateWay = pcSOA.DefaultGateWay;
        }

        internal void EstablecerDatosRouter(RouterSOA router)
        {
            RouterLogico rou = _routers[router.Id];
            rou.Nombre = router.Nombre;
            rou.RipHabilitado = router.RipHabilitado;
        }

        internal void EstablecerDatosSwitch(SwitchSOA swi)
        {
            SwitchLogico swiLogico = _switches[swi.Id];
            swiLogico.Nombre = swi.Nombre;
        }

        internal void EliminarCable(Guid idCable)
        {
            CableDeRedLogico cable = _diccioCables[idCable];
            cable.DesconectarPuertos();
            _diccioCables.Remove(idCable);
        }

        internal List<CableDeRedLogico> BuscarCablesConectadosAlEquipo(Guid idEquipo)
        {
            List<CableDeRedLogico> cablesConectados = new List<CableDeRedLogico>();
            List<PuertoEthernetLogicoBase> puertosEquipo = BuscarPuertosDelEquipo(idEquipo);
            foreach (KeyValuePair<Guid,CableDeRedLogico> item in _diccioCables)
            {
                if (puertosEquipo.Contains(item.Value.Puerto1) ||puertosEquipo.Contains(item.Value.Puerto2))
                {
                    cablesConectados.Add(item.Value);
                }
            }

            return cablesConectados;
        }

        public List<PuertoEthernetLogicoBase> BuscarPuertosDelEquipo(Guid idEquipo)
        {
            List<PuertoEthernetLogicoBase> puertos = new List<PuertoEthernetLogicoBase>();
            if (_computadores.ContainsKey(idEquipo))
            {
                puertos.Add(_computadores[idEquipo].PuertoEthernet);
                return puertos;
            }
            if (_switches.ContainsKey(idEquipo))
            {
                foreach (PuertoEthernetLogicoBase puerto in _switches[idEquipo].PuertosEthernet)
                {
                    puertos.Add(puerto);
                }
                return puertos;
            }
            if (_hubs.ContainsKey(idEquipo))
            {
                foreach (PuertoEthernetLogicoBase puerto in _hubs[idEquipo].PuertosEthernet)
                {
                    puertos.Add(puerto);
                }
                return puertos;
            }
            if (_switchesVLan.ContainsKey(idEquipo))
            {
                foreach (PuertoEthernetLogicoBase puerto in _switchesVLan[idEquipo].PuertosEthernet)
                {
                    puertos.Add(puerto);
                }
                return puertos;
            }
            if (_routers.ContainsKey(idEquipo))
            {
                foreach (PuertoEthernetCompleto puerto in _routers[idEquipo].PuertosEthernet)
                {
                    puertos.Add(puerto);
                }
                return puertos;
            }


            throw new Exception();
        }

        internal void EliminarEquipo(Guid idEquipo)
        {
            EquipoLogico equipo = BorrarEquipoById(idEquipo);
            equipo.DesconectarEquipo();
        }

        private EquipoLogico BorrarEquipoById(Guid idEquipo)
        {
            if (_computadores.ContainsKey(idEquipo))
            {
                EquipoLogico equipo = _computadores[idEquipo];
                equipo.Dispose();
                _computadores.Remove(idEquipo);
                return equipo;
            }
            if (_switches.ContainsKey(idEquipo))
            {
                EquipoLogico equipo = _switches[idEquipo];
                equipo.Dispose();
                _switches.Remove(idEquipo);
                return equipo;
            }
            if (_hubs.ContainsKey(idEquipo))
            {
                EquipoLogico equipo = _hubs[idEquipo];
                equipo.Dispose();
                _hubs.Remove(idEquipo);
                return equipo;
            }
            if (_switchesVLan.ContainsKey(idEquipo))
            {
                EquipoLogico equipo = _switchesVLan[idEquipo];
                equipo.Dispose();
                _switchesVLan.Remove(idEquipo);
                return equipo;
            }
            if (_routers.ContainsKey(idEquipo))
            {
                EquipoLogico equipo = _routers[idEquipo];
                equipo.Dispose();
                _routers.Remove(idEquipo);
                return equipo;
            }
            throw new Exception();
        }







        public void Dispose()
        {
            foreach (KeyValuePair<Guid,ComputadorLogico> pcs in _computadores)
            {
                pcs.Value.Dispose();
            }
            foreach (KeyValuePair<Guid, SwitchLogico> pcs in _switches)
            {
                pcs.Value.Dispose();
            }
            foreach (KeyValuePair<Guid, SwitchVLAN> pcs in _switchesVLan)
            {
                pcs.Value.Dispose();
            }
            foreach (KeyValuePair<Guid, RouterLogico> pcs in _routers)
            {
                pcs.Value.Dispose();
            }
            foreach (KeyValuePair<Guid, HUBLogico> pcs in _hubs)
            {
                pcs.Value.Dispose();
            }
            foreach (KeyValuePair<Guid, CableDeRedLogico> pcs in _diccioCables)
            {
                pcs.Value.Dispose();
            }
        }
    }


}
