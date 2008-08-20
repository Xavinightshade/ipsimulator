using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace RedesIP.SOA
{
    public interface ICallBackEstacion
    {
        [OperationContract(IsOneWay = true)]
		void CrearComputador(ComputadorSOA pc);
        [OperationContract(IsOneWay = true)]
        void CrearSwitch(SwitchSOA swi);
        [OperationContract(IsOneWay = true)]
        void CrearRouter(RouterSOA router);
		[OperationContract(IsOneWay = true)]
		void MoverEquipo(Guid idEquipo, int x, int y);
		[OperationContract(IsOneWay = true)]
		void ConectarPuertos(CableSOA cable);
        void EstablecerDatosPuertoBase(PuertoBaseSOA puerto);
        [OperationContract()]
        void EstablecerDatosPuertoCompleto(PuertoCompletoSOA puerto);
        [OperationContract(IsOneWay = true)]
		void ActualizarEstacion(EstacionSOA estacion);

    }
}
