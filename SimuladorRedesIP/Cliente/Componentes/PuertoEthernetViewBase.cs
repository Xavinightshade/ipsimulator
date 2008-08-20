using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RedesIP.Vistas.Equipos.Componentes
{
	public class PuertoEthernetViewBase:ElementoGraficoCuadrado
	{
		private bool _seleccionado;
		private bool _conectado;
        private bool _reseltado;

		public bool Conectado
		{
			get { return _conectado; }
			set { _conectado = value; }
		}

		public bool Seleccionado
		{
			get { return _seleccionado; }
			set { _seleccionado = value; }
		}
        public bool Reseltado
        {
            get { return _reseltado; }
            set { _reseltado = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

		public PuertoEthernetViewBase(Guid id,int origenX,int origenY,EquipoView equipoPadre,string nombre)
			: base(id,origenX,origenY, 10, 10)
		{
			ElementoPadre = equipoPadre;
            _nombre = nombre;
		}
		public override void DibujarElemento(System.Drawing.Graphics grafico)
		{
            if (!_reseltado && !_seleccionado && !_conectado)
                return;
			Brush brush = Brushes.Black;
            if (_reseltado)
            {
                brush = Brushes.Yellow;
            }
			if (_seleccionado)
			{
				brush = Brushes.LightGreen;

			}
			if (_conectado)
			{
				brush = Brushes.Salmon;
			}

            	                Pen p = new Pen(Color.White);
            grafico.FillRectangle(brush, DimensionMundo.OrigenX, DimensionMundo.OrigenY, Dimension.Ancho, Dimension.Alto);
            grafico.DrawRectangle(p, DimensionMundo.OrigenX, DimensionMundo.OrigenY, Dimension.Ancho, Dimension.Alto);
            grafico.DrawString(_nombre, new Font("Arial", 7, FontStyle.Bold), Brushes.White, new PointF(DimensionMundo.OrigenX, DimensionMundo.OrigenY + DimensionMundo.Alto));

            //    brush.Dispose();
            p.Dispose();
			
			
		}


	}
}
