using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Componentes;
using BusinessLogic.Modelos.Logicos.Datos;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Common;

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
            foreach (EntradaTablaRouter ruta in _router.TablaDeRutas.TablaRouter)
            {      

                bool perteneceAlaRed = IPAddressFactory.PerteneceAlaRed(ruta.Red, paquete.IpDestino);
                if (perteneceAlaRed)
                {
                    _router.PuertoEthernetCapaRed[ruta.Puerto].CapaDatos.EnviarPaqueteDirecto(paquete, MACAddressFactory.BroadCast);
                }
            }
        }
    }
}
