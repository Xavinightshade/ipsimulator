using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Datos
{
    public class UDPSegment : Segment
    {

        public UDPSegment(int sourcePort, int destinationPort, byte[] datos, int dataLength)
            : base(sourcePort, destinationPort, datos,dataLength)
        {
        }

    }
}
