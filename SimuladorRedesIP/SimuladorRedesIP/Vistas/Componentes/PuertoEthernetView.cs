using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;
using System.Drawing;

namespace RedesIP.Vistas.Equipos.Componentes
{
	public class PuertoEthernetView:ElementoGraficoCuadrado
	{
		public PuertoEthernetView(int origenX,int origenY,EquipoView equipoPadre)
			: base(origenX,origenY, 10, 10)
		{
			ElementoPadre = equipoPadre;
		}
		public override void DibujarElemento(System.Drawing.Graphics grafico)
		{
			int origenX = ElementoPadre.Dimension.OrigenX + Dimension.OrigenX;
			int origenY = ElementoPadre.Dimension.OrigenY + Dimension.OrigenY;
			grafico.FillRectangle(Brushes.Black, origenX, origenY, Dimension.Ancho, Dimension.Alto);
			grafico.DrawRectangle(new Pen(Color.White), origenX, origenY, Dimension.Ancho, Dimension.Alto);

		}


	}
}
