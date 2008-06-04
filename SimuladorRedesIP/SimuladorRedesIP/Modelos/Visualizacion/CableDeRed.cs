using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Utilidades;
using RedesIP.Modelos.Visualizacion.Equipos;

namespace RedesIP.Modelos.Visualizacion
{
	public class CableDeRed
	{
		private Equipo _equipo1;
		private Equipo _equipo2;
		private Linea _linea;

		public Linea Linea
		{
			get { return _linea; }
		}
		public event EventHandler CambioEnPosicionConexion;

		public CableDeRed(Equipo equipo1, Equipo equipo2)
		{
			_equipo1 = equipo1;
			_equipo2 = equipo2;

			Inicializar();
		}
		private void Inicializar()
		{
			_linea = new Linea(_equipo1.OrigenX, _equipo1.OrigenY, _equipo2.OrigenX, _equipo2.OrigenY);
			_linea.CambioDePosicion += new EventHandler(HandlerCambioEnLinea);
			_equipo1.CambioEnPosicion += new EventHandler(HandlerCambioPosicionDispositivo);
			_equipo2.CambioEnPosicion += new EventHandler(HandlerCambioPosicionDispositivo);
		}

		private void HandlerCambioEnLinea(object sender, EventArgs e)
		{
			OnCambioDeConexion();
		}

		private void OnCambioDeConexion()
		{
			if (CambioEnPosicionConexion != null)
				CambioEnPosicionConexion(this, new EventArgs());
		}

		private void HandlerCambioPosicionDispositivo(object sender, EventArgs e)
		{
			_linea.X1 = _equipo1.OrigenX;
			_linea.Y1 = _equipo1.OrigenY;
			_linea.X2 = _equipo2.OrigenX;
			_linea.Y2 = _equipo2.OrigenY;
		}
	}



}
