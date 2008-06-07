using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;
using System.Drawing;

namespace RedesIP.Vistas.Equipos
{
	public class ComputadorView:EquipoView
	{
		public ComputadorView(int origenX, int origenY, int ancho, int alto)
			:base(origenX,origenY,ancho,alto)
		{

		}
		public override Image Imagen
		{
			get { return Resources.Computador; }
		}


	}
}
