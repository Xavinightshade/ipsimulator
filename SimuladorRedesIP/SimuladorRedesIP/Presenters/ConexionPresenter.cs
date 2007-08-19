using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Utilidades;

namespace RedesIP.Presenters
{
	public class ConexionPresenter:MarshalByRefObject
	{
		Linea _lineaVista;
		Linea _lineaModelo;
		public ConexionPresenter(Linea lineaModelo,Linea lineaVista)
		{
			_lineaModelo = lineaModelo;
			_lineaVista = lineaVista;
			_lineaModelo.CambioDePosicion += new EventHandler(_lineaModelo_CambioDePosicion);
		}

		public void _lineaModelo_CambioDePosicion(object sender, EventArgs e)
		{
			_lineaVista.X1 = _lineaModelo.X1;
			_lineaVista.X2 = _lineaModelo.X2;
			_lineaVista.Y1 = _lineaModelo.Y1;
			_lineaVista.Y2 = _lineaModelo.Y2;
		}
	}
}
