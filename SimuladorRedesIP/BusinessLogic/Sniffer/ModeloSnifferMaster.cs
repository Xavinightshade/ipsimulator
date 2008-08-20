using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using RedesIP;
using RedesIP.Modelos;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferMaster:IModeloSniffer
    {
        private List<IVisualizacion> _vistas;
        private EstacionModelo _estacion;
        private List<ModeloCableSniffer> _snifferCables = new List<ModeloCableSniffer>();
        public ModeloSnifferMaster(List<IVisualizacion> vistas,EstacionModelo estacion) 
        {
            _vistas = vistas;
            _estacion = estacion;
        }

        public void PeticionEnviarInformacionConexion(Guid idConexion)
        {
            CableDeRedLogico cable = _estacion.Cables[idConexion];
            ModeloCableSniffer snifferCable = new ModeloCableSniffer(cable, _vistas);
            _snifferCables.Add(snifferCable);

        }

    }
}
