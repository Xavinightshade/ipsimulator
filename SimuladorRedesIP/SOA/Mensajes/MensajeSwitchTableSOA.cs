using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOA.Datos;
using System.Runtime.Serialization;

namespace RedesIP.SOA.Elementos
{
    [DataContract]
    public class MensajeSwitchTableSOA:MensajeBaseSOA
    {
        private SwitchTableSOA _swiTable;
        [DataMember]
        public SwitchTableSOA SwiTable
        {
            get { return _swiTable; }
            set { _swiTable = value; }
        }
        public MensajeSwitchTableSOA(Guid id,DateTime horaDeCambio)
            :base(id,horaDeCambio)
        {

        }
    }
}
