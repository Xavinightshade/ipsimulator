using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Equipos;
using RedesIP.Vistas;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using RedesIP.SOA.Elementos;

namespace SimuladorCliente.Marcadores
{
	public abstract class MarcadorBase:ElementoGrafico
    {
        

        private static List<Color> _colores = LlenarColores();



        private static List<Color> LlenarColores()
        {
            List<Color> colores = new List<Color>();
            colores.Add(Color.Aquamarine);
            colores.Add(Color.Green);
            colores.Add(Color.Salmon);
            colores.Add(Color.Yellow);
            colores.Add(Color.White);
            return colores;
        }

		Color _color;


		public Color Color
		{
			get { return _color; }
            set { _color = value;
            _mainView.Invalidate();
            }
		}
		Random r = new Random();

        private IRegistroMovimientosMouse _mainView;

        protected IRegistroMovimientosMouse MainView
        {
            get { return _mainView; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value;
            _mainView.Invalidate();
            }
        }
        private string _nombre;
		public MarcadorBase(Guid id,string nombre,IRegistroMovimientosMouse mainView)
			:base(id)
		{
            _nombre = nombre;
            _mainView = mainView;
            _color = _colores[r.Next(_colores.Count)];
		}
        public virtual void Dispose()
        {
            _mainView = null;
        }

	
	}

}
