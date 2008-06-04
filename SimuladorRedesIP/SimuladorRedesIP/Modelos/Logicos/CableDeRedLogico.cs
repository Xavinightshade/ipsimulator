using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.ModelosLogicos.Datos;
using RedesIP.ModelosLogicos.Equipos.Componentes;

namespace RedesIP.ModelosLogicos
{
	public class CableDeRedLogico
	{
        private Object _syncObject = new Object();
		private static List<PuertoEthernet> _listaPuertos = new List<PuertoEthernet>();
		private PuertoEthernet _puerto1;
		private PuertoEthernet _puerto2;

		public CableDeRedLogico(PuertoEthernet puerto1, PuertoEthernet puerto2)
		{
			_puerto1 = puerto1;
			_puerto2 = puerto2;
			ConectarPuertos();
		}

	    public PuertoEthernet Puerto1
	    {
	        get { return _puerto1; }
	    }
        public PuertoEthernet Puerto2
        {
            get { return _puerto2; }
        }

	    private void ConectarPuertos()
		{
			if (Puerto1 == _puerto2)
				System.Diagnostics.Debug.Assert(false, "no me puedo conectar a mi mismo");
			if (_listaPuertos.Contains(Puerto1) || _listaPuertos.Contains(_puerto2))
				System.Diagnostics.Debug.Assert(false, "este puerto ya fue conectado");
			Puerto1.FrameTransmitido += new EventHandler<FrameTransmitidoEventArgs>(OnFrameTransmitidoDelPuerto1);
			_puerto2.FrameTransmitido += new EventHandler<FrameTransmitidoEventArgs>(OnFrameTransmitidoDelPuerto2);
			_listaPuertos.Add(Puerto1);
			_listaPuertos.Add(_puerto2);
		}
		public void DesconectarPuertos()
		{
			Puerto1.FrameTransmitido -= new EventHandler<FrameTransmitidoEventArgs>(OnFrameTransmitidoDelPuerto1);
			_puerto2.FrameTransmitido -= new EventHandler<FrameTransmitidoEventArgs>(OnFrameTransmitidoDelPuerto2);
			_listaPuertos.Remove(Puerto1);
			_listaPuertos.Remove(_puerto2);

		}


		private void OnFrameTransmitidoDelPuerto2(object sender, FrameTransmitidoEventArgs e)
		{
			((IEnvioReciboDatos)Puerto1).RecibirFrame(e.FrameTransmitido);
		}

		private void OnFrameTransmitidoDelPuerto1(object sender, FrameTransmitidoEventArgs e)
		{
			((IEnvioReciboDatos)_puerto2).RecibirFrame(e.FrameTransmitido);
		}


	}
}
