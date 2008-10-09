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
using DevAge.Windows.Forms;
using BusinessLogic.Sniffer;

namespace SimuladorCliente
{
    public partial class MainFrame : Form
    {
        private bool _esEstacionNueva;
        private EstacionView _estacionView;
        private EstacionModelo _estacionModelo;
        PresenterLocal _presenterLocal;
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
            EstablecerToolBarInicial();
            _presenterLocal = new PresenterLocal(_estacionView);
            ModeloSnifferMaster modeloSniffer = new ModeloSnifferMaster();
            modeloSniffer.setEstacion(_estacionModelo);
            _presenterLocal.SetEstacion(_estacionModelo, modeloSniffer);
            _estacionView.Inicializar(_presenterLocal, _dockMain);

            _presenterLocal.ConectarCliente();





        }

        #region ToolBarEstados
        private void pc_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionCrearEquipo(TipoDeEquipo.Computador);
            _toolBarMouse.CheckState = CheckState.Unchecked;
            _toolBarPC.CheckState = CheckState.Checked;
            _toolBarSwitch.CheckState = CheckState.Unchecked;
            _toolBarConectarEquipos.CheckState = CheckState.Unchecked;
            _toolBarRouter.CheckState = CheckState.Unchecked;
            _toolBarPuntaMedicion.CheckState = CheckState.Unchecked;
        }
        private void Nouse_Click(object sender, EventArgs e)
        {
            _estacionView.CambiarHerramienta(Herramienta.Seleccion);
            _toolBarMouse.CheckState = CheckState.Checked;
            _toolBarPC.CheckState = CheckState.Unchecked;
            _toolBarSwitch.CheckState = CheckState.Unchecked;
            _toolBarConectarEquipos.CheckState = CheckState.Unchecked;
            _toolBarRouter.CheckState = CheckState.Unchecked;
            _toolBarPuntaMedicion.CheckState = CheckState.Unchecked;
        }
        private void Switch_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionCrearEquipo(TipoDeEquipo.Switch);
            _toolBarMouse.CheckState = CheckState.Unchecked;
            _toolBarPC.CheckState = CheckState.Unchecked;
            _toolBarSwitch.CheckState = CheckState.Checked;
            _toolBarConectarEquipos.CheckState = CheckState.Unchecked;
            _toolBarRouter.CheckState = CheckState.Unchecked;
            _toolBarPuntaMedicion.CheckState = CheckState.Unchecked;
        }
        private void Router_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionCrearEquipo(TipoDeEquipo.Router);
            _toolBarMouse.CheckState = CheckState.Unchecked;
            _toolBarPC.CheckState = CheckState.Unchecked;
            _toolBarSwitch.CheckState = CheckState.Unchecked;
            _toolBarConectarEquipos.CheckState = CheckState.Unchecked;
            _toolBarRouter.CheckState = CheckState.Checked;
            _toolBarPuntaMedicion.CheckState = CheckState.Unchecked;
        }
        private void Conexion_Click(object sender, EventArgs e)
        {
            _estacionView.CambiarHerramienta(Herramienta.Conectar);
            _toolBarMouse.CheckState = CheckState.Unchecked;
            _toolBarPC.CheckState = CheckState.Unchecked;
            _toolBarSwitch.CheckState = CheckState.Unchecked;
            _toolBarConectarEquipos.CheckState = CheckState.Checked;
            _toolBarRouter.CheckState = CheckState.Unchecked;
            _toolBarPuntaMedicion.CheckState = CheckState.Unchecked;
        }
        private void Punta_Click(object sender, EventArgs e)
        {
            _estacionView.CambiarHerramienta(Herramienta.Marcadores);
            _toolBarMouse.CheckState = CheckState.Unchecked;
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
            binding.ReceiveTimeout = TimeSpan.MaxValue;
            IModeloSOA clien = factory.CreateChannel();


            _estacionView.LimpiarEstacion();
            _estacionView.Inicializar(clien, _dockMain);




            clien.ConectarCliente();

            _toolBarMouse.Enabled = true;
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
                    _toolBarCargarBDarchivo.Enabled = false;
                    _toolBarCargarBDdefault.Enabled = false;
                    _toolBarConectar.Enabled = false;
                    _toolBarDelete.Enabled = false;
                    _toolBarNew.Enabled = false;
                    _toolBarOpen.Enabled = false;
                    _toolBarConfigurarServidor.Enabled = false;
                    _toolBarSave.Enabled = false;
                    _menuCargarDBArchivo.Enabled = false;
                    _menuCargarDBDefault.Enabled = false;
                    _menuConectarServidor.Enabled = false;
                    _menuConfigurarServidor.Enabled = false;
                    _menuDelete.Enabled = false;
                    _menuDesconectarServidor.Enabled = true;
                    _menuGuardar.Enabled = false;
                    _menuNew.Enabled = false;
                    _menuGuardarComo.Enabled = false;
                    _toolBarGuardarBD.Enabled = false;
                    _menuOpen.Enabled = false;
                    _toolBarDesonectar.Enabled = true;
                    _menuGuardarBD.Enabled = false;

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
                    presenterSOA.SetEstacion(_estacionModelo, _presenterLocal.SnifferMaster);


                    InicializarServicio(presenterSOA, modeloConexion.Puerto, modeloConexion.DireccionIp);
                    string texto = "Servicio Iniciado." + Environment.NewLine +
                        "Dirección IP: " + modeloConexion.DireccionIp + Environment.NewLine +
                    "Puerto: " + modeloConexion.Puerto;
                    _notifyIcon.Visible = true;
                    _notifyIcon.ShowBalloonTip(5000, "Acceso Remoto", texto,
                    ToolTipIcon.Info);
                    _notifyIcon.ContextMenu = new ContextMenu();
                    MenuItem menuDesconectar = new MenuItem("Cerrar Servicio");
                    _notifyIcon.ContextMenu.MenuItems.Add(menuDesconectar);
                    menuDesconectar.Click += new EventHandler(menuDesconectar_Click);
                    _notifyIcon.Text = texto;
                    _toolBarCargarBDarchivo.Enabled = false;
                    _toolBarCargarBDdefault.Enabled = false;
                    _toolBarConectar.Enabled = false;
                    _toolBarDelete.Enabled = false;
                    _toolBarNew.Enabled = false;
                    _toolBarOpen.Enabled = false;
                    _toolBarConfigurarServidor.Enabled = false;
                    _toolBarSave.Enabled = false;
                    _menuCargarDBArchivo.Enabled = false;
                    _menuCargarDBDefault.Enabled = false;
                    _menuConectarServidor.Enabled = false;
                    _menuConfigurarServidor.Enabled = false;
                    _menuDelete.Enabled = false;
                    _menuDesconectarServidor.Enabled = false;
                    _menuGuardar.Enabled = false;
                    _menuNew.Enabled = false;
                    _menuGuardarComo.Enabled = false;
                    _toolBarGuardarBD.Enabled = false;
                    _menuOpen.Enabled = false;
                    _toolBarDesonectar.Enabled = false;
                    _menuGuardarBD.Enabled = false;
                    _toolBarMouse.Checked = false;
                }
            }


        }

        void menuDesconectar_Click(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
        }

        private static void InicializarServicio(IModeloSOA singletonCalculator, string puerto, string direccionIP)
        {
            ServiceHost calculatorHost =
                new ServiceHost(singletonCalculator);

            NetTcpBinding binding =
                new NetTcpBinding(SecurityMode.None, true);
            Uri address = new Uri(@"net.tcp://" + direccionIP + ":" + puerto + "/Simulador");
            binding.ReceiveTimeout = TimeSpan.MaxValue;
            binding.ReliableSession.InactivityTimeout = TimeSpan.MaxValue;


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
                    _toolBarDelete.Enabled = true;
                    _menuDelete.Enabled = true;
                    _esEstacionNueva = false;
                }
            }
        }

        private void CrearNuevaEstacion()
        {
            _estacionView.LimpiarEstacion();

            _presenterLocal.SnifferMaster.setEstacion(_estacionModelo);
            _presenterLocal.SetEstacion(_estacionModelo, _presenterLocal.SnifferMaster);
            _esEstacionNueva = true;
            EstablecerToolBarCrearTopologia();
            _estacionView.Inicializar(_presenterLocal, _dockMain);
            _presenterLocal.ConectarCliente();
        }

        private void EstablecerToolBarCrearTopologia()
        {
            _menuDelete.Enabled = false;
            _menuNew.Enabled = true;
            _menuOpen.Enabled = true;
            _menuGuardar.Enabled = true;
            _menuGuardarComo.Enabled = true;
            _menuConectarServidor.Enabled = true;
            _menuConfigurarServidor.Enabled = true;
            _menuDesconectarServidor.Enabled = false;
            _toolBarDelete.Enabled = false;
            _toolBarSave.Enabled = true;
            _toolBarPuntaMedicion.Enabled = true;
            _toolBarRouter.Enabled = true;
            _toolBarSwitch.Enabled = true;
            _toolBarPC.Enabled = true;
            _toolBarConectar.Enabled = true;
            _toolBarDesonectar.Enabled = false;
            _toolBarMouse.Enabled = true;
            _toolBarConfigurarServidor.Enabled = true;
            _toolBarConectarEquipos.Enabled = true;
            _toolBarMouse.Checked = true;
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
                redSaveForm.Inicializar(_estacionModelo.Nombre, _estacionModelo.Descripcion, imagenEstacion);

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
                    EstablecerToolBarCrearTopologia();
                    _menuDelete.Enabled = true;
                    _toolBarDelete.Enabled = true;
                }


            }


        }

        private void ToolBarDeleteClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar red: " + _estacionModelo.Nombre + "?", "Eliminar Red", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AccesoDatos.AlmacenadorInformacion.Eliminar(_estacionModelo.Id);
                EstablecerToolBarInicial();

            }

        }

        private void EstablecerToolBarInicial()
        {
            _menuDelete.Enabled = false;
            _menuNew.Enabled = true;
            _menuOpen.Enabled = true;
            _menuGuardar.Enabled = false;
            _menuGuardarComo.Enabled = false;
            _menuConectarServidor.Enabled = false;
            _menuConfigurarServidor.Enabled = false;
            _menuDesconectarServidor.Enabled = false;
            _menuConectarServidor.Enabled = false;
            _menuConfigurarServidor.Enabled = false;
            _menuDesconectarServidor.Enabled = false;
            _toolBarDelete.Enabled = false;
            _toolBarSave.Enabled = false;
            _toolBarPuntaMedicion.Enabled = false;
            _toolBarRouter.Enabled = false;
            _toolBarSwitch.Enabled = false;
            _toolBarPC.Enabled = false;
            _toolBarConectar.Enabled = false;
            _toolBarDesonectar.Enabled = false;
            _toolBarMouse.Enabled = false;
            _toolBarConfigurarServidor.Enabled = false;
            _toolBarConectarEquipos.Enabled = false;
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
                EstablecerToolBarCrearTopologia();
                _esEstacionNueva = true;

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
                if (File.Exists(dialog.FileName))
                    File.Delete(dialog.FileName);
                File.Copy(AccesoDatos.AlmacenadorInformacion.RutaBD, dialog.FileName);
            }
        }

        private void _menuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Bitmap imagenEstacion = _estacionView.GetImagen();

            using (RedSaveForm redSaveForm = new RedSaveForm())
            {
                redSaveForm.Inicializar(_estacionModelo.Nombre, _estacionModelo.Descripcion, imagenEstacion);

                if (redSaveForm.ShowDialog() == DialogResult.OK)
                {
                    MemoryStream ms = new MemoryStream();
                    imagenEstacion.Save(ms, ImageFormat.Jpeg);
                    byte[] bitmapData = ms.ToArray();
                    _estacionModelo.Nombre = redSaveForm.NombreRed;
                    _estacionModelo.Descripcion = redSaveForm.DescripcionRed;

                    AccesoDatos.AlmacenadorInformacion.GuardarComo(_estacionModelo, bitmapData);
                }


            }
        }



        private void _toolBarCargarBDdefault_Click(object sender, EventArgs e)
        {
            AccesoDatos.AlmacenadorInformacion.SetDefaultBD();
            EstablecerToolBarCrearTopologia();
            _esEstacionNueva = true;
        }


















    }
}