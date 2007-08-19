using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RedesIP.Vistas.ElementosVisuales;
using System.Drawing;

namespace RedesIP.Vistas
{
	public class EstacionVista:PictureBox,IEstacionVista
	{
		private delegate void AgregarControl(Control control);
		public EstacionVista()
		{
			this.BackColor = Color.DarkBlue;
		}
		#region IEstacionVista Members

		public IDispositivoVista CrearDispositivo()
		{
			Computador pc = new Computador();
			CrearDispo(pc);
			return pc;

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


	}
}
