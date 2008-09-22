using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;
using RedesIP.Modelos.Equipos.Componentes;
using System.Collections.ObjectModel;
using RedesIP.Common;
using BusinessLogic.Modelos.Logicos.Datos;
using BusinessLogic.OSI;
using BusinessLogic.Protocolos;


namespace RedesIP.Modelos.Logicos.Equipos
{
	public class ComputadorLogico : EquipoLogico
	{


		private PuertoEthernetCompleto _puertoEthernet;
        private CapaDatos _capaDatos;
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


        public void Ping(Guid idEquipo, string ipDestino, string datos)
        {
            Packet paquete = new Packet(_puertoEthernet.IPAddress, ipDestino, datos);
            _capaDatos.EnviarPaquete(paquete);
        }
 


		private void EnviarMensaje(IFrameMessage mensaje, string MACDestino)
		{
            Frame frameATransmitir = new Frame(mensaje, _puertoEthernet.MACAddress, MACDestino);
			((IEnvioReciboDatos)_puertoEthernet).TransmitirFrame(frameATransmitir);

		}





        public override void AgregarPuerto(Guid idPuerto,string nombre)
        {
            _puertoEthernet = new PuertoEthernetCompleto(MACAddressFactory.NewMAC(), idPuerto,nombre);
        }

        public override void InicializarEquipo()
        {
            _capaDatos = new CapaDatos(new ARP(), _puertoEthernet);


        }


    }
}
