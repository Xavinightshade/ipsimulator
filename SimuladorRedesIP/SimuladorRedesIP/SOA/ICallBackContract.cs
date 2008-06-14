using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace RedesIP.SOA
{
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
}
