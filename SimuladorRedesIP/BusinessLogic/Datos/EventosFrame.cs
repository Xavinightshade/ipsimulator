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
        private TimeSpan _horaDeTransmision;

        public TimeSpan HoraDeTransmision
        {
            get { return _horaDeTransmision; }
        }

        public FrameTransmitidoEventArgs(Frame frame,TimeSpan horaTransmision)
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
        private TimeSpan _horaDeRecepcion;
        public TimeSpan HoraDeRecepcion
        {
            get { return _horaDeRecepcion; }
        }

        public FrameRecibidoEventArgs(Frame frame,TimeSpan horaDeRecepcion)
        {
            _frameRecibido = frame;
            _horaDeRecepcion = horaDeRecepcion;

        }
    }
}
public class TiempoEventArgs : EventArgs
{


    private TimeSpan _horaDeRecepcion;
    public TimeSpan HoraDeRecepcion
    {
        get { return _horaDeRecepcion; }
    }

    public TiempoEventArgs(TimeSpan horaDeRecepcion)
    {
        _horaDeRecepcion = horaDeRecepcion;

    }
}
