using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SourceGrid;
using RedesIP.SOA.Elementos;
using SimuladorCliente.Formularios;

namespace SimuladorCliente.Sniffers
{
    public class DoubleClickEventSnifferCable : SourceGrid.Cells.Controllers.ControllerBase
    {
        public override void OnDoubleClick(CellContext sender, EventArgs e)
        {
            base.OnClick(sender, e);
            Grid grilla = sender.Grid as Grid;
            MensajeCableSOA mensa = grilla.Rows[sender.Position.Row].Tag as MensajeCableSOA;
            using (FrameForm f=new FrameForm())
            {
                f.Inicializar(mensa);
                f.ShowDialog();
            }
        }

    }
}
