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
using RedesIP.SOA;
using System.ServiceModel;
using WeifenLuo.WinFormsUI.Docking;
using SimuladorCliente.Vistas;

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



		IContract _clien = null;
		private void button1_Click(object sender, EventArgs e)
		{
            System.ServiceModel.Channels.Binding binding =
                new NetTcpBinding(SecurityMode.None,true);
            EndpointAddress address =
                new EndpointAddress(@"net.tcp://192.168.0.101:8000/Simulador/");


            InstanceContext context = new InstanceContext(_estacionView);
            DuplexChannelFactory<IContract> factory =
                new DuplexChannelFactory<IContract>
                (context, binding, address);
           _clien = factory.CreateChannel();




           _estacionView.EstablecerServer(_clien);
           _clien.Conectar();

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

		private void trackBar1_Scroll(object sender, EventArgs e)
		{

            _clien.SetVelocidadSimulacion((trackBar1.Value * 100 / trackBar1.Maximum));
		}




















	}
}