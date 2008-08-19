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

namespace RedesIP.Vistas
{
	[CallbackBehavior(
	 ConcurrencyMode = ConcurrencyMode.Multiple,
	 UseSynchronizationContext = false)]
	public partial class EstacionView : PictureBox, IRegistroMovimientosMouse, IVisualizacion
	{





        HerramientaBase _herramienta;
        IModeloSOA _server;

		Dictionary<Guid, EquipoView> _equipos = new Dictionary<Guid, EquipoView>();
		List<PuertoEthernetView> _puertos = new List<PuertoEthernetView>();
		Dictionary<Guid, PuertoEthernetView> _diccioPuertos = new Dictionary<Guid, PuertoEthernetView>();
		List<ComputadorView> _computadores = new List<ComputadorView>();
		List<SwitchView> _switches = new List<SwitchView>();
        List<RouterView> _routers = new List<RouterView>();
		public void EstablecerServer(IModeloSOA server)
		{
			_server = server;
		}
        public EstacionView()
        {
            _herramienta = FabricaHerramienta.CrearHerramienta(Herramienta.CreacionEquipos, this);
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
        public void ActualizarEstacion(List<EquipoSOA> equipos, List<CableSOA> conexiones)
		{
			LimpiarEstacion();
			for (int i = 0; i < equipos.Count; i++)
			{
				CrearEquipo(equipos[i]);
			}
			for (int i = 0; i < conexiones.Count; i++)
			{
				ConectarPuertos(conexiones[i]);
			}
			Invalidate();
		}
		private void LimpiarEstacion()
		{
			_conexiones.Clear();
			_diccioPuertos.Clear();
			_puertos.Clear();
			_puerto1 = null;
			_equipos.Clear();
			_switches.Clear();
			_computadores.Clear();
			_marcadores.Clear();
		}


    }
}
