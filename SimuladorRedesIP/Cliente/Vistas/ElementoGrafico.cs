using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace RedesIP.Vistas.Equipos
{
	public abstract class ElementoGrafico
	{

		private Guid _id;


		public Guid Id
		{
			get { return _id; }
		}
		public abstract void DibujarElemento(Graphics grafico);
		public ElementoGrafico(Guid id)
		{
			_id = id;
		}
		public abstract bool HitTest(int x, int y);

	}
	
}
