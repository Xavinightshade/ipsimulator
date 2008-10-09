using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RedesIP;

namespace BusinessLogic.Threads
{
    public class ThreadManager
    {
        private static Random _r = new Random();
        private static EventWaitHandle _waitHandle = new AutoResetEvent(false);
        private static Dictionary<Thread, EventWaitHandle> _threads = new Dictionary<Thread, EventWaitHandle>();
        private static Dictionary<Thread, bool> _threadsPausado = new Dictionary<Thread, bool>();


        public static void Sleep()
        {
            Thread current = Thread.CurrentThread;
            Console.WriteLine(current.ThreadState.ToString()+" "+current.ManagedThreadId.ToString());
            if (!_threads.ContainsKey(current))
            {
                _threads.Add(current, new AutoResetEvent(false));
                _threadsPausado.Add(current, false);
            }
            if (_pausado)
            {
                _threadsPausado[current] = true;
                _threads[current].WaitOne();
            }
            Thread.Sleep(_r.Next(CalcularVelocidad(EstacionModelo.PorcentajeDeVelocidadSimulacion)));

        }
        private static int CalcularVelocidad(float porcentaje)
        {
            return 90;
            float m = (7000 - 10) / 100;
            return (int)(m * (100 - porcentaje) + 10);
        }
        private static bool _pausado;

        public static bool Pausado
        {
            get { return _pausado; }
            set
            {
                _pausado = value;
                if (!_pausado)
                {
                    foreach (KeyValuePair<Thread, EventWaitHandle> item in _threads)
                    {
                        if (_threadsPausado[item.Key])
                        {
                            _threadsPausado[item.Key] = false;
                            item.Value.Set();
                        }
                              

                        
                       
                    }
                }

            }
        }
    }
}
