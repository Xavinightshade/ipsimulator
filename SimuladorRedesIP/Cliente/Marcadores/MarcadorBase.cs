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
		}
		Random r = new Random();
		public MarcadorBase(Guid id)
			:base(id)
		{

            _color = _colores[r.Next(_colores.Count)];
		}

	
	}

}
