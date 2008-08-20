using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Vistas;
using WeifenLuo.WinFormsUI.Docking;

namespace SimuladorCliente
{
    public class ControladorMarcador
    {
        EstacionView _estacion;
        DockPanel _dockMain;
        public ControladorMarcador(DockPanel dockMain)
        {
            _dockMain = dockMain;

        }
        public void EstablecerEstacion(EstacionView estacion)
        {
            if (_estacion != null)
                _estacion.NuevoMarcador -= new EventHandler<SimuladorCliente.Vistas.NuevoMarcadorEventArgs>(OnNuevoMarcador);

            _estacion = estacion;

            _estacion.NuevoMarcador += new EventHandler<SimuladorCliente.Vistas.NuevoMarcadorEventArgs>(OnNuevoMarcador);

        }

        void OnNuevoMarcador(object sender, SimuladorCliente.Vistas.NuevoMarcadorEventArgs e)
        {
            SnifferBeta sniffer = new SnifferBeta(e.Marcador);
            sniffer.AllowEndUserDocking = false;
            sniffer.Show(_dockMain, DockState.DockBottom);
        }
    }
}
