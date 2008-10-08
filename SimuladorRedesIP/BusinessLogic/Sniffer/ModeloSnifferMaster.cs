using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using RedesIP;
using RedesIP.Modelos;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Modelos.Equipos.Componentes;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferMaster
    {
        private EstacionModelo _estacion;
        private Dictionary<Guid, ModeloSnifferPC> _sniffersPc = new Dictionary<Guid, ModeloSnifferPC>();
        private Dictionary<Guid, ModeloSnifferSwitch> _sniffersSwi = new Dictionary<Guid, ModeloSnifferSwitch>();
        private Dictionary<Guid, ModeloSnifferRouter> _sniffersRou = new Dictionary<Guid, ModeloSnifferRouter>();
        private Dictionary<Guid, ModeloCableSniffer> _sniffersCable = new Dictionary<Guid, ModeloCableSniffer>();
        private Dictionary<Guid, ModeloSnifferPuertoCompleto> _sniffersPuerto = new Dictionary<Guid, ModeloSnifferPuertoCompleto>();

        public ModeloSnifferMaster(EstacionModelo estacion)
        {
            _estacion = estacion;
        }
        public void DesconectarCliente(IVisualizacion cliente)
        {
            foreach (KeyValuePair<Guid,ModeloSnifferPC> item in _sniffersPc)
            {
                item.Value.EliminarVista(cliente);
            }
            foreach (KeyValuePair<Guid, ModeloSnifferSwitch> item in _sniffersSwi)
            {
                item.Value.EliminarVista(cliente);
            }
            foreach (KeyValuePair<Guid, ModeloSnifferRouter> item in _sniffersRou)
            {
                item.Value.EliminarVista(cliente);
            }
            foreach (KeyValuePair<Guid, ModeloCableSniffer> item in _sniffersCable)
            {
                item.Value.EliminarVista(cliente);
            }
            foreach (KeyValuePair<Guid, ModeloSnifferPuertoCompleto> item in _sniffersPuerto)
            {
                item.Value.EliminarVista(cliente);
            }

        }

        public void PeticionEnviarInformacionConexion(Guid idConexion, IVisualizacion cliente)
        {
            if (!_sniffersCable.ContainsKey(idConexion))
            {
                CableDeRedLogico cable = _estacion.Cables[idConexion];
                ModeloCableSniffer snifferCable = new ModeloCableSniffer(cable);
                _sniffersCable.Add(idConexion, snifferCable);
            }
            _sniffersCable[idConexion].AgregarVista(cliente);

        }



        public void PeticionEnviarInformacionSwitch(Guid idSwitch, IVisualizacion cliente)
        {
            if (!_sniffersSwi.ContainsKey(idSwitch))
            {
                SwitchLogico swi = _estacion.Switches[idSwitch];
                ModeloSnifferSwitch snifferSwitch = new ModeloSnifferSwitch(swi);
                _sniffersSwi.Add(idSwitch, snifferSwitch);
            }
            _sniffersSwi[idSwitch].AgregarVista(cliente);

        }





        public void PeticionEnviarInformacionPuertoCompleto(Guid idPuerto, IVisualizacion cliente)
        {
            if (!_sniffersPuerto.ContainsKey(idPuerto))
            {
                PuertoEthernetCompleto puerto = _estacion.Puertos[idPuerto] as PuertoEthernetCompleto;
                ModeloSnifferPuertoCompleto puertoSniffer = new ModeloSnifferPuertoCompleto(puerto);
                _sniffersPuerto.Add(idPuerto, puertoSniffer);
            }
            _sniffersPuerto[idPuerto].AgregarVista(cliente);
        }



        public void PeticionEnviarInformacionPC(Guid idPC, IVisualizacion cliente)
        {
            if (!_sniffersPc.ContainsKey(idPC))
            {
                ComputadorLogico pc = _estacion.Computadores[idPC];
                ModeloSnifferPC sniffer = new ModeloSnifferPC(pc);
                _sniffersPc.Add(idPC, sniffer);
            }
            _sniffersPc[idPC].AgregarVista(cliente);
        }

        public void PeticionEnviarInformacionRouter(Guid idRouter, IVisualizacion cliente)
        {

            if (!_sniffersRou.ContainsKey(idRouter))
            {
                RouterLogico rou = _estacion.Routers[idRouter];
                ModeloSnifferRouter sniffer = new ModeloSnifferRouter(rou);
                _sniffersRou.Add(idRouter, sniffer);
            }
            _sniffersRou[idRouter].AgregarVista(cliente);
        }



        internal void PeticionPararEnviarInformacionConexion(Guid idConexion, IVisualizacion cliente)
        {
            ModeloCableSniffer snifferCable=_sniffersCable[idConexion];
            snifferCable.EliminarVista(cliente);
            if (snifferCable.NumeroDeClientes == 0)
            {
                snifferCable.Dispose();
                _sniffersCable.Remove(idConexion);
            }
        }
    }
}
