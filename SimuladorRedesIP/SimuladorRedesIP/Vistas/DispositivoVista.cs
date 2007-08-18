using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace RedesIP.Vistas.ElementosVisuales
{
	public class DispositivoVista : PictureBox,IDispositivoVista
	{
		delegate void dele(int valor);
		private bool _elBotonDelMouseEstaPresionado;
		private int _clickOffSetX, _clickOffSetY;
		public DispositivoVista()
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



		#region IDispositivoVista Members

		public int OrigenX
		{
			get
			{
				return this.Left;
			}
			set
			{
				EstablecerX(value);
			}
		}

		private void EstablecerX(int value)
		{
			if (InvokeRequired)
			{
				dele nuevo = new dele(EstablecerX);
				BeginInvoke(nuevo, new object[] { value });
			}
			else
			{
				this.Left = value;
			}
		}
		private void EstablecerY(int value)
		{
			if (InvokeRequired)
			{
				dele nuevo = new dele(EstablecerY);
				BeginInvoke(nuevo, new object[] { value });
			}
			else
			{
				this.Top= value;
			}
		}



		public int OrigenY
		{
			get
			{
				return this.Top;
			}
			set
			{
				EstablecerY(value);
			}
		}

		public event EventHandler<EventCambioEnPosicionArgs> CambioEnPosicion;

		private void OnCambioDePosicion(int deltaEnX,int deltaEnY)
		{
			if (CambioEnPosicion != null)
				CambioEnPosicion(this,new EventCambioEnPosicionArgs(deltaEnX,deltaEnY));
		}

		#endregion
	}

}
