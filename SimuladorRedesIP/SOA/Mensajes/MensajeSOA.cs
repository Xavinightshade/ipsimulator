using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA.Elementos
{
    [DataContract]
    public class MensajeCableSOA
    {
        private Guid _idConexion;
        [DataMember]
        public Guid IdConexion
        {
            get { return _idConexion; }
            set { _idConexion = value; }
        }
        private FrameSOA _frame;
        [DataMember]
        public FrameSOA Frame
        {
            get { return _frame; }
            set { _frame = value; }
        }

        DateTime _horaRecepcion;
        [DataMember]
        public DateTime HoraRecepcion
        {
            get { return _horaRecepcion; }
            set { _horaRecepcion = value; }
        }

        public MensajeCableSOA (Guid idConexion, FrameSOA frame,DateTime horaRecepcion)
	{
        _idConexion = idConexion;
        _frame = frame;
        _horaRecepcion = horaRecepcion;
            
	}

    }
}
