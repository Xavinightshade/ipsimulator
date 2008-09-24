using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimuladorCliente;
using SimuladorCliente.Formularios;
using RedesIP.Vistas.Equipos;

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



        }
        
    }
}
