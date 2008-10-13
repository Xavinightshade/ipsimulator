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
        }
        private int _destinationPort;

        public int DestinationPort
        {
            get { return _destinationPort; }
        }
        private byte[] _data;

        public byte[] Data
        {
            get { return _data; }
        }
        private int _dataLength;

        public int DataLength
        {
            get { return _dataLength; }
            set { _dataLength = value; }
        }
        public Segment(int sourcePort, int destinationPort, byte[] datos,int dataLength)
        {
            _sourcePort = sourcePort;
            _destinationPort = destinationPort;
            _data = datos;
            _dataLength = dataLength;
        }
    }
}
