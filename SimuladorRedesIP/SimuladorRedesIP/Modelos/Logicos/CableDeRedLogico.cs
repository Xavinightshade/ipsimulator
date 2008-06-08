using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;
using RedesIP.Modelos.Equipos.Componentes;

namespace RedesIP.Modelos
{
	public class CableDeRedLogico
	{
		private Guid _id;

		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}
        private Object _syncObject = new Object();
		private static List<PuertoEthernetLogico> _listaPuertos = new List<PuertoEthernetLogico>();
		private PuertoEthernetLogico _puerto1;
		private PuertoEthernetLogico _puerto2;

		public CableDeRedLogico(PuertoEthernetLogico puerto1, PuertoEthernetLogico puerto2)
		{
			_id = Guid.NewGuid();
			_puerto1 = puerto1;
			_puerto2 = puerto2;
			ConectarPuertos();
		}
		public event EventHandler<FrameTransmitidoEventArgs> FrameTransmitidoPuerto1;
		public event EventHandler<FrameTransmitidoEventArgs> FrameTransmitidoPuerto2;

	    public PuertoEthernetLogico Puerto1
	    {
	        get { return _puerto1; }
	    }
        public PuertoEthernetLogico Puerto2
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
			if (FrameTransmitidoPuerto2 != null)
			{
				FrameTransmitidoPuerto2(this, e);
			}
			((IEnvioReciboDatos)Puerto1).RecibirFrame(e.FrameTransmitido);
		}

		private void OnFrameTransmitidoDelPuerto1(object sender, FrameTransmitidoEventArgs e)
		{
			if (FrameTransmitidoPuerto1 != null)
			{
				FrameTransmitidoPuerto1(this, e);
			}
			((IEnvioReciboDatos)_puerto2).RecibirFrame(e.FrameTransmitido);
		}


	}
}
