using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace RedesIP.Vistas.Equipos
{
	public abstract class ComponenteMovibleView : PictureBox,IMovibleView
	{
		delegate void dele(int valor);
		public ComponenteMovibleView()
		{

			this.SizeMode = PictureBoxSizeMode.AutoSize;
		}



	







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

		protected void OnCambioDePosicion(int deltaEnX,int deltaEnY)
		{
			if (CambioEnPosicion != null)
				CambioEnPosicion(this,new EventCambioEnPosicionArgs(deltaEnX,deltaEnY));
		}


	}

}
