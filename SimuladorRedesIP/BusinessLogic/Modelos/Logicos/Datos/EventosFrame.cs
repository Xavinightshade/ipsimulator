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


        public FrameTransmitidoEventArgs(Frame frame)
        {
            _frameTransmitido = frame;
        }
    }
    public class FrameRecibidoEventArgs : EventArgs
    {

        private Frame _frameRecibido;
        public Frame FrameRecibido
        {
            get { return _frameRecibido; }
        }


        public FrameRecibidoEventArgs(Frame frame)
        {
            _frameRecibido = frame;

        }
    }
}
