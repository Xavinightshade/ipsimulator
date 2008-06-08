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

			grafico.FillRectangle(Brushes.Black, DimensionMundo.OrigenX, DimensionMundo.OrigenY, Dimension.Ancho, Dimension.Alto);
			grafico.DrawRectangle(new Pen(Color.White), DimensionMundo.OrigenX, DimensionMundo.OrigenY, Dimension.Ancho, Dimension.Alto);

		}


	}
}
