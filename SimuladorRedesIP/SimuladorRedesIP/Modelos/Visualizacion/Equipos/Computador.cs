using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Equipos;
using RedesIP.Modelos.Datos;
using RedesIP.Modelos.Logicos.Equipos;

namespace RedesIP.Modelos.Visualizacion.Equipos
{
	public class Computador:Equipo
	{
		private readonly ComputadorLogico _computadorLogico;
		private readonly PuertoEthernet _puertoEthernet;

		public PuertoEthernet PuertoEthernet
		{
			get { return _puertoEthernet; }
		} 


		public Computador(string nombre,MACAddress direccionMAC,int posicionX,int posicionY):base(posicionX,posicionY)
		{
			_computadorLogico = new ComputadorLogico(nombre, direccionMAC);
			_puertoEthernet = new PuertoEthernet(_computadorLogico.PuertoEthernet, posicionX, posicionY);
		}
		public override Guid Id
		{
			get { return _computadorLogico.Id; }
		}


		public override System.Collections.ObjectModel.ReadOnlyCollection<RedesIP.Modelos.Equipos.Componentes.PuertoEthernetLogico> PuertosEthernet
		{
			get { return _computadorLogico.PuertosEthernet; }
		}
	}
}
