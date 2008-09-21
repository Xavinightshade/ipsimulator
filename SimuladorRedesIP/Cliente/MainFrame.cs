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
            _estacionView.Inicializar(presenterLocal,_dockMain);

            presenterLocal.ConectarCliente();


           


		}




		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			_estacionView.PeticionCrearEquipo(TipoDeEquipo.Computador);
			toolStripButton1.Enabled = true;
			toolStripButton3.Enabled = true;
			toolStripButton4.Enabled = true;
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			_estacionView.CambiarHerramienta(Herramienta.Seleccion);
			toolStripButton2.Enabled = true;
			toolStripButton3.Enabled = true;
			toolStripButton4.Enabled = true;
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			_estacionView.PeticionCrearEquipo(TipoDeEquipo.Switch);
			toolStripButton2.Enabled = true;
			toolStripButton1.Enabled = true;
			toolStripButton4.Enabled = true;
		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			_estacionView.CambiarHerramienta(Herramienta.Conectar);
			toolStripButton2.Enabled = true;
			toolStripButton3.Enabled = true;
			toolStripButton1.Enabled = true;
		}



		IModeloSOA _clien = null;


        private void ConectarSOA()
        {
            System.ServiceModel.Channels.Binding binding =
                new NetTcpBinding(SecurityMode.None, true);
            EndpointAddress address =
                new EndpointAddress(@"net.tcp://localhost:8000/Simulador/");


            InstanceContext context = new InstanceContext(_estacionView);
            DuplexChannelFactory<IModeloSOA> factory =
                new DuplexChannelFactory<IModeloSOA>
                (context, binding, address);
           IModeloSOA clien = factory.CreateChannel();




            clien.ConectarCliente();

      //      button1.Visible = false;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
        }



		private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_clien != null)
			{
				_clien.DesconectarCliente();
				//_clien.Close();
			}
		}

		private void toolStripButton5_Click(object sender, EventArgs e)
		{
			_estacionView.CambiarHerramienta(Herramienta.Marcadores);
		}


        private void button2_Click(object sender, EventArgs e)
        {

            IModeloSOA singletonCalculator = new PresenterSOA();
            _clien = singletonCalculator;

            ServiceHost calculatorHost =
                new ServiceHost(singletonCalculator);

            NetTcpBinding binding =
                new NetTcpBinding(SecurityMode.None, true);
            Uri address =
                new Uri(@"net.tcp://localhost:8000/Simulador");

            calculatorHost.AddServiceEndpoint(
                typeof(IModeloSOA), binding, address);

            calculatorHost.Open();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConectarSOA();
        }

        private void guardarEnBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccesoDatos.AlmacenadorInformacion.AlmacenarEstacion(_estacionModelo);
        }
        
        private void CargarDesdeBD(object sender, EventArgs e)
        {
            _estacionView.Limpiar();
            _estacionModelo = AccesoDatos.AlmacenadorInformacion.CargarEstacion(new Guid("47400cea-24e5-45f1-9bcd-5fb7c3c068e6"));
            PresenterLocal presenter = new PresenterLocal(_estacionView);
            presenter.SetEstacion(_estacionModelo);
            _estacionView.Inicializar(presenter, _dockMain);
            presenter.ConectarCliente();
        //    button1.Visible = false;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
        }

        private void eliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccesoDatos.AlmacenadorInformacion.Eliminar(new Guid("0f65682b-0d70-4b29-a72a-e7784a21a3c9"));
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            _estacionView.PeticionCrearEquipo(TipoDeEquipo.Router);
            toolStripButton2.Enabled = true;
            toolStripButton1.Enabled = true;
            toolStripButton4.Enabled = true;
        }



        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConectarSOA();
        }

        private void inicializarServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomConnectionModel modeloConexion = new CustomConnectionModel(8000);
            using (CustomConnectionForm customForm = new CustomConnectionForm(modeloConexion))
            {
                if (customForm.ShowDialog() == DialogResult.OK)
                {
                    IModeloSOA singletonCalculator = new PresenterSOA();
                    _clien = singletonCalculator;

                    InicializarServicio(singletonCalculator,modeloConexion.Puerto,modeloConexion.DireccionIp);

                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(5000, "Acceso Remoto", "Servicio Iniciado."+Environment.NewLine+
                        "Dirección IP: "+modeloConexion.DireccionIp+ Environment.NewLine+
                    "Puerto: "+modeloConexion.Puerto,
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
                new Uri(@"net.tcp://"+direccionIP +":"+puerto+"/Simulador");

            calculatorHost.AddServiceEndpoint(
                typeof(IModeloSOA), binding, address);

            calculatorHost.Open();
        }





















	}
}