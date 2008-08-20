using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Vistas;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimuladorCliente.Marcadores
{
    public class MarcadorCable : MarcadorBase
    {



        CableView _conexion;

        public CableView Conexion
        {
            get { return _conexion; }
        }

        Random r = new Random();
        public MarcadorCable(CableView conexion)
            : base(conexion.Id)
        {

            _conexion = conexion;
        }

        public override void DibujarElemento(System.Drawing.Graphics grafico)
        {
            Pen p = new Pen(Color, 2);
            p.StartCap = LineCap.Triangle;
            int mitadX = (_conexion.PosicionMundoPuerto1.X + _conexion.PosicionMundoPuerto2.X) / 2;
            int mitadY = (_conexion.PosicionMundoPuerto1.Y + _conexion.PosicionMundoPuerto2.Y) / 2;
            grafico.DrawLine(p, mitadX, mitadY, mitadX + 30, mitadY - 30);
            grafico.FillEllipse(new SolidBrush(Color), mitadX + 20, mitadY - 30, 10, 10);
            grafico.DrawString(this.Id.ToString().Substring(0, 8), new Font("Arial", 8, FontStyle.Regular), Brushes.White, new PointF(mitadX + 15, mitadY - 15));

        }

        public override bool HitTest(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
