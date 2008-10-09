using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using RedesIP.SOA;
using SOA.Componentes;

namespace RedesIP.SOA
{
    [ServiceContract(Name = "EstacionServer", SessionMode = SessionMode.Required, CallbackContract = typeof(ICallBackEstacion))]

    public interface IModeloEstacion
    {
        [OperationContract()]
        void PeticionCrearComputador(ComputadorSOA computador);
        [OperationContract()]
        void PeticionCrearSwitch(SwitchSOA swi);
        [OperationContract()]
        void PeticionCrearRouter(RouterSOA router);
        [OperationContract()]
        void PeticionMoverEquipo(Guid idEquipo, int x, int y);
        [OperationContract()]
        void PeticionConectarPuertos(Guid idPuerto1, Guid idPuerto2);
        [OperationContract()]
        void PeticionActualizarEstacion();
        [OperationContract()]
        void PeticionEstablecerDatosPuertoBase(PuertoBaseSOA puerto);
        [OperationContract()]
        void PeticionEstablecerDatosPuertoCompleto(PuertoCompletoSOA puerto);
        [OperationContract()]
        void PeticionEstablecerDatosComputador(ComputadorSOA pcSOA);
        [OperationContract()]
        void Ping(Guid idEquipo, string ipDestino);
        [OperationContract()]
        List<RutaSOA> TraerRutas(Guid idRouter);
        [OperationContract()]
        void ActualizarRutas(Guid IdRouter, List<RutaSOA> rutas);
        [OperationContract()]
        void PeticionEstablecerDatosRouter(RouterSOA router);

    }
}
