using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Vistas.Equipos;
using RedesIP.Vistas;

namespace SimuladorCliente.Marcadores
{
    public class MarcadorSwitch : MarcadorEquipo
    {
        public MarcadorSwitch(SwitchView swi, IRegistroMovimientosMouse mainView)
            : base(swi, mainView)
        {

        }
        private SwitchView Switch
        {
            get { return base.Equipo as SwitchView; }
        }
        public override void EliminarMarcador()
        {
            MainView.Contrato.PeticionPararDeEnviarInformacionSwitch(Switch.Id);
        }
    }
}
