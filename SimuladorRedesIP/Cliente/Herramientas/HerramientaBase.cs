using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimuladorCliente;
using SimuladorCliente.Formularios;

namespace RedesIP.Vistas
{
    public partial class EstacionView
    {
        private abstract class HerramientaBase
        {
            private EstacionView _estacion;

            protected EstacionView Estacion
            {
                get { return _estacion; }
            }
            public HerramientaBase(EstacionView estacion)
            {
                _estacion = estacion;
            }
            public abstract void OnMouseMove(MouseEventArgs e);
            public abstract void OnMouseUp(MouseEventArgs e);
            public virtual void OnMouseDoubleClick(MouseEventArgs e)
            {
                FormularioComputador formaPC = new FormularioComputador();
                formaPC.ShowDialog();
                return;
                for (int i = 0; i < _estacion._computadores.Count; i++)
                {
                    if (_estacion._computadores[i].HitTest(e.X, e.Y))
                    {
                        Ping forma = new Ping();
                        forma.ShowDialog();
                        if (forma.DialogResult == DialogResult.Cancel)
                            return;
                        for (int j = 0; j < forma.Numero; j++)
                        {
                            _estacion._server.Ping(_estacion._computadores[i].Id, forma.Mensaje, forma.P1, forma.P2, forma.P3);
                        }

                        return;
                    }
                }
            }
        }
        
    }
}
