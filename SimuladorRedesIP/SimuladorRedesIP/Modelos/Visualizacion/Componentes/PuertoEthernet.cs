using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.Modelos.Datos;

namespace RedesIP.Modelos.Visualizacion
{
	public class PuertoEthernet:ComponenteMovible
	{
		private PuertoEthernetLogico _puertoLogico;
		public PuertoEthernet(PuertoEthernetLogico puertoLogico, int posicionX, int posicionY) :
			base(posicionX,posicionY)
		{
			_puertoLogico = puertoLogico;
			_puertoLogico.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);
			_puertoLogico.FrameTransmitido += new EventHandler<FrameTransmitidoEventArgs>(OnFrameTransmitido);
		}

		private void OnFrameTransmitido(object sender, FrameTransmitidoEventArgs e)
		{
			if (FrameTransmitido != null)
				FrameTransmitido(sender, e);
		}

		private void OnFrameRecibido(object sender, FrameRecibidoEventArgs e)
		{
			if (FrameRecibido != null)
				FrameRecibido(sender, e);
		}

		public event EventHandler<FrameTransmitidoEventArgs> FrameTransmitido;
		public event EventHandler<FrameRecibidoEventArgs> FrameRecibido;
		public MACAddress MACAddress { get { return _puertoLogico.MACAddress; } }

		#region IMovible Members

		public event EventHandler CambioEnPosicion;

	


		public int OrigenX
		{
			get { throw new NotImplementedException(); }
		}

		public int OrigenY
		{
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}
