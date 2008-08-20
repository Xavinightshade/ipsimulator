using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA.Elementos;
using System.ServiceModel;

namespace RedesIP.SOA
{
    public interface ICallBackSniffer
    {
        [OperationContract(IsOneWay = true)]
        void EnviarInformacionConexion(MensajeCableSOA mensaje);
    }
}
