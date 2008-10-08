using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA.Elementos;
using System.ServiceModel;
using SOA.Datos;

namespace RedesIP.SOA
{
    public interface ICallBackSniffer
    {
        [OperationContract(IsOneWay = true)]
        void EnviarInformacionConexion(MensajeCableSOA mensaje);
        [OperationContract(IsOneWay = true)]
        void EliminarSnifferCable(Guid idCable);  
        [OperationContract(IsOneWay = true)]
        void EnviarInformacionEncapsulacionPC(EncapsulacionSOA encapsulacion);
        [OperationContract(IsOneWay = true)]
        void EnviarInformacionEncapsulacionRouter(EncapsulacionSOA encapsulacion);
        [OperationContract(IsOneWay = true)]
        void EnviarCambioARP(Guid idEquipo, ARP_SOA listARP);
        [OperationContract(IsOneWay = true)]
        void EnviarCambioDeTablaDeSwitch(MensajeSwitchTableSOA mensajeTablaSwitch);


    }
}
