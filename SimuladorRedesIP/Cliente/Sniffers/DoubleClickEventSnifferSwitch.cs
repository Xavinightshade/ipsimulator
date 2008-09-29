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
    public class DoubleClickEventSnifferSwitch : SourceGrid.Cells.Controllers.ControllerBase
    {
        public override void OnDoubleClick(CellContext sender, EventArgs e)
        {
            base.OnClick(sender, e);
            Grid grilla = sender.Grid as Grid;
            MensajeSwitchTableSOA mensa = grilla.Rows[sender.Position.Row].Tag as MensajeSwitchTableSOA;
            using (FilterTableForm f = new FilterTableForm())
            {
                f.Inicializar(mensa);
                f.ShowDialog();
            }
        }

    }
}
