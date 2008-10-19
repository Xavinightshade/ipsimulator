using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Logicos.Equipos;
using BusinessLogic.Componentes;
using SOA.Componentes;

namespace BusinessLogic.Equipos
{
    public class SwitchVLAN : EquipoLogico
    {
        public static SwitchVLanSOA CrearSwitchVLanSOA(SwitchVLAN swiLogico)
        {
            SwitchVLanSOA swiRespuesta = new SwitchVLanSOA(swiLogico.TipoDeEquipo, swiLogico.Id, swiLogico.X, swiLogico.Y, swiLogico.Nombre);
            foreach (PuertoEthernetLogicoBase puerto in swiLogico.PuertosEthernet)
            {
                swiRespuesta.AgregarPuerto(new PuertoBaseSOA(puerto.Id, puerto.Nombre, puerto.Habilitado));
            }
            foreach (VLan vLan in swiLogico._vLans)
            {
                VLanSOA vLanSOA = new VLanSOA(vLan.Id, vLan.Nombre);
                foreach (PuertoEthernetLogicoBase puerto in vLan.Puertos)
                {
                    vLanSOA.IdPuertos.Add(puerto.Id);
                }
                swiRespuesta.VLans.Add(vLanSOA);
            }
            return swiRespuesta;
        }

        private List<PuertoEthernetLogicoBase> _puertosEthernet = new List<PuertoEthernetLogicoBase>();


        public ReadOnlyCollection<PuertoEthernetLogicoBase> PuertosEthernet
        {
            get { return _puertosEthernet.AsReadOnly(); }
        }
        public SwitchVLAN(Guid id, int X, int Y, string nombre)
            : base(id, TipoDeEquipo.SwitchVLan, X, Y, nombre)
        {


        }


        List<VLan> _vLans = new List<VLan>();

        public List<VLan> VLans
        {
            get { return _vLans; }
        }



        public void AgregarPuerto(Guid idPuerto, string nombre, bool habilitado)
        {
            PuertoEthernetLogicoBase puerto = new PuertoEthernetLogicoBase(idPuerto, nombre, habilitado);
            _puertosEthernet.Add(puerto);
        }


        public override void InicializarEquipo()
        {
            //  InicializarPuertos();
        }

        public override void DesconectarEquipo()
        {
            _puertosEthernet = null;
        }

        internal void ActualizarVLans(List<VLanSOA> vLansActuales)
        {
            foreach (VLan vLan in _vLans)
            {
                vLan.Dispose();
            }
            _vLans.Clear();
            foreach (VLanSOA vLan in vLansActuales)
            {
                CapaSwitcheo capaSwitcheo = new CapaSwitcheo();
                foreach (Guid idPuerto in vLan.IdPuertos)
                {
                    capaSwitcheo.AgregarPuerto(GetPuerto(idPuerto));
                }
                VLan vLanLogica = new VLan(vLan.Id, vLan.Nombre, capaSwitcheo);
                _vLans.Add(vLanLogica);
            }
        }

        private PuertoEthernetLogicoBase GetPuerto(Guid idPuerto)
        {
            foreach (PuertoEthernetLogicoBase puerto in _puertosEthernet)
            {
                if (puerto.Id == idPuerto)
                    return puerto;
            }
            throw new Exception();
        }

        public override void Dispose()
        {
            foreach (VLan vLan in _vLans)
            {
                vLan.Dispose();
            }
            _puertosEthernet.Clear();
            
        }
    }
}
