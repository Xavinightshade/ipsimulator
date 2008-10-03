using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.SOA;
using RedesIP.Modelos.Equipos.Componentes;
using BusinessLogic.OSI;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferRouter
    {
        private RouterLogico _router;
        private List<IVisualizacion> _vistas;
        public ModeloSnifferRouter(RouterLogico router, List<IVisualizacion> vistas)
        {
          _router=router;
            _vistas = vistas;
            EscucharEventos();
        }
        private void EscucharEventos()
        {
            foreach (KeyValuePair<PuertoEthernetCompleto, CapaRedRouter> item in _router.PuertoEthernetCapaRed)
            {
                item.Value.CapaDatos.PaqueteDesEncapsulado += new EventHandler<BusinessLogic.Datos.PaqueteDesencapsuladoEventArgs>(CapaDatos_PaqueteDesEncapsulado);
                item.Value.CapaDatos.PaqueteEncapsulado += new EventHandler<BusinessLogic.Datos.PaqueteEncapsuladoEventArgs>(CapaDatos_PaqueteEncapsulado);
            }
        }

        void CapaDatos_PaqueteEncapsulado(object sender, BusinessLogic.Datos.PaqueteEncapsuladoEventArgs e)
        {
            throw new NotImplementedException();
        }

        void CapaDatos_PaqueteDesEncapsulado(object sender, BusinessLogic.Datos.PaqueteDesencapsuladoEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
