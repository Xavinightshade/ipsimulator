using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RedesIP.Vistas;
using System.Collections;
using RedesIP;
using System.ServiceModel;
using WeifenLuo.WinFormsUI.Docking;
using SimuladorCliente.Vistas;
using RedesIP.SOA;
using SimuladorCliente.Herramientas;
using System.Net;
using TesGestion.SOA;
using SimuladorCliente.Formularios;
using System.IO;
using System.Drawing.Imaging;

namespace SimuladorCliente
{
    public partial class MainFrame : Form
    {
        EstacionView _estacionView;
        EstacionModelo _estacionModelo;
        public MainFrame()
        {
            InitializeComponent();

            FormaEstacion formaEstacion = new FormaEstacion();
            formaEstacion.Show(_dockMain, DockState.Document);

            PaletaHerramienta formaPaletaHerramientas = new PaletaHerramienta();

            formaPaletaHerramientas.Show(_dockMain, DockState.DockLeftAutoHide);
            formaPaletaHerramientas.DockPanel.DockLeftPortion = 140;
            formaPaletaHerramientas.DockHandler.AllowEndUserDocking = false;
            formaPaletaHerramientas.AutoHidePortion = 140;

            _estacionView = formaEstacion.EstacionView;
            _estacionModelo = new EstacionModelo(Guid.NewGuid());

            PresenterLocal presenterLocal = new PresenterLocal(_estacionView);
            presenterLocal.SetEstacion(_estacionModelo);
            _estacionView.Inicializar(presenterLocal, _dockMain);

            presenterLocal.ConectarCliente();





        }




        private void pc_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionCrearEquipo(TipoDeEquipo.Computador);
            _mouse.CheckState = CheckState.Unchecked;
            _pc.CheckState = CheckState.Checked;
            _switch.CheckState = CheckState.Unchecked;
            _conexion.CheckState = CheckState.Unchecked;
            _router.CheckState = CheckState.Unchecked;
            _punta.CheckState = CheckState.Unchecked;
        }

        private void Nouse_Click(object sender, EventArgs e)
        {
            _estacionView.CambiarHerramienta(Herramienta.Seleccion);
            _mouse.CheckState = CheckState.Checked;
            _pc.CheckState = CheckState.Unchecked;
            _switch.CheckState = CheckState.Unchecked;
            _conexion.CheckState = CheckState.Unchecked;
            _router.CheckState = CheckState.Unchecked;
            _punta.CheckState = CheckState.Unchecked;
        }

        private void Switch_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionCrearEquipo(TipoDeEquipo.Switch);
            _mouse.CheckState = CheckState.Unchecked;
            _pc.CheckState = CheckState.Unchecked;
            _switch.CheckState = CheckState.Checked;
            _conexion.CheckState = CheckState.Unchecked;
            _router.CheckState = CheckState.Unchecked;
            _punta.CheckState = CheckState.Unchecked;
        }

        private void Conexion_Click(object sender, EventArgs e)
        {
            _estacionView.CambiarHerramienta(Herramienta.Conectar);
            _mouse.CheckState = CheckState.Unchecked;
            _pc.CheckState = CheckState.Unchecked;
            _switch.CheckState = CheckState.Unchecked;
            _conexion.CheckState = CheckState.Checked;
            _router.CheckState = CheckState.Unchecked;
            _punta.CheckState = CheckState.Unchecked;
        }





        private void ConectarSOA(string ipAddress, string puerto)
        {
            System.ServiceModel.Channels.Binding binding =
                new NetTcpBinding(SecurityMode.None, true);
            EndpointAddress address =


               new EndpointAddress(@"net.tcp://" + ipAddress + ":" + puerto + "/Simulador/");


            InstanceContext context = new InstanceContext(_estacionView);
            DuplexChannelFactory<IModeloSOA> factory =
                new DuplexChannelFactory<IModeloSOA>
                (context, binding, address);
            IModeloSOA clien = factory.CreateChannel();

            _estacionView.Limpiar();
            _estacionView.Inicializar(clien, _dockMain);




            clien.ConectarCliente();

            //      button1.Visible = false;
            _mouse.Enabled = true;
            _pc.Enabled = true;
            _switch.Enabled = true;
            _conexion.Enabled = true;
        }





        private void Punta_Click(object sender, EventArgs e)
        {
            _estacionView.CambiarHerramienta(Herramienta.Marcadores);
            _mouse.CheckState = CheckState.Unchecked;
            _pc.CheckState = CheckState.Unchecked;
            _switch.CheckState = CheckState.Unchecked;
            _conexion.CheckState = CheckState.Unchecked;
            _router.CheckState = CheckState.Unchecked;
            _punta.CheckState = CheckState.Checked;
        }






        private void guardarEnBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap imagenEstacion = _estacionView.GetImagen();
            MemoryStream ms = new MemoryStream();
            imagenEstacion.Save(ms, ImageFormat.Jpeg);
            byte[] bitmapData = ms.ToArray();
            AccesoDatos.AlmacenadorInformacion.AlmacenarEstacion(_estacionModelo, bitmapData);
        }

        private void CargarDesdeBD(object sender, EventArgs e)
        {
            _estacionView.Limpiar();
            _estacionModelo = AccesoDatos.AlmacenadorInformacion.CargarEstacion(new Guid("47400cea-24e5-45f1-9bcd-5fb7c3c068e6"));
            if (_estacionModelo.Imagen != null)
            {
                using (MemoryStream ms = new MemoryStream(_estacionModelo.Imagen))
                {

                    Bitmap img = (Bitmap)Image.FromStream(ms);

                }
            }

            PresenterLocal presenter = new PresenterLocal(_estacionView);
            presenter.SetEstacion(_estacionModelo);
            _estacionView.Inicializar(presenter, _dockMain);
            presenter.ConectarCliente();

        }



        private void Router_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionCrearEquipo(TipoDeEquipo.Router);
            _mouse.CheckState = CheckState.Unchecked;
            _pc.CheckState = CheckState.Unchecked;
            _switch.CheckState = CheckState.Unchecked;
            _conexion.CheckState = CheckState.Unchecked;
            _router.CheckState = CheckState.Checked;
            _punta.CheckState = CheckState.Unchecked;
        }



        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ConexionServidor formularioConexion = new ConexionServidor())
            {
                if (formularioConexion.ShowDialog() == DialogResult.OK)
                {
                    ConectarSOA(formularioConexion.IPAddress.ToString(), formularioConexion.Puerto.ToString());
                    _servicioConectado = true;
                }
            }


        }

        private void inicializarServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomConnectionModel modeloConexion = new CustomConnectionModel(8000);
            using (CustomConnectionForm customForm = new CustomConnectionForm(modeloConexion))
            {
                if (customForm.ShowDialog() == DialogResult.OK)
                {
                    PresenterSOA presenterSOA = new PresenterSOA();
                    presenterSOA.SetEstacion(_estacionModelo);


                    InicializarServicio(presenterSOA, modeloConexion.Puerto, modeloConexion.DireccionIp);

                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(5000, "Acceso Remoto", "Servicio Iniciado." + Environment.NewLine +
                        "Dirección IP: " + modeloConexion.DireccionIp + Environment.NewLine +
                    "Puerto: " + modeloConexion.Puerto,
                    ToolTipIcon.Info);
                }
            }


        }

        private static void InicializarServicio(IModeloSOA singletonCalculator, string puerto, string direccionIP)
        {
            ServiceHost calculatorHost =
                new ServiceHost(singletonCalculator);

            NetTcpBinding binding =
                new NetTcpBinding(SecurityMode.None, true);
            Uri address =

               new Uri(@"net.tcp://" + direccionIP + ":" + puerto + "/Simulador");

            calculatorHost.AddServiceEndpoint(
                typeof(IModeloSOA), binding, address);

            calculatorHost.Open();
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_servicioConectado)
                _estacionView.Contrato.DesconectarCliente();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _estacionView.Contrato.DesconectarCliente();
            _servicioConectado = false;
        }





        private bool _servicioConectado;

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {

        }















    }
}