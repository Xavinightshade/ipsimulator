using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using SimuladorCliente.Properties;

namespace RedesIP.Vistas.Equipos
{
    public abstract class EquipoView : ElementoGraficoCuadrado
    {
        public EquipoView(Guid id,string nombre, int origenX, int origenY, int ancho, int alto)
            : base(id, origenX, origenY, ancho, alto)
        {
            _nombre = nombre;
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private IRegistroMovimientosMouse _reg;
        ContextMenuStrip _menu = new ContextMenuStrip();

        protected ContextMenuStrip Menu
        {
            get { return _menu; }

        }
        Control _ownerControl;

        protected Control OwnerControl
        {
            get { return _ownerControl; }
        }

        protected IRegistroMovimientosMouse Contenedor
        {
            get { return _reg; }
        }
        private bool _elBotonDelMouseEstaPresionado;
        private int _clickOffSetX;
        private int _clickOffSetY;
        public void EstablecerContenedor(IRegistroMovimientosMouse inst)
        {
            _reg = inst;
            _ownerControl = inst as Control;
            inst.MouseDown += new System.Windows.Forms.MouseEventHandler(OnMouseDown);
            inst.MouseMove += new System.Windows.Forms.MouseEventHandler(OnMouseMove);
            inst.MouseUp += new System.Windows.Forms.MouseEventHandler(OnMouseUp);
            ToolStripMenuItem item = new ToolStripMenuItem("Eliminar Equipo",Resources.Symbols_Delete_16x16);
            item.Click += new EventHandler(BorrarClick);
            Menu.Items.Add(item);

            _ownerControl.MouseDoubleClick += new MouseEventHandler(_ownerControl_MouseDoubleClick);
        }

        private void BorrarClick(object sender, EventArgs e)
        {
            _reg.Contrato.PeticionEliminarEquipo(Id);
        }

        void _ownerControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (HitTest(e.X, e.Y))
            {

                OnMouseDobleClick(e);

            }
        }

        protected virtual void OnMouseDobleClick(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
        public void DesconectarDelContenedor()
        {
            _ownerControl.MouseDown -= new System.Windows.Forms.MouseEventHandler(OnMouseDown);
            _ownerControl.MouseMove -= new System.Windows.Forms.MouseEventHandler(OnMouseMove);
            _ownerControl.MouseUp -= new System.Windows.Forms.MouseEventHandler(OnMouseUp);
            _ownerControl.MouseDoubleClick -= new MouseEventHandler(_ownerControl_MouseDoubleClick);

            
        }
        public void MoverEquipo(int x, int y)
        {
            Dimension.OrigenX = x;
            Dimension.OrigenY = y;
        }
        private   void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            if (HitTest(e.X, e.Y))
            {

                OnMouseUpEvent(e);

            }


        }
        protected virtual void OnMouseUpEvent(System.Windows.Forms.MouseEventArgs e)
        {
             _elBotonDelMouseEstaPresionado = false;
                _reg.Contrato.PeticionMoverEquipo(Id, DimensionMundo.OrigenX, DimensionMundo.OrigenY);
                if (e.Button == MouseButtons.Right)
                {
                    Menu.Show(OwnerControl, e.X, e.Y);
                }
        }

        private void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            IWin32Window window = _reg.Window;
            if (_elBotonDelMouseEstaPresionado)
            {
                _tooltip.Hide(window);
                Dimension.OrigenX = this.Dimension.OrigenX + (e.X - _clickOffSetX);
                Dimension.OrigenY = this.Dimension.OrigenY + (e.Y - _clickOffSetY);
                _clickOffSetX = e.X;
                _clickOffSetY = e.Y;
                _reg.Invalidate();
            }
            else
            {
                
                if (HitTest(e.X, e.Y))
                {
                    _tooltip.Show(GetFullInfoMapa(), window, DimensionMundo.OrigenX + DimensionMundo.Ancho, DimensionMundo.OrigenY+DimensionMundo.Alto, 4000);
                }
                else
                {
                    _tooltip.Hide(window);
                }
            }


        }

        private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (HitTest(e.X, e.Y))
            {
                _elBotonDelMouseEstaPresionado = true;
                _clickOffSetX = e.X;
                _clickOffSetY = e.Y;

            }
        }
        public abstract Image Imagen { get; }

        public override void DibujarElemento(Graphics grafico)
        {
            grafico.DrawImage(Imagen, this.Dimension.OrigenX, this.Dimension.OrigenY, this.Dimension.Ancho, this.Dimension.Alto);
            grafico.DrawString(Environment.NewLine+ GetInfoMapa(), new Font("Arial Narrow", 8, FontStyle.Regular), Brushes.LightGreen, new PointF(DimensionMundo.OrigenX, DimensionMundo.OrigenY + DimensionMundo.Alto-10));
            Imagen.Dispose();
        }
        protected virtual string GetInfoMapa()
        {
            return this.Nombre;
        }
        protected virtual string GetFullInfoMapa()
        {
            string tip = "Nombre: " + _nombre;
            return tip;
        }
        private ToolTip _tooltip = new ToolTip();

    }
}