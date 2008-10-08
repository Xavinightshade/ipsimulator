using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Vistas.Equipos;
using System.Drawing;
using System.Drawing.Drawing2D;
using RedesIP.Vistas;

namespace SimuladorCliente.Marcadores
{
    public abstract class MarcadorEquipo:MarcadorBase
    {
        


        EquipoView _equipo;

        public EquipoView Equipo
        {
            get { return _equipo; }
        }

        public MarcadorEquipo(EquipoView equipo, IRegistroMovimientosMouse mainView)
            : base(equipo.Id,equipo.Nombre,mainView)
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
            grafico.DrawString(Nombre, new Font("Arial", 8, FontStyle.Regular), Brushes.White, new PointF(mitadX + 30, mitadY - 30));

        }

        public override bool HitTest(int x, int y)
        {
            throw new NotImplementedException();
        }


    }
}
