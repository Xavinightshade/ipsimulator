using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Vistas.Equipos;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimuladorCliente.Marcadores
{
    public class MarcadorEquipo:MarcadorBase
    {
        


        EquipoView _equipo;

        public EquipoView Equipo
        {
            get { return _equipo; }
        }

        public MarcadorEquipo(EquipoView equipo)
            : base(equipo.Id)
        {
            _equipo = equipo;
        }

        public override void DibujarElemento(System.Drawing.Graphics grafico)
        {
            Pen p = new Pen(Color, 2);
            p.StartCap = LineCap.Triangle;
            int mitadX = _equipo.DimensionMundo.Centro.X;
            int mitadY = _equipo.DimensionMundo.Centro.Y;
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
