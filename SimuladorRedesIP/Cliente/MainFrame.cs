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


		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			_estacionView.CrearEquipo(TipoDeEquipo.Computador);
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
			_estacionView.CrearEquipo(TipoDeEquipo.Switch);
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



		EstacionServerClient _clien = null;
		private void button1_Click(object sender, EventArgs e)
		{
			_clien= new EstacionServerClient(new InstanceContext(_estacionView), "TcpBinding");


			_estacionView.EstablecerServer(_clien);
			_clien.Open();
			_clien.Conectar();
			splitContainer1.Panel2Collapsed = false;
			button1.Visible = false;
			toolStripButton1.Enabled = true;
			toolStripButton2.Enabled = true;
			toolStripButton3.Enabled = true;
			toolStripButton4.Enabled = true;
			_estacionView.NuevoMarcador += new EventHandler<SimuladorCliente.Vistas.NuevoMarcadorEventArgs>(_estacionView_NuevoMarcador);
			_estacionView.NuevoMensaje += new EventHandler<SimuladorCliente.Vistas.NuevoMensajeEventArgs>(_estacionView_NuevoMensaje);

		}

		void _estacionView_NuevoMensaje(object sender, SimuladorCliente.Vistas.NuevoMensajeEventArgs e)
		{
			sniffer1.ReportarMensaje(e.IdConexion, e.Mensaje);
			sniffer2.ReportarMensaje(e.IdConexion, e.Mensaje);
		}

		void _estacionView_NuevoMarcador(object sender, SimuladorCliente.Vistas.NuevoMarcadorEventArgs e)
		{
			sniffer1.AgregarMarcador(e.Marcador);
			sniffer2.AgregarMarcador(e.Marcador);

		}

		private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_clien != null)
			{
				_clien.Desconectar();
				_clien.Close();
			}
		}

		private void toolStripButton5_Click(object sender, EventArgs e)
		{
			_estacionView.CambiarHerramienta(Herramienta.Marcadores);
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			_clien.CambiarVelocidad((trackBar1.Value * 100 / trackBar1.Maximum));
		}




















	}
}