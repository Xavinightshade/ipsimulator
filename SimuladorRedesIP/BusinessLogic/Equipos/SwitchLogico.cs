using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Common;
using RedesIP.SOA;
using BusinessLogic.Componentes;



namespace RedesIP.Modelos.Logicos.Equipos
{
	public class SwitchLogico:EquipoLogico
	{
        private CapaSwitcheo _capaSwitcheo=new CapaSwitcheo();
        public static SwitchSOA CrearSwitchSOA(SwitchLogico swiLogico)
        {
            SwitchSOA swiRespuesta = new SwitchSOA(swiLogico.TipoDeEquipo, swiLogico.Id, swiLogico.X, swiLogico.Y,swiLogico.Nombre);
            foreach (PuertoEthernetLogicoBase puerto in swiLogico.PuertosEthernet)
            {
                swiRespuesta.AgregarPuerto(new PuertoBaseSOA(puerto.Id,puerto.Nombre));
            }
            return swiRespuesta;
        }

		private List<PuertoEthernetLogicoBase> _puertosEthernet=new List<PuertoEthernetLogicoBase>();


		public  ReadOnlyCollection<PuertoEthernetLogicoBase> PuertosEthernet
		{
			get { return _puertosEthernet.AsReadOnly(); }
		}
        public SwitchLogico(Guid id, int X, int Y,string nombre)
            : base(id, TipoDeEquipo.Switch, X, Y,nombre)
        {


        }
        public SwitchTable SwitchTable
        {
            get { return _capaSwitcheo.SwitchTable; }
        }





        public  void AgregarPuerto(Guid idPuerto,string nombre)
        {
            PuertoEthernetLogicoBase puerto = new PuertoEthernetLogicoBase(idPuerto, nombre);
            _puertosEthernet.Add(puerto);
            _capaSwitcheo.AgregarPuerto(puerto);
        }


        public override void InicializarEquipo()
        {
          //  InicializarPuertos();
        }
    }
}
