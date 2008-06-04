using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace RedesIP.Vistas.Equipos
{
	public abstract class ComponenteArrastableView : ComponenteMovibleView
	{

		private bool _elBotonDelMouseEstaPresionado;
		private int _clickOffSetX, _clickOffSetY;
		public ComponenteArrastableView():base()
		{
			Inicializar();

		}

		private void Inicializar()
		{
			this.MouseDown += new MouseEventHandler(CuandoDejaPresionadoUnBotonDelMouse);
			this.MouseMove += new MouseEventHandler(CuandoMueveElMouse);
			this.MouseUp += new MouseEventHandler(CuandoSueltaElBotonDelMouse);
		}

		private void CuandoDejaPresionadoUnBotonDelMouse(object sender, MouseEventArgs e)
		{
			_elBotonDelMouseEstaPresionado = true;
			_clickOffSetX = e.X;
			_clickOffSetY = e.Y;
		}

		private void CuandoMueveElMouse(object sender, MouseEventArgs e)
		{
			if (_elBotonDelMouseEstaPresionado)
			{
				OnCambioDePosicion(e.X - _clickOffSetX, e.Y - _clickOffSetY);
			}

		}

		private void CuandoSueltaElBotonDelMouse(object sender, MouseEventArgs e)
		{
			_elBotonDelMouseEstaPresionado = false;
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
		}




	}

}
