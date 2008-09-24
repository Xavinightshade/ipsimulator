using System;
using System.Collections.Generic;
using System.Text;
using SimuladorCliente.Properties;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.SOA;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using SimuladorCliente.Formularios;
using SOA.Componentes;

namespace RedesIP.Vistas.Equipos
{
    class RouterView : EquipoView
    {
		public RouterView(RouterSOA equipo)
            : base(equipo.Id,equipo.Nombre, equipo.X, equipo.Y, Resources.Switch.Size.Width,
            Resources.Switch.Size.Height)
		{
			CrearPuertos(equipo.Puertos);
            ToolStripMenuItem item = new ToolStripMenuItem("Tabla de Rutas", Resources.sniffer);
            item.Click += new EventHandler(MenuRutasClick);
            Menu.Items.Add(item);

		}

        private void MenuRutasClick(object sender, EventArgs e)
        {
            List<RutaSOA> rutas = Contenedor.Contrato.TraerRutas(this.Id);
            using (RouteTableForm rouForm=new RouteTableForm() )
            {
                rouForm.Inicializar(rutas,_puertosEthernet);
                if (rouForm.ShowDialog()==DialogResult.OK)
                {
                    Contenedor.Contrato.ActualizarRutas(Id, rutas);
                } 
                
            }
        }

        private List<PuertoEthernetViewCompleto> _puertosEthernet = new List<PuertoEthernetViewCompleto>();

        public ReadOnlyCollection<PuertoEthernetViewCompleto> PuertosEthernet
        {
            get { return _puertosEthernet.AsReadOnly(); }
        }




        private void CrearPuertos(IEnumerable<PuertoCompletoSOA> puertos)
        {
            int i = 0;
            foreach (PuertoCompletoSOA puerto in puertos)
            {

                _puertosEthernet.Add(new PuertoEthernetViewCompleto(puerto.Id,
                    puerto.DireccionMAC,puerto.IPAddress,puerto.Mask, (i * 30)+3 , 7, this,puerto.Nombre));
                i++;
            }

        }



        public override void DibujarElemento(System.Drawing.Graphics grafico)
        {
            base.DibujarElemento(grafico);
            for (int i = 0; i < _puertosEthernet.Count; i++)
            {
                _puertosEthernet[i].DibujarElemento(grafico);
            }
        }
        protected override string GetInfoMapa()
        {
            return "Router";
        }
        public override System.Drawing.Image Imagen
        {
            get { return Resources.Router; }
        }

    }
}

