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
		event EventHandler<EventNuevaConexionArgs> NuevaConexion;
		void CrearDispositivo(int x, int y);
		void Conectar(int a, int b);
		void CrearConexion(IDispositivoModelo dispositivo1, IDispositivoModelo dispositivo2);
		ReadOnlyCollection<IDispositivoModelo> DispositivosActuales { get;}
	}
}
