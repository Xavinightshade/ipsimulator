using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace RedesIp.Vistas.ElementosVisuales
{
	class ElementoVisual : PictureBox
	{
		private bool _elBotonDelMouseEstaPresionado;
		private int _clickOffSetX, _clickOffSetY;
		public ElementoVisual()
		{
			Inicializar();
			this.SizeMode = PictureBoxSizeMode.AutoSize;
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
				this.Left += e.X - _clickOffSetX;
				this.Top += e.Y - _clickOffSetY;
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
