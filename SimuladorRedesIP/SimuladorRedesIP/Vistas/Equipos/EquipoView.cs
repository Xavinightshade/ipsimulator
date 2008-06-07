using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;
using System.Drawing;

namespace RedesIP.Vistas.Equipos
{
	public abstract class EquipoView : ElementoGraficoCuadrado
	{
		public EquipoView(int origenX, int origenY, int ancho, int alto)
			: base(origenX, origenY, ancho, alto)
		{

		}

		public abstract Image Imagen { get; }

		public override void DibujarElemento(Graphics grafico)
		{
			grafico.DrawImage(Imagen, this.OrigenX, this.OrigenY, this.Ancho, this.Alto);
		}

	}
}