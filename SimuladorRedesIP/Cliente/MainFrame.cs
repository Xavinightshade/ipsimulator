using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RedesIP.Modelos;
using RedesIP.Vistas;
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using RedesIP.Modelos.Equipos;
using RedesIP.Modelos.Datos;
using RedesIP.ModelosVisualizacion;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP;

namespace SimuladorCliente
{
	public partial class MainFrame : Form
	{
		public MainFrame()
		{
			InitializeComponent();
		}
        private delegate void ImprimirReporte(FrameRecibidoEventArgs e);
		  private delegate void ImprimirReporteTrans(FrameTransmitidoEventArgs e);
	    private ComputadorLogico pc;
	    private ComputadorLogico pc2;

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



			



		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			_estacionView.CrearEquipo(TipoDeEquipo.Computador);
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			_estacionView.CambiarHerramientaNada();
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			_estacionView.CrearEquipo(TipoDeEquipo.Switch);
		}




















	}
}