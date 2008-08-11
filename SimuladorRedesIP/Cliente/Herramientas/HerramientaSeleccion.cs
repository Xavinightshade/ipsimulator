using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedesIP.Vistas
{
    public partial class EstacionView
    {
        private  class HerramientaSeleccion:HerramientaBase
        {
            public HerramientaSeleccion(EstacionView estacion)
                :base(estacion)
            {
                Estacion.Cursor = Cursors.Default;
            }

            public override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
            {
                //throw new NotImplementedException();
            }

            public override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
            {
                //throw new NotImplementedException();
            }
        }

    }
}