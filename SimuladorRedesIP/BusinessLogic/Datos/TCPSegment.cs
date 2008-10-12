using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Datos
{
    public class TCPSegment : Segment
    {
        public TCPSegment(int sourcePort, int destinationPort, byte[] datos)
            : base(sourcePort, destinationPort, datos)
        {

        }
        private bool _synFlag;

        public bool SYN_Flag
        {
            get { return _synFlag; }
            set { _synFlag = value; }
        }
        private bool _ackFlag;

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
        public override string ToString()
        {
            string texto = string.Empty;
            texto += "Puerto Origen: " + SourcePort.ToString() + " ,";
            texto += "Puerto Destino: " + DestinationPort.ToString() + " ,";
            texto += "SYN: " + _synFlag.ToString() + " ,";
            texto += "ACK: " +  _ackFlag.ToString() + " ,";
            texto += "SEQ Number: " + _seqNumber.ToString() + " ,";
            texto += "ACK Number: " + _ackNumber.ToString();
            return texto;
            
        }

    }
}
