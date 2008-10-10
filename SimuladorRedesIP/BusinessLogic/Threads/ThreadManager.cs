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
        private static  DateTime _horaInicial = DateTime.Now;
        private static TimeSpan _contador = TimeSpan.Zero;
        public static TimeSpan HoraActual
        {
            get
            {
                double miliSecondsElapsed = DateTime.Now.Subtract(_horaInicial).TotalMilliseconds * _constante;

                return _contador.Add(TimeSpan.FromMilliseconds(miliSecondsElapsed));            
            }
        }

        private static EventWaitHandle _waitHandle = new AutoResetEvent(false);
        private static Dictionary<Thread, EventWaitHandle> _threads = new Dictionary<Thread, EventWaitHandle>();
        private static Dictionary<Thread, bool> _threadsPausado = new Dictionary<Thread, bool>();


        public static void Sleep(int valor)
        {
            Thread current = Thread.CurrentThread;
            Console.WriteLine(current.ThreadState.ToString() + " " + current.ManagedThreadId.ToString());
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
            Thread.Sleep(valor * Constante);

        }
        public static int GetIntervalo(int valor)
        {
            return valor * _constante;
        }
        private static int _constante=1;
        public static int Constante
        {
            get { return _constante; }
            set
            {
                double miliSecondsElapsed = _contador.TotalMilliseconds / _constante;
                _contador = _contador.Add(TimeSpan.FromMilliseconds(miliSecondsElapsed));           
                _constante = value;
            
            }

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
