using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using RedesIP.SOA;

namespace RedesIP.SOA
{
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
        void PeticionEstablecerDireccionIP(string ipAddress, Guid idPuerto);
        [OperationContract()]
        void Ping(Guid idEquipo, string ipDestino, string datos);
    }
}
