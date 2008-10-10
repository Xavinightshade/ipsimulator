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
using SOA;
using SimuladorCliente.Formularios;
using System.IO;
using System.Drawing.Imaging;
using BusinessLogic.Sniffer;
using BusinessLogic.Threads;
using SimuladorCliente.Properties;

namespace SimuladorCliente
{
    public partial class MainFrame : Form,IPaletaHerramienta
    {
        private bool _esEstacionNueva;
        private EstacionView _estacionView;
        private EstacionModelo _estacionModelo;
        PresenterLocal _presenterLocal;
        private bool _servicioConectado;
        PaletaHerramienta _formaPaletaHerramientas;
        public MainFrame()
        {
            InitializeComponent();

            FormaEstacion formaEstacion = new FormaEstacion();
            formaEstacion.Show(_dockMain, DockState.Document);

            _formaPaletaHerramientas = new PaletaHerramienta();
            _formaPaletaHerramientas.CloseButton = false;

            _formaPaletaHerramientas.Show(_dockMain, DockState.DockLeft);
            _formaPaletaHerramientas.DockPanel.DockLeftPortion = 140;
            _formaPaletaHerramientas.AllowEndUserDocking = false;
            _formaPaletaHerramientas.AutoHidePortion = 140;
            UnificarPaleta();

            _estacionView = formaEstacion.EstacionView;
            _estacionModelo = new EstacionModelo(Guid.NewGuid());
            _esEstacionNueva = true;
            EstablecerToolBarInicial();
            _presenterLocal = new PresenterLocal(_estacionView);
            ModeloSnifferMaster modeloSniffer = new ModeloSnifferMaster();
            modeloSniffer.setEstacion(_estacionModelo);
            _presenterLocal.SetEstacion(_estacionModelo, modeloSniffer);
            _estacionView.Inicializar(_presenterLocal, _dockMain,this);

            _presenterLocal.ConectarCliente();





        }

        private void UnificarPaleta()
        {
            _formaPaletaHerramientas._PaletabdDefault.Click+=new EventHandler(ToolBarCargarBDdefault_Click);
            _formaPaletaHerramientas._PaletaConexion.Click+=new EventHandler(Conexion_Click);
            _formaPaletaHerramientas._PaletadbArchivo.Click+=new EventHandler(ToolBarDBOpenClick);
            _formaPaletaHerramientas._PaletadbSave.Click+=new EventHandler(ToolBarDBSaveClick);
            _formaPaletaHerramientas._PaletaMouse.Click+=new EventHandler(Nouse_Click);
            _formaPaletaHerramientas._PaletaPc.Click+=new EventHandler(pc_Click);
            _formaPaletaHerramientas._PaletaPunta.Click+=new EventHandler(Punta_Click);
            _formaPaletaHerramientas._PaletaRouter.Click+=new EventHandler(Router_Click);
            _formaPaletaHerramientas._PaletaSwitch.Click+=new EventHandler(Switch_Click);
            _formaPaletaHerramientas._PaletasoaConectar.Click+=new EventHandler(ToolBarConectarClick);
            _formaPaletaHerramientas._PaletasoaConfigurar.Click+=new EventHandler(ToolBarConfigurarServidorClick);
            _formaPaletaHerramientas._PaletasoaDesconectar.Click+=new EventHandler(ToolBarDesconectarClick);
            _formaPaletaHerramientas._paletaTrackBar.MouseUp += new MouseEventHandler(_paletaTrackBar_MouseUp);
        }

        void _paletaTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            _estacionView.peticionEstablecerConstanteSimulacion(11-_formaPaletaHerramientas._paletaTrackBar.Value);
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

            _formaPaletaHerramientas._PaletaMouse.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPc.FlatStyle = FlatStyle.Flat;
            _formaPaletaHerramientas._PaletaSwitch.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaConexion.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaRouter.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPunta.FlatStyle = FlatStyle.Standard;
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

            _formaPaletaHerramientas._PaletaMouse.FlatStyle = FlatStyle.Flat;
            _formaPaletaHerramientas._PaletaPc.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaSwitch.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaConexion.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaRouter.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPunta.FlatStyle = FlatStyle.Standard;
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

            _formaPaletaHerramientas._PaletaMouse.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPc.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaSwitch.FlatStyle = FlatStyle.Flat;
            _formaPaletaHerramientas._PaletaConexion.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaRouter.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPunta.FlatStyle = FlatStyle.Standard;
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

            _formaPaletaHerramientas._PaletaMouse.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPc.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaSwitch.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaConexion.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaRouter.FlatStyle = FlatStyle.Flat;
            _formaPaletaHerramientas._PaletaPunta.FlatStyle = FlatStyle.Standard;
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

            _formaPaletaHerramientas._PaletaMouse.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPc.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaSwitch.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaConexion.FlatStyle = FlatStyle.Flat;
            _formaPaletaHerramientas._PaletaRouter.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPunta.FlatStyle = FlatStyle.Standard;
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

            _formaPaletaHerramientas._PaletaMouse.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPc.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaSwitch.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaConexion.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaRouter.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPunta.FlatStyle = FlatStyle.Flat;
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
            _estacionView.Inicializar(clien, _dockMain, this);
            _servicioConectado = true;


            clien.ConectarCliente();

        }

        private void ToolBarConectarClick(object sender, EventArgs e)
        {
            using (ConexionServidor formularioConexion = new ConexionServidor())
            {
                if (formularioConexion.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ConectarSOA(formularioConexion.IPAddress.ToString(), formularioConexion.Puerto.ToString());
                        EstablecerToolBarConectarServidor();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se pudo conectar al servidor," + Environment.NewLine + "compruebe la dirección IP y el puerto" 
                            ,"Conectar Servidor",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }


        }

        private void EstablecerToolBarConectarServidor()
        {
            _toolBarCargarBDarchivo.Enabled = false;
            _toolBarCargarBDdefault.Enabled = false;
            _toolBarConectar.Enabled = false;
            _toolBarDelete.Enabled = false;
            _toolBarNew.Enabled = false;
            _toolBarOpen.Enabled = false;
            _toolBarConfigurarServidor.Enabled = false;
            _toolBarSave.Enabled = false;
            _toolBarGuardarBD.Enabled = false;
            _toolBarDesonectar.Enabled = true;

            _menuCargarDBArchivo.Enabled = false;
            _menuCargarDBDefault.Enabled = false;
            _menuConectarServidor.Enabled = false;
            _menuConfigurarServidor.Enabled = false;
            _menuDelete.Enabled = false;
            _menuDesconectarServidor.Enabled = true;
            _menuGuardar.Enabled = false;
            _menuNew.Enabled = false;
            _menuGuardarComo.Enabled = false;
            _menuOpen.Enabled = false;
            _menuGuardarBD.Enabled = false;

            _formaPaletaHerramientas._PaletadbArchivo.Enabled = false;
            _formaPaletaHerramientas._PaletabdDefault.Enabled = false;
            _formaPaletaHerramientas._PaletasoaConectar.Enabled = false;
            _formaPaletaHerramientas._PaletasoaConfigurar.Enabled = false;
            _formaPaletaHerramientas._PaletasoaDesconectar.Enabled = false;
            _formaPaletaHerramientas._PaletadbSave.Enabled = false;
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

                    try
                    {
                        InicializarServicio(presenterSOA, modeloConexion.Puerto, modeloConexion.DireccionIp);

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("No se pudo iniciar el servidor,"+Environment.NewLine+"compruebe que el puerto no este siendo usado,"+
                            Environment.NewLine+"o que esté protegido por un Firewall", "Servicio Remoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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
                    EstablecerToolBarConfigurarServicio();
                }
            }


        }

        private void EstablecerToolBarConfigurarServicio()
        {
            _toolBarCargarBDarchivo.Enabled = false;
            _toolBarCargarBDdefault.Enabled = false;
            _toolBarConectar.Enabled = false;
            _toolBarDelete.Enabled = false;
            _toolBarNew.Enabled = false;
            _toolBarOpen.Enabled = false;
            _toolBarConfigurarServidor.Enabled = false;
            _toolBarSave.Enabled = false;
            _toolBarMouse.Checked = false;
            _toolBarDesonectar.Enabled = false;
            _toolBarGuardarBD.Enabled = false;

            _menuCargarDBArchivo.Enabled = false;
            _menuCargarDBDefault.Enabled = false;
            _menuConectarServidor.Enabled = false;
            _menuConfigurarServidor.Enabled = false;
            _menuDelete.Enabled = false;
            _menuDesconectarServidor.Enabled = false;
            _menuGuardar.Enabled = false;
            _menuNew.Enabled = false;
            _menuGuardarComo.Enabled = false;
            _menuOpen.Enabled = false;
            _menuGuardarBD.Enabled = false;


            _formaPaletaHerramientas._PaletadbArchivo.Enabled = false;
            _formaPaletaHerramientas._PaletabdDefault.Enabled = false;
            _formaPaletaHerramientas._PaletasoaConectar.Enabled = false;
            _formaPaletaHerramientas._PaletasoaConfigurar.Enabled = false;
            _formaPaletaHerramientas._PaletasoaDesconectar.Enabled = false;
            _formaPaletaHerramientas._PaletadbSave.Enabled = false;
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
            _estacionView.Inicializar(_presenterLocal, _dockMain, this);
            _presenterLocal.ConectarCliente();
            _estacionView.Invalidate();
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

            _formaPaletaHerramientas._PaletadbArchivo.Enabled = false;
            _formaPaletaHerramientas._PaletabdDefault.Enabled = false;
            _formaPaletaHerramientas._PaletasoaConectar.Enabled = true;
            _formaPaletaHerramientas._PaletasoaConfigurar.Enabled = true;
            _formaPaletaHerramientas._PaletasoaDesconectar.Enabled = false;
            _formaPaletaHerramientas._PaletadbSave.Enabled = false;

            _formaPaletaHerramientas._PaletaMouse.Enabled = true;
            _formaPaletaHerramientas._PaletaMouse.FlatStyle = FlatStyle.Flat;
            _formaPaletaHerramientas._PaletaRouter.Enabled = true;
            _formaPaletaHerramientas._PaletaPc.Enabled = true;
            _formaPaletaHerramientas._PaletaSwitch.Enabled = true;
            _formaPaletaHerramientas._PaletaPunta.Enabled = true;
            _formaPaletaHerramientas._PaletaConexion.Enabled = true;

            
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
                    _esEstacionNueva = false;
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
            _menuConectarServidor.Enabled = true;
            _menuConfigurarServidor.Enabled = false;
            _menuDesconectarServidor.Enabled = false;

            _toolBarDelete.Enabled = false;
            _toolBarSave.Enabled = false;
            _toolBarPuntaMedicion.Enabled = false;
            _toolBarRouter.Enabled = false;
            _toolBarSwitch.Enabled = false;
            _toolBarPC.Enabled = false;
            _toolBarConectar.Enabled = true;
            _toolBarDesonectar.Enabled = false;
            _toolBarMouse.Enabled = false;
            _toolBarConfigurarServidor.Enabled = false;
            _toolBarConectarEquipos.Enabled = false;

            _formaPaletaHerramientas._PaletadbArchivo.Enabled = true;
            _formaPaletaHerramientas._PaletabdDefault.Enabled = true;
            _formaPaletaHerramientas._PaletasoaConectar.Enabled = true;
            _formaPaletaHerramientas._PaletasoaConfigurar.Enabled = false;
            _formaPaletaHerramientas._PaletasoaDesconectar.Enabled = false;
            _formaPaletaHerramientas._PaletadbSave.Enabled = true;

            _formaPaletaHerramientas._PaletaMouse.Enabled = false;
            _formaPaletaHerramientas._PaletaRouter.Enabled = false;
            _formaPaletaHerramientas._PaletaPc.Enabled = false;
            _formaPaletaHerramientas._PaletaSwitch.Enabled = false;
            _formaPaletaHerramientas._PaletaPunta.Enabled = false;
            _formaPaletaHerramientas._PaletaConexion.Enabled = false;
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



        private void ToolBarCargarBDdefault_Click(object sender, EventArgs e)
        {
            AccesoDatos.AlmacenadorInformacion.SetDefaultBD();
            EstablecerToolBarCrearTopologia();
            _esEstacionNueva = true;
        }

        private void _menuDesconectarServidor_Click(object sender, EventArgs e)
        {
           
            _estacionView.Contrato.DesconectarCliente();
            CrearNuevaEstacion();
            _servicioConectado = false;
      
        }



        private void _toolBarPlayPause_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionPlayPause();
        }

        public void EstablecerEstadoSimulacion(bool pausado)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EstablecerEstadoSimulacionDelegate(EstablecerEstadoSimulacion), new object[] { pausado });
                return;
            }

            if (pausado)
            {
                _toolBarPlayPause.Image = Resources.play_16x16;
                _toolBarPlayPause.Text = "Continuar la ejecución";
            }
            else
            {
                _toolBarPlayPause.Image = Resources.pause_16x16;
                _toolBarPlayPause.Text = "Detener la ejecución";
            }
        }

        private delegate void EstablecerEstadoSimulacionDelegate(bool pausado);

        public void SetValor(int valor)
        {
            _formaPaletaHerramientas.SetValor(valor);
        }

        private void _toolBarSwitchVLan_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionCrearEquipo(TipoDeEquipo.SwitchVLan);
            _toolBarMouse.CheckState = CheckState.Unchecked;
            _toolBarPC.CheckState = CheckState.Unchecked;
            _toolBarSwitch.CheckState = CheckState.Checked;
            _toolBarConectarEquipos.CheckState = CheckState.Unchecked;
            _toolBarRouter.CheckState = CheckState.Unchecked;
            _toolBarPuntaMedicion.CheckState = CheckState.Unchecked;

            _formaPaletaHerramientas._PaletaMouse.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPc.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaSwitch.FlatStyle = FlatStyle.Flat;
            _formaPaletaHerramientas._PaletaConexion.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaRouter.FlatStyle = FlatStyle.Standard;
            _formaPaletaHerramientas._PaletaPunta.FlatStyle = FlatStyle.Standard;
        }


    }
}