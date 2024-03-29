﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using BusinessLogic.Threads;

namespace BusinessLogic.Componentes
{
    public class ControladorRutasDinamicas
    {
        private List<EntradaTablaRouter> _tablaDinamica;
        private Dictionary<Timer, EntradaTablaRouter> _entradas = new Dictionary<Timer, EntradaTablaRouter>();
        private Dictionary<EntradaTablaRouter, Timer> _timers = new Dictionary<EntradaTablaRouter, Timer>();

        public ControladorRutasDinamicas(List<EntradaTablaRouter> tablaDinamica)
        {
            _tablaDinamica = tablaDinamica;
        }

        internal void NotificarEntrada(EntradaTablaRouter entrada)
        {
            foreach (EntradaTablaRouter entradaTabla in _tablaDinamica)
            {
                if (entradaTabla.EsIgual(entrada))
                {
                    if (entrada.HopCount >= entradaTabla.HopCount)
                    {
                        _timers[entradaTabla].Stop();
                        _timers[entradaTabla].Start();
                        return;
                    }
                }
            }
            _tablaDinamica.Add(entrada);
            Timer timer = new Timer(ThreadManager.GetIntervalo(30000));
            _timers.Add(entrada, timer);
            _entradas.Add(timer, entrada);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();


        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Timer timer = (Timer)sender;
            timer.Stop();
            timer.Elapsed -= new ElapsedEventHandler(timer_Elapsed);
            EntradaTablaRouter entrada=_entradas[timer];
            _entradas.Remove(timer);
            _timers.Remove(entrada);
            _tablaDinamica.Remove(entrada);

        }

        internal void Stop()
        {
            foreach (KeyValuePair<Timer,EntradaTablaRouter> item in _entradas)
            {
                Timer timer = item.Key;
                timer.Stop();
                timer.Elapsed -= new ElapsedEventHandler(timer_Elapsed);
            }
            _entradas.Clear();
            _tablaDinamica.Clear();
            _timers.Clear();
        }

        internal void Dispose()
        {
        }
    }
}
