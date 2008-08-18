using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using System.Collections.ObjectModel;

namespace RedesIP.Modelos.Logicos.Equipos
{
    public abstract class EquipoLogico : IUnique, IPosisionable
	{
        private int _X;
        private int _Y;
        private TipoDeEquipo _tipoDeEquipo;

        public TipoDeEquipo TipoDeEquipo
        {
            get { return _tipoDeEquipo; }
            set { _tipoDeEquipo = value; }
        }
        public EquipoLogico(TipoDeEquipo tipoEquipo,int X, int Y)
        {
            _X = X;
            _Y = Y;
        }
		 public abstract Guid Id { get; }
         public int X { get { return _X; } set { _X = value; } }
         public int Y { get { return _Y; } set { _Y = value; } }
		 public abstract ReadOnlyCollection<PuertoEthernetLogico> PuertosEthernet { get; }
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
