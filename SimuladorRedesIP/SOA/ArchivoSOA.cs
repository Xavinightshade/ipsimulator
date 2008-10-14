using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SOA
{
    [DataContract]
    public class ArchivoSOA
    {
        [DataMember]
        private TimeSpan _fecha;
        public TimeSpan Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private int _sourcePort;
        [DataMember]
        public int SourcePort
        {
            get { return _sourcePort; }
            set { _sourcePort = value; }
        }
        private int _destinationPort;
        [DataMember]
        public int DestinationPort
        {
            get { return _destinationPort; }
            set { _destinationPort = value; }
        }

        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private byte[] _data;
        [DataMember]
        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }
        private string _fileName;
        [DataMember]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        private int _length;
        [DataMember]
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public ArchivoSOA(Guid id, string fileName, int sourcePort, int destinationPort,TimeSpan fecha,int length)
        {
            _id = id;
            _fileName = fileName;
            _sourcePort = sourcePort;
            _destinationPort = destinationPort;
            _fecha = fecha;
            _length = length;
        }
    }
}
