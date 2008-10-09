using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using System.Runtime.Serialization;

namespace SOA.Datos
{
    [DataContract]
    public class EncapsulacionSOA
    {
        private Guid _idEquipo;
        [DataMember]
        public Guid IdEquipo
        {
            get { return _idEquipo; }
            set { _idEquipo = value; }
        }
        private TimeSpan _fecha;
        [DataMember]
        public TimeSpan Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private PacketSOA _paquete;
        [DataMember]
        public PacketSOA Paquete
        {
            get { return _paquete; }
            set { _paquete = value; }
        }
        private FrameSOA _frame;
        [DataMember]
        public FrameSOA Frame
        {
            get { return _frame; }
            set { _frame = value; }
        }
        private bool _esEncapsulacion;
        [DataMember]
        public bool EsEncapsulacion
        {
            get { return _esEncapsulacion; }
            set { _esEncapsulacion = value; }
        }
    }
}
