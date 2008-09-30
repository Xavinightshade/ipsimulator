using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.SOA;
using SOA.Datos;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferPuertoCompleto
    {
                private PuertoEthernetCompleto _puerto;
        private List<IVisualizacion> _vistas;
        public ModeloSnifferPuertoCompleto(PuertoEthernetCompleto puerto, List<IVisualizacion> vistas)
        {
            _puerto = puerto;
            _vistas = vistas;
            EscucharARP();
        }
        private void EscucharARP()
        {
            _puerto.Arp.CambioDeTablaArp += new EventHandler<TiempoEventArgs>(Arp_CambioDeTablaArp);
        }

       private void Arp_CambioDeTablaArp(object sender, TiempoEventArgs e)
        {
            List<AsociacionIpMacSOA> listARP = new List<AsociacionIpMacSOA>();
            foreach (KeyValuePair<string,string> asociacionIP_MAC in _puerto.Arp.IP_To_MAC)
            {
                AsociacionIpMacSOA asoc = new AsociacionIpMacSOA();
                asoc.Ip = asociacionIP_MAC.Key;
                asoc.MacAddress = asociacionIP_MAC.Value;
                listARP.Add(asoc);
            }
            foreach (IVisualizacion vist in _vistas)
            {
                vist.EnviarCambioARP(_puerto.Id, listARP);

            }
        }


    }
}
