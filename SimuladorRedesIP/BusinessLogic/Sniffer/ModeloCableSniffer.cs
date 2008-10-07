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
    public class ModeloCableSniffer
    {
        private CableDeRedLogico _cable;
        private List<IVisualizacion> _vistas=new List<IVisualizacion>();
        public ModeloCableSniffer(CableDeRedLogico cable)
        {
            _cable=cable;
            EscucharPuerto();
        }
        private void EscucharPuerto()
        {
            _cable.FrameRecibidoPuerto1 += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
            _cable.FrameRecibidoPuerto2 += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);          

        }
        public void AgregarVista(IVisualizacion vista)
        {
            _vistas.Add(vista);
        }
        public void EliminarVista(IVisualizacion vista)
        {
            if (_vistas.Contains(vista))
                _vistas.Remove(vista);
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
