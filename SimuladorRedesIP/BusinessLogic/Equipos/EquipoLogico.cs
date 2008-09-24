using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using System.Collections.ObjectModel;

namespace RedesIP.Modelos.Logicos.Equipos
{
    public abstract class EquipoLogico : IUnique, IPosisionable
	{
        public abstract void AgregarPuerto(Guid idPuerto,string nombre);
        private int _X;
        private int _Y;
        private TipoDeEquipo _tipoDeEquipo;
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
        }

        public TipoDeEquipo TipoDeEquipo
        {
            get { return _tipoDeEquipo; }
        }
        public EquipoLogico(Guid id, TipoDeEquipo tipoEquipo,int X, int Y,string nombre)
        {
            _id = id;
            _nombre = nombre;
            _tipoDeEquipo = tipoEquipo;
            _X = X;
            _Y = Y;
        }
        private Guid _id;
		 public  Guid Id { get{return _id;} }
         public int X { get { return _X; } set { _X = value; } }
         public int Y { get { return _Y; } set { _Y = value; } }
         public abstract void InicializarEquipo();

	}
    public interface IUnique
    {
        Guid Id { get; }
    }
    public interface IPosisionable
    {
        int X { get; set; }
        int Y { get; set; }
    }
}
