using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using RedesIP.SOA.Elementos;
using SOA.Datos;

namespace RedesIP.SOA
{
	public interface IVisualizacion:ICallBackEstacion,ICallBackSniffer
	{
        void EstablecerDatosRouter(RouterSOA router);

        void EstablecerDatosSwitch(SwitchSOA swi);

        void EnviarCambioARP(Guid guid, ARP_SOA listARP);


        void EnviarInformacionEncapsulacionPC(Guid guid, FrameSOA frameSOA, PacketSOA packSOA, DateTime dateTime);

        void EnviarInformacionDesEncapsulacionPC(Guid guid, FrameSOA frameSOA, PacketSOA packSOA, DateTime dateTime);
    }
}
