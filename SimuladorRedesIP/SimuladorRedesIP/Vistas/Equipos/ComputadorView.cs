using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;
using System.Drawing;
using RedesIP.Vistas.Equipos.Componentes;

namespace RedesIP.Vistas.Equipos
{
	public class ComputadorView:EquipoView
	{
		public ComputadorView(int origenX, int origenY)
			:base(origenX,origenY,40,40)
		{
			_puerto = new PuertoEthernetView(origenX + 10, origenY + 10);
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


	}
}
