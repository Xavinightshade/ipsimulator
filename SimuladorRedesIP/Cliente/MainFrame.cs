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
        private bool _esEstacionNueva;
        private EstacionView _estacionView;
        private EstacionModelo _estacionModelo;
        private bool _servicioConectado;
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
            _esEstacionNueva = true;
            _toolBarDelete.Enabled = false;

            PresenterLocal presenterLocal = new PresenterLocal(_estacionView);
            presenterLocal.SetEstacion(_estacionModelo);
            _estacionView.Inicializar(presenterLocal, _dockMain);

            presenterLocal.ConectarCliente();





        }

        #region ToolBarEstados
        private void pc_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionCrearEquipo(TipoDeEquipo.Computador);
            _mouse.CheckState = CheckState.Unchecked;
            _toolBarPC.CheckState = CheckState.Checked;
            _toolBarSwitch.CheckState = CheckState.Unchecked;
            _toolBarConectarEquipos.CheckState = CheckState.Unchecked;
            _toolBarRouter.CheckState = CheckState.Unchecked;
            _toolBarPuntaMedicion.CheckState = CheckState.Unchecked;
        }
        private void Nouse_Click(object sender, EventArgs e)
        {
            _estacionView.CambiarHerramienta(Herramienta.Seleccion);
            _mouse.CheckState = CheckState.Checked;
            _toolBarPC.CheckState = CheckState.Unchecked;
            _toolBarSwitch.CheckState = CheckState.Unchecked;
            _toolBarConectarEquipos.CheckState = CheckState.Unchecked;
            _toolBarRouter.CheckState = CheckState.Unchecked;
            _toolBarPuntaMedicion.CheckState = CheckState.Unchecked;
        }
        private void Switch_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionCrearEquipo(TipoDeEquipo.Switch);
            _mouse.CheckState = CheckState.Unchecked;
            _toolBarPC.CheckState = CheckState.Unchecked;
            _toolBarSwitch.CheckState = CheckState.Checked;
            _toolBarConectarEquipos.CheckState = CheckState.Unchecked;
            _toolBarRouter.CheckState = CheckState.Unchecked;
            _toolBarPuntaMedicion.CheckState = CheckState.Unchecked;
        }
        private void Router_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionCrearEquipo(TipoDeEquipo.Router);
            _mouse.CheckState = CheckState.Unchecked;
            _toolBarPC.CheckState = CheckState.Unchecked;
            _toolBarSwitch.CheckState = CheckState.Unchecked;
            _toolBarConectarEquipos.CheckState = CheckState.Unchecked;
            _toolBarRouter.CheckState = CheckState.Checked;
            _toolBarPuntaMedicion.CheckState = CheckState.Unchecked;
        }
        private void Conexion_Click(object sender, EventArgs e)
        {
            _estacionView.CambiarHerramienta(Herramienta.Conectar);
            _mouse.CheckState = CheckState.Unchecked;
            _toolBarPC.CheckState = CheckState.Unchecked;
            _toolBarSwitch.CheckState = CheckState.Unchecked;
            _toolBarConectarEquipos.CheckState = CheckState.Checked;
            _toolBarRouter.CheckState = CheckState.Unchecked;
            _toolBarPuntaMedicion.CheckState = CheckState.Unchecked;
        }
        private void Punta_Click(object sender, EventArgs e)
        {
            _estacionView.CambiarHerramienta(Herramienta.Marcadores);
            _mouse.CheckState = CheckState.Unchecked;
            _toolBarPC.CheckState = CheckState.Unchecked;
            _toolBarSwitch.CheckState = CheckState.Unchecked;
            _toolBarConectarEquipos.CheckState = CheckState.Unchecked;
            _toolBarRouter.CheckState = CheckState.Unchecked;
            _toolBarPuntaMedicion.CheckState = CheckState.Checked;
        }
        #endregion


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

            _estacionView.LimpiarEstacion();
            _estacionView.Inicializar(clien, _dockMain);




            clien.ConectarCliente();

            _mouse.Enabled = true;
            _toolBarPC.Enabled = true;
            _toolBarSwitch.Enabled = true;
            _toolBarConectarEquipos.Enabled = true;
        }

        private void ToolBarConectarClick(object sender, EventArgs e)
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

        private void ToolBarConfigurarServidorClick(object sender, EventArgs e)
        {
            CustomConnectionModel modeloConexion = new CustomConnectionModel(8000);
            using (CustomConnectionForm customForm = new CustomConnectionForm(modeloConexion))
            {
                if (customForm.ShowDialog() == DialogResult.OK)
                {
                    PresenterSOA presenterSOA = new PresenterSOA();
                    presenterSOA.SetEstacion(_estacionModelo);


                    InicializarServicio(presenterSOA, modeloConexion.Puerto, modeloConexion.DireccionIp);

                    _notifyIcon.Visible = true;
                    _notifyIcon.ShowBalloonTip(5000, "Acceso Remoto", "Servicio Iniciado." + Environment.NewLine +
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

        private void MainFrameClosing(object sender, FormClosingEventArgs e)
        {
            if (_servicioConectado)
                _estacionView.Contrato.DesconectarCliente();
        }

        private void ToolBarDesconectarClick(object sender, EventArgs e)
        {
            _estacionView.Contrato.DesconectarCliente();
            _servicioConectado = false;
        }



        private void ToolBarOpenClick(object sender, EventArgs e)
        {
            List<RedBrowserModel> redes = AccesoDatos.AlmacenadorInformacion.CargarEstaciones();

            using (RedBrowser forma = new RedBrowser(redes))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    _estacionModelo = AccesoDatos.AlmacenadorInformacion.CargarEstacion(forma.Id);
                    CrearNuevaEstacion();
                }
            }
        }

        private void CrearNuevaEstacion()
        {
            _estacionView.LimpiarEstacion();
            PresenterLocal presenter = new PresenterLocal(_estacionView);
            presenter.SetEstacion(_estacionModelo);
            _esEstacionNueva = false;
            _toolBarDelete.Enabled = true;
            _estacionView.Inicializar(presenter, _dockMain);
            presenter.ConectarCliente();
        }

        private void ToolBarNewClick(object sender, EventArgs e)
        {
            _estacionModelo = new EstacionModelo(Guid.NewGuid());
            CrearNuevaEstacion();
        }

        private void ToolBarSaveClick(object sender, EventArgs e)
        {
            Bitmap imagenEstacion = _estacionView.GetImagen();

            using (RedSaveForm redSaveForm = new RedSaveForm())
            {
                redSaveForm.Inicializar(_estacionModelo.Nombre, _estacionModelo.Descripcion,imagenEstacion);

                if (redSaveForm.ShowDialog() == DialogResult.OK)
                {
                    MemoryStream ms = new MemoryStream();
                    imagenEstacion.Save(ms, ImageFormat.Jpeg);
                    byte[] bitmapData = ms.ToArray();
                    _estacionModelo.Nombre = redSaveForm.NombreRed;
                    _estacionModelo.Descripcion = redSaveForm.DescripcionRed;

                    if (_esEstacionNueva)
                    {
                        AccesoDatos.AlmacenadorInformacion.GuardarNuevaEstacion(_estacionModelo, bitmapData);

                    }
                    else
                    {
                        AccesoDatos.AlmacenadorInformacion.ActualizarEstacion(_estacionModelo, bitmapData);
                    }
                }


            }


        }

        private void ToolBarDeleteClick(object sender, EventArgs e)
        {
            AccesoDatos.AlmacenadorInformacion.Eliminar(_estacionModelo.Id);
            _estacionModelo = new EstacionModelo(Guid.NewGuid());
            CrearNuevaEstacion();


        }

        private void ToolBarDBOpenClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "Red.sdf";
            dialog.Filter = "(*.sdf)|*.sdf";
            dialog.ValidateNames = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AccesoDatos.AlmacenadorInformacion.RutaBD = dialog.FileName;

            }
        }

        private void ToolBarDBSaveClick(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Red.sdf";
            dialog.Filter = "(*.sdf)|*.sdf";
            dialog.ValidateNames = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(AccesoDatos.AlmacenadorInformacion.RutaBD, dialog.FileName);
            }
        }















    }
}