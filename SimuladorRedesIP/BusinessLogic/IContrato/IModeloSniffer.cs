using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace RedesIP.SOA
{
    public interface IModeloSniffer
    {

        [OperationContract()]
        void PeticionEnviarInformacionConexion(Guid idConexion);
    }
}
