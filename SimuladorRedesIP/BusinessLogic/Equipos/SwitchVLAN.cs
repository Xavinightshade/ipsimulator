using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Logicos.Equipos;

namespace BusinessLogic.Equipos
{
    public class SwitchVLAN:EquipoLogico
    {
                public static SwitchVLanSOA CrearSwitchVLanSOA(SwitchVLAN swiLogico)
        {
            SwitchVLanSOA swiRespuesta = new SwitchVLanSOA(swiLogico.TipoDeEquipo, swiLogico.Id, swiLogico.X, swiLogico.Y, swiLogico.Nombre);
            foreach (PuertoEthernetLogicoBase puerto in swiLogico.PuertosEthernet)
            {
                swiRespuesta.AgregarPuerto(new PuertoBaseSOA(puerto.Id,puerto.Nombre,puerto.Habilitado));
            }
            return swiRespuesta;
        }

		private List<PuertoEthernetLogicoBase> _puertosEthernet=new List<PuertoEthernetLogicoBase>();


		public  ReadOnlyCollection<PuertoEthernetLogicoBase> PuertosEthernet
		{
			get { return _puertosEthernet.AsReadOnly(); }
		}
        public SwitchVLAN(Guid id, int X, int Y, string nombre)
            : base(id, TipoDeEquipo.SwitchVLan, X, Y,nombre)
        {


        }






        public  void AgregarPuerto(Guid idPuerto,string nombre,bool habilitado)
        {
            PuertoEthernetLogicoBase puerto = new PuertoEthernetLogicoBase(idPuerto, nombre,habilitado);
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
    }
}
