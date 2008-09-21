using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace RedesIP.SOA
{
    [ServiceContract(Name = "EstacionServer", SessionMode = SessionMode.Required, CallbackContract = typeof(IVisualizacion))]

    public interface IModeloSniffer
    {

        [OperationContract()]
        void PeticionEnviarInformacionConexion(Guid idConexion);
        [OperationContract()]
        void PeticionEnviarInformacionSwitch(Guid idSwitch);
    }
}
