using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using RedesIP.SOA;

namespace SOA.Datos
{
    [DataContract]
    public class TCPSegmentSOA:SegmentSOA
    {
        public TCPSegmentSOA(int sourcePort, int destinationPort,PacketSOA paquete,
            bool synFlag, bool ackFlag, uint seqNumber, uint ackNumber, TimeSpan fecha, bool esEnviado,int dataLength)
            :base(sourcePort,destinationPort,paquete,fecha,esEnviado,dataLength)
        {
            _ackFlag = ackFlag;
            _ackNumber = ackNumber;
            _seqNumber = seqNumber;
            _synFlag = synFlag;
        }
        private bool _synFlag;
        [DataMember]
        public bool SYN_Flag
        {
            get { return _synFlag; }
            set { _synFlag = value; }
        }
        private bool _ackFlag;
        [DataMember]
        public bool ACK_Flag
        {
            get { return _ackFlag; }
            set { _ackFlag = value; }
        }
        private uint _seqNumber;
        [DataMember]
        public uint SEQ_Number
        {
            get { return _seqNumber; }
            set { _seqNumber = value; }
        }
        private uint _ackNumber;
        [DataMember]
        public uint ACK_Number
        {
            get { return _ackNumber; }
            set { _ackNumber = value; }
        }
    }
}
