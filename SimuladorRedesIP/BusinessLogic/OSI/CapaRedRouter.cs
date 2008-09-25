using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Componentes;
using BusinessLogic.Modelos.Logicos.Datos;

namespace BusinessLogic.OSI
{
    public class CapaRedRouter:CapaRed
    {
        private RouteTable _tablaRouter;
        public CapaRedRouter(CapaDatos capaDatos,RouteTable tablaRouter)
            :base(capaDatos)
        {
            _tablaRouter = tablaRouter;
        }
        protected override void ProcesarPaquete(Packet paquete)
        {
            uint redPuerto = IPAddressFactory.GetRed(base.CapaDatos.Puerto.IPAddress, base.CapaDatos.Puerto.Mascara.Value);
            foreach (EntradaTablaRouter ruta in _tablaRouter.TablaRouter)
            {
                bool perteneceAlaRed = IPAddressFactory.PerteneceAlaRed(redPuerto, paquete.IpDestino);
                //CapaDatos.EnviarPaquete(paquete,);
            }
        }
    }
}
