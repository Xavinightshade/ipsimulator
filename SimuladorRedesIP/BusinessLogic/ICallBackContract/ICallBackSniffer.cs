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
        void EliminarSnifferPC(Guid idPc);
        [OperationContract(IsOneWay = true)]
        void EliminarSnifferSwitch(Guid idSwitch);
        [OperationContract(IsOneWay = true)]
        void EliminarSnifferRouter(Guid idRouter);
        [OperationContract(IsOneWay = true)]
        void EliminarSnifferPuerto(Guid idPuerto);
        [OperationContract(IsOneWay = true)]
        void EnviarInformacionEncapsulacionPC(EncapsulacionSOA encapsulacion);
        [OperationContract(IsOneWay = true)]
        void EnviarInformacionSegmentoEnviados(Guid idPC, TCPSegmentSOA segment);
        [OperationContract(IsOneWay = true)]
        void EnviarInformacionSegmentoRecibido(Guid idPC, TCPSegmentSOA segment);
        [OperationContract(IsOneWay = true)]
        void EnviarInformacionEncapsulacionRouter(EncapsulacionSOA encapsulacion);
        [OperationContract(IsOneWay = true)]
        void EnviarCambioARP(Guid idEquipo, ARP_SOA listARP);
        [OperationContract(IsOneWay = true)]
        void EnviarCambioDeTablaDeSwitch(MensajeSwitchTableSOA mensajeTablaSwitch);


    }
}
