using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;
using RedesIP.Modelos.Equipos.Componentes;
using System.Collections.ObjectModel;
using RedesIP.Common;


namespace RedesIP.Modelos.Logicos.Equipos
{
	public class ComputadorLogico : EquipoLogico
	{
        private string _direccionIP;

        public string DireccionIP
        {
            get { return _direccionIP; }
            set { _direccionIP = value; }
        }

		private PuertoEthernetCompleto _puertoEthernet;
		private string _nombreDelPc;
		/// <summary>
		/// Puerto Ethernet Del PC
		/// </summary>
        public PuertoEthernetCompleto PuertoEthernet
		{
			get { return _puertoEthernet; }
		}
		/// <summary>
		/// Nombre Del Pc
		/// </summary>
		public string Nombre
		{
			get { return _nombreDelPc; }
		}
		/// <summary>
		/// Crea un nuevo PC
		/// </summary>
		/// <param name="nombre"></param>
		public ComputadorLogico(Guid id, int X,int Y):base(id, TipoDeEquipo.Computador,X,Y)
		{

			_nombreDelPc = "PC_"+GetHashCode().ToString();

		}


		private void OnFrameRecibido(object sender, FrameRecibidoEventArgs e)
		{


		}




		private void EnviarMensaje(IFrameMessage mensaje, string stringDestino)
		{
            Frame frameATransmitir = new Frame(mensaje, _puertoEthernet.MACAddress, stringDestino);
			((IEnvioReciboDatos)_puertoEthernet).TransmitirFrame(frameATransmitir);

		}




		public override ReadOnlyCollection<PuertoEthernetLogicoBase> PuertosEthernet
		{
			get {
			Collection<PuertoEthernetLogicoBase> puertos=	new Collection<PuertoEthernetLogicoBase>();
				puertos.Add(_puertoEthernet);

				return new ReadOnlyCollection<PuertoEthernetLogicoBase>(puertos);
			}
		}
        public override void AgregarPuerto(Guid idPuerto)
        {
            _puertoEthernet = new PuertoEthernetCompleto(MACAddressFactory.NewMAC(), idPuerto);
        }

        public override void InicializarEquipo()
        {
            _puertoEthernet.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(OnFrameRecibido);

        }
    }
}
