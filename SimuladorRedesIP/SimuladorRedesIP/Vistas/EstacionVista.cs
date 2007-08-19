using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RedesIP.Vistas.ElementosVisuales;
using System.Drawing;
using RedesIP.Vistas.Utilidades;

namespace RedesIP.Vistas
{
	public class EstacionVista:PictureBox,IEstacionVista
	{
		private delegate void AgregarControl(Control control);
		public EstacionVista()
		{
			this.BackColor = Color.Black;
		}
		#region IEstacionVista Members

		bool selec;
		public IDispositivoVista CrearDispositivo()
		{
			selec = !selec;
			Control control = null;
			IDispositivoVista dispositivo = null;
			if (selec)
			{
				Computador pc = new Computador();
				control = pc;
				dispositivo = pc;
			}
			else
			{
				Switch sswitch = new Switch();
				control = sswitch;
				dispositivo = sswitch;
			}
			CrearDispo(control);
			return dispositivo;

		}

		private void CrearDispo(Control control)
		{
			if (this.InvokeRequired)
			{
				AgregarControl agregarControl = new AgregarControl(CrearDispo);
				this.BeginInvoke(agregarControl,control);
			}
			else
			{
				this.Controls.Add(control);
			}
		}
		private void OnCreacionDispositivo(int x,int y)
		{
			if (CreacionDispositivo != null)
				CreacionDispositivo(this, new EventNuevoDispositivoVistaArgs(x, y));
		}

		public event EventHandler<EventDispositivoVistaArgs> DispositivoEliminado;

		public event EventHandler<EventDispositivoVistaArgs> DispositivoDesAsociado;

		public event EventHandler<EventNuevoDispositivoVistaArgs> CreacionDispositivo;

		#endregion
		public void NewDispositivo(int x,int y)
		{
			OnCreacionDispositivo(x, y);
		}
		public void NewDispositivo()
		{
			NewDispositivo(0, 0);
		}



		#region IEstacionVista Members


		public void RefrescarConexiones()
		{
			this.Invalidate();
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			foreach (Linea linea in _lineas)
			{
				pe.Graphics.DrawLine(_pen, linea.X1, linea.Y1, linea.X2, linea.Y2);
			}
		}
		Pen _pen = new Pen(Color.White, 10);
		public Linea CrearLinea(int x1,int y1,int x2,int y2)
		{
			Linea linea = new Linea(x1, y1, x2, y2);
			_lineas.Add(linea);
			return linea;
		}

		private List<Linea> _lineas = new List<Linea>();




		#endregion

	}
}
