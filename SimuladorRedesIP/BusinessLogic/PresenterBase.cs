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
using SOA.Componentes;

namespace RedesIP
{
    public abstract class PresenterBase : IModeloSOA
    {     

        private EstacionModelo _estacion;

        private ModeloSnifferMaster _snifferMaster;

        public ModeloSnifferMaster SnifferMaster
        {
            get { return _snifferMaster; }
        }

        private void RegistrarCliente()
        {
            IVisualizacion vista = GetCurrentClient();
            if (_vistas.Contains(vista))
                return;
            _vistas.Add(vista);
        }


        public void SetEstacion(EstacionModelo estacion,ModeloSnifferMaster modeloSnifferMaster)
        {
            _estacion = estacion;
            _snifferMaster = modeloSnifferMaster;
        }

        private static List<IVisualizacion> _vistas = new List<IVisualizacion>();

        protected static List<IVisualizacion> Vistas
        {
            get { return PresenterBase._vistas; }
        }





        public void PeticionMoverEquipo(Guid idEquipo, int x, int y)
        {
            _estacion.MoverPosicionElemento(idEquipo, x, y);
            foreach (IVisualizacion cliente in _vistas)
            {
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
            _snifferMaster.DesconectarCliente(GetCurrentClient());

        }
        public void PeticionEnviarInformacionConexion(Guid idConexion)
        {
            _snifferMaster.PeticionEnviarInformacionConexion(idConexion, GetCurrentClient());
        }



        public int GetFactorSimulacion()
        {
            return EstacionModelo.PorcentajeDeVelocidadSimulacion;
        }

        public void PeticionSetFactorSimulacion(int valor)
        {
            EstacionModelo.PorcentajeDeVelocidadSimulacion = valor;
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.SetValorConstanteSimulacion(valor);
            }

        }




        public void PeticionCrearComputador(ComputadorSOA computadorVisulizacion)
        {

            ComputadorLogico pcLogico = new ComputadorLogico(Guid.NewGuid(),
                computadorVisulizacion.X, computadorVisulizacion.Y,computadorVisulizacion.Nombre,
                computadorVisulizacion.DefaultGateWay);
            pcLogico.AgregarPuerto(Guid.NewGuid(),"E.0",MACAddressFactory.NewMAC(),null,null);
            _estacion.CrearComputador(pcLogico);

            ComputadorSOA equipoRespuesta = CrearComputadorSOA(pcLogico);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.CrearComputador(equipoRespuesta);
            }

        }

        private static ComputadorSOA CrearComputadorSOA(ComputadorLogico pcLogico)
        {
            ComputadorSOA equipoRespuesta = new ComputadorSOA(pcLogico.TipoDeEquipo, pcLogico.Id, pcLogico.X, pcLogico.Y,pcLogico.Nombre,pcLogico.DefaultGateWay);
            equipoRespuesta.AgregarPuerto(new PuertoCompletoSOA(pcLogico.PuertoEthernet.Id, pcLogico.PuertoEthernet.MACAddress,pcLogico.PuertoEthernet.Nombre,
                pcLogico.PuertoEthernet.IPAddress,pcLogico.PuertoEthernet.Mascara));
            return equipoRespuesta;
        }

        public void PeticionCrearSwitch(SwitchSOA swiPeticion)
        {
            SwitchLogico swiLogico = new SwitchLogico(Guid.NewGuid(), swiPeticion.X, swiPeticion.Y,swiPeticion.Nombre);
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
            RouterLogico routerLogico = new RouterLogico(Guid.NewGuid(), router.X, router.Y, router.Nombre);
            for (int i = 0; i < 5; i++)
            {
                routerLogico.AgregarPuerto(Guid.NewGuid(),"E."+i.ToString(),MACAddressFactory.NewMAC(),null,null);
            }
            _estacion.CrearRouter(routerLogico);
            RouterSOA rouRespuesta = RouterLogico.CrearRouterSOA(routerLogico);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.CrearRouter(rouRespuesta);
            }
        }





        public void Ping(Guid idEquipo, string ipDestino)
        {
            _estacion.Ping(idEquipo, ipDestino);
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






        public void PeticionEnviarInformacionSwitch(Guid idSwitch)
        {
            _snifferMaster.PeticionEnviarInformacionSwitch(idSwitch, GetCurrentClient());
        }






        public void PeticionEstablecerDatosComputador(ComputadorSOA pcSOA)
        {
            _estacion.EstablecerDatosComputador(pcSOA);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.EstablecerDatosComputador(pcSOA);
            }
        }






        public List<RutaSOA> TraerRutas(Guid idRouter)
        {
            List<RutaSOA> rutasSOA = _estacion.Routers[idRouter].TraerRutas();
            return rutasSOA;
        }






        public void ActualizarRutas(Guid IdRouter, List<RutaSOA> rutas)
        {
            _estacion.Routers[IdRouter].ActualizarRutas(rutas);
        }






        public void PeticionEstablecerDatosRouter(RouterSOA router)
        {
            _estacion.EstablecerDatosRouter(router);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.EstablecerDatosRouter(router);
            }
        }






        public List<RutaSOA> TraerRutasRouter(Guid idRouter)
        {
            List<RutaSOA> rutasSOA = _estacion.Routers[idRouter].TraerRutasRouter();
            return rutasSOA;
        }





        public void PeticionEnviarInformacionPuertoCompleto(Guid idPuerto)
        {
            _snifferMaster.PeticionEnviarInformacionPuertoCompleto(idPuerto, GetCurrentClient());
        }

        #endregion

        #region IModeloSOA Members


        public void PeticionEstablecerDatosSwitch(SwitchSOA swi)
        {
            _estacion.EstablecerDatosSwitch(swi);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.EstablecerDatosSwitch(swi);
            }
        }

        #endregion




        public void PeticionEnviarInformacionPC(Guid idPC)
        {
            _snifferMaster.PeticionEnviarInformacionPC(idPC, GetCurrentClient());
        }

        public void PeticionEnviarInformacionRouter(Guid idRouter)
        {
            _snifferMaster.PeticionEnviarInformacionRouter(idRouter, GetCurrentClient());
        }



        #region IModeloSniffer Members


        public void PeticionPararDeEnviarInformacionConexion(Guid idConexion)
        {
            _snifferMaster.PeticionPararEnviarInformacionConexion(idConexion, GetCurrentClient());
                        
        }



        public void PeticionPararDeEnviarInformacionPC(Guid idPc)
        {
           _snifferMaster.PeticionPararDeEnviarInformacionPC(idPc,GetCurrentClient());
        }

        public void PeticionPararDeEnviarInformacionPuertoCompleto(Guid idPuerto)
        {
            _snifferMaster.PeticionPararDeEnviarInformacionPuertoCompleto(idPuerto, GetCurrentClient());
        }

        public void PeticionPararDeEnviarInformacionRouter(Guid idRouter)
        {
            _snifferMaster.PeticionPararDeEnviarInformacionRouter(idRouter, GetCurrentClient());
        }

        public void PeticionPararDeEnviarInformacionSwitch(Guid idSwitch)
        {
            _snifferMaster.PeticionPararDeEnviarInformacionSwitch(idSwitch, GetCurrentClient());
        }
        #endregion

        #region IModeloSOA Members


        public void PeticionEliminarCable(Guid idCable)
        {
            EliminarCable(idCable);
        }

        private void EliminarCable(Guid idCable)
        {
            _snifferMaster.EliminarSnifferCableBuscandoCable(idCable);
            _estacion.EliminarCable(idCable);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.EliminarCable(idCable);
            }
        }




        public void PeticionEliminarEquipo(Guid idEquipo)
        {
            List<CableDeRedLogico> cablesConectadosAlEquipo = _estacion.BuscarCablesConectadosAlEquipo(idEquipo);
            foreach (CableDeRedLogico cable in cablesConectadosAlEquipo)
            {
                EliminarCable(cable.Id);
            }
            _snifferMaster.EliminarSniffersDelEquipo(idEquipo);
            _estacion.EliminarEquipo(idEquipo);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.EliminarEquipo(idEquipo);
            }
        }

        #endregion
    }


}
