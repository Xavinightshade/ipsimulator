using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Equipos;

namespace RedesIP.Modelos
{
	public interface IEstacion
	{
		event EventHandler<EventDispositivoArgs> DispositivoCreado;
		event EventHandler<EventDispositivoArgs> DispositivoEliminado;
		event EventHandler<EventNuevaConexionArgs> NuevaConexion;
		void CrearDispositivo(int x, int y);
		void Conectar(int a, int b);
        void CrearConexion(IEquipo dispositivo1, IEquipo dispositivo2);
        ReadOnlyCollection<IEquipo> DispositivosActuales { get;}
	}
}
