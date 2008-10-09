using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA.Elementos
{
    [DataContract]
    public class MensajeBaseSOA
    {
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        TimeSpan _horaRecepcion;
        [DataMember]
        public TimeSpan HoraRecepcion
        {
            get { return _horaRecepcion; }
            set { _horaRecepcion = value; }
        }
        public MensajeBaseSOA(Guid id, TimeSpan horaRecepcion)
        {
            _id = id;
            _horaRecepcion = horaRecepcion;
        }
    }
}
