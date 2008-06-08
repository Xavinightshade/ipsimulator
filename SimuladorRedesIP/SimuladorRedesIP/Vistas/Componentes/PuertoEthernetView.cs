using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;
using System.Drawing;

namespace RedesIP.Vistas.Equipos.Componentes
{
	public class PuertoEthernetView:ElementoGraficoCuadrado
	{
		public PuertoEthernetView(int origenX, int origenY)
			:base(origenX,origenY,10,10)
		{

		}
		public override void DibujarElemento(System.Drawing.Graphics grafico)
		{
			grafico.DrawRectangle(new Pen(Color.White, 1), Dimension.OrigenX, Dimension.OrigenY, Dimension.Ancho, Dimension.Alto);
		}


	}
}
