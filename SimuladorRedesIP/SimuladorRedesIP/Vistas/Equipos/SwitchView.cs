using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Properties;
using RedesIP.Vistas.Equipos.Componentes;
using System.Collections.ObjectModel;

namespace RedesIP.Vistas.Equipos
{
	public class SwitchView:EquipoView
	{
		private List<PuertoEthernetView> _puertosEthernet = new List<PuertoEthernetView>();


		public SwitchView(int origenX, int origenY)
			:base(origenX,origenY,300,50)
		{
			CrearPuertos();
		}

		private void CrearPuertos()
		{
			for (int i = 0; i < 11; i++)
			{
				PuertoEthernetView puerto = new PuertoEthernetView((i * 20) + 25, 30, this);
				_puertosEthernet.Add(puerto);
			}
		}


		public override System.Drawing.Image Imagen
		{
			get { return Resources.Switch; }
		}
		public override void DibujarElemento(System.Drawing.Graphics grafico)
		{
			base.DibujarElemento(grafico);
			for (int i = 0; i < _puertosEthernet.Count; i++)
			{
				_puertosEthernet[i].DibujarElemento(grafico);
			}
		}
	}
}
