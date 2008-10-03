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
using SimuladorCliente.Marcadores;
using RedesIP.Vistas.Equipos;
using SOA.Datos;

namespace SimuladorCliente.Sniffers
{
   public  class VistaSnifferMaster
    {
       private IModeloSniffer _modeloSniffer;
       private Dictionary<Guid, FormaSnifferCable> _cableSniffers = new Dictionary<Guid, FormaSnifferCable>();
       private Dictionary<Guid, FormaSnifferSwitch> _switchSniffers = new Dictionary<Guid, FormaSnifferSwitch>();
       private Dictionary<Guid, FormaSnifferPC> _pcSniffers = new Dictionary<Guid, FormaSnifferPC>();

       private Dictionary<Guid, FormaSnifferPuerto> _puertoSniffers = new Dictionary<Guid, FormaSnifferPuerto>();
       public VistaSnifferMaster(IModeloSniffer modeloSniffer)
       {
           _modeloSniffer = modeloSniffer;
       }


       public void EnviarInformacionConexion(MensajeCableSOA mensaje)
       {
           _cableSniffers[mensaje.Id].ReportarMensaje(mensaje);
       }



       #region IModeloSniffer Members

       public void IniciarSnifferCable(MarcadorCable marcador,DockPanel dockMain)
       {
           _modeloSniffer.PeticionEnviarInformacionConexion(marcador.Id);
           FormaSnifferCable sniffer = new FormaSnifferCable(marcador);
           sniffer.AllowEndUserDocking = false;
           sniffer.Show(dockMain, DockState.DockBottom);
           _cableSniffers.Add(marcador.Id,sniffer);

       }

       #endregion

       internal void EnviarCambioDeTablaDeSwitch(MensajeSwitchTableSOA mensajeTablaSwitch)
       {

           _switchSniffers[mensajeTablaSwitch.Id].ReportarMensaje(mensajeTablaSwitch);
       }

       public void IniciarSnifferSwitch(MarcadorEquipo marcador, DockPanel dockPanel)
       {
           _modeloSniffer.PeticionEnviarInformacionSwitch(marcador.Id);
           FormaSnifferSwitch sniffer = new FormaSnifferSwitch(marcador.Equipo as SwitchView, marcador.Color);
           sniffer.AllowEndUserDocking = false;
           sniffer.Show(dockPanel, DockState.DockBottom);
           _switchSniffers.Add(marcador.Id, sniffer);
       }

       internal void IniciarSnifferPuerto(MarcadorPuertoCompleto marcador, DockPanel dockPanel)
       {
           _modeloSniffer.PeticionEnviarInformacionPuertoCompleto(marcador.Id);
           FormaSnifferPuerto sniffer = new FormaSnifferPuerto(marcador);
           sniffer.AllowEndUserDocking = false;
           sniffer.Show(dockPanel, DockState.DockBottom);
           _puertoSniffers.Add(marcador.Id, sniffer);
       }

       internal void EnviarCambioDeTablaARP(Guid idPuerto, ARP_SOA listARP)
       {
           _puertoSniffers[idPuerto].ReportarMensaje(listARP);
       }

       internal void EnviarInformacionEncapsulacionPC(EncapsulacionSOA encapsulacion)
       {
           _pcSniffers[encapsulacion.IdEquipo].ReportarMensaje(encapsulacion);
       }

       internal void EnviarInformacionDesEncapsulacionPC(EncapsulacionSOA encapsulacion)
       {
           _pcSniffers[encapsulacion.IdEquipo].ReportarMensaje(encapsulacion);
       }

       internal void IniciarSnifferPC(MarcadorEquipo marcador, DockPanel dockPanel)
       {
           _modeloSniffer.PeticionEnviarInformacionPC(marcador.Id);
           FormaSnifferPC sniffer = new FormaSnifferPC(marcador.Equipo as ComputadorView, marcador.Color);
           sniffer.AllowEndUserDocking = false;
           sniffer.Show(dockPanel, DockState.DockBottom);
           _pcSniffers.Add(marcador.Id, sniffer);
       }
    }
}
