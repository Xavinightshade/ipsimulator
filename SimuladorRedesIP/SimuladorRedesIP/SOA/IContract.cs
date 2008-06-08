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
		void PeticionMoverEquipo(Guid idEquipo, int x, int y);
		[OperationContract()]
		void PeticionConectarPuertos(Guid idPuerto1, Guid idPuerto2);

	}
	public interface ICallBackContract
	{
		[OperationContract(IsOneWay = true)]
		void CrearEquipo(EquipoSOA equipo);
		[OperationContract(IsOneWay = true)]
		void MoverEquipo(Guid idEquipo, int x, int y);
		[OperationContract(IsOneWay = true)]
		void ConectarPuertos(Guid idConexion,Guid idPuerto1, Guid idPuerto2);
	}
	[ServiceBehavior(
	 ConcurrencyMode = ConcurrencyMode.Single,
	 InstanceContextMode = InstanceContextMode.PerCall)]
	public class Contrato : IContract
	{
		List<ICallBackContract> _clientes = new List<ICallBackContract>();
		public void RegistrarCliente(ICallBackContract cliente)
		{

			_clientes.Add(cliente);
		}
		public void PeticionCrearEquipo(TipoDeEquipo tipoEquipo, int x, int y)
		{
			EquipoSOA equipo = new EquipoSOA(tipoEquipo,Guid.NewGuid(), x, y);
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
				cliente.ConectarPuertos(idConexion, idPuerto1, idPuerto2);
			}
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
		public EquipoSOA(TipoDeEquipo tipoEquipo,Guid id,int x,int y)
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
