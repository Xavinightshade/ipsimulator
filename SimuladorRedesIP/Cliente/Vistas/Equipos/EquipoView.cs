using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace RedesIP.Vistas.Equipos
{
	public abstract class EquipoView : ElementoGraficoCuadrado
	{
		public EquipoView(Guid id,int origenX, int origenY, int ancho, int alto)
			: base(id,origenX, origenY, ancho, alto)
		{

		}
		private IRegistroMovimientosMouse _reg;
		private bool _elBotonDelMouseEstaPresionado;
		private int _clickOffSetX;
		private int _clickOffSetY;
		public void EstablecerContenedor(IRegistroMovimientosMouse inst)
		{
			_reg = inst;
			inst.MouseDown += new System.Windows.Forms.MouseEventHandler(OnMouseDown);
			inst.MouseMove += new System.Windows.Forms.MouseEventHandler(OnMouseMove);
			inst.MouseUp += new System.Windows.Forms.MouseEventHandler(OnMouseUp);
		}
		public void MoverEquipo(int x, int y)
		{
			Dimension.OrigenX = x;
			Dimension.OrigenY = y;
		}
		private void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			if (HitTest(e.X, e.Y))
			{
				_elBotonDelMouseEstaPresionado = false;
				_reg.Contrato.PeticionMoverEquipo(Id, DimensionMundo.OrigenX, DimensionMundo.OrigenY);


			}
	

		}

		private void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            if (HitTest(e.X, e.Y))
            {
                _tooltip.Show(GetInfoMapa(), _reg.MainWindow, DimensionMundo.OrigenX+DimensionMundo.Ancho, DimensionMundo.OrigenY, 4000);
            }
            else
            {
                _tooltip.Hide(_reg.MainWindow);
            }
				
				if (_elBotonDelMouseEstaPresionado)
				{
					Dimension.OrigenX = this.Dimension.OrigenX+(e.X - _clickOffSetX);
					Dimension.OrigenY = this.Dimension.OrigenY+(e.Y - _clickOffSetY);
					_clickOffSetX = e.X;
					_clickOffSetY = e.Y;
					_reg.Invalidate();
				}
				
			
		}

		private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (HitTest(e.X, e.Y))
			{
				_elBotonDelMouseEstaPresionado = true;
				_clickOffSetX = e.X;
				_clickOffSetY = e.Y;
			
			}
		}
		public abstract Image Imagen { get; }

		public override void DibujarElemento(Graphics grafico)
		{
			grafico.DrawImage(Imagen, this.Dimension.OrigenX, this.Dimension.OrigenY, this.Dimension.Ancho, this.Dimension.Alto);
            grafico.DrawString(GetInfoMapa(), new Font("Arial", 8, FontStyle.Regular), Brushes.LightGreen, new PointF(DimensionMundo.OrigenX, DimensionMundo.OrigenY + DimensionMundo.Alto));
			Imagen.Dispose();
		}
        protected virtual string GetInfoMapa()
        {
            return this.Id.ToString();
        }
        private ToolTip _tooltip = new ToolTip();

	}
}