using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BusinessLogic.Componentes;
using BusinessLogic.Threads;
using RedesIP.Modelos.Equipos.Componentes;
using BusinessLogic.OSI;
using SOA.Componentes;
using BusinessLogic.Datos;

namespace BusinessLogic.Protocolos
{
    public class RIPV2
    {
        Thread _hiloDePublicacionTablas;
        RouteTable _routeTable;
        Dictionary<PuertoEthernetCompleto, CapaRedRouter> _puertos;
        public RIPV2(RouteTable routeTable,Dictionary<PuertoEthernetCompleto, CapaRedRouter> puertos )
        {
            _routeTable = routeTable;
            _puertos = puertos;
            _hiloDePublicacionTablas = new Thread(PublicarTablasDeRutas);
            _hiloDePublicacionTablas.IsBackground = true;
            _routeTable = routeTable;
           
        }
        public void Inicializar()
        {
            _hiloDePublicacionTablas.Start();
        }

        private void PublicarTablasDeRutas()
        {
            do
            {
                EnviarRutasPorPuertos();
                ThreadManager.Sleep(30000);
            } while (true);
            
        }

        private void EnviarRutasPorPuertos()
        {
            List<RutaSOA> rutasTotales = _routeTable.GetAllRutas();
            foreach (KeyValuePair<PuertoEthernetCompleto,CapaRedRouter> puertos in _puertos)
            {
                puertos.Value.EnviarRutas(rutasTotales);
            }
        }

        internal void ProcesarRutas(RoutesMessage mensajeRutas)
        {
            throw new NotImplementedException();
        }
    }
}
