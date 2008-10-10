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
        ControladorRutasDinamicas _controladorRutas;
        public RIPV2(RouteTable routeTable, Dictionary<PuertoEthernetCompleto, CapaRedRouter> puertos)
        {
            _routeTable = routeTable;
            _controladorRutas = new ControladorRutasDinamicas(_routeTable.TablaRouterDinamico);

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
            foreach (KeyValuePair<PuertoEthernetCompleto, CapaRedRouter> puertos in _puertos)
            {
                if (puertos.Key.Habilitado)
                {
                    puertos.Value.EnviarRutas(rutasTotales);
                }
            }
        }

        internal void ProcesarRutas(RoutesMessage mensajeRutas, string nextHopIp, Guid idPuertoDondeSeRecibio)
        {
            IngresarEntradasDinamicas(mensajeRutas.RutasTotales, nextHopIp, idPuertoDondeSeRecibio);
        }
        private void IngresarEntradasDinamicas(List<RutaSOA> entradas, string nextHopIp, Guid idPuertoDondeSeRecibio)
        {
            PuertoEthernetCompleto puertoDondeSeRecibio = BuscarPuertoConId(idPuertoDondeSeRecibio);
            foreach (RutaSOA ruta in entradas)
            {
                EntradaTablaRouter entrada = new EntradaTablaRouter(ruta.Id);
                entrada.Mask = ruta.Mask;
                entrada.NextHopIP = nextHopIp;
                entrada.Puerto = puertoDondeSeRecibio;
                entrada.Red = ruta.Red;
                if (ExisteLaRuta(entrada, _routeTable.TablaRouterInternas))
                    continue;
                if (ExisteLaRuta(entrada, _routeTable.TablaRouterEstatico))
                    continue;
                _controladorRutas.NotificarEntrada(entrada);
            }
        }

        private bool ExisteLaRuta(EntradaTablaRouter entrada, List<EntradaTablaRouter> tabla)
        {
            foreach (EntradaTablaRouter entradaDinamica in tabla)
            {
                if (entradaDinamica.EsIgual(entrada))
                    return true;
            }
            return false;
        }
        private PuertoEthernetCompleto BuscarPuertoConId(Guid id)
        {
            foreach (KeyValuePair<PuertoEthernetCompleto,CapaRedRouter> puerto in _puertos)
            {
                if (puerto.Key.Id == id)
                {
                    return puerto.Key;
                }
            }
            throw new Exception();
        }
    }
}
