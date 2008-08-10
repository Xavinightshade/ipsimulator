using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Modelos;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.SOA;
using RedesIP.Modelos.Datos;
using RedesIP.SOA.Elementos;

namespace RedesIP
{
	public class Estacion
	{
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
        private Dictionary<Guid, IPosisionable> _elementosPosisionables = new Dictionary<Guid, IPosisionable>();
        public ComputadorLogico CrearComputador(int X, int Y)
        {
            ComputadorLogico pc = new ComputadorLogico(X,Y);           
            _computadores.Add(pc.Id, pc);
            _elementosPosisionables.Add(pc.Id, pc);
            _puertos.Add(pc.PuertoEthernet.Id, pc.PuertoEthernet);
            return pc;
        }
        public SwitchLogico CrearSwitch(int X, int Y)
        {
            SwitchLogico swi = new SwitchLogico(11,X,Y);
            _switches.Add(swi.Id, swi);
            _elementosPosisionables.Add(swi.Id, swi);
            LLenarPuertos(_puertos, swi.PuertosEthernet);
            return swi;
        }
        public void MoverPosicionElemento(Guid id,int x, int y)
        {
            IPosisionable elemento = _elementosPosisionables[id];
            elemento.X = x;
            elemento.Y = y;
        }

        public CableDeRedLogico ConectarPuertos(Guid idPuertoA, Guid idPuertoB)
        {
            CableDeRedLogico cable = new CableDeRedLogico(_puertos[idPuertoA], _puertos[idPuertoB]);
            _diccioCables.Add(cable.Id, cable);
            return cable;
        }
        public void Ping(Guid idComputador, string mensaje,MACAddress macDestino)
        {
            _computadores[idComputador].EnviarMensajeDeTexto(mensaje,macDestino);


        }

        private  void LLenarPuertos(Dictionary<Guid, PuertoEthernetLogico> diccionarioPuertos, IEnumerable<PuertoEthernetLogico> puertos) 
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
        internal void EscucharPuerto(Guid idConexion)
        {
            CableDeRedLogico cable = _diccioCables[idConexion];
            if (_PuertosEscuchando.Contains(cable.Puerto1.Id) || _PuertosEscuchando.Contains(cable.Puerto2.Id))
            {

            }
            else
            {
                cable.Puerto1.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
                cable.Puerto2.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
                _PuertosEscuchando.Add(cable.Puerto1.Id);
                _PuertosEscuchando.Add(cable.Puerto2.Id);
            }
         


        }
    }
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]

    public class EstacionSOA : IContract
    {
        private Estacion _estacion;
        public void SetEstacionLogica(Estacion estacion)
        {
            _estacion = estacion;
        }
		private List<ICallBackContract> _clientes = new List<ICallBackContract>();
		private void RegistrarCliente()
		{
			ICallBackContract cliente = OperationContext.Current.GetCallbackChannel<ICallBackContract>();
			if (_clientes.Contains(cliente))
				return;
			_clientes.Add(cliente);
		}
		public void PeticionCrearEquipo(TipoDeEquipo tipoEquipo, int x, int y)
		{
            EquipoLogico equipoLogico=null;
			switch (tipoEquipo)
			{
				case TipoDeEquipo.Ninguno:
					break;
				case TipoDeEquipo.Computador:
                    equipoLogico= _estacion.CrearComputador(x, y);
					break;
				case TipoDeEquipo.Switch:
                   equipoLogico= _estacion.CrearSwitch(x, y);
					break;
				default:
					break;
			}
            EquipoSOA equipo = new EquipoSOA(tipoEquipo, equipoLogico.Id, equipoLogico.X, equipoLogico.Y);
			foreach (ICallBackContract cliente in _clientes)
			{
				cliente.CrearEquipo(equipo);
			}

		}

		public void PeticionMoverEquipo(Guid idEquipo, int x, int y)
		{
            _estacion.MoverPosicionElemento(idEquipo, x, y);

			foreach (ICallBackContract cliente in _clientes)
			{
				cliente.MoverEquipo(idEquipo, x, y);
			}

		}

		public void PeticionConectarPuertos(Guid idPuerto1, Guid idPuerto2)
		{
            CableDeRedLogico  cableLogico= _estacion.ConectarPuertos(idPuerto1, idPuerto2);
            CableSOA cableSOA = new CableSOA(cableLogico.Id, cableLogico.Puerto1.Id, cableLogico.Puerto2.Id);
			foreach (ICallBackContract cliente in _clientes)
			{
                cliente.ConectarPuertos(cableSOA);
			}
		}

		public void PeticionActualizarEstacion()
		{
			throw new NotImplementedException();
		}




		public void Conectar()
		{
			RegistrarCliente();
			ICallBackContract cliente = OperationContext.Current.GetCallbackChannel<ICallBackContract>();

            List<EquipoSOA> equipos = new List<EquipoSOA>();
            foreach (KeyValuePair<Guid,ComputadorLogico> par in _estacion.Computadores)
            {
                ComputadorLogico pc=par.Value;
                equipos.Add(new EquipoSOA(pc.TipoDeEquipo, pc.Id, pc.X, pc.Y));
            }
            List<CableSOA> cables= new List<CableSOA>();
            foreach (KeyValuePair<Guid, CableDeRedLogico> par in _estacion.Cables)
            {
                CableDeRedLogico cable = par.Value;
                cables.Add(new CableSOA(cable.Id, cable.Puerto1.Id, cable.Puerto2.Id));                
            }
            cliente.ActualizarEstacion(equipos, cables);

		}





		public void Desconectar()
		{
			ICallBackContract cliente = OperationContext.Current.GetCallbackChannel<ICallBackContract>();
			_clientes.Remove(cliente);

		}



	

		private Dictionary<Guid, List<ICallBackContract>> _diccioMensajes = new Dictionary<Guid, List<ICallBackContract>>();
		public void PeticionEnviarInformacionConexion(Guid idConexion)
		{
			if (!_diccioMensajes.ContainsKey(idConexion))
			{
				_diccioMensajes.Add(idConexion, new List<ICallBackContract>());
			}
			_diccioMensajes[idConexion].Add(OperationContext.Current.GetCallbackChannel<ICallBackContract>());
            _estacion.EscucharPuerto(idConexion);
            _estacion.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
		}

        void OnFrameRecibido(object sender, FrameRecibidoEventArgs e)
        {
            CableDeRedLogico cable = (CableDeRedLogico)sender;
            string mensaje=e.FrameRecibido.Informacion.ToString();
            MACAddressSOA macOrigen=new MACAddressSOA(e.FrameRecibido.MACAddressOrigen);
            MACAddressSOA macDestino=new MACAddressSOA(e.FrameRecibido.MACAddressDestino);
            foreach (ICallBackContract cliente in _diccioMensajes[cable.Id])
            {
                cliente.EnviarInformacionConexion(cable.Id,mensaje,macOrigen,macDestino);
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
}
