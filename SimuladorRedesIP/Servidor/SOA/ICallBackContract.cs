using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using RedesIP.SOA.Elementos;

namespace RedesIP.SOA
{
	public interface ICallBackContract
	{
		[OperationContract(IsOneWay = true)]
		void CrearEquipo(EquipoSOA equipo);
		[OperationContract(IsOneWay = true)]
		void MoverEquipo(Guid idEquipo, int x, int y);
		[OperationContract(IsOneWay = true)]
		void ConectarPuertos(CableSOA cable);
		[OperationContract(IsOneWay = true)]
		void ActualizarEstacion(List<EquipoSOA> equipos, List<CableSOA> cables);
		[OperationContract(IsOneWay = true)]
		void EnviarInformacionConexion(MensajeSOA mensaje);
	}
}
