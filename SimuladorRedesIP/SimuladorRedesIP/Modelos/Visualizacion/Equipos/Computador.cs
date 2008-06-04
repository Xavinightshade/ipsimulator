using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.ModelosLogicos.Equipos;
using RedesIP.ModelosLogicos.Datos;

namespace RedesIP.Modelos.Visualizacion.Equipos
{
	public class Computador:Equipo
	{
		private readonly ComputadorLogico _computadorLogico;
		public Computador(string nombre,MACAddress direccionMAC,int posicionX,int posicionY):base(posicionX,posicionY)
		{
			_computadorLogico = new ComputadorLogico(nombre, direccionMAC);
		}
	}
}
