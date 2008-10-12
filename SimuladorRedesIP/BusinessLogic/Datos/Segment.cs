using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Datos
{
    public abstract class Segment:IPacketMessage
    {
        private int _sourcePort;

        public int SourcePort
        {
            get { return _sourcePort; }
            set { _sourcePort = value; }
        }
        private int _destinationPort;

        public int DestinationPort
        {
            get { return _destinationPort; }
            set { _destinationPort = value; }
        }
        private byte[] _data;

        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public Segment(int sourcePort, int destinationPort, byte[] datos)
        {
            _sourcePort = sourcePort;
            _destinationPort = destinationPort;
            _data = datos;
        }
    }
}
