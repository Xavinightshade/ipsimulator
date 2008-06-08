using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.Vistas.Equipos;
using System.Drawing;

namespace RedesIP.Vistas
{
	public class Conexion:ElementoGrafico
	{
		private PuertoEthernetView _puerto1;
		private PuertoEthernetView _puerto2;
		public Conexion(Guid id,PuertoEthernetView puerto1,PuertoEthernetView puerto2)
			:base(id)
		{
			_puerto1 = puerto1;
			_puerto2 = puerto2;
			_puerto1.Conectado = true;
			_puerto2.Conectado = true;
		}
		public override void DibujarElemento(System.Drawing.Graphics grafico)
		{
			Pen p=new Pen(Brushes.Yellow);
			grafico.DrawLine(p,
				_puerto1.DimensionMundo.Centro.X,
				_puerto1.DimensionMundo.Centro.Y,
				_puerto2.DimensionMundo.Centro.X,
				_puerto2.DimensionMundo.Centro.Y);

		}
		public override bool HitTest(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}
