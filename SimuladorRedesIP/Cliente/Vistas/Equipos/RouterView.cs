using System;
using System.Collections.Generic;
using System.Text;
using SimuladorCliente.Properties;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.SOA;
using System.Collections.ObjectModel;

namespace RedesIP.Vistas.Equipos
{
    class RouterView : EquipoView
    {
		public RouterView(EquipoSOA equipo)
            : base(equipo.Id, equipo.X, equipo.Y, Resources.Switch.Size.Width, Resources.Switch.Size.Height)
		{
			CrearPuertos(equipo.Puertos);
		}

        private List<PuertoEthernetView> _puertosEthernet = new List<PuertoEthernetView>();

        public ReadOnlyCollection<PuertoEthernetView> PuertosEthernet
        {
            get { return _puertosEthernet.AsReadOnly(); }
        }




        private void CrearPuertos(IEnumerable<PuertoSOA> puertos)
        {
            int i = 0;
            foreach (PuertoSOA puerto in puertos)
            {

                _puertosEthernet.Add(new PuertoEthernetView(puerto.Id, puerto.DireccionMAC, (i * 30)+3 , 7, this));
                i++;
            }

        }



        public override void DibujarElemento(System.Drawing.Graphics grafico)
        {
            base.DibujarElemento(grafico);
            for (int i = 0; i < _puertosEthernet.Count; i++)
            {
                _puertosEthernet[i].DibujarElemento(grafico);
            }
        }
        protected override string GetInfoMapa()
        {
            return "Router";
        }
        public override System.Drawing.Image Imagen
        {
            get { return Resources.Router; }
        }

    }
}

