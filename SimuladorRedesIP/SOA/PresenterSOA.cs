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

        public PresenterBase(Estacion estacion)
        {
            _estacion = estacion;
            _estacion.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
        }
        private static List<IVisualizacion> _vistas = new List<IVisualizacion>();

        public void PeticionCrearEquipo(TipoDeEquipo tipoEquipo, int x, int y)
        {
            EquipoLogico equipoLogico = null;
            switch (tipoEquipo)
            {
                case TipoDeEquipo.Ninguno:
                    break;
                case TipoDeEquipo.Computador:
                    equipoLogico = _estacion.CrearComputador(x, y);
                    break;
                case TipoDeEquipo.Switch:
                    equipoLogico = _estacion.CrearSwitch(x, y);
                    break;
                default:
                    break;
            }
            EquipoSOA equipo = new EquipoSOA(tipoEquipo, equipoLogico.Id, equipoLogico.X, equipoLogico.Y);
            LLenarPuertos(equipoLogico, equipo);
            foreach (IVisualizacion cliente in _vistas)
            {
                cliente.CrearEquipo(equipo);
            }

        }

        private static void LLenarPuertos(EquipoLogico equipoLogico, EquipoSOA equipo)
        {
            foreach (PuertoEthernetLogico puertoLogico in equipoLogico.PuertosEthernet)
            {
                equipo.Puertos.Add(new PuertoSOA(puertoLogico.Id));
            }
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

        public  void Conectar()
        {
            RegistrarCliente();
            IVisualizacion cliente = GetCurrentClient();

            List<EquipoSOA> equipos = new List<EquipoSOA>();
            foreach (KeyValuePair<Guid, ComputadorLogico> par in _estacion.Computadores)
            {
                ComputadorLogico pc = par.Value;
                equipos.Add(new EquipoSOA(pc.TipoDeEquipo, pc.Id, pc.X, pc.Y));
            }
            List<CableSOA> cables = new List<CableSOA>();
            foreach (KeyValuePair<Guid, CableDeRedLogico> par in _estacion.Cables)
            {
                CableDeRedLogico cable = par.Value;
                cables.Add(new CableSOA(cable.Id, cable.Puerto1.Id, cable.Puerto2.Id));
            }
            cliente.ActualizarEstacion(equipos, cables);

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
            MACAddressSOA macPuerto = new MACAddressSOA(e.DireccionPuerto);
            MACAddressSOA macOrigen = new MACAddressSOA(e.FrameRecibido.MACAddressOrigen);
            MACAddressSOA macDestino = new MACAddressSOA(e.FrameRecibido.MACAddressDestino);
            MensajeSOA mensajeSOA = new MensajeSOA(cable.Id, mensaje, macPuerto, macOrigen, macDestino, e.FrameRecibido.HoraTransmision, e.FrameRecibido.HoraRecepcion);
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


        public void Ping(Guid idComputador, string mensaje, byte p1, byte p2, byte p3)
        {
            _estacion.Ping(idComputador, mensaje, MACAddress.Direccion(p1, p2, p3));
        }



    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class PresenterSOA : PresenterBase
    {
        public PresenterSOA(Estacion estacion)
            :base(estacion)
        {

        }
        protected override IVisualizacion GetCurrentClient()
        {
            return OperationContext.Current.GetCallbackChannel<IVisualizacion>();
        }


    }
}
