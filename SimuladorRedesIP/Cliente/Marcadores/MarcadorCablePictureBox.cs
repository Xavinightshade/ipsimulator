using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimuladorCliente.Vistas
{
    public class MarcadorCablePictureBox : PictureBox
    {
        private Color _color;

        public Color Color
        {
            get { return _color; }

            set
            {
                _color = value;
                Invalidate();
            }
        }
        public MarcadorCablePictureBox()
        {

        }
        protected override void OnPaint(PaintEventArgs pe)
        {

            Pen p = new Pen(_color, 2);
            p.StartCap = LineCap.Triangle;
            int mitadX = Width / 2;
            int mitadY = Height / 2;
            pe.Graphics.DrawLine(p, 4, Height - 4, mitadX + 4, mitadY - 4);
            pe.Graphics.FillEllipse(new SolidBrush(_color), mitadX + 1, mitadY - 9, 9, 9);
            //    grafico.DrawString(this.Id.ToString().Substring(0, 8), new Font("Arial", 8, FontStyle.Regular), Brushes.White, new PointF(mitadX+15,mitadY-15));

        }

    }
}
