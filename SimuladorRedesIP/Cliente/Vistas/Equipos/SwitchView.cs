using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Equipos.Componentes;
using System.Collections.ObjectModel;
using SimuladorCliente.Properties;
using RedesIP.SOA;
using System.Drawing;

namespace RedesIP.Vistas.Equipos
{
	public class SwitchView:EquipoView
	{
		private List<PuertoEthernetViewBase> _puertosEthernet = new List<PuertoEthernetViewBase>();

		public ReadOnlyCollection<PuertoEthernetViewBase> PuertosEthernet
		{
			get { return _puertosEthernet.AsReadOnly(); }
		}


		public SwitchView(SwitchSOA equipo)
            : base(equipo.Id, equipo.X, equipo.Y, Resources.Switch.Size.Width, Resources.Switch.Size.Height)
		{
			CrearPuertos(equipo.Puertos);
		}

		private void CrearPuertos(IEnumerable<PuertoBaseSOA> puertos)
		{
			int i = 0;
			foreach (PuertoBaseSOA puerto in puertos)
	{

        _puertosEthernet.Add(new PuertoEthernetViewBase(puerto.Id, (i * 30)+3, 7, this));
				i++;
	}

		}


		public override System.Drawing.Image Imagen
		{
			get { return Resources.Switch; }
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
            return "Switch";
        }
	}
}
