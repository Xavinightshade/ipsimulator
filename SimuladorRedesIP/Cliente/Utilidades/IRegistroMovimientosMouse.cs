using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RedesIP.SOA;
using System.ComponentModel;

namespace RedesIP.Vistas
{
	public interface IRegistroMovimientosMouse
	{
       IAsyncResult BeginInvoke(Delegate method, params object[] args);
        bool InvokeRequired { get; }
        IWin32Window Window { get; }
		event MouseEventHandler MouseDown;
		event MouseEventHandler MouseUp;
		event MouseEventHandler MouseMove;
		void Invalidate();
		IModeloSOA Contrato { get; }
	}
}
