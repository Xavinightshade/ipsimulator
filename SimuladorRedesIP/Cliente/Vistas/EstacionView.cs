using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using RedesIP.Vistas.Utilidades;
using RedesIP.Vistas.Equipos;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.SOA;
using System.ServiceModel;
using SimuladorCliente.Vistas;
using SimuladorCliente;

namespace RedesIP.Vistas
{
	[CallbackBehavior(
	 ConcurrencyMode = ConcurrencyMode.Multiple,
	 UseSynchronizationContext = false)]
	public class EstacionView : PictureBox, IRegistroMovimientosMouse, EstacionServerCallback
	{
		EstacionServer _server;
		private Herramienta _herramientaActual;
		Dictionary<Guid, EquipoView> _equipos = new Dictionary<Guid, EquipoView>();
		List<PuertoEthernetView> _puertos = new List<PuertoEthernetView>();
		Dictionary<Guid, PuertoEthernetView> _diccioPuertos = new Dictionary<Guid, PuertoEthernetView>();
		List<ComputadorView> _computadores = new List<ComputadorView>();
		List<SwitchView> _switches = new List<SwitchView>();
		List<Conexion> _conexiones = new List<Conexion>();
		List<Marcador> _marcadores = new List<Marcador>();
		Dictionary<Guid, Marcador> _diccioMarcadores = new Dictionary<Guid, Marcador>();
		public void EstablecerServer(EstacionServer server)
		{
			_server = server;
		}
		private void InsertarComputador(EquipoSOA equipo)
		{

			ComputadorView computador = new ComputadorView(equipo);
			computador.EstablecerContenedor(this);
			_computadores.Add(computador);
			_equipos.Add(computador.Id, computador);
			_puertos.Add(computador.Puerto);
			_diccioPuertos.Add(computador.Puerto.Id, computador.Puerto);
		}
		private void InsertarSwitch(EquipoSOA equipo)
		{
			SwitchView swi = new SwitchView(equipo);
			swi.EstablecerContenedor(this);
			_switches.Add(swi);
			_equipos.Add(swi.Id, swi);
			foreach (PuertoEthernetView puerto in swi.PuertosEthernet)
			{
				_puertos.Add(puerto);
				_diccioPuertos.Add(puerto.Id, puerto);
			}


		}
		private PuertoEthernetView _puerto1;

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			switch (_herramientaActual)
			{
				case Herramienta.Marcadores:
					for (int i = 0; i < _conexiones.Count; i++)
					{
						if (_conexiones[i].HitTest(e.X, e.Y))
						{
							_conexiones[i].Seleccionado = true;
							continue;
						}
						_conexiones[i].Seleccionado = false;
					}
					Invalidate();
					break;

				case Herramienta.CreacionEquipos:
					Cursor = Cursors.Cross;
					break;
				case Herramienta.Conectar:
					Cursor = Cursors.Cross;
					for (int i = 0; i < _puertos.Count; i++)
					{
						if (_puertos[i].HitTest(e.X, e.Y))
						{

							_puertos[i].Seleccionado = true;


						}
						else
						{
							if (_puertos[i] != _puerto1)
								_puertos[i].Seleccionado = false;
						}
						Invalidate();

					}
					break;


				default:
					Cursor = Cursors.Default;
					break;
			}

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
			for (int i = 0; i < _conexiones.Count; i++)
			{
				_conexiones[i].DibujarElemento(g);
			}
			for (int i = 0; i < _marcadores.Count; i++)
			{
				_marcadores[i].DibujarElemento(g);
			}
		//	g.Dispose();
		}




		private TipoDeEquipo _tipoDeEquipo;
		public void CrearEquipo(TipoDeEquipo tipoDeEquipo)
		{
			_herramientaActual = Herramienta.CreacionEquipos;
			_tipoDeEquipo = tipoDeEquipo;
		}
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);
			for (int i = 0; i < _puertos.Count; i++)
			{
				if (_puertos[i].HitTest(e.X, e.Y))
				{
					_server.PeticionDeDireccionMAC(_puertos[i].Id);
					return;
				}
			}
			for (int i = 0; i < _computadores.Count; i++)
			{
				if (_computadores[i].HitTest(e.X, e.Y))
				{
					Ping forma = new Ping();
					forma.ShowDialog();
					if (forma.DialogResult == DialogResult.Cancel)
						return;
					for (int j = 0; j < forma.Numero; j++)
					{
						_server.Ping(_computadores[i].Id, forma.Mensaje, forma.P1, forma.P2, forma.P3);
					}

					return;
				}
			}

		}


		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (_herramientaActual == Herramienta.CreacionEquipos)
			{
				_server.PeticionCrearEquipo(_tipoDeEquipo, e.X, e.Y);
				Invalidate();
				_herramientaActual = Herramienta.Seleccion;
			}
			if (_herramientaActual == Herramienta.Conectar)
			{
				for (int i = 0; i < _puertos.Count; i++)
				{
					if (_puertos[i].HitTest(e.X, e.Y))
					{
						if (_puerto1 == null)
						{
							_puertos[i].Seleccionado = true;
							_puerto1 = _puertos[i];
						}
						else
						{
							_server.PeticionConectarPuertos(_puerto1.Id, _puertos[i].Id);
							_puerto1 = null;
						}
						break;
					}
				}

			}
			if (_herramientaActual == Herramienta.Marcadores)
			{
				for (int i = 0; i < _conexiones.Count; i++)
				{
					if (_conexiones[i].HitTest(e.X, e.Y))
					{
						bool yaEstaSeleccionado = false;
						for (int j = 0; j < _marcadores.Count; j++)
						{
							if (_marcadores[j].Conexion == _conexiones[i])
							{
								yaEstaSeleccionado = true;
								break;
							}
						}
						if (!yaEstaSeleccionado)
						{
							Marcador marcador = new Marcador(Guid.NewGuid(), _conexiones[i]);
							_marcadores.Add(marcador);
							_diccioMarcadores.Add(marcador.Id, marcador);
							if (NuevoMarcador != null)
							{
								NuevoMarcador(this, new NuevoMarcadorEventArgs(marcador));
								_server.PeticionEnviarInformacionConexion(marcador.Conexion.Id);
							}
						}
					}
				}
			}


		}

		public event EventHandler<NuevoMarcadorEventArgs> NuevoMarcador;


		public void CambiarHerramienta(Herramienta herramienta)
		{
			_herramientaActual = herramienta;
		}

		#region IRegistroMovimientosMouse Members


		public EstacionServer Contrato
		{
			get { return _server; }
		}

		#endregion

		#region ICallBackContract Members

		public void CrearEquipo(EquipoSOA equipo)
		{
			switch (equipo.TipoEquipo)
			{
				case TipoDeEquipo.Ninguno:
					break;
				case TipoDeEquipo.Computador:
					InsertarComputador(equipo);
					break;
				case TipoDeEquipo.Switch:
					InsertarSwitch(equipo);
					break;
				default:
					break;
			}
			Invalidate();
		}

		public void MoverEquipo(Guid idEquipo, int x, int y)
		{
			_equipos[idEquipo].MoverEquipo(x, y);
			Invalidate();
		}

		#endregion



		#region ICallBackContract Members


		public void ConectarPuertos(ConexionSOA conexion)
		{

			_conexiones.Add(new Conexion(conexion.Id, _diccioPuertos[conexion.IdPuerto1], _diccioPuertos[conexion.IdPuerto2]));
			Invalidate();
		}

		#endregion


		#region EstacionServerCallback Members


		public void ActualizarEstacion(EquipoSOA[] equipos, ConexionSOA[] conexiones)
		{
			LimpiarEstacion();
			for (int i = 0; i < equipos.Length; i++)
			{
				CrearEquipo(equipos[i]);
			}
			for (int i = 0; i < conexiones.Length; i++)
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
			_diccioMarcadores.Clear();
		}

		#endregion

		#region EstacionServerCallback Members

		public event EventHandler<NuevoMensajeEventArgs> NuevoMensaje;
		public void EnviarInformacionConexion(Guid idConexion, string info)
		{
			if (NuevoMensaje != null)
			{
				NuevoMensaje(this, new NuevoMensajeEventArgs(idConexion, info));
			}
		}

		#endregion
	}
}
