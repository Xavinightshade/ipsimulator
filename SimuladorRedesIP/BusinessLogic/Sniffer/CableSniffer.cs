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
    public class CableSniffer
    {
        private CableDeRedLogico _cable;
        private List<IVisualizacion> _vistas;
        public CableSniffer(CableDeRedLogico cable, List<IVisualizacion> vistas)
        {
            _cable=cable;
            _vistas = vistas;
            EscucharPuerto();
        }
        public void EscucharPuerto()
        {
            _cable.FrameRecibidoPuerto1 += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
            _cable.FrameRecibidoPuerto2 += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);          

        }

        private void OnFrameRecibido(object sender, FrameRecibidoEventArgs e)
        {
            foreach (IVisualizacion  vist in _vistas)
            {
                vist.EnviarInformacionConexion(new MensajeCableSOA(_cable.Id, Frame.ConvertirFrame(e.FrameRecibido), e.HoraDeRecepcion));

            }
        }
    }
}
