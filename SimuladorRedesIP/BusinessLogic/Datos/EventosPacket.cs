using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Modelos.Logicos.Datos;

namespace BusinessLogic.Datos
{
    public class PaqueteRecibidoEventArgs : EventArgs
    {
        private Packet _paqueteRecibido;
        public Packet PaqueteRecibido
        {
            get { return _paqueteRecibido; }
        }
        private TimeSpan _horaDeRecepcion;
        public TimeSpan HoraDeRecepcion
        {
            get { return _horaDeRecepcion; }
        }

        public PaqueteRecibidoEventArgs(Packet paquete, TimeSpan horaDeRecepcion)
        {
           _paqueteRecibido=paquete;
            _horaDeRecepcion = horaDeRecepcion;
        }
    }

}
