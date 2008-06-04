using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace RedesIP.Vistas.Equipos
{
	public abstract class EquipoView : ComponenteArrastableView
	{

		public EquipoView()
			: base()
		{
			this.Image = GetImage();

		}

		public abstract Image GetImage();

	}

}
