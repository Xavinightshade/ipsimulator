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
	[ServiceContract(	 Name = "EstacionServer", SessionMode = SessionMode.Required, CallbackContract = typeof(IVisualizacion))]

	public interface IModeloSOA
	{
		[OperationContract()]
		void PeticionCrearComputador(ComputadorSOA computador);
        [OperationContract()]
        void PeticionCrearSwitch(SwitchSOA swi);
        [OperationContract()]
        void PeticionCrearRouter(RouterSOA router);
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
        void PeticionEstablecerDireccionIP(string ipAddress, Guid idPuerto);
		[OperationContract()]
		void PeticionEnviarInformacionConexion(Guid idConexion);
		[OperationContract()]
        float GetVelocidadSimulacion();
        [OperationContract()]
        void  SetVelocidadSimulacion(float valor);


	}










}
