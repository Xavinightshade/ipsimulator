using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SourceGrid;
using RedesIP.SOA.Elementos;
using SimuladorCliente.Formularios;
using SOA.Datos;

namespace SimuladorCliente.Sniffers
{
    public class DoubleClickEventPuertoCompleto : SourceGrid.Cells.Controllers.ControllerBase
    {
        public override void OnDoubleClick(CellContext sender, EventArgs e)
        {
            base.OnClick(sender, e);
            Grid grilla = sender.Grid as Grid;
            ARP_SOA mensa = grilla.Rows[sender.Position.Row].Tag as ARP_SOA;
            using (Tabla_ARP f = new Tabla_ARP())
            {
                f.Inicializar(mensa);
                f.ShowDialog();
            }
        }

    }
}
