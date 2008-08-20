using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.SOA;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferSwitch
    {
        private SwitchLogico _switch;
        private List<IVisualizacion> _vistas;
        public ModeloSnifferSwitch(SwitchLogico swi, List<IVisualizacion> vistas)
        {
            _switch = swi;
            _vistas = vistas;
            EscucharTablasDeFiltro();
        }
        public void EscucharTablasDeFiltro()
        {

        }
    }
}
