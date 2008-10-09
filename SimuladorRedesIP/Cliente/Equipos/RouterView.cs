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
    public class RouterView : EquipoView
    {
        public RouterView(RouterSOA equipo)
            : base(equipo.Id, equipo.Nombre, equipo.X, equipo.Y, Resources.Switch.Size.Width,
            Resources.Switch.Size.Height)
        {
            CrearPuertos(equipo.Puertos);
            ToolStripMenuItem item = new ToolStripMenuItem("Tabla de Rutas", Resources.sniffer);
            item.Click += new EventHandler(MenuRutasClick);
            Menu.Items.Add(item);

        }

        private void MenuRutasClick(object sender, EventArgs e)
        {
            List<RutaSOA> rutasEstaticas = Contenedor.Contrato.TraerRutas(this.Id);
            List<RutaSOA> rutasRouter = Contenedor.Contrato.TraerRutasRouter(this.Id);

            using (RouteTableForm rouForm = new RouteTableForm())
            {
                rouForm.Inicializar(rutasEstaticas,rutasRouter, _puertosEthernet);
                if (rouForm.ShowDialog() == DialogResult.OK)
                {
                    Contenedor.Contrato.ActualizarRutas(Id, rutasEstaticas);
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
                    puerto.DireccionMAC, puerto.IPAddress, puerto.Mask, (i * 30) + 3, 7, this, puerto.Nombre,puerto.Habilitado));
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
            return Nombre;
        }
        protected override string GetFullInfoMapa()
        {
            string tip = base.GetFullInfoMapa();
            foreach (PuertoEthernetViewCompleto puerto in _puertosEthernet)
            {
                tip += Environment.NewLine + "Puerto:  " + puerto.Nombre;
                tip += Environment.NewLine + "Dirección IP:  " + puerto.DireccionIP + " / " + puerto.Mask;
                tip += Environment.NewLine + "Dirección MAC:  " + puerto.DireccionMAC;

            }
            return tip;
        }
        public override System.Drawing.Image Imagen
        {
            get { return Resources.Router; }
        }
        protected override void OnMouseDobleClick(MouseEventArgs e)
        {
            using (FormularioRouter rouForm = new FormularioRouter())
            {
                List<PuertoCompletoSOA> puertos = new List<PuertoCompletoSOA>();
                foreach (PuertoEthernetViewCompleto item in _puertosEthernet)
                {
                    PuertoCompletoSOA puerto = new PuertoCompletoSOA(item.Id, item.DireccionMAC, item.Nombre, item.DireccionIP, item.Mask,item.Habilitado);
                    puertos.Add(puerto);

                }
                rouForm.Inicializar(puertos);
                rouForm.NombreRouter = Nombre;
                if (rouForm.ShowDialog() == DialogResult.OK)
                {
                    RouterSOA router = new RouterSOA();
                    router.Id = Id;
                    router.Nombre = rouForm.NombreRouter;
                    Contenedor.Contrato.PeticionEstablecerDatosRouter(router);

                    foreach (PuertoCompletoSOA puertoNuevo in puertos)
                    {
                        Contenedor.Contrato.PeticionEstablecerDatosPuertoCompleto(puertoNuevo);
                    }

                }
            }
        }

    }
}

