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
        public RouterSOA(TipoDeEquipo tipoEquipo, Guid id, int x, int y, string nombre,bool ripHabilitado)
            : base(tipoEquipo, id, x, y,nombre)
        {
            _ripHabilitado = ripHabilitado;
        }
        public RouterSOA(TipoDeEquipo tipoEquipo, int x, int y)
            : base(tipoEquipo, x, y)
        {

        }
        public RouterSOA()
        {

        }
        List<PuertoCompletoSOA> _puertos = new List<PuertoCompletoSOA>();
        [DataMember]
        public List<PuertoCompletoSOA> Puertos
        {
            get { return _puertos; }
            set { _puertos = value; }
        }

        private bool _ripHabilitado;
        [DataMember]
        public bool RipHabilitado
        {
            get { return _ripHabilitado; }
            set { _ripHabilitado = value; }
        }

        public void AgregarPuerto(PuertoCompletoSOA puerto)
        {
            _puertos.Add(puerto);
        }
    }
}
