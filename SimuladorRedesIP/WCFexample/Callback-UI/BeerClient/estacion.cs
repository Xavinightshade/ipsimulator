using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace BeerClient
{
    public class Estacion:PictureBox
    {
        public Estacion():base()
        {
			  base.BackColor = Color.White;
			  IniciarThread();
        }
		  int _y;
		  int _x;



		  public void MoverBola(int x, int y)
		  {
			  _x = x;
			  _y = y;
		  }
		  private void IniciarThread()
		  {
			  new Thread(Pintar).Start();
		  }
		  private void Pintar()
		  {
			  Thread.Sleep(10);
			  Invalidate();
			  Pintar();
		  }

		  protected override void OnPaint(PaintEventArgs pe)
		  {
			  base.OnPaint(pe);

			  pe.Graphics.FillEllipse(Brushes.Red, new RectangleF(_x, _y, 20, 20));
			  
		  }
    }
}
