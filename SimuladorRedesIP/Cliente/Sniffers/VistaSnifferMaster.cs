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
       private Dictionary<Guid, FormaSnifferBase> _formsSniffers = new Dictionary<Guid, FormaSnifferBase>();
       public VistaSnifferMaster(IModeloSniffer modeloSniffer)
       {
           _modeloSniffer = modeloSniffer;
       }


       public void EnviarInformacionConexion(MensajeCableSOA mensaje)
       {
           (_formsSniffers[mensaje.Id] as FormaSnifferCable).ReportarMensaje(mensaje);
       }




       public void IniciarSnifferCable(MarcadorCable marcador,DockPanel dockMain)
       {
           _modeloSniffer.PeticionEnviarInformacionConexion(marcador.Id);
           FormaSnifferCable sniffer = new FormaSnifferCable(marcador);
           sniffer.AllowEndUserDocking = false;
           sniffer.Show(dockMain, DockState.DockBottom);
           _formsSniffers.Add(marcador.Id, sniffer);

       }



       internal void EnviarCambioDeTablaDeSwitch(MensajeSwitchTableSOA mensajeTablaSwitch)
       {

           (_formsSniffers[mensajeTablaSwitch.Id] as FormaSnifferSwitch).ReportarMensaje(mensajeTablaSwitch);
       }

       public void IniciarSnifferSwitch(MarcadorSwitch marcador, DockPanel dockPanel)
       {
           _modeloSniffer.PeticionEnviarInformacionSwitch(marcador.Id);
           FormaSnifferSwitch sniffer = new FormaSnifferSwitch(marcador);
           sniffer.AllowEndUserDocking = false;
           sniffer.Show(dockPanel, DockState.DockBottom);
           _formsSniffers.Add(marcador.Id, sniffer);
       }

       internal void IniciarSnifferPuerto(MarcadorPuertoCompleto marcador, DockPanel dockPanel)
       {
           _modeloSniffer.PeticionEnviarInformacionPuertoCompleto(marcador.Id);
           FormaSnifferPuerto sniffer = new FormaSnifferPuerto(marcador);
           sniffer.AllowEndUserDocking = false;
           sniffer.Show(dockPanel, DockState.DockBottom);
           _formsSniffers.Add(marcador.Id, sniffer);
       }

       internal void EnviarCambioDeTablaARP(Guid idPuerto, ARP_SOA listARP)
       {
           (_formsSniffers[idPuerto] as FormaSnifferPuerto ).ReportarMensaje(listARP);
       }

       internal void EnviarInformacionEncapsulacionPC(EncapsulacionSOA encapsulacion)
       {
           (_formsSniffers[encapsulacion.IdEquipo] as FormaSnifferPC).ReportarMensajeEncapsulacion(encapsulacion);
       }



       internal void IniciarSnifferPC(MarcadorPC marcador, DockPanel dockPanel)
       {
           _modeloSniffer.PeticionEnviarInformacionPC(marcador.Id);
           FormaSnifferPC sniffer = new FormaSnifferPC(marcador);
           sniffer.AllowEndUserDocking = false;
           sniffer.Show(dockPanel, DockState.DockBottom);
           _formsSniffers.Add(marcador.Id, sniffer);
       }

       internal void IniciarSnifferRouter(MarcadorRouter marcador, DockPanel dockPanel)
       {
           _modeloSniffer.PeticionEnviarInformacionRouter(marcador.Id);
           FormaSnifferRouter sniffer = new FormaSnifferRouter(marcador);
           sniffer.AllowEndUserDocking = false;
           sniffer.Show(dockPanel, DockState.DockBottom);
           _formsSniffers.Add(marcador.Id, sniffer);
       }

       internal void EnviarInformacionEncapsulacionRouter(EncapsulacionSOA encapsulacion)
       {
           (_formsSniffers[encapsulacion.IdEquipo] as FormaSnifferRouter).ReportarMensaje(encapsulacion);
       }

       internal void DeleteSnifferCable(Guid idCable)
       {

           DeleteSniffer(idCable);

       }

       private void DeleteSniffer(Guid idSniffer)
       {
           _formsSniffers[idSniffer].CerrarSniffer();
           _formsSniffers.Remove(idSniffer);
       }

       internal void DeleteSnifferPC(Guid idPc)
       {
           DeleteSniffer(idPc);
       }

       internal void DeleteSnifferSwitch(Guid idSwitch)
       {
           DeleteSniffer(idSwitch);
       }

       internal void DeleteSnifferRouter(Guid idRouter)
       {
           DeleteSniffer(idRouter);
       }

       internal void DeleteSnifferPuerto(Guid idPuerto)
       {
           DeleteSniffer(idPuerto);
       }

       internal void EnviarInformacionSegmentoEnviados(Guid idPC, TCPSegmentSOA segment)
       {
           (_formsSniffers[idPC] as FormaSnifferPC).ReportarSegmentoEnviado(segment);

       }

       internal void EnviarInformacionSegmentoRecibido(Guid idPC, TCPSegmentSOA segment)
       {
           (_formsSniffers[idPC] as FormaSnifferPC).ReportarSegmentoEnviado(segment);
       }
    }
}
