﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using RedesIP.SOA.Elementos;

namespace RedesIP.SOA
{
	public interface IVisualizacion:ICallBackEstacion,ICallBackSniffer
	{
        void EstablecerDatosRouter(RouterSOA router);

        void EstablecerDatosSwitch(SwitchSOA swi);

        void EnviarCambioARP(Guid guid, List<global::SOA.Datos.AsociacionIpMacSOA> listARP);
    }
}
