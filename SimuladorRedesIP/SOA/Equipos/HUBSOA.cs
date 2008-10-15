using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using RedesIP.SOA;
using RedesIP;

namespace SOA.Equipos
{
    [DataContract]
    public class HUBSOA : EquipoBaseSOA
    {
        public HUBSOA(TipoDeEquipo tipoEquipo, Guid id, int x, int y, string nombre)
            : base(tipoEquipo, id, x, y, nombre)
        {

        }
        public HUBSOA(TipoDeEquipo tipoEquipo, int x, int y)
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
