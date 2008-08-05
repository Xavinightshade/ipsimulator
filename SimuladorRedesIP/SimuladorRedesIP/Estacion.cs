using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Modelos;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.SOA;
using RedesIP.Modelos.Datos;

namespace RedesIP
{
	[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
	public class Estacion : IContract
	{
		private static float _porcentajeDeVelocidad = 50;

		public static float PorcentajeDeVelocidad
		{
			get { return Estacion._porcentajeDeVelocidad; }
			set { Estacion._porcentajeDeVelocidad = value; }
		}

        /// <summary>
        /// Computadores de la red
        /// </summary>
		private Dictionary<Guid, ComputadorLogico> _computadores = new Dictionary<Guid, ComputadorLogico>();
        /// <summary>
        /// Switches de la red
        /// </summary>
		private List<SwitchLogico> _switches = new List<SwitchLogico>();
        /// <summary>
        /// Cables de la red
        /// </summary>
		private Dictionary<Guid, CableDeRedLogico> _diccioCables = new Dictionary<Guid, CableDeRedLogico>();
        /// <summary>
        /// Puertos Logicos de la red
        /// </summary>
		private Dictionary<Guid, PuertoEthernetLogico> _puertos = new Dictionary<Guid, PuertoEthernetLogico>();

        /// <summary>
        /// Lista de clientes de la red
        /// </summary>
		private List<ICallBackContract> _clientes = new List<ICallBackContract>();
		private Dictionary<Guid, EquipoSOA> _diccioEquipos = new Dictionary<Guid, EquipoSOA>();
		private void RegistrarCliente()
		{
			ICallBackContract cliente = OperationContext.Current.GetCallbackChannel<ICallBackContract>();
			if (_clientes.Contains(cliente))
				return;
			_clientes.Add(cliente);
		}
		private List<EquipoSOA> _equipos = new List<EquipoSOA>();
		private List<ConexionSOA> _conexiones = new List<ConexionSOA>();
		public void PeticionCrearEquipo(TipoDeEquipo tipoEquipo, int x, int y)
		{
			EquipoSOA equipo = new EquipoSOA(tipoEquipo, Guid.NewGuid(), x, y);
			switch (tipoEquipo)
			{
				case TipoDeEquipo.Ninguno:
					break;
				case TipoDeEquipo.Computador:
					ComputadorLogico pc = new ComputadorLogico("nombre", MACAddress.New());
					equipo.Id = pc.Id;
					_computadores.Add(pc.Id, pc);
					_puertos.Add(pc.PuertoEthernet.Id, pc.PuertoEthernet);
					equipo.AgregarPuerto(new PuertoSOA(pc.PuertoEthernet.Id));
					break;
				case TipoDeEquipo.Switch:
					SwitchLogico swi = new SwitchLogico(11);
					equipo.Id = swi.Id;
					for (int i = 0; i < 11; i++)
					{
						equipo.AgregarPuerto(new PuertoSOA(swi.PuertosEthernet[i].Id));
						_puertos.Add(swi.PuertosEthernet[i].Id, swi.PuertosEthernet[i]);
					}

					break;
				default:
					break;
			}
			_equipos.Add(equipo);
			_diccioEquipos.Add(equipo.Id, equipo);

			foreach (ICallBackContract cliente in _clientes)
			{
				cliente.CrearEquipo(equipo);
			}

		}

		public void PeticionMoverEquipo(Guid idEquipo, int x, int y)
		{
			_diccioEquipos[idEquipo].X = x;
			_diccioEquipos[idEquipo].Y = y;

			foreach (ICallBackContract cliente in _clientes)
			{
				cliente.MoverEquipo(idEquipo, x, y);
			}

		}

		public void PeticionConectarPuertos(Guid idPuerto1, Guid idPuerto2)
		{
			CableDeRedLogico conexionLogica = new CableDeRedLogico(_puertos[idPuerto1], _puertos[idPuerto2]);
			_diccioCables.Add(conexionLogica.Id, conexionLogica);
			ConexionSOA conexion = new ConexionSOA(conexionLogica.Id, idPuerto1, idPuerto2);
			_conexiones.Add(conexion);
			foreach (ICallBackContract cliente in _clientes)
			{
				cliente.ConectarPuertos(conexion);
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
			cliente.ActualizarEstacion(_equipos, _conexiones);

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
			_diccioCables[idConexion].FrameTransmitidoPuerto1 += new EventHandler<FrameTransmitidoEventArgs>(Contrato_FrameTransmitidoPuerto1);
			_diccioCables[idConexion].FrameTransmitidoPuerto2 += new EventHandler<FrameTransmitidoEventArgs>(Contrato_FrameTransmitidoPuerto2);
		}

		void Contrato_FrameTransmitidoPuerto2(object sender, FrameTransmitidoEventArgs e)
		{
			CableDeRedLogico cable = (CableDeRedLogico)sender;
			foreach (ICallBackContract cliente in _diccioMensajes[cable.Id])
			{
				cliente.EnviarInformacionConexion(cable.Id, e.FrameTransmitido.ToString());
			}
		}

		void Contrato_FrameTransmitidoPuerto1(object sender, FrameTransmitidoEventArgs e)
		{
			CableDeRedLogico cable = (CableDeRedLogico)sender;
			foreach (ICallBackContract cliente in _diccioMensajes[cable.Id])
			{
				cliente.EnviarInformacionConexion(cable.Id, e.FrameTransmitido.ToString() + "    a las: " + DateTime.Now.ToString());
			}
		}








		public void Ping(Guid idComputador, string mensaje, byte p1, byte p2, byte p3)
		{
			_computadores[idComputador].EnviarMensajeDeTexto(mensaje, MACAddress.Direccion(p1, p2, p3));


		}




		public void PeticionDeDireccionMAC(Guid idPuerto)
		{
			Console.WriteLine("la direc es: " + _puertos[idPuerto].MACAddress.ToString());
		}






		public void CambiarVelocidad(float percent)
		{
			_porcentajeDeVelocidad = percent;
		}


	}
}
