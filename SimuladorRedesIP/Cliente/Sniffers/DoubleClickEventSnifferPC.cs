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
    public class DoubleClickEventSnifferPC : SourceGrid.Cells.Controllers.ControllerBase
    {
        public override void OnDoubleClick(CellContext sender, EventArgs e)
        {
            base.OnClick(sender, e);
            Grid grilla = sender.Grid as Grid;
            EncapsulacionSOA mensa = grilla.Rows[sender.Position.Row].Tag as EncapsulacionSOA;
            if (mensa.EsEncapsulacion)
            {
                using (Encapsulacion f = new Encapsulacion())
                {
                    f.Inicializar(mensa);
                    f.ShowDialog();
                }
            }
            else
            {
                using (DesEncapsulacion f = new DesEncapsulacion())
                {
                    f.Inicializar(mensa);
                    f.ShowDialog();
                }
            }

        }

    }
}
