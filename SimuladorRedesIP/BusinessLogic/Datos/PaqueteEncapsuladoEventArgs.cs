using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Modelos.Logicos.Datos;
using RedesIP.Modelos.Datos;

namespace BusinessLogic.Datos
{
    public class PaqueteEncapsuladoEventArgs:EventArgs
    {

        private DateTime _horaDeRecepcion;
        public DateTime HoraDeRecepcion
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

        public PaqueteEncapsuladoEventArgs(Frame frame, DateTime horaDeRecepcion)
        {
            _frame = frame;
            _horaDeRecepcion = horaDeRecepcion;
        }
    }

}
