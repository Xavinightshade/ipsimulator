using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Datos
{
    public class PingEventArgs : EventArgs
    {
        private bool _esReply;

        public bool EsReply
        {
            get { return _esReply; }
        }
        private string _ipOrigen;

        public string IpOrigen
        {
            get { return _ipOrigen; }
        }
        private TimeSpan _hora;

        public TimeSpan Hora
        {
            get { return _hora; }
        }

        public PingEventArgs(bool esReply,string ipOrigen, TimeSpan horaDeRecepcion)
        {
            _esReply = esReply;
            _ipOrigen = ipOrigen;
            _hora = horaDeRecepcion;
        }
    }
}
