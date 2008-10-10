using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using SOA.Componentes;

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

        List<VLanSOA> _vLans = new List<VLanSOA>();
        [DataMember]
        public List<VLanSOA> VLans
        {
            get { return _vLans; }
            set { _vLans = value; }
        }


        public void AgregarPuerto(PuertoBaseSOA puerto)
        {
            _puertos.Add(puerto);
        }
    }
}
