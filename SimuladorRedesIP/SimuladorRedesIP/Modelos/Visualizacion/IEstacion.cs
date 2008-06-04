using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using RedesIP.ModelosLogicos.Equipos;
using RedesIP.ModelosVisualizacion.Equipos;

namespace RedesIP.ModelosVisualizacion
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
