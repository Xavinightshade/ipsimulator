using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Utilidades;
using RedesIP.Modelos.Visualizacion.Equipos;

namespace RedesIP.Modelos.Visualizacion
{
	public class CableDeRed
	{
		private CableDeRedLogico _cableRedLogico;
		private PuertoEthernet _puerto1;
		private PuertoEthernet _puerto2;
		private Linea _linea;

		public Linea Linea
		{
			get { return _linea; }
		}
		public event EventHandler CambioEnPosicionConexion;

		public CableDeRed(PuertoEthernet puerto1, PuertoEthernet puerto2)
		{
			_puerto1 = puerto1;
			_puerto2 = puerto2;

			Inicializar();
			InicializarConexionLogica();
		}

		private void InicializarConexionLogica()
		{
			_cableRedLogico = new CableDeRedLogico(_cableRedLogico.Puerto1, _cableRedLogico.Puerto2);
		}
		private void Inicializar()
		{
			_linea = new Linea(_puerto1.OrigenX, _puerto1.OrigenY, _puerto2.OrigenX, _puerto2.OrigenY);
			_linea.CambioDePosicion += new EventHandler(HandlerCambioEnLinea);
			_puerto1.CambioEnPosicion += new EventHandler(HandlerCambioPosicionDispositivo);
			_puerto2.CambioEnPosicion += new EventHandler(HandlerCambioPosicionDispositivo);
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
			_linea.X1 = _puerto1.OrigenX;
			_linea.Y1 = _puerto1.OrigenY;
			_linea.X2 = _puerto2.OrigenX;
			_linea.Y2 = _puerto2.OrigenY;
		}
	}



}
