using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.SOA;
using SimuladorCliente.Properties;
using System.Windows.Forms;
using System.ComponentModel;
using SimuladorCliente.Formularios;

namespace RedesIP.Vistas.Equipos
{
	public class ComputadorView:EquipoView
	{
		public ComputadorView(ComputadorSOA equipo)
            : base(equipo.Id, equipo.X, equipo.Y, Resources.Computador.Width, Resources.Computador.Height)
		{
            ToolStripMenuItem item = new ToolStripMenuItem("Hacer Ping", Resources.sniffer);
            item.Click += new EventHandler(OnPingClick);
            Menu.Items.Add(item);
            _puerto = new PuertoEthernetViewCompleto(equipo.Puerto.Id, equipo.Puerto.DireccionMAC,15, 30, this);
		}

        private void OnPingClick(object sender, EventArgs e)
        {
            PingForm pingForm = new PingForm();
            pingForm.Text = "Host: IP:" + _puerto.IPAddress + ", MAC:" + _puerto.DireccionMAC;
            pingForm.ShowDialog();
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
        protected override void OnMouseUpEvent(MouseEventArgs e)
        {
            base.OnMouseUpEvent(e);
            if (e.Button == MouseButtons.Right)
            {
                Menu.Show(base.OwnerControl, DimensionMundo.OrigenX + DimensionMundo.Ancho, DimensionMundo.OrigenY + DimensionMundo.Alto);
            }

        }    


	}
}
