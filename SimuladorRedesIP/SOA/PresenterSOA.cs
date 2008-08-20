using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using System.ServiceModel;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Modelos.Datos;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Modelos;
using RedesIP.SOA.Elementos;
using RedesIP.Common;

namespace RedesIP
{
    public abstract class PresenterBase : IModeloSOA
    {
        private Estacion _estacion;
        private void RegistrarCliente()
        {
            IVisualizacion vista = GetCurrentClient();
            if (_vistas.Contains(vista))
                return;
            _vistas.Add(vista);
        }

        private static void RealizarOperacionEnVista(IVisualizacion vista)
        {

        }
        public void SetEstacion(Estacion estacion)
        {
            _vistas.Clear();
            if (_estacion != null)
                throw new Exception();
            _estacion = estacion;
            _estacion.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
        }
        private static List<IVisualizacion> _vistas = new List<IVisualizacion>();





        public void PeticionMoverEquipo(Guid idEquipo, int x, int y)
        {
            _estacion.MoverPosicionElemento(idEquipo, x, y);

            foreach (IVisualizacion cliente in _vistas)
            {
                RealizarOperacionEnVista(cliente);
                cliente.MoverEquipo(idEquipo, x, y);

            }

        }

        public void PeticionConectarPuertos(Guid idPuerto1, Guid idPuerto2)
        {
            CableDeRedLogico cableLogico = _estacion.ConectarPuertos(idPuerto1, idPuerto2);
            CableSOA cableSOA = new CableSOA(cableLogico.Id, cableLogico.Puerto1.Id, cableLogico.Puerto2.Id);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.ConectarPuertos(cableSOA);
            }
        }

        public void PeticionActualizarEstacion()
        {

        }


        protected virtual IVisualizacion GetCurrentClient()
        {
            throw new NotImplementedException();
        }

        public void Conectar()
        {
            RegistrarCliente();
            IVisualizacion cliente = GetCurrentClient();

            EstacionSOA estacionSOA = new EstacionSOA();
            foreach (KeyValuePair<Guid,ComputadorLogico> par in _estacion.Computadores)
            {
               estacionSOA.Computadores.Add(CrearComputadorSOA(par.Value));
            }
            foreach (KeyValuePair<Guid,SwitchLogico> par in _estacion.Switches)
            {
               estacionSOA.Switches.Add(CrearSwitchSOA(par.Value));
            }
            foreach (KeyValuePair<Guid,RouterLogico> par in _estacion.Routers)
            {
               estacionSOA.Routers.Add(CrearRouterSOA(par.Value));
            }

            foreach (KeyValuePair<Guid, CableDeRedLogico> par in _estacion.Cables)
            {
                CableDeRedLogico cable = par.Value;
                estacionSOA.Cables.Add(new CableSOA(cable.Id, cable.Puerto1.Id, cable.Puerto2.Id));
            }
            cliente.ActualizarEstacion(estacionSOA);

        }





        public void Desconectar()
        {
            IVisualizacion cliente = GetCurrentClient();
            _vistas.Remove(cliente);

        }





        private static Dictionary<Guid, List<IVisualizacion>> _diccioMensajes = new Dictionary<Guid, List<IVisualizacion>>();

        public void PeticionEnviarInformacionConexion(Guid idConexion)
        {
            if (!_diccioMensajes.ContainsKey(idConexion))
            {
                _diccioMensajes.Add(idConexion, new List<IVisualizacion>());
            }
            _diccioMensajes[idConexion].Add(GetCurrentClient());

            _estacion.EscucharPuerto(idConexion);
        }

        void OnFrameRecibido(object sender, FrameRecibidoEventArgs e)
        {
            CableDeRedLogico cable = (CableDeRedLogico)sender;
            string mensaje = e.FrameRecibido.Informacion.ToString();
            string macOrigen = e.FrameRecibido.MACAddressOrigen;
            string macDestino = e.FrameRecibido.MACAddressDestino;
            MensajeSOA mensajeSOA = new MensajeSOA(cable.Id, mensaje, macOrigen, macDestino, e.FrameRecibido.HoraTransmision, e.FrameRecibido.HoraRecepcion);
            foreach (IVisualizacion cliente in _diccioMensajes[cable.Id])
            {
                cliente.EnviarInformacionConexion(mensajeSOA);
            }
        }










        public float GetVelocidadSimulacion()
        {
            return Estacion.PorcentajeDeVelocidadSimulacion;
        }

        public void SetVelocidadSimulacion(float valor)
        {
            Estacion.PorcentajeDeVelocidadSimulacion = valor;
        }







        #region IModeloSOA Members

        public void PeticionCrearComputador(ComputadorSOA computadorVisulizacion)
        {

            ComputadorLogico pcLogico = new ComputadorLogico(Guid.NewGuid(), computadorVisulizacion.X, computadorVisulizacion.Y);
            pcLogico.AgregarPuerto(Guid.NewGuid());
            _estacion.CrearComputador(pcLogico);
            pcLogico.InicializarEquipo();

            ComputadorSOA equipoRespuesta = CrearComputadorSOA(pcLogico);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.CrearComputador(equipoRespuesta);
            }

        }

        private static ComputadorSOA CrearComputadorSOA(ComputadorLogico pcLogico)
        {
            ComputadorSOA equipoRespuesta = new ComputadorSOA(pcLogico.TipoDeEquipo, pcLogico.Id, pcLogico.X, pcLogico.Y);
            equipoRespuesta.AgregarPuerto(new PuertoCompletoSOA(pcLogico.PuertoEthernet.Id, pcLogico.PuertoEthernet.MACAddress));
            return equipoRespuesta;
        }

        public void PeticionCrearSwitch(SwitchSOA swiPeticion)
        {
            SwitchLogico swiLogico = new SwitchLogico(Guid.NewGuid(), swiPeticion.X, swiPeticion.Y);
            for (int i = 0; i < 5; i++)
            {
                swiLogico.AgregarPuerto(Guid.NewGuid());
            }
            swiLogico.InicializarEquipo();
            _estacion.CrearSwitch(swiLogico);


            SwitchSOA swiRespuesta = CrearSwitchSOA(swiLogico);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.CrearSwitch(swiRespuesta);
            }



        }

        private static SwitchSOA CrearSwitchSOA(SwitchLogico swiLogico)
        {
            SwitchSOA swiRespuesta = new SwitchSOA(swiLogico.TipoDeEquipo, swiLogico.Id, swiLogico.X, swiLogico.Y);
            foreach (PuertoEthernetLogicoBase puerto in swiLogico.PuertosEthernet)
            {
                swiRespuesta.AgregarPuerto(new PuertoBaseSOA(puerto.Id));
            }
            return swiRespuesta;
        }

        public void PeticionCrearRouter(RouterSOA router)
        {
            RouterLogico routerLogico = new RouterLogico(Guid.NewGuid(), router.X, router.Y);
            for (int i = 0; i < 5; i++)
            {
                routerLogico.AgregarPuerto(Guid.NewGuid());
            }
            routerLogico.InicializarEquipo();
            _estacion.CrearRouter(routerLogico);
            RouterSOA rouRespuesta = CrearRouterSOA(routerLogico);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.CrearRouter(rouRespuesta);
            }
        }

        private static RouterSOA CrearRouterSOA(RouterLogico routerLogico)
        {
            RouterSOA rouRespuesta = new RouterSOA(routerLogico.TipoDeEquipo, routerLogico.Id, routerLogico.X, routerLogico.Y);
            foreach (PuertoEthernetCompleto puerto in routerLogico.PuertosEthernet)
            {
                rouRespuesta.AgregarPuerto(new PuertoCompletoSOA(puerto.Id, puerto.MACAddress));
            }
            return rouRespuesta;
        }

        #endregion

        #region IModeloSOA Members


        public void PeticionEstablecerDireccionIP(string ipAddress, Guid idPuerto)
        {
            _estacion.EstablecerDireccionIP(ipAddress,idPuerto);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.EstablecerDireccionIP(idPuerto, ipAddress);
            }
        }

        #endregion
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class PresenterSOA : PresenterBase
    {
        public PresenterSOA()
        {

        }
        protected override IVisualizacion GetCurrentClient()
        {
            return OperationContext.Current.GetCallbackChannel<IVisualizacion>();
        }


    }
}
