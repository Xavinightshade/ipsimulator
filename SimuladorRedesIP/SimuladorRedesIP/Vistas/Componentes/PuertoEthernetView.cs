using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;
using System.Drawing;

namespace RedesIP.Vistas.Equipos.Componentes
{
	public class PuertoEthernetView:ElementoGraficoCuadrado
	{
		public PuertoEthernetView(int origenX, int origenY, int ancho, int alto)
			:base(origenX,origenY,ancho,alto)
		{

		}
		public override void DibujarElemento(System.Drawing.Graphics grafico)
		{
			grafico.DrawRectangle(new Pen(Color.Black, 10), OrigenX, OrigenY, Ancho, Alto);
		}


	}
}
