using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RedesIP.Vistas.Utilidades
{

	public class Linea:MarshalByRefObject
	{
		private int _x1;

		public int X1
		{
			get { return _x1; }
			set
			{
				_x1 = value;
				OnCambioPosicion();
			}
		}
		private int _y1;

		public int Y1
		{
			get { return _y1; }
			set
			{
				_y1 = value;
				OnCambioPosicion();
			}
		}
		private int _x2;

		public int X2
		{
			get { return _x2; }
			set
			{
				_x2 = value;
				OnCambioPosicion();
			}
		}
		private int _y2;

		public int Y2
		{
			get { return _y2; }
			set
			{
				_y2 = value;
				OnCambioPosicion();
			}
		}
		public Linea(int x1, int y1, int x2, int y2)
		{
			_x1 = x1; _y1 = y1; _x2 = x2; _y2 = y2;
		}

		public event EventHandler CambioDePosicion;

		private void OnCambioPosicion()
		{
			if (CambioDePosicion != null)
				CambioDePosicion(this, new EventArgs());
		}
	}



	public class DibujadorLineas
	{
		List<Linea> _listaLineas=new List<Linea>();
		Pen _pen = new Pen(Color.White, 2);

		public event EventHandler CambioDeLinea;
		public DibujadorLineas()
		{
		}
		public void AgregarLineas(List<Linea> listaLineas)
		{
			foreach (Linea linea in listaLineas)
			{
				AgregarLinea(linea);
			}
		}
		public void EliminarLineas(List<Linea> listaLineas)
		{
			foreach (Linea linea in listaLineas)
			{
				EliminarLinea(linea);
			}
		}
		public void AgregarLinea(Linea linea)
		{
			_listaLineas.Add(linea);
			linea.CambioDePosicion+=new EventHandler(OnCambioDePosicionDeAlgunaLinea);
		}
		public void EliminarLinea(Linea linea)
		{
			_listaLineas.Remove(linea);
			linea.CambioDePosicion -= new EventHandler(OnCambioDePosicionDeAlgunaLinea);
		}

		private void OnCambioDePosicionDeAlgunaLinea(object sender, EventArgs e)
		{
			OnCambioLinea();
		}
		public void PintarLineas(Graphics superficieGrafica)
		{
			foreach (Linea linea in _listaLineas)
			{
				
			}
		}
		private void OnCambioLinea()
		{
			if (CambioDeLinea != null)
				CambioDeLinea(this, new EventArgs());
		}
	}
}
