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
        private Dictionary<Guid, ModeloSnifferBase> _sniffers = new Dictionary<Guid, ModeloSnifferBase>();

        public ModeloSnifferMaster()
        {

        }
        public void setEstacion(EstacionModelo estacion)
        {
            _estacion = estacion;
        }
        public void DesconectarCliente(IVisualizacion cliente)
        {
            foreach (KeyValuePair<Guid, ModeloSnifferBase> item in _sniffers)
            {
                if (item.Value.Vistas.Contains(cliente))
                    item.Value.Vistas.Remove(cliente);
            }

        }

        public void PeticionEnviarInformacionConexion(Guid idConexion, IVisualizacion cliente)
        {
            if (!_sniffers.ContainsKey(idConexion))
            {
                CableDeRedLogico cable = _estacion.Cables[idConexion];
                ModeloCableSniffer snifferCable = new ModeloCableSniffer(cable);
                _sniffers.Add(idConexion, snifferCable);
            }
            _sniffers[idConexion].AgregarVista(cliente);

        }



        public void PeticionEnviarInformacionSwitch(Guid idSwitch, IVisualizacion cliente)
        {
            if (!_sniffers.ContainsKey(idSwitch))
            {
                SwitchLogico swi = _estacion.Switches[idSwitch];
                ModeloSnifferSwitch snifferSwitch = new ModeloSnifferSwitch(swi);
                _sniffers.Add(idSwitch, snifferSwitch);
            }
            _sniffers[idSwitch].AgregarVista(cliente);

        }





        public void PeticionEnviarInformacionPuertoCompleto(Guid idPuerto, IVisualizacion cliente)
        {
            if (!_sniffers.ContainsKey(idPuerto))
            {
                PuertoEthernetCompleto puerto = _estacion.Puertos[idPuerto] as PuertoEthernetCompleto;
                ModeloSnifferPuertoCompleto puertoSniffer = new ModeloSnifferPuertoCompleto(puerto);
                _sniffers.Add(idPuerto, puertoSniffer);
            }
            _sniffers[idPuerto].AgregarVista(cliente);
        }



        public void PeticionEnviarInformacionPC(Guid idPC, IVisualizacion cliente)
        {
            if (!_sniffers.ContainsKey(idPC))
            {
                ComputadorLogico pc = _estacion.Computadores[idPC];
                ModeloSnifferPC sniffer = new ModeloSnifferPC(pc);
                _sniffers.Add(idPC, sniffer);
            }
            _sniffers[idPC].AgregarVista(cliente);
        }

        public void PeticionEnviarInformacionRouter(Guid idRouter, IVisualizacion cliente)
        {

            if (!_sniffers.ContainsKey(idRouter))
            {
                RouterLogico rou = _estacion.Routers[idRouter];
                ModeloSnifferRouter sniffer = new ModeloSnifferRouter(rou);
                _sniffers.Add(idRouter, sniffer);
            }
            _sniffers[idRouter].AgregarVista(cliente);
        }



        public void PeticionPararEnviarInformacionConexion(Guid idConexion, IVisualizacion cliente)
        {
            EliminarSniffer(idConexion, cliente);
        }

        private void EliminarSniffer(Guid idSniffer, IVisualizacion cliente)
        {
            ModeloSnifferBase sniffer = _sniffers[idSniffer];
            sniffer.EliminarVista(cliente);
            if (sniffer.NumeroDeClientes == 0)
            {
                sniffer.Dispose();
                _sniffers.Remove(idSniffer);
            }
        }

        internal void PeticionPararDeEnviarInformacionPC(Guid idPc, IVisualizacion cliente)
        {
            EliminarSniffer(idPc, cliente);

        }

        internal void PeticionPararDeEnviarInformacionPuertoCompleto(Guid idPuerto, IVisualizacion cliente)
        {
            EliminarSniffer(idPuerto, cliente);
        }

        internal void PeticionPararDeEnviarInformacionRouter(Guid idRouter, IVisualizacion cliente)
        {
            EliminarSniffer(idRouter, cliente);
        }

        internal void PeticionPararDeEnviarInformacionSwitch(Guid idSwitch, IVisualizacion cliente)
        {
            EliminarSniffer(idSwitch, cliente);
        }

        public void EliminarSnifferCableBuscandoCable(Guid idCable)
        {
            EliminarSniffer(idCable);

        }

        private void EliminarSniffer(Guid idSnifer)
        {
            if (_sniffers.ContainsKey(idSnifer))
            {
                ModeloSnifferBase snifferCable = _sniffers[idSnifer];
                snifferCable.EliminarSnifferTotal();
                snifferCable.Dispose();
                _sniffers.Remove(idSnifer);
            }
        }

        internal void EliminarSniffersDelEquipo(Guid idEquipo)
        {
            List<PuertoEthernetLogicoBase> puertos = _estacion.BuscarPuertosDelEquipo(idEquipo);
            foreach (PuertoEthernetLogicoBase puerto in puertos)
            {
                if (puerto is PuertoEthernetCompleto)
                    EliminarSniffer(puerto.Id);
            }
            EliminarSniffer(idEquipo);
        }
    }
}
