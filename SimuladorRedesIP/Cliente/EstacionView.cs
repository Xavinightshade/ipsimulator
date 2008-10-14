using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using RedesIP.Vistas.Utilidades;
using RedesIP.Vistas.Equipos;
using RedesIP.Vistas.Equipos.Componentes;
using System.ServiceModel;
using SimuladorCliente.Vistas;
using SimuladorCliente;
using RedesIP.Common;
using RedesIP.SOA;
using DevAge.Drawing.VisualElements;
using WeifenLuo.WinFormsUI.Docking;
using System.Drawing.Imaging;
using SOA.Componentes;
using SOA.Datos;
using SimuladorCliente.Marcadores;
using SimuladorCliente.Herramientas;
using SOA;

namespace RedesIP.Vistas
{
    [CallbackBehavior(
     ConcurrencyMode = ConcurrencyMode.Multiple,
     UseSynchronizationContext = false)]
    public partial class EstacionView : PictureBox, IRegistroMovimientosMouse, IVisualizacion
    {
        public Bitmap GetImagen()
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            DibujarGrafico(g);
            return b;
        }


        public IWin32Window Window { get { return this; } }

        HerramientaBase _herramienta;
        IModeloSOA _server;

        Dictionary<Guid, EquipoView> _equipos = new Dictionary<Guid, EquipoView>();
        List<PuertoEthernetViewBase> _puertos = new List<PuertoEthernetViewBase>();
        Dictionary<Guid, PuertoEthernetViewBase> _diccioPuertos = new Dictionary<Guid, PuertoEthernetViewBase>();
        List<ComputadorView> _computadores = new List<ComputadorView>();
        List<SwitchView> _switches = new List<SwitchView>();
        List<SwitchVLanView> _switchesVLan = new List<SwitchVLanView>();

        List<RouterView> _routers = new List<RouterView>();

        public EstacionView()
        {
            _herramienta = FabricaHerramienta.CrearHerramienta(Herramienta.Seleccion, this);
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _herramienta.OnMouseMove(e);


        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            DibujarGrafico(g);

        }

        private void DibujarGrafico(Graphics g)
        {
            for (int i = 0; i < _computadores.Count; i++)
            {
                _computadores[i].DibujarElemento(g);
            }
            for (int i = 0; i < _switches.Count; i++)
            {
                _switches[i].DibujarElemento(g);
            }
            for (int i = 0; i <  _switchesVLan.Count; i++)
            {
                _switchesVLan[i].DibujarElemento(g);
            }
            for (int i = 0; i < _routers.Count; i++)
            {
                _routers[i].DibujarElemento(g);
            }
            for (int i = 0; i < _conexiones.Count; i++)
            {
                _conexiones[i].DibujarElemento(g);
            }
            for (int i = 0; i < _marcadores.Count; i++)
            {
                _marcadores[i].DibujarElemento(g);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _herramienta.OnMouseUp(e);
        }





        public IModeloSOA Contrato
        {
            get { return _server; }
        }

        public void MoverEquipo(Guid idEquipo, int x, int y)
        {
            _equipos[idEquipo].MoverEquipo(x, y);
            Invalidate();
        }
        public void ActualizarEstacion(EstacionSOA estacionSOA)
        {
            LimpiarEstacion();
            foreach (ComputadorSOA pc in estacionSOA.Computadores)
            {
                CrearComputador(pc);
            }
            foreach (SwitchSOA swi in estacionSOA.Switches)
            {
                CrearSwitch(swi);
            }
            foreach (SwitchVLanSOA swi in estacionSOA.SwitchesVLan)
            {
                CrearSwitchVLan(swi);
            }
            foreach (RouterSOA rou in estacionSOA.Routers)
            {
                CrearRouter(rou);
            }
            foreach (CableSOA cable in estacionSOA.Cables)
            {
                ConectarPuertos(cable);
            }
            Invalidate();
            _paleta.SetValor(_server.GetFactorSimulacion());
            _paleta.EstablecerEstadoSimulacion(_server.GetEstadoSimulacion());
        }
        public void LimpiarEstacion()
        {
            
            foreach (KeyValuePair<Guid, EquipoView> equipo in _equipos)
            {
                equipo.Value.DesconectarDelContenedor();
            }
            _conexiones.Clear();
            _diccioPuertos.Clear();
            _puertos.Clear();
            _puerto1 = null;
            _equipos.Clear();
            _switches.Clear();
            _switchesVLan.Clear();
            _routers.Clear();
            _computadores.Clear();
            _marcadores.Clear();
        }


        private DockPanel _dockMain;

        IPaletaHerramienta _paleta;
        internal void Inicializar(IModeloSOA presenterLocal, DockPanel dockMain,IPaletaHerramienta paleta)
        {
            _paleta=paleta;
            _server = presenterLocal;
            _dockMain = dockMain;
            _snifferMaster = new SimuladorCliente.Sniffers.VistaSnifferMaster(presenterLocal);
        }



        public void EstablecerDatosPuertoBase(PuertoBaseSOA puerto)
        {
            PuertoEthernetViewBase puertoLogico = _diccioPuertos[puerto.Id];
            puertoLogico.Nombre = puerto.Nombre;
        }

        public void EstablecerDatosPuertoCompleto(PuertoCompletoSOA puerto)
        {
            PuertoEthernetViewCompleto puertoLogico = _diccioPuertos[puerto.Id] as PuertoEthernetViewCompleto;
            puertoLogico.Nombre = puerto.Nombre;
            puertoLogico.DireccionIP = puerto.IPAddress;
            puertoLogico.Habilitado = puerto.Habilitado;
            puertoLogico.Mask = puerto.Mask;
        }




        public void EnviarCambioDeTablaDeSwitch(RedesIP.SOA.Elementos.MensajeSwitchTableSOA mensajeTablaSwitch)
        {
            _snifferMaster.EnviarCambioDeTablaDeSwitch(mensajeTablaSwitch);
        }



        #region ICallBackEstacion Members


        public void EstablecerDatosComputador(ComputadorSOA pcSOA)
        {
            ComputadorView pcView = _equipos[pcSOA.Id] as ComputadorView;
            pcView.Nombre = pcSOA.Nombre;
            pcView.DefaultGateWay = pcSOA.DefaultGateWay;
        }


        public void EstablecerDatosRouter(RouterSOA router)
        {
            RouterView rouView = _equipos[router.Id] as RouterView;
            rouView.Nombre = router.Nombre;
            rouView.RipHabilitado = router.RipHabilitado;
        }

        #endregion

        #region IVisualizacion Members


        public void EstablecerDatosSwitch(SwitchSOA swi)
        {
            SwitchView swiView = _equipos[swi.Id] as SwitchView;
            swiView.Nombre = swi.Nombre;
        }

        #endregion

        #region IVisualizacion Members


        public void EnviarCambioARP(Guid idPuerto, ARP_SOA listARP)
        {
            _snifferMaster.EnviarCambioDeTablaARP(idPuerto, listARP);

        }

        #endregion

        #region IVisualizacion Members


        public void EnviarInformacionEncapsulacionPC(EncapsulacionSOA encapsulacion)
        {
            _snifferMaster.EnviarInformacionEncapsulacionPC(encapsulacion);
        }
        public void EnviarInformacionSegmentoEnviados(Guid idPC, TCPSegmentSOA segment)
        {
            _snifferMaster.EnviarInformacionSegmentoEnviados(idPC, segment);
        }

        public void EnviarInformacionSegmentoRecibido(Guid idPC, TCPSegmentSOA segment)
        {
            _snifferMaster.EnviarInformacionSegmentoRecibido(idPC, segment);
        }




        public void EnviarInformacionEncapsulacionRouter(EncapsulacionSOA encapsulacion)
        {
            _snifferMaster.EnviarInformacionEncapsulacionRouter(encapsulacion);
        }

        #endregion

        #region IVisualizacion Members


        public void DesconectarDeServidor()
        {
            _server.DesconectarCliente();
        }

        #endregion

        #region ICallBackSniffer Members

        private void EliminarSniffer(Guid idCable)
        {
            MarcadorBase marcadorParaBorrar = null;
            foreach (MarcadorBase marcador in _marcadores)
            {
                if (marcador.Id == idCable)
                {
                    marcadorParaBorrar = marcador;
                }
            }
            _marcadores.Remove(marcadorParaBorrar);
            marcadorParaBorrar.Dispose();
        }
        public void EliminarSnifferCable(Guid idCable)
        {
            EliminarSniffer(idCable);
            _snifferMaster.DeleteSnifferCable(idCable);
            Invalidate();
        }




        public void EliminarSnifferPC(Guid idPc)
        {
            EliminarSniffer(idPc);
            _snifferMaster.DeleteSnifferPC(idPc);
            Invalidate();
        }

        public void EliminarSnifferSwitch(Guid idSwitch)
        {
            EliminarSniffer(idSwitch);
            _snifferMaster.DeleteSnifferSwitch(idSwitch);
            Invalidate();
        }

        public void EliminarSnifferRouter(Guid idRouter)
        {
            EliminarSniffer(idRouter);
            _snifferMaster.DeleteSnifferRouter(idRouter);
            Invalidate();
        }

        public void EliminarSnifferPuerto(Guid idPuerto)
        {
            EliminarSniffer(idPuerto);
            _snifferMaster.DeleteSnifferPuerto(idPuerto);
            Invalidate();
        }

        #endregion

        #region IVisualizacion Members


        public void EliminarCable(Guid idCable)
        {
            CableView cableABorrar = null;
            foreach (CableView cable in _conexiones)
            {
                if (cable.Id == idCable)
                {
                    cableABorrar = cable;
                    break;
                }
            }
              cableABorrar.Dispose();
              _conexiones.Remove(cableABorrar);
            Invalidate();

        }

        #endregion

        #region IVisualizacion Members


        public void EliminarEquipo(Guid idEquipo)
        {
            EquipoView equipo = _equipos[idEquipo];
            equipo.DesconectarDelContenedor();
            if (_routers.Contains(equipo as RouterView ))
                _routers.Remove(equipo as RouterView);
            if (_switches.Contains(equipo as SwitchView))
                _switches.Remove(equipo as SwitchView);
            if (_switchesVLan.Contains(equipo as SwitchVLanView))
                _switchesVLan.Remove(equipo as SwitchVLanView);
            if (_computadores.Contains(equipo as ComputadorView))
                _computadores.Remove(equipo as ComputadorView);
            Invalidate();
        }

        #endregion

        #region IVisualizacion Members


        public void SetValorConstanteSimulacion(int valor)
        {
           _paleta.SetValor(valor);
        }



        internal void peticionEstablecerConstanteSimulacion(int valor)
        {
            _server.PeticionSetFactorSimulacion(valor);
        }

        internal void PeticionPlayPause()
        {
            _server.PeticionPlayPause();
        }

        public void SetEstadoSimulacion(bool pausado)
        {
           _paleta.EstablecerEstadoSimulacion(pausado);
        }

        #endregion



        #region IVisualizacion Members


        public void SetVLans(Guid idSwitchVLan, List<VLanSOA> vLansActuales)
        {
            SwitchVLanView swiView = _equipos[idSwitchVLan] as SwitchVLanView;
            swiView.SetVLans(vLansActuales);            
        }

        #endregion



        #region IVisualizacion Members


        public void NotificarArchivo(Guid guid, ArchivoSOA archivoSOA, TimeSpan timeSpan)
        {
            ComputadorView pcView = _equipos[guid] as ComputadorView;
            pcView.NotificarArchivo(archivoSOA, timeSpan);
        }

        #endregion
    }
}
