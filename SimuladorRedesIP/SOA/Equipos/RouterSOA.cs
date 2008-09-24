using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA
{
    [DataContract]
    public class RouterSOA : EquipoBaseSOA
    {
        public RouterSOA(TipoDeEquipo tipoEquipo, Guid id, int x, int y, string nombre)
            : base(tipoEquipo, id, x, y,nombre)
        {

        }
        public RouterSOA(TipoDeEquipo tipoEquipo, int x, int y)
            : base(tipoEquipo, x, y)
        {

        }
        List<PuertoCompletoSOA> _puertos = new List<PuertoCompletoSOA>();
        [DataMember]
        public List<PuertoCompletoSOA> Puertos
        {
            get { return _puertos; }
            set { _puertos = value; }
        }

        private string _direccionIP;
        [DataMember]
        public string DireccionIP
        {
            get { return _direccionIP; }
            set { _direccionIP = value; }
        }

        public void AgregarPuerto(PuertoCompletoSOA puerto)
        {
            _puertos.Add(puerto);
        }
    }
}
