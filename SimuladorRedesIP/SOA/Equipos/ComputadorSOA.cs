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
        public ComputadorSOA(TipoDeEquipo tipoEquipo, Guid id, int x, int y, string nombre,string defaultGateWay)
            : base(tipoEquipo, id, x, y,nombre)
        {
            _defaultGateWay = defaultGateWay;
        }
        public ComputadorSOA(TipoDeEquipo tipoEquipo, int x, int y)
            : base(tipoEquipo, x, y)
        {

        }
        public ComputadorSOA(Guid id,string nombre,string defaultGateWay )
        {
            Id = id;
            Nombre = nombre;
            _defaultGateWay = defaultGateWay;
        }
        private string _defaultGateWay;
        [DataMember]
        public string DefaultGateWay
        {
            get { return _defaultGateWay; }
            set { _defaultGateWay = value; }
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
