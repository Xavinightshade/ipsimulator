using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.SOA;
using SOA.Datos;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferPuertoCompleto:ModeloSnifferBase
    {
                private PuertoEthernetCompleto _puerto;
        public ModeloSnifferPuertoCompleto(PuertoEthernetCompleto puerto)
        {
            _puerto = puerto;
            EscucharARP();
        }

        private void EscucharARP()
        {
            _puerto.Arp.CambioDeTablaArp += new EventHandler<TiempoEventArgs>(Arp_CambioDeTablaArp);
        }

       private void Arp_CambioDeTablaArp(object sender, TiempoEventArgs e)
        {
            ARP_SOA arp = new ARP_SOA();
            arp.Fecha = e.HoraDeRecepcion;
            foreach (KeyValuePair<string,string> asociacionIP_MAC in _puerto.Arp.IP_To_MAC)
            {
                AsociacionIpMacSOA asoc = new AsociacionIpMacSOA();
                asoc.Ip = asociacionIP_MAC.Key;
                asoc.MacAddress = asociacionIP_MAC.Value;
                arp.Asociaciones.Add(asoc);
            }
            foreach (IVisualizacion vist in Vistas)
            {
                vist.EnviarCambioARP(_puerto.Id, arp);

            }
        }


    }
}
