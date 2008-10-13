using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Datos
{
    public class TCPSegment : Segment
    {
        public TCPSegment(int sourcePort, int destinationPort, byte[] datos, int dataLength)
            : base(sourcePort, destinationPort, datos,dataLength)
        {

        }
        private bool _synFlag;

        public bool SYN_Flag
        {
            get { return _synFlag; }
            set { _synFlag = value; }
        }
        private bool _ackFlag;
        private bool _finFlag;

        public bool FinFlag
        {
            get { return _finFlag; }
            set { _finFlag = value; }
        }
        public bool ACK_Flag
        {
            get { return _ackFlag; }
            set { _ackFlag = value; }
        }
        private uint _seqNumber;

        public uint SEQ_Number
        {
            get { return _seqNumber; }
            set { _seqNumber = value; }
        }
        private uint _ackNumber;

        public uint ACK_Number
        {
            get { return _ackNumber; }
            set { _ackNumber = value; }
        }
        private int _segmentSize;
        public int SegmentSize
        {
            get { return _segmentSize; }
            set { _segmentSize = value; }
        }
        private int _windowsSize;

        public int WindowsSize
        {
            get { return _windowsSize; }
            set { _windowsSize = value; }
        }
        public override string ToString()
        {
            string texto = string.Empty;
            texto += "Puerto Origen:" + SourcePort.ToString() + " , ";
            texto += "Puerto Destino:" + DestinationPort.ToString() + " , ";
            texto += "SYN:" + ConvertirValor(_synFlag).ToString() + " , ";
            texto += "ACK:" + ConvertirValor(_ackFlag).ToString() + " , ";
            texto += "SEQ Number:" + _seqNumber.ToString() + " , ";
            texto += "ACK Number:" + _ackNumber.ToString();
            return texto;
            
        }
        private int ConvertirValor(bool valor)
        {
            if (valor)
                return 1;
            return 0;
        }

    }
}
