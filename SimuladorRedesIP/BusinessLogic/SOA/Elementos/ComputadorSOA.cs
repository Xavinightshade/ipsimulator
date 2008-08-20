using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using RedesIP;
using System.Runtime.Serialization;

namespace RedesIP.SOA
{
    [DataContract]
    public class ComputadorSOA : EquipoBaseSOA
    {
        public ComputadorSOA(TipoDeEquipo tipoEquipo, Guid id, int x, int y)
            : base(tipoEquipo, id, x, y)
        {

        }
        public ComputadorSOA(TipoDeEquipo tipoEquipo, int x, int y)
            : base(tipoEquipo, x, y)
        {

        }
        private string _direccionIP;
        [DataMember]
        public string DireccionIP
        {
            get { return _direccionIP; }
            set { _direccionIP = value; }
        }
        PuertoCompletoSOA _puerto;




        [DataMember]
        public PuertoCompletoSOA Puerto
        {
            get { return _puerto; }
            set { _puerto = value; }
        }
        public void AgregarPuerto(PuertoCompletoSOA puerto)
        {
            _puerto = puerto;
        }
    }
}
