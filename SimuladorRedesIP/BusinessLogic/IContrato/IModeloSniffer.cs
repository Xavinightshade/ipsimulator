using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace RedesIP.SOA
{
    [ServiceContract(Name = "EstacionServer", SessionMode = SessionMode.Required, CallbackContract = typeof(ICallBackSniffer))]

    public interface IModeloSniffer
    {

        [OperationContract()]
        void PeticionEnviarInformacionConexion(Guid idConexion);
        [OperationContract()]
        void PeticionPararDeEnviarInformacionConexion(Guid idConexion);
        [OperationContract()]
        void PeticionEnviarInformacionSwitch(Guid idSwitch);
        [OperationContract()]
        void PeticionEnviarInformacionPuertoCompleto(Guid idPuerto);
        [OperationContract()]
        void PeticionEnviarInformacionPC(Guid idPC);
        [OperationContract()]
        void PeticionEnviarInformacionRouter(Guid idRouter);
    }
}
