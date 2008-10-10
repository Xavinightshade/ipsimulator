using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using System.Runtime.Serialization;

namespace SOA.Componentes
{
    [DataContract]
    public class VLanSOA
    {
        private string _nombre;
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }

        }
        [DataMember]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }

        }
        private List<Guid> _idPuertos=new List<Guid>();
        [DataMember]
        public List<Guid> IdPuertos
        {
            get { return _idPuertos; }
            set { _idPuertos = value; }
        }
        public VLanSOA(Guid id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }

    }
}
