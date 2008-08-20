using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA
{
    [DataContract]
    public class SwitchSOA : EquipoBaseSOA
    {
        public SwitchSOA(TipoDeEquipo tipoEquipo, Guid id, int x, int y)
            : base(tipoEquipo, id, x, y)
        {

        }
        public SwitchSOA(TipoDeEquipo tipoEquipo, int x, int y)
            : base(tipoEquipo, x, y)
        {

        }
        List<PuertoBaseSOA> _puertos = new List<PuertoBaseSOA>();
        [DataMember]
        public List<PuertoBaseSOA> Puertos
        {
            get { return _puertos; }
            set { _puertos = value; }
        }



        public void AgregarPuerto(PuertoBaseSOA puerto)
        {
            _puertos.Add(puerto);
        }
    }
}
