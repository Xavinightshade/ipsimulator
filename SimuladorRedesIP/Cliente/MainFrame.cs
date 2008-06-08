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

namespace SimuladorCliente
{
	public partial class MainFrame : Form
	{
		public MainFrame()
		{
			InitializeComponent();
		}


		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);



	
		//pc = new ComputadorLogico("pc1", MACAddress.Direccion(1, 2, 3));
		//pc2 = new ComputadorLogico("pc2", MACAddress.Direccion(4, 5, 6));
		////    CableDeRed cab=new CableDeRed(pc,pc2);
		//SwitchLogico swi = new SwitchLogico(30);
		//SwitchLogico swi2 = new SwitchLogico(30);

		//CableDeRedLogico cab2 = new CableDeRedLogico(pc.PuertoEthernet, swi.PuertosEthernet[0]);
		//CableDeRedLogico cab3 = new CableDeRedLogico(swi.PuertosEthernet[1], swi2.PuertosEthernet[0]);
		//CableDeRedLogico cab4 = new CableDeRedLogico(pc2.PuertoEthernet, swi2.PuertosEthernet[1]);



			//Contrato server = new Contrato();
			//server.RegistrarCliente(_estacionView);
			//_estacionView.EstablecerServer(server);

			//SegundoCliente form = new SegundoCliente();
			//server.RegistrarCliente(form.Cliente);
			//form.EstablecerServer(server);

			//SegundoCliente form2 = new SegundoCliente();
			//server.RegistrarCliente(form2.Cliente);
			//form2.EstablecerServer(server);

			//form.Show();
			//form2.Show();



		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			_estacionView.CrearEquipo(TipoDeEquipo.Computador);
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			_estacionView.CambiarHerramienta(Herramienta.Seleccion);
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			_estacionView.CrearEquipo(TipoDeEquipo.Switch);
		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			_estacionView.CambiarHerramienta(Herramienta.Conectar);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			EstacionServerClient clien = new EstacionServerClient(new InstanceContext(_estacionView), "TcpBinding");
			
			
			_estacionView.EstablecerServer(clien);
			clien.Open();
		}




















	}
}