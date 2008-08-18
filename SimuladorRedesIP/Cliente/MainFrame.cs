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

namespace SimuladorCliente
{
    public partial class MainFrame : DockContent
	{
		public MainFrame()
		{
			InitializeComponent();

		}

        public IMarker Marcador { get { return _estacionView as IMarker; } }


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

		private void button1_Click(object sender, EventArgs e)
		{
       
            _es = new Estacion(Guid.NewGuid());
            Presenter p = new Presenter(_estacionView);
            p.SetEstacion(_es);
            _estacionView.EstablecerServer(p);
            p.Conectar();
            button1.Visible = false;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
		}

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




            _estacionView.EstablecerServer(clien);
            clien.Conectar();

            button1.Visible = false;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
        }



		private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_clien != null)
			{
				_clien.Desconectar();
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
            AccesoDatos.AlmacenadorInformacion.AlmacenarEstacion(_es);
        }
        Estacion _es;
        private void cargarDesdeBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _estacionView.Limpiar();
            _es = AccesoDatos.AlmacenadorInformacion.CargarEstacion(new Guid("47400cea-24e5-45f1-9bcd-5fb7c3c068e6"));
            Presenter p = new Presenter(_estacionView);
            p.SetEstacion(_es);
            _estacionView.EstablecerServer(p);
            p.Conectar();
            button1.Visible = false;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
        }

        private void eliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccesoDatos.AlmacenadorInformacion.Eliminar(new Guid("0f65682b-0d70-4b29-a72a-e7784a21a3c9"));
        }




















	}
}