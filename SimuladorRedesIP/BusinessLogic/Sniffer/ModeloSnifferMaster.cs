using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using RedesIP;
using RedesIP.Modelos;
using RedesIP.Modelos.Logicos.Equipos;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferMaster:IModeloSniffer
    {
        private List<IVisualizacion> _vistas;
        private EstacionModelo _estacion;
        public ModeloSnifferMaster(List<IVisualizacion> vistas,EstacionModelo estacion) 
        {
            _vistas = vistas;
            _estacion = estacion;
        }

        public void PeticionEnviarInformacionConexion(Guid idConexion)
        {
            CableDeRedLogico cable = _estacion.Cables[idConexion];
            ModeloCableSniffer snifferCable = new ModeloCableSniffer(cable, _vistas);

        }



        public void PeticionEnviarInformacionSwitch(Guid idSwitch)
        {
            SwitchLogico swi = _estacion.Switches[idSwitch];
            ModeloSnifferSwitch snifferSwitch = new ModeloSnifferSwitch(swi, _vistas);
        }


    }
}
