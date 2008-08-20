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
using BusinessLogic.Modelos.Logicos.Datos;
using BusinessLogic.Sniffer;

namespace RedesIP
{
    public abstract class PresenterBase : IModeloSOA
    {     

        private EstacionModelo _estacion;

        private ModeloSnifferMaster _snifferMaster;

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
        public void SetEstacion(EstacionModelo estacion)
        {
            _vistas.Clear();
            _estacion = estacion;
            _snifferMaster = new ModeloSnifferMaster(_vistas, estacion);
        }

        private static List<IVisualizacion> _vistas = new List<IVisualizacion>();





        public void PeticionMoverEquipo(Guid idEquipo, int x, int y)
        {
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

        public void ConectarCliente()
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
               estacionSOA.Switches.Add(SwitchLogico.CrearSwitchSOA(par.Value));
            }
            foreach (KeyValuePair<Guid,RouterLogico> par in _estacion.Routers)
            {
               estacionSOA.Routers.Add(RouterLogico.CrearRouterSOA(par.Value));
            }

            foreach (KeyValuePair<Guid, CableDeRedLogico> par in _estacion.Cables)
            {
                CableDeRedLogico cable = par.Value;
                estacionSOA.Cables.Add(new CableSOA(cable.Id, cable.Puerto1.Id, cable.Puerto2.Id));
            }
            cliente.ActualizarEstacion(estacionSOA);

        }





        public void DesconectarCliente()
        {
            IVisualizacion cliente = GetCurrentClient();
            _vistas.Remove(cliente);

        }
        public void PeticionEnviarInformacionConexion(Guid idConexion)
        {
            _snifferMaster.PeticionEnviarInformacionConexion(idConexion);
        }



        public float GetVelocidadSimulacion()
        {
            return EstacionModelo.PorcentajeDeVelocidadSimulacion;
        }

        public void SetVelocidadSimulacion(float valor)
        {
            EstacionModelo.PorcentajeDeVelocidadSimulacion = valor;
        }




        public void PeticionCrearComputador(ComputadorSOA computadorVisulizacion)
        {

            ComputadorLogico pcLogico = new ComputadorLogico(Guid.NewGuid(), computadorVisulizacion.X, computadorVisulizacion.Y);
            pcLogico.AgregarPuerto(Guid.NewGuid(),"E.0");
            _estacion.CrearComputador(pcLogico);

            ComputadorSOA equipoRespuesta = CrearComputadorSOA(pcLogico);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.CrearComputador(equipoRespuesta);
            }

        }

        private static ComputadorSOA CrearComputadorSOA(ComputadorLogico pcLogico)
        {
            ComputadorSOA equipoRespuesta = new ComputadorSOA(pcLogico.TipoDeEquipo, pcLogico.Id, pcLogico.X, pcLogico.Y);
            equipoRespuesta.AgregarPuerto(new PuertoCompletoSOA(pcLogico.PuertoEthernet.Id, pcLogico.PuertoEthernet.MACAddress,pcLogico.PuertoEthernet.Nombre));
            return equipoRespuesta;
        }

        public void PeticionCrearSwitch(SwitchSOA swiPeticion)
        {
            SwitchLogico swiLogico = new SwitchLogico(Guid.NewGuid(), swiPeticion.X, swiPeticion.Y);
            for (int i = 0; i < 5; i++)
            {
                swiLogico.AgregarPuerto(Guid.NewGuid(),"E."+i.ToString());
            }
            _estacion.CrearSwitch(swiLogico);


            SwitchSOA swiRespuesta =SwitchLogico.CrearSwitchSOA(swiLogico);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.CrearSwitch(swiRespuesta);
            }



        }

 

        public void PeticionCrearRouter(RouterSOA router)
        {
            RouterLogico routerLogico = new RouterLogico(Guid.NewGuid(), router.X, router.Y);
            for (int i = 0; i < 5; i++)
            {
                routerLogico.AgregarPuerto(Guid.NewGuid(),"E."+i.ToString());
            }
            _estacion.CrearRouter(routerLogico);
            RouterSOA rouRespuesta = RouterLogico.CrearRouterSOA(routerLogico);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.CrearRouter(rouRespuesta);
            }
        }





        public void Ping(Guid idEquipo, string ipDestino, string datos)
        {
            _estacion.Ping(idEquipo, ipDestino, datos);
        }


        #region IModeloEstacion Members


        public void PeticionEstablecerDatosPuertoBase(PuertoBaseSOA puerto)
        {
            _estacion.EstablecerDatosPueroBase(puerto);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.EstablecerDatosPuertoBase(puerto);
            }
        }

        public void PeticionEstablecerDatosPuertoCompleto(PuertoCompletoSOA puerto)
        {
            _estacion.EstablecerDatosPuertoCompleto(puerto);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.EstablecerDatosPuertoCompleto(puerto);
            }
        }

        #endregion
    }


}
