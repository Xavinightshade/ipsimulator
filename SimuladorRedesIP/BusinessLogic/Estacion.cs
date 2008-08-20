using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Modelos;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Modelos.Datos;
using RedesIP.Common;

namespace RedesIP
{
    public class Estacion
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
        }
        public Estacion(Guid id)
        {
            _id = id;
        }
        private static float _porcentajeDeVelocidad = 50;

        public static float PorcentajeDeVelocidadSimulacion
        {
            get { return Estacion._porcentajeDeVelocidad; }
            set { Estacion._porcentajeDeVelocidad = value; }
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
        }
        public void CrearSwitch(SwitchLogico swi)
        {

            _switches.Add(swi.Id, swi);
            LLenarPuertos(_puertos, swi.PuertosEthernet);
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
        public void Ping(Guid idComputador, string mensaje, string macDestino)
        {
            _computadores[idComputador].EnviarMensajeDeTexto(mensaje, macDestino);


        }

        private void LLenarPuertos(Dictionary<Guid, PuertoEthernetLogicoBase> diccionarioPuertos, IEnumerable<PuertoEthernetLogicoBase> puertos)
        {
            foreach (PuertoEthernetLogicoBase puerto in puertos)
            {
                diccionarioPuertos.Add(puerto.Id, puerto);
            }
        }

        private void OnFrameRecibido(object sender, FrameRecibidoEventArgs e)
        {
            if (FrameRecibido != null)
                FrameRecibido(sender, e);
        }
        public event EventHandler<FrameRecibidoEventArgs> FrameRecibido;





        private List<Guid> _PuertosEscuchando = new List<Guid>();
        public void EscucharPuerto(Guid idConexion)
        {
            CableDeRedLogico cable = _diccioCables[idConexion];
            if (_PuertosEscuchando.Contains(cable.Puerto1.Id) || _PuertosEscuchando.Contains(cable.Puerto2.Id))
            {

            }
            else
            {
                cable.FrameRecibidoPuerto1 += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
                cable.FrameRecibidoPuerto2 += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
                _PuertosEscuchando.Add(cable.Puerto1.Id);
                _PuertosEscuchando.Add(cable.Puerto2.Id);
            }



        }

        public void CrearRouter(RouterLogico router)
        {
            _routers.Add(router.Id, router);
            LLenarPuertos(_puertos, router.PuertosEthernet);
        }

        public void EstablecerDireccionIP(string ipAddress, Guid idPuerto)
        {
            PuertoEthernetCompleto puerto = _puertos[idPuerto] as PuertoEthernetCompleto;
            puerto.IPAddress = ipAddress;
        }
    }


}
