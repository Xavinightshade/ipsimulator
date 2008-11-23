﻿using System;
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
            _routeTable = routeTable;

        }
        private void Start()
        {
            if (_habilitado)
                return;
            _habilitado = true;
            _hiloDePublicacionTablas = new Thread(PublicarTablasDeRutas);
            _hiloDePublicacionTablas.IsBackground = true;
            _hiloDePublicacionTablas.Start();
        }
        private void Stop()
        {
            _habilitado = false;
            _controladorRutas.Stop();
        }
        private bool _habilitado;

        public bool Habilitado
        {
            get { return _habilitado; }
            set{
                if (value)
                {
                    Start();
                }
                else
                {
                    Stop();
                }
            }
        }
        private void PublicarTablasDeRutas()
        {
            while (_habilitado)
            {
                EnviarRutasPorPuertos();
                ThreadManager.Sleep(ThreadManager.GetIntervalo(30000));
            }

        }

        private void EnviarRutasPorPuertos()
        {
            List<RutaSOA> rutasTotales = _routeTable.GetRutasInternasYDinamicas();
            IncrementarHopCountDeRutas(rutasTotales);
            foreach (KeyValuePair<PuertoEthernetCompleto, CapaRedRouter> puertos in _puertos)
            {
                if (puertos.Key.Habilitado)
                {
                    puertos.Value.EnviarRutas(rutasTotales);
                }
            }
        }

        private void IncrementarHopCountDeRutas(List<RutaSOA> rutasTotales)
        {
            foreach (RutaSOA ruta in rutasTotales)
            {
                ruta.HopCount++;
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
                entrada.HopCount = ruta.HopCount;
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

        internal void Dispose()
        {
            _controladorRutas.Dispose();
        }
    }
}
