using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Vistas.Equipos.Componentes;
using SOA.Equipos;
using SimuladorCliente.Properties;
using RedesIP.Vistas.Equipos;
using System.Collections.ObjectModel;
using RedesIP.SOA;
using RedesIP.Vistas;

namespace SimuladorCliente.Equipos
{
   public class HUBView:EquipoView
    {
        		private List<PuertoEthernetViewBase> _puertosEthernet = new List<PuertoEthernetViewBase>();

		public ReadOnlyCollection<PuertoEthernetViewBase> PuertosEthernet
		{
			get { return _puertosEthernet.AsReadOnly(); }
		}


        public HUBView(HUBSOA equipo)
            : base(equipo.Id, equipo.Nombre, equipo.X, equipo.Y, Resources.HUB.Size.Width, Resources.HUB.Size.Height)
		{
			CrearPuertos(equipo.Puertos);
		}

		private void CrearPuertos(IEnumerable<PuertoBaseSOA> puertos)
		{
			int i = 0;
			foreach (PuertoBaseSOA puerto in puertos)
	{

        _puertosEthernet.Add(new PuertoEthernetViewBase(puerto.Id, (i * 20)+3, 4, this,puerto.Nombre,puerto.Habilitado));
				i++;
	}

		}


		public override System.Drawing.Image Imagen
		{
            get { return Resources.HUB; }
		}
		public override void DibujarElemento(System.Drawing.Graphics grafico)
		{
			base.DibujarElemento(grafico);
			for (int i = 0; i < _puertosEthernet.Count; i++)
			{
				_puertosEthernet[i].DibujarElemento(grafico);
			}
		}
        protected override string GetFullInfoMapa()
        {
            string tip = base.GetFullInfoMapa();
            foreach (PuertoEthernetViewBase puerto in _puertosEthernet)
            {
                tip += Environment.NewLine + "Puerto:  " + puerto.Nombre;
            }
            return tip;
        }
        public override bool HitTest(int x, int y)
        {
            return base.HitTest(x, y);
        }
        public override void EstablecerContenedor(IRegistroMovimientosMouse inst)
        {
            base.EstablecerContenedor(inst);
            foreach (PuertoEthernetViewBase puerto in _puertosEthernet)
            {
                puerto.EstablecerContenedor(inst);
            }
        }
    }
}
