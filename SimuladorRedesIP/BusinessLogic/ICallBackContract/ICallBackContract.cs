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
        [OperationContract(IsOneWay = true)]
        void EnviarCambioARP(Guid guid, ARP_SOA listARP);



        [OperationContract(IsOneWay = true)]
        void EnviarInformacionEncapsulacionPC(EncapsulacionSOA encapsulacion);
        [OperationContract(IsOneWay = true)]
        void EnviarInformacionEncapsulacionRouter(EncapsulacionSOA encapsulacion);
        [OperationContract(IsOneWay = true)]
        void DesconectarDeServidor();
    }
}
