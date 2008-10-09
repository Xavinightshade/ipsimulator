using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA.Elementos
{
    [DataContract]
    public class MensajeCableSOA:MensajeBaseSOA
    {

        private FrameSOA _frame;
        [DataMember]
        public FrameSOA Frame
        {
            get { return _frame; }
            set { _frame = value; }
        }



        public MensajeCableSOA (Guid idConexion, FrameSOA frame,TimeSpan horaRecepcion)
            :base(idConexion,horaRecepcion)
	{

        _frame = frame;
            
	}

    }
}
