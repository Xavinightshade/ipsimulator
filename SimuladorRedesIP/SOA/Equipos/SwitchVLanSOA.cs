using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA
{
    [DataContract]
    public class SwitchVLanSOA : EquipoBaseSOA
    {
        public SwitchVLanSOA(TipoDeEquipo tipoEquipo, Guid id, int x, int y,string nombre)
            : base(tipoEquipo, id, x, y,nombre)
        {

        }
        public SwitchVLanSOA(TipoDeEquipo tipoEquipo, int x, int y)
            : base(tipoEquipo, x, y)
        {

        }
        public SwitchVLanSOA()
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
