using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Vistas.Equipos;
using RedesIP.Vistas;

namespace SimuladorCliente.Marcadores
{
    public class MarcadorPC : MarcadorEquipo
    {
        public MarcadorPC(ComputadorView pc, IRegistroMovimientosMouse mainView)
            :base(pc,mainView)
        {

        }
        private ComputadorView PC
        {
            get { return base.Equipo as ComputadorView; }
        }
    }
}
