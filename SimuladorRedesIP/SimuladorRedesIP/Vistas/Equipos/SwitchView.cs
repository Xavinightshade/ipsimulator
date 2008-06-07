using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;

namespace RedesIP.Vistas.Equipos
{
	public class Switch:EquipoView
	{
		public Switch(int origenX, int origenY, int ancho, int alto)
			:base(origenX,origenY,ancho,alto)
		{
	
		}


		public override System.Drawing.Image Imagen
		{
			get { return Resources.Switch; }
		}
	}
}
