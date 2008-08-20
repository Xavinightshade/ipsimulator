using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RedesIP.SOA;

namespace RedesIP.Vistas
{
	public interface IRegistroMovimientosMouse
	{
        IWin32Window MainWindow { get; }
		event MouseEventHandler MouseDown;
		event MouseEventHandler MouseUp;
		event MouseEventHandler MouseMove;
		void Invalidate();
		IModeloSOA Contrato { get; }
	}
}
