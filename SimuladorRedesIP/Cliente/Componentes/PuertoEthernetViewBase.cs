using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RedesIP.Vistas.Equipos.Componentes
{
    public class PuertoEthernetViewBase : ElementoGraficoCuadrado
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
        private bool _habilitado;

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }
        private IRegistroMovimientosMouse _inst;
        public PuertoEthernetViewBase(Guid id, int origenX, int origenY, EquipoView equipoPadre, string nombre, bool habilitado)
            : base(id, origenX, origenY, 10, 10)
        {
            ElementoPadre = equipoPadre;
            _habilitado = habilitado;
            _nombre = nombre;
        }
        public void EstablecerContenedor(IRegistroMovimientosMouse inst)
        {
            _inst = inst;
            _inst.MouseMove += new System.Windows.Forms.MouseEventHandler(MouseMove);

        }
        private bool _estaSobre = false;
        private void MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (HitTest(e.X, e.Y))
            {
                _estaSobre = true;
               
            }
            else
            {
               _estaSobre = false;
            }
            _inst.Invalidate();
         
        }

        protected virtual string GetInfo()
        {
            return _nombre;
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
            if (_estaSobre)
                grafico.DrawString(GetInfo(), new Font("Arial", 9, FontStyle.Bold), Brushes.White, new PointF(DimensionMundo.OrigenX, DimensionMundo.OrigenY + DimensionMundo.Alto+12));

            //    brush.Dispose();
            p.Dispose();


        }


    }
}
