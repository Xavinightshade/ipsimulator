using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using RedesIP.Modelos.Datos;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Modelos;
using RedesIP.Modelos.Equipos.Componentes;

namespace RedesIP.SOA
{
	[ServiceContract(
	 Name = "EstacionServer",
	 SessionMode = SessionMode.Required,
	 CallbackContract = typeof(ICallBackContract))]
	public interface IContract
	{
		[OperationContract()]
		void PeticionCrearEquipo(TipoDeEquipo tipoEquipo, int x, int y);
		[OperationContract()]
		void Conectar();
		[OperationContract()]
		void Desconectar();
		[OperationContract()]
		void PeticionMoverEquipo(Guid idEquipo, int x, int y);
		[OperationContract()]
		void PeticionConectarPuertos(Guid idPuerto1, Guid idPuerto2);
		[OperationContract()]
		void PeticionActualizarEstacion();
		[OperationContract()]
		void PeticionEnviarInformacionConexion(Guid idConexion);
		[OperationContract()]
		void Ping(Guid idComputador,string mensaje,byte p1,byte p2,byte p3);
		[OperationContract()]
		void PeticionDeDireccionMAC(Guid idPuerto);

		[OperationContract()]
		void CambiarVelocidad(float percent);


	}
	public interface ICallBackContract
	{
		[OperationContract(IsOneWay = true)]
		void CrearEquipo(EquipoSOA equipo);
		[OperationContract(IsOneWay = true)]
		void MoverEquipo(Guid idEquipo, int x, int y);
		[OperationContract(IsOneWay = true)]
		void ConectarPuertos(ConexionSOA conexion);
		[OperationContract(IsOneWay = true)]
		void ActualizarEstacion(List<EquipoSOA> equipos, List<ConexionSOA> conexiones);

		[OperationContract(IsOneWay = true)]
		void EnviarInformacionConexion(Guid idConexion, string info);
	}
	[ServiceBehavior(
	 ConcurrencyMode = ConcurrencyMode.Single,
	 InstanceContextMode = InstanceContextMode.Single)]
	public class Contrato : IContract
	{
		private static float _porcentaje=50;

		public static float Porcentaje
		{
			get { return Contrato._porcentaje; }
			set { Contrato._porcentaje = value; }
		}


		private Dictionary<Guid, ComputadorLogico> _computadores = new Dictionary<Guid, ComputadorLogico>();
		private List<SwitchLogico> _switches = new List<SwitchLogico>();
		private Dictionary<Guid, CableDeRedLogico> _diccioCables = new Dictionary<Guid, CableDeRedLogico>();

		private Dictionary<Guid, PuertoEthernetLogico> _puertos = new Dictionary<Guid, PuertoEthernetLogico>();


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
					_computadores.Add(pc.Id,pc);
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



		#region IContract Members


		public void PeticionActualizarEstacion()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IContract Members


		public void Conectar()
		{
			RegistrarCliente();
			ICallBackContract cliente = OperationContext.Current.GetCallbackChannel<ICallBackContract>();
			cliente.ActualizarEstacion(_equipos, _conexiones);

		}

		#endregion

		#region IContract Members


		public void Desconectar()
		{
			ICallBackContract cliente = OperationContext.Current.GetCallbackChannel<ICallBackContract>();
			_clientes.Remove(cliente);

		}

		#endregion

		#region IContract Members

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
				cliente.EnviarInformacionConexion(cable.Id, e.FrameTransmitido.ToString()+"    a las: "+DateTime.Now.ToString());
			}
		}



		#endregion

		#region IContract Members


		public void Ping(Guid idComputador,string mensaje, byte p1, byte p2, byte p3)
		{
							_computadores[idComputador].EnviarMensajeDeTexto(mensaje, MACAddress.Direccion(p1, p2, p3));

			
		}

		#endregion

		#region IContract Members


		public void PeticionDeDireccionMAC(Guid idPuerto)
		{
			Console.WriteLine("la direc es: "+ _puertos[idPuerto].MACAddress.ToString());
		}

		#endregion

		#region IContract Members


		public void CambiarVelocidad(float percent)
		{
			_porcentaje = percent;
		}

		#endregion
	}

	[DataContract]
	public class ConexionSOA
	{
		private Guid _id;
		[DataMember]
		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}
		private Guid _idPuerto1;
		[DataMember]
		public Guid IdPuerto1
		{
			get { return _idPuerto1; }
			set { _idPuerto1 = value; }
		}
		private Guid _idPuerto2;
		[DataMember]
		public Guid IdPuerto2
		{
			get { return _idPuerto2; }
			set { _idPuerto2 = value; }
		}
		public ConexionSOA(Guid id, Guid idPuerto1, Guid idPuerto2)
		{
			_id = id;
			_idPuerto1 = idPuerto1;
			_idPuerto2 = idPuerto2;
		}
	}

	[DataContract]
	public class EquipoSOA
	{
		private Guid _id;
		private int _x;
		[DataMember]
		public int X
		{
			get { return _x; }
			set { _x = value; }
		}
		private int _y;
		[DataMember]

		public int Y
		{
			get { return _y; }
			set { _y = value; }
		}
		private TipoDeEquipo _tipoEquipo;
		[DataMember]

		public TipoDeEquipo TipoEquipo
		{
			get { return _tipoEquipo; }
			set { _tipoEquipo = value; }
		}
		[DataMember]

		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private List<PuertoSOA> _puertos = new List<PuertoSOA>();
		[DataMember]
		public List<PuertoSOA> Puertos
		{
			get { return _puertos; }
			set { _puertos = value; }
		}

		public void AgregarPuerto(PuertoSOA puerto)
		{
			_puertos.Add(puerto);
		}
		public EquipoSOA(TipoDeEquipo tipoEquipo, Guid id, int x, int y)
		{
			_tipoEquipo = tipoEquipo;
			_x = x;
			_y = y;
			_id = id;

		}


	}

	[DataContract]
	public class PuertoSOA
	{
		private Guid _id;
		[DataMember]
		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}
		public PuertoSOA(Guid id)
		{
			_id = id;
		}
	}



}
