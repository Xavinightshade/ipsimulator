using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Componentes;
using BusinessLogic.Modelos.Logicos.Datos;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Common;
using RedesIP.Modelos.Equipos.Componentes;

namespace BusinessLogic.OSI
{
    public class CapaRedRouter:CapaRed
    {
        private RouterLogico _router;
        public CapaRedRouter(CapaDatos capaDatos,RouterLogico router)
            :base(capaDatos)
        {
            _router = router;
        }
        protected override void ProcesarPaquete(Packet paquete)
        {
            base.ProcesarPaquete(paquete);
            PuertoEthernetCompleto puerto=_router.TablaDeRutas.BuscarPuertoDeLaRed(paquete.IpDestino);
            _router.PuertoEthernetCapaRed[puerto].CapaDatos.EnviarPaquete(paquete, paquete.IpDestino);

            //foreach (EntradaTablaRouter ruta in _router.TablaDeRutas.TablaRouter)
            //{      

            //    bool perteneceAlaRed = IPAddressFactory.PerteneceAlaRed(ruta.Red, paquete.IpDestino);
            //    if (perteneceAlaRed)
            //    {
            //        _router.PuertoEthernetCapaRed[ruta.Puerto].CapaDatos.EnviarPaqueteDirecto(paquete, MACAddressFactory.BroadCast);
            //    }
            //}
        }
    }
}
