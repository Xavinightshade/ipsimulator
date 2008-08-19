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

        private Dictionary<Guid, EquipoLogico> _equipos = new Dictionary<Guid, EquipoLogico>();

        public Dictionary<Guid, EquipoLogico> Equipos
        {
            get { return _equipos; }
        }
        private Dictionary<Guid, RouterLogico> _routers = new Dictionary<Guid, RouterLogico>();


        /// <summary>
        /// Switches de la red
        /// </summary>
        private Dictionary<Guid, SwitchLogico> _switches = new Dictionary<Guid, SwitchLogico>();
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
        private Dictionary<Guid, PuertoEthernetLogico> _puertos = new Dictionary<Guid, PuertoEthernetLogico>();





        /// <summary>
        /// Lista de clientes de la red
        /// </summary>
        /// 
        public void CrearComputador(ComputadorLogico pc)
        {
            _computadores.Add(pc.Id, pc);
            _equipos.Add(pc.Id, pc);
            _puertos.Add(pc.PuertoEthernet.Id, pc.PuertoEthernet);
        }
        public void CrearSwitch(SwitchLogico swi)
        {

            _switches.Add(swi.Id, swi);
            _equipos.Add(swi.Id, swi);
            LLenarPuertos(_puertos, swi.PuertosEthernet);
        }
        public void MoverPosicionElemento(Guid id, int x, int y)
        {
            IPosisionable elemento = _equipos[id];
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

        private void LLenarPuertos(Dictionary<Guid, PuertoEthernetLogico> diccionarioPuertos, IEnumerable<PuertoEthernetLogico> puertos)
        {
            foreach (PuertoEthernetLogico puerto in puertos)
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
            _equipos.Add(router.Id, router);
            LLenarPuertos(_puertos, router.PuertosEthernet);
        }
    }


}
