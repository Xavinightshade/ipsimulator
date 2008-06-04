using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;

namespace RedesIP.Vistas.Equipos
{
	public class ComputadorView:EquipoView
	{
		public ComputadorView()
		{

		}

		public override System.Drawing.Image GetImage()
		{
			return Resources.Computador;
		}
	}
}
