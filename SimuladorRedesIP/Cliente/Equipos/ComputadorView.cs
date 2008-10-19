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
using SOA;

namespace RedesIP.Vistas.Equipos
{
    public class ComputadorView : EquipoView
    {
        public ComputadorView(ComputadorSOA equipo)
            : base(equipo.Id, equipo.Nombre, equipo.X, equipo.Y, Resources.Computador.Width, Resources.Computador.Height)
        {
            _defaultGateWay = equipo.DefaultGateWay;
            Nombre = equipo.Nombre;
            ToolStripMenuItem pingItem = new ToolStripMenuItem("Hacer Ping", Resources.shell_script_16x16);
            ToolStripMenuItem tcpItem = new ToolStripMenuItem("Enviar Archivo por TCP", Resources.html_file_16x16);
            ToolStripSeparator sepItem = new ToolStripSeparator();
            ToolStripMenuItem archivosItem = new ToolStripMenuItem("Archivos Recibidos", Resources.folder_with_file_16x16);
            pingItem.Click += new EventHandler(OnPingClick);
            tcpItem.Click += new EventHandler(tcpItem_Click);
            archivosItem.Click += new EventHandler(archivosItem_Click);
            Menu.Items.Add(pingItem);
            Menu.Items.Add(tcpItem);
            Menu.Items.Add(sepItem);
            Menu.Items.Add(archivosItem);
            _puerto = new PuertoEthernetViewCompleto(equipo.Puerto.Id,
                equipo.Puerto.DireccionMAC, equipo.Puerto.IPAddress, equipo.Puerto.Mask, 15, 26, this, equipo.Puerto.Nombre, equipo.Puerto.Habilitado);
        }

        void archivosItem_Click(object sender, EventArgs e)
        {
            ArchivoForm form = new ArchivoForm();
            form.Inicializar(Id, _archivos, base.Contenedor.Contrato);
            form.ShowDialog();
        }

        void tcpItem_Click(object sender, EventArgs e)
        {
            if (!_puerto.Habilitado)
            {
                MessageBox.Show("El puerto del Equipo no está habilitado," +
                Environment.NewLine + "Configure el puerto del equipo", "Ping", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            EnviarTCPForm pingForm = new EnviarTCPForm();
            pingForm.SetInfoEquipo(GetFullInfoMapa());
            if (pingForm.ShowDialog() == DialogResult.OK)
            {
                Contenedor.Contrato.EnviarStream(Id, pingForm.IPAddress, pingForm.SourcePort, pingForm.DestinationPort, pingForm.Stream,
                    pingForm.SegmentSize, pingForm.FileName);
            }
        }

        private string _defaultGateWay;

        public string DefaultGateWay
        {
            get { return _defaultGateWay; }
            set { _defaultGateWay = value; }
        }

        public override void EstablecerContenedor(IRegistroMovimientosMouse inst)
        {
            base.EstablecerContenedor(inst);
            _puerto.EstablecerContenedor(inst);

        }

        private void OnPingClick(object sender, EventArgs e)
        {
            if (!_puerto.Habilitado)
            {
                MessageBox.Show("El puerto del Equipo no está habilitado," +
                Environment.NewLine + "Configure el puerto del equipo", "Ping", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            if (string.IsNullOrEmpty(_puerto.DireccionIP))
                return string.Empty;
            return base.GetInfoMapa() + _puerto.DireccionIP + " / " + _puerto.Mask;
        }
        protected override void OnMouseUpEvent(MouseEventArgs e)
        {
            base.OnMouseUpEvent(e);


        }
        protected override string GetFullInfoMapa()
        {
            string tip = base.GetFullInfoMapa();
            tip += Environment.NewLine + "Puerto:  " + _puerto.Nombre;
            tip += Environment.NewLine + "Dirección IP:  " + _puerto.DireccionIP + " / " + _puerto.Mask;
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
                        formaPC.MACAddress, formaPC.NombrePuerto, formaPC.IPAddress, mask, formaPC.PuertoHabilitado));
            }
            return;
        }




        private delegate void SetLabelTextDelegate(ArchivoSOA archivoSOA);
        private delegate void SetEcho(bool esReply, string ipOrigen, TimeSpan hora);
        private List<ArchivoSOA> _archivos = new List<ArchivoSOA>();
        internal void NotificarArchivo(ArchivoSOA archivoSOA)
        {
            if (Contenedor.InvokeRequired)
            {
                Contenedor.BeginInvoke(new SetLabelTextDelegate(NotificarArchivo),
                                                            new object[] { archivoSOA });

                return;
            }
            _archivos.Add(archivoSOA);
            string mensaje =
            "Hora: " + archivoSOA.Fecha.ToString() + Environment.NewLine +
            "Nombre: " + archivoSOA.FileName + Environment.NewLine +
            "Tamaño: " + archivoSOA.Length.ToString() + " bytes" + Environment.NewLine +
            "Puerto Origen: " + archivoSOA.SourcePort.ToString() + Environment.NewLine +
            "Puerto Destino: " + archivoSOA.DestinationPort.ToString();
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            toolTip.ToolTipTitle = "Archivo Recibido";
            toolTip.Show(mensaje, base.Contenedor.Window, DimensionMundo.Centro.X, DimensionMundo.Centro.Y, 9000);
        }

        internal void AgregarArchivos(List<ArchivoSOA> archivos)
        {
            _archivos.AddRange(archivos);
        }

        public override void Dispose()
        {
            base.Dispose();
            _archivos.Clear();
        }

        internal void NotificarEchoMessage(bool esReply, string ipOrigen, TimeSpan hora)
        {
            if (Contenedor.InvokeRequired)
            {
                Contenedor.BeginInvoke(new SetEcho(NotificarEchoMessage),
                                                            new object[] { esReply, ipOrigen, hora });

                return;
            }
            string mensaje =
"Hora: " + hora.ToString() + Environment.NewLine +
"IP Origen: " + ipOrigen;

            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            if (!esReply)
            {
                toolTip.ToolTipTitle = "Echo Recibido";
                mensaje +=Environment.NewLine+ "Enviando Respuesta a: " + ipOrigen + "...";
            }
            else
            {
                toolTip.ToolTipTitle = "Echo Respondido";
            }
            toolTip.Show(mensaje, base.Contenedor.Window, DimensionMundo.Centro.X, DimensionMundo.Centro.Y, 5000);

        }
    }
}
