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
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);
            _herramienta.OnMouseDoubleClick(e);
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
            foreach (RouterSOA rou in estacionSOA.Routers)
            {
                CrearRouter(rou);
            }
            foreach (CableSOA cable in estacionSOA.Cables)
            {
                ConectarPuertos(cable);
            }
			Invalidate();
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
            _routers.Clear();
			_computadores.Clear();
			_marcadores.Clear();
		}


        private DockPanel _dockMain;


        internal void Inicializar(IModeloSOA presenterLocal, DockPanel dockMain)
        {
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

        #endregion
    }
}
