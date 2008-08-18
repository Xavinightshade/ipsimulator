using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Equipos;
using RedesIP.Vistas;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.ObjectModel;

namespace SimuladorCliente.Vistas
{
	public class Marcador:ElementoGrafico
	{
        private static List<Color> _colores = LlenarColores();

        private static List<Color> LlenarColores()
        {
            List<Color> colores = new List<Color>();
            colores.Add(Color.Aquamarine);
            colores.Add(Color.Green);
            colores.Add(Color.Salmon);
            colores.Add(Color.Yellow);
            colores.Add(Color.White);
            return colores;
        }
		Conexion _conexion;

		public Conexion Conexion
		{
			get { return _conexion; }
		}
		Color _color;


		public Color Color
		{
			get { return _color; }
		}
		Random r = new Random();
		public Marcador(Guid id,Conexion conexion)
			:base(id)
		{

			_conexion = conexion;
            _color = _colores[r.Next(_colores.Count)];
		}

		public override void DibujarElemento(System.Drawing.Graphics grafico)
		{
			Pen p=new Pen(_color,2);
			p.StartCap = LineCap.Triangle;
			int mitadX = (_conexion.PosicionMundoPuerto1.X + _conexion.PosicionMundoPuerto2.X) / 2;
			int mitadY = (_conexion.PosicionMundoPuerto1.Y + _conexion.PosicionMundoPuerto2.Y) / 2;
			grafico.DrawLine(p, mitadX, mitadY, mitadX + 30, mitadY - 30);
			grafico.FillEllipse(new SolidBrush(_color), mitadX + 20, mitadY - 30, 10, 10);
            grafico.DrawString(this.Id.ToString().Substring(0, 8), new Font("Arial", 8, FontStyle.Regular), Brushes.White, new PointF(mitadX+15,mitadY-15));

		}

		public override bool HitTest(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}
