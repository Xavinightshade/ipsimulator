using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.Vistas;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimuladorCliente.Marcadores
{
    public class MarcadorPuertoCompleto:MarcadorBase
    {
                PuertoEthernetViewCompleto _puerto;

        public PuertoEthernetViewCompleto Puerto
        {
            get { return _puerto; }
        }

        public MarcadorPuertoCompleto(string nombre, PuertoEthernetViewCompleto puerto, IRegistroMovimientosMouse mainView)
            : base( puerto.Id,nombre,mainView)
        {

            _puerto = puerto;
        }

        public override void DibujarElemento(System.Drawing.Graphics grafico)
        {
            Pen p = new Pen(Color, 2);
            p.StartCap = LineCap.Triangle;
            int mitadX = _puerto.DimensionMundo.Centro.X;
            int mitadY = _puerto.DimensionMundo.Centro.Y;
            grafico.DrawLine(p, mitadX, mitadY, mitadX + 30, mitadY - 30);
            grafico.FillEllipse(new SolidBrush(Color), mitadX + 20, mitadY - 30, 10, 10);
            grafico.DrawString(Nombre, new Font("Arial", 8, FontStyle.Regular), Brushes.White, new PointF(mitadX + 30, mitadY - 30));

        }
        public override bool HitTest(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void EliminarMarcador()
        {
            base.MainView.Contrato.PeticionPararDeEnviarInformacionPuertoCompleto(_puerto.Id);

        }
    }
}
