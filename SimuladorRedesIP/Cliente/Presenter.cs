using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP;
using RedesIP.SOA;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Modelos;
using RedesIP.Modelos.Datos;
using RedesIP.Common;

namespace SimuladorCliente
{
    public class Presenter:PresenterBase
    {
        private IVisualizacion _vista;

        public Presenter(IVisualizacion vista)
        {
            _vista = vista;

        }
        protected override IVisualizacion GetCurrentClient()
        {
            return _vista;
        }
  
    }
}
