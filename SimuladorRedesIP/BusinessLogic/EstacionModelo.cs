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
        private static float _porcentajeDeVelocidad = 50;

        public static float PorcentajeDeVelocidadSimulacion
        {
            get { return EstacionModelo._porcentajeDeVelocidad; }
            set { EstacionModelo._porcentajeDeVelocidad = value; }
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

        public Dictionary<Guid, SwitchLogico> Switches
        {
            get { return _switches; }
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
        public void MoverPosicionElemento(Guid id, int x, int y)
        {
            IPosisionable elemento=null;
            if (_computadores.ContainsKey(id))
            {
                elemento = _computadores[id];
            }
            else if (_switches.ContainsKey(id))
            {
                elemento = _switches[id];
            }
            else if (_routers.ContainsKey(id))
            {
                elemento = _routers[id];
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




        public void Ping(Guid idEquipo, string ipDestino,string datos)
        {
            _computadores[idEquipo].Ping(idEquipo, ipDestino, datos);
        }

        public void EstablecerDatosPueroBase(PuertoBaseSOA puerto)
        {
            PuertoEthernetLogicoBase puertoLogico = _puertos[puerto.Id];
            puertoLogico.Nombre = puerto.Nombre;
        }
        public void EstablecerDatosPuertoCompleto(PuertoCompletoSOA puerto)
        {
            PuertoEthernetCompleto puertoLogico = _puertos[puerto.Id] as PuertoEthernetCompleto;
            puertoLogico.Nombre = puerto.Nombre;
            puertoLogico.IPAddress = puerto.IPAddress;
            puertoLogico.Mascara = puerto.Mask;
        }

        internal void EstablecerDatosComputador(ComputadorSOA pcSOA)
        {
            ComputadorLogico pcLogico = _computadores[pcSOA.Id] as ComputadorLogico;
            pcLogico.Nombre = pcSOA.Nombre;
            pcLogico.DefaultGateWay = pcSOA.DefaultGateWay;
        }
    }


}
