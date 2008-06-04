using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;

namespace RedesIP.Vistas.Equipos
{
	class RouterView:EquipoView
	{
		public RouterView()
		{
		
		}
		public override System.Drawing.Image GetImage()
		{
			return Resources.Router;
		}
	}
}
