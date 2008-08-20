using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.SOA;
using SimuladorCliente.Properties;

namespace RedesIP.Vistas.Equipos
{
	public class ComputadorView:EquipoView
	{
		public ComputadorView(ComputadorSOA equipo)
            : base(equipo.Id, equipo.X, equipo.Y, Resources.Computador.Width, Resources.Computador.Height)
		{
            _puerto = new PuertoEthernetViewCompleto(equipo.Puerto.Id, equipo.Puerto.DireccionMAC,15, 30, this);
		}
        PuertoEthernetViewCompleto _puerto;

		public PuertoEthernetViewCompleto Puerto
		{
			get { return _puerto; }
		}
		public override Image Imagen
		{
			get { return Resources.Computador; }
		}
		public override void DibujarElemento(Graphics grafico)
		{
			base.DibujarElemento(grafico);
			_puerto.DibujarElemento(grafico);
		}
        protected override string GetInfoMapa()
        {
            return _puerto.DireccionMAC;
        }


	}
}
