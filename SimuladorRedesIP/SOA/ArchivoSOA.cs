using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SOA
{
    [DataContract]
   public  class ArchivoSOA
    {
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
       public ArchivoSOA(Guid id, string fileName)
       {
           _id = id;
           _fileName = fileName;
       }
    }
}
