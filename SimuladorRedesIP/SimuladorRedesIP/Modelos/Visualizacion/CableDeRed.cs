using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Visualizacion.Equipos;

namespace RedesIP.Modelos.Visualizacion
{
	public class CableDeRed
	{
		private CableDeRedLogico _cableRedLogico;
		private PuertoEthernet _puerto1;
		private PuertoEthernet _puerto2;


		public event EventHandler CambioEnPosicionConexion;

		public CableDeRed(PuertoEthernet puerto1, PuertoEthernet puerto2)
		{
			_puerto1 = puerto1;
			_puerto2 = puerto2;

				InicializarConexionLogica();
		}

		private void InicializarConexionLogica()
		{
			_cableRedLogico = new CableDeRedLogico(_cableRedLogico.Puerto1, _cableRedLogico.Puerto2);
		}
	}



}
