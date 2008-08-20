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
		private static List<PuertoEthernetLogicoBase> _listaPuertos = new List<PuertoEthernetLogicoBase>();
		private PuertoEthernetLogicoBase _puerto1;
		private PuertoEthernetLogicoBase _puerto2;

		public CableDeRedLogico(PuertoEthernetLogicoBase puerto1, PuertoEthernetLogicoBase puerto2)
		{
			_id = Guid.NewGuid();
			_puerto1 = puerto1;
			_puerto2 = puerto2;
			ConectarPuertos();
		}
		public event EventHandler<FrameRecibidoEventArgs> FrameRecibidoPuerto1;
        public event EventHandler<FrameRecibidoEventArgs> FrameRecibidoPuerto2;

	    public PuertoEthernetLogicoBase Puerto1
	    {
	        get { return _puerto1; }
	    }
        public PuertoEthernetLogicoBase Puerto2
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
            Puerto1.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(Puerto1_FrameRecibido);
            _puerto2.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(_puerto2_FrameRecibido);
			_listaPuertos.Add(Puerto1);
			_listaPuertos.Add(_puerto2);
		}

        void _puerto2_FrameRecibido(object sender, FrameRecibidoEventArgs e)
        {
            if (FrameRecibidoPuerto2 != null)
            {
                FrameRecibidoPuerto2(this, new FrameRecibidoEventArgs(e.FrameRecibido, Puerto2.MACAddress));
            }
        }

        void Puerto1_FrameRecibido(object sender, FrameRecibidoEventArgs e)
        {
            if (FrameRecibidoPuerto1 != null)
            {
                FrameRecibidoPuerto1(this, new FrameRecibidoEventArgs(e.FrameRecibido, Puerto1.MACAddress));
            }
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
