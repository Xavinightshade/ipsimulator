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
using RedesIP.Common;

namespace RedesIP.Vistas.Equipos
{
	public class ComputadorView:EquipoView
	{
		public ComputadorView(ComputadorSOA equipo)
            : base(equipo.Id,equipo.Nombre, equipo.X, equipo.Y, Resources.Computador.Width, Resources.Computador.Height)
		{
            _defaultGateWay = equipo.DefaultGateWay;
            Nombre = equipo.Nombre;
            ToolStripMenuItem item = new ToolStripMenuItem("Hacer Ping", Resources.shell_script_16x16);
            item.Click += new EventHandler(OnPingClick);
            Menu.Items.Add(item);
            _puerto = new PuertoEthernetViewCompleto(equipo.Puerto.Id,
                equipo.Puerto.DireccionMAC,equipo.Puerto.IPAddress,equipo.Puerto.Mask,15, 30, this,equipo.Puerto.Nombre,equipo.Puerto.Habilitado);
		}

        private string _defaultGateWay;

        public string DefaultGateWay
        {
            get { return _defaultGateWay; }
            set { _defaultGateWay = value; }
        }


        private void OnPingClick(object sender, EventArgs e)
        {
            if (!_puerto.Habilitado)
            {
                MessageBox.Show("El puerto del Equipo no está habilitado,"+
                Environment.NewLine+"Configure el puerto del equipo","Ping",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            PingForm pingForm = new PingForm();
            pingForm.SetInfoEquipo(GetFullInfoMapa());
            if (pingForm.ShowDialog() == DialogResult.OK)
            {
                    Contenedor.Contrato.Ping(Id, pingForm.IPAddress);

            }
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
            return Nombre+ Environment.NewLine+_puerto.DireccionIP+" / "+_puerto.Mask;
        }
        protected override void OnMouseUpEvent(MouseEventArgs e)
        {
            base.OnMouseUpEvent(e);


        }
        protected override string GetFullInfoMapa()
        {
            string tip = base.GetFullInfoMapa();
            tip += Environment.NewLine + "Puerto:  " + _puerto.Nombre;
            tip += Environment.NewLine+"Dirección IP:  " + _puerto.DireccionIP + " / " + _puerto.Mask;
            tip += Environment.NewLine + "Default GateWay:  " + _defaultGateWay;
            tip += Environment.NewLine + "Dirección MAC:  " + _puerto.DireccionMAC;
            return tip;

        }
        protected override void OnMouseDobleClick(MouseEventArgs e)
        {
           
            FormularioComputador formaPC = new FormularioComputador();
            if (this.Puerto.DireccionIP != null)
                formaPC.IPAddress = this.Puerto.DireccionIP;
            if (this.Puerto.Nombre != null)
                formaPC.NombrePuerto = this.Puerto.Nombre;
            if (this.Puerto.Mask != null)
                formaPC.Mask = this.Puerto.Mask.ToString();
            if (this.Nombre != null)
                formaPC.NombrePC = this.Nombre;
            if (this.DefaultGateWay != null)
                formaPC.DefaultGateWay = this.DefaultGateWay;
            formaPC.PuertoHabilitado = this.Puerto.Habilitado;

            formaPC.MACAddress = this.Puerto.DireccionMAC;
            if (formaPC.ShowDialog() == DialogResult.OK)
            {

                base.Contenedor.Contrato.PeticionEstablecerDatosComputador(new RedesIP.SOA.ComputadorSOA(this.Id, formaPC.NombrePC, formaPC.DefaultGateWay));
                int? mask = null;
                int maskParsed;
                if (int.TryParse(formaPC.Mask, out maskParsed))
                {
                    mask = maskParsed;
                }
                base.Contenedor.Contrato.PeticionEstablecerDatosPuertoCompleto(
                    new RedesIP.SOA.PuertoCompletoSOA(this.Puerto.Id,
                        formaPC.MACAddress, formaPC.NombrePuerto, formaPC.IPAddress, mask,formaPC.PuertoHabilitado));
            }
            return;
        }




	}
}
