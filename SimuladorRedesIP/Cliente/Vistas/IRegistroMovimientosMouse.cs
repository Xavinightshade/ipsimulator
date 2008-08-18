using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RedesIP.SOA;

namespace RedesIP.Vistas
{
	public interface IRegistroMovimientosMouse
	{
		event MouseEventHandler MouseDown;
		event MouseEventHandler MouseUp;
		event MouseEventHandler MouseMove;
		void Invalidate();
		IModeloSOA Contrato { get; }
	}
}
