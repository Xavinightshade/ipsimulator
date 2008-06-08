using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

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
		void ActualizarEstacion(List<EquipoSOA> equipos,List<ConexionSOA> conexiones);
	}
	[ServiceBehavior(
	 ConcurrencyMode = ConcurrencyMode.Single,
	 InstanceContextMode = InstanceContextMode.Single)]
	public class Contrato : IContract
	{
		private List<ICallBackContract> _clientes = new List<ICallBackContract>();
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
					equipo.AgregarPuerto(new PuertoSOA(Guid.NewGuid()));
					break;
				case TipoDeEquipo.Switch:
					for (int i = 0; i < 11; i++)
					{
						equipo.AgregarPuerto(new PuertoSOA(Guid.NewGuid()));
					}

					break;
				default:
					break;
			}
			_equipos.Add(equipo);
			
			foreach (ICallBackContract cliente in _clientes)
			{
				cliente.CrearEquipo(equipo);
			}

		}

		public void PeticionMoverEquipo(Guid idEquipo, int x, int y)
		{
			
			foreach (ICallBackContract cliente in _clientes)
			{
				cliente.MoverEquipo(idEquipo, x, y);
			}

		}

		public void PeticionConectarPuertos(Guid idPuerto1, Guid idPuerto2)
		{
			Guid idConexion = Guid.NewGuid();
			foreach (ICallBackContract cliente in _clientes)
			{
				ConexionSOA conexion = new ConexionSOA(idConexion, idPuerto1, idPuerto2);
				_conexiones.Add(conexion);
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
		public ConexionSOA(Guid id,Guid idPuerto1,Guid idPuerto2)
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
