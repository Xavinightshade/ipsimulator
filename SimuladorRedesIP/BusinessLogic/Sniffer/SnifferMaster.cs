using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using RedesIP;
using RedesIP.Modelos;

namespace BusinessLogic.Sniffer
{
    public class SnifferMaster:IModeloSniffer
    {
        private List<IVisualizacion> _vistas;
        private Estacion _estacion;
        private List<CableSniffer> _snifferCables = new List<CableSniffer>();
        public SnifferMaster(List<IVisualizacion> vistas,Estacion estacion) 
        {
            _vistas = vistas;
            _estacion = estacion;
        }

        public void PeticionEnviarInformacionConexion(Guid idConexion)
        {
            CableDeRedLogico cable = _estacion.Cables[idConexion];
            CableSniffer snifferCable = new CableSniffer(cable, _vistas);
            _snifferCables.Add(snifferCable);

        }

    }
}
