using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace RedesIP.Modelos
{
	public interface IEstacionModelo
	{
		event EventHandler<EventDispositivoArgs> DispositivoCreado;
		event EventHandler<EventDispositivoArgs> DispositivoEliminado;
		void CrearDispositivo();
		void CrearDispositivo(int x, int y);
		ReadOnlyCollection<IDispositivoModelo> DispositivosActuales { get;}
	}
}
