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
	[ServiceContract(	 Name = "EstacionServer", SessionMode = SessionMode.Required, CallbackContract = typeof(ICallBackContract))]

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
        float GetVelocidadSimulacion();
        [OperationContract()]
        void  SetVelocidadSimulacion(float valor);


	}










}
