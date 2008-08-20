using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using RedesIP.SOA;

namespace RedesIP
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class PresenterSOA : PresenterBase
    {
        public PresenterSOA()
        {

        }
        protected override IVisualizacion GetCurrentClient()
        {
            return OperationContext.Current.GetCallbackChannel<IVisualizacion>();
        }


    }
}
