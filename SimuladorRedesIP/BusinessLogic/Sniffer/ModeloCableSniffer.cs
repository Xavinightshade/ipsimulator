using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos;
using RedesIP.Modelos.Datos;
using RedesIP.SOA;
using RedesIP.SOA.Elementos;

namespace BusinessLogic.Sniffer
{
    public class ModeloCableSniffer:ModeloSnifferBase
    {
        private CableDeRedLogico _cable;

        public CableDeRedLogico Cable
        {
            get { return _cable; }
        }
        public ModeloCableSniffer(CableDeRedLogico cable)
        {
            _cable = cable;
            EscucharPuerto();
        }
        private void EscucharPuerto()
        {
            _cable.FrameRecibidoPuerto1 += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
            _cable.FrameRecibidoPuerto2 += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);

        }

        public override void EliminarVista(IVisualizacion vista)
        {
            base.EliminarVista(vista);
            vista.EliminarSnifferCable(_cable.Id);

        }
        public override void Dispose()
        {
            base.Dispose();
            _cable.FrameRecibidoPuerto1 -= new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
            _cable.FrameRecibidoPuerto2 -= new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
            _cable = null;
        }

        private void OnFrameRecibido(object sender, FrameRecibidoEventArgs e)
        {
            foreach (IVisualizacion vist in Vistas)
            {
                vist.EnviarInformacionConexion(new MensajeCableSOA(_cable.Id, Frame.ConvertirFrame(e.FrameRecibido), e.HoraDeRecepcion));

            }
        }


    }
}
