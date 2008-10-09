using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Componentes;
using BusinessLogic.Modelos.Logicos.Datos;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Common;
using RedesIP.Modelos.Equipos.Componentes;
using SOA.Componentes;
using BusinessLogic.Datos;

namespace BusinessLogic.OSI
{
    public class CapaRedRouter : CapaRed
    {
        private RouterLogico _router;
        public CapaRedRouter(CapaDatos capaDatos, RouterLogico router)
            : base(capaDatos)
        {
            _router = router;
        }
        protected override void ProcesarPaquete(Packet paquete)
        {
            base.ProcesarPaquete(paquete);
            RoutesMessage mensajeRutas = paquete.Datos as RoutesMessage;
            if (mensajeRutas != null)
            {
                _router.RipV2.ProcesarRutas(mensajeRutas);
                return;
            }
            EntradaTablaRouter rutaInterna = _router.TablaDeRutas.BuscarRutaEnRutasInternas(paquete.IpDestino);
            if (rutaInterna != null)
            {
                _router.PuertoEthernetCapaRed[rutaInterna.Puerto].CapaDatos.EnviarPaquete(paquete, paquete.IpDestino);
                return;
            }
            EntradaTablaRouter rutaEstatica = _router.TablaDeRutas.BuscarPuertoEnRutasEstaticas(paquete.IpDestino);
            if (rutaEstatica!=null)
            {
                _router.PuertoEthernetCapaRed[rutaEstatica.Puerto].CapaDatos.EnviarPaquete(paquete, rutaEstatica.NextHopIP);

            }

        }

        public void EnviarRutas(List<RutaSOA> rutasTotales)
        {
            IPacketMessage mensajeRutas=new RoutesMessage(rutasTotales);
            Packet paqueteRutas=new Packet(CapaDatos.Puerto.IPAddress,IPAddressFactory.CalcularBroadCastAddress(),mensajeRutas);
            CapaDatos.EnviarPaquete(paqueteRutas, IPAddressFactory.CalcularBroadCastAddress());
        }
    }
}
