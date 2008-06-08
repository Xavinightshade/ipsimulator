using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Equipos.Componentes;
using System.Collections.ObjectModel;
using RedesIP.SOA;
using SimuladorCliente.Properties;

namespace RedesIP.Vistas.Equipos
{
	public class SwitchView:EquipoView
	{
		private List<PuertoEthernetView> _puertosEthernet = new List<PuertoEthernetView>();

		public ReadOnlyCollection<PuertoEthernetView> PuertosEthernet
		{
			get { return _puertosEthernet.AsReadOnly(); }
		}


		public SwitchView(EquipoSOA equipo)
			:base(equipo.Id,equipo.X,equipo.Y, 300,50)
		{
			CrearPuertos(equipo.Puertos);
		}

		private void CrearPuertos(IEnumerable<PuertoSOA> puertos)
		{
			int i = 0;
			foreach (PuertoSOA puerto in puertos)
	{
		 
				_puertosEthernet.Add(new PuertoEthernetView(puerto.Id, (i * 20) + 25, 30, this));
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
	}
}
