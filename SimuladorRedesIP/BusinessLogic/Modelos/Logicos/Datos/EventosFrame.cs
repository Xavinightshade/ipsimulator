using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesIP.Modelos.Datos
{
    public class FrameTransmitidoEventArgs : EventArgs
    {
        private Frame _frameTransmitido;
        public Frame FrameTransmitido
        {
            get { return _frameTransmitido; }
        }
        private DateTime _horaDeTransmision;

        public DateTime HoraDeTransmision
        {
            get { return _horaDeTransmision; }
        }

        public FrameTransmitidoEventArgs(Frame frame,DateTime horaTransmision)
        {
            _frameTransmitido = frame;
            _horaDeTransmision = horaTransmision;
        }
    }
    public class FrameRecibidoEventArgs : EventArgs
    {

        private Frame _frameRecibido;
        public Frame FrameRecibido
        {
            get { return _frameRecibido; }
        }
        private DateTime _horaDeRecepcion;
        public DateTime HoraDeRecepcion
        {
            get { return _horaDeRecepcion; }
        }

        public FrameRecibidoEventArgs(Frame frame,DateTime horaDeRecepcion)
        {
            _frameRecibido = frame;
            _horaDeRecepcion = horaDeRecepcion;

        }
    }
}
