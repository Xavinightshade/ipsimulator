using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Equipos;
using RedesIP.Vistas;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimuladorCliente.Vistas
{
	public class Marcador:ElementoGrafico
	{
		Conexion _conexion;
		Color _color;
		Random r = new Random();
		public Marcador(Guid id,Conexion conexion)
			:base(id)
		{
			_conexion = conexion;
			_color = Color.FromKnownColor(KnownColor(r.Next(100)));
		}

		private KnownColor KnownColor(int p)
		{
			return (KnownColor)p;
		}
		public override void DibujarElemento(System.Drawing.Graphics grafico)
		{
			Pen p=new Pen(_color,2);
			p.StartCap = LineCap.Triangle;
			int mitadX = (_conexion.PosicionMundoPuerto1.X + _conexion.PosicionMundoPuerto2.X) / 2;
			int mitadY = (_conexion.PosicionMundoPuerto1.Y + _conexion.PosicionMundoPuerto2.Y) / 2;
			grafico.DrawLine(p, mitadX, mitadY, mitadX + 30, mitadY - 30);
			grafico.DrawEllipse(p, mitadX + 20, mitadY - 30, 10, 10);
		}

		public override bool HitTest(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}
