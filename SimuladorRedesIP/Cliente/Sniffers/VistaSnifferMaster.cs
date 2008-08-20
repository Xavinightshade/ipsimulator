using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using RedesIP.SOA.Elementos;
using RedesIP.Vistas;
using System.Drawing;
using SimuladorCliente.Vistas;
using WeifenLuo.WinFormsUI.Docking;

namespace SimuladorCliente.Sniffers
{
   public  class VistaSnifferMaster
    {
       private IModeloSniffer _modeloSniffer;
       private FormaSnifferCable _sniffer;
       public VistaSnifferMaster(IModeloSniffer modeloSniffer)
       {
           _modeloSniffer = modeloSniffer;
       }


       public void EnviarInformacionConexion(MensajeCableSOA mensaje)
       {
           _sniffer.ReportarMensaje(mensaje);
       }



       #region IModeloSniffer Members

       public void IniciarSnifferCable(MarcadorCable marcador,DockPanel dockMain)
       {
           _modeloSniffer.PeticionEnviarInformacionConexion(marcador.Id);
           _sniffer = new FormaSnifferCable(marcador.Conexion, marcador.Color);
           _sniffer.AllowEndUserDocking = false;
           _sniffer.Show(dockMain, DockState.DockBottom);

       }

       #endregion
    }
}
