using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using RedesIP.SOA.Elementos;
using SOA.Datos;

namespace RedesIP.SOA
{
	public interface IVisualizacion:ICallBackEstacion,ICallBackSniffer
	{
        [OperationContract(IsOneWay = true)]
        void EstablecerDatosRouter(RouterSOA router);
        [OperationContract(IsOneWay = true)]
        void EstablecerDatosSwitch(SwitchSOA swi);
        void DesconectarDeServidor();
        [OperationContract(IsOneWay = true)]
        void EliminarCable(Guid idCable);
        [OperationContract(IsOneWay = true)]
        void EliminarEquipo(Guid idEquipo);
    }
}
