using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;

namespace RedesIP.Vistas.Equipos
{
	class RouterView:EquipoView
	{
		public RouterView(Guid id,int origenX, int origenY, int ancho, int alto)
			: base(id,origenX, origenY, ancho, alto)
		{
		
		}
		public override System.Drawing.Image Imagen
		{
			get { return Resources.Router; }
		}

	}
}
