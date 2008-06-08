using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RedesIP.Vistas.Utilidades
{





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
