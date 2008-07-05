using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.SOA;
using SimuladorCliente.Properties;

namespace RedesIP.Vistas.Equipos
{
	public class ComputadorView:EquipoView
	{
		public ComputadorView(EquipoSOA equipo)
            : base(equipo.Id, equipo.X, equipo.Y, Resources.Computador.Width, Resources.Computador.Height)
		{
			_puerto = new PuertoEthernetView(equipo.Puertos[0].Id,15,30,this);
		}
		PuertoEthernetView _puerto;

		public PuertoEthernetView Puerto
		{
			get { return _puerto; }
		}
		public override Image Imagen
		{
			get { return Resources.Computador; }
		}
		public override void DibujarElemento(Graphics grafico)
		{
			base.DibujarElemento(grafico);
			_puerto.DibujarElemento(grafico);
		}


	}
}
