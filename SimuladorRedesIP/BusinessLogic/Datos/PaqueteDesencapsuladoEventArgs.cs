using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Datos;
using BusinessLogic.Modelos.Logicos.Datos;

namespace BusinessLogic.Datos
{
   public class PaqueteDesencapsuladoEventArgs:EventArgs
    {
               private TimeSpan _horaDeRecepcion;
        public TimeSpan HoraDeRecepcion
        {
            get { return _horaDeRecepcion; }
        }
        private Frame _frame;
        public Frame Frame
        {
            get { return _frame; }
        }
        public Packet Paquete
        {
            get { return _frame.Informacion as Packet; }
        }

        public PaqueteDesencapsuladoEventArgs(Frame frame, TimeSpan horaDeRecepcion)
        {
            _frame = frame;
            _horaDeRecepcion = horaDeRecepcion;
        }
    }
}
