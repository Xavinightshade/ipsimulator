using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Vistas.Equipos;
using RedesIP.Vistas;

namespace SimuladorCliente.Marcadores
{
    public class MarcadorRouter : MarcadorEquipo
    {
        public MarcadorRouter(RouterView router,IRegistroMovimientosMouse mainView)
            :base(router,mainView)
        {

        }
        private RouterView Router
        {
            get { return base.Equipo as RouterView; }
        }
        public override void EliminarMarcador()
        {
            MainView.Contrato.PeticionPararDeEnviarInformacionRouter(Router.Id);
        }
    }
}
