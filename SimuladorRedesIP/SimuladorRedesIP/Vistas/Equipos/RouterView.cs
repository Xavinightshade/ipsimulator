using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;

namespace RedesIP.Vistas.Equipos
{
	class RouterView:EquipoView
	{
		public RouterView(int origenX, int origenY, int ancho, int alto)
			: base(origenX, origenY, ancho, alto)
		{
		
		}
		public override System.Drawing.Image Imagen
		{
			get { return Resources.Router; }
		}

	}
}
