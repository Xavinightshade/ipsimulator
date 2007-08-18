using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RedesIP.Modelos.ElementosLogicos;
using RedesIP.Modelos.Datos;
using RedesIp.Vistas.ElementosVisuales;
using RedesIp.Vistas.Utilidades;


namespace RedesIP
{
	public partial class MainFrame : Form
	{
		public MainFrame()
		{
			InitializeComponent();
			Inicializar();
		}
		private DibujadorLineas _dibujadorCables = new DibujadorLineas();
		private void Inicializar()
		{
			_dibujadorCables.CambioDeLinea += new EventHandler(OnCambioDeAlgunaLinea);
			ComputadorLogico pcNumero1 = new ComputadorLogico("PcNumero1", MACAddress.New(99, 42, 3));
			ComputadorLogico pcNumero2 = new ComputadorLogico("PcNumero2", MACAddress.New(99, 46, 26));
			ComputadorLogico pcNumero3 = new ComputadorLogico("pcNymero3", MACAddress.New(79, 68, 79));
			ComputadorLogico pcNumero4 = new ComputadorLogico("pcNymero4", MACAddress.New(29, 35, 46));
			ComputadorLogico pcNumero5 = new ComputadorLogico("pcNymero5", MACAddress.New(79, 65, 57));

			SwitchLogico switch4 = new SwitchLogico(3);

			CableDeRedLogico cablePc1ConSwitch = new CableDeRedLogico(pcNumero1.PuertoEthernet, switch4.PuertosEthernet[0]);
			CableDeRedLogico cablePc2ConSwitch = new CableDeRedLogico(pcNumero2.PuertoEthernet, switch4.PuertosEthernet[1]);
			CableDeRedLogico cablePc3ConSwitch = new CableDeRedLogico(pcNumero3.PuertoEthernet, switch4.PuertosEthernet[2]);

			CableDeRedLogico cablePc4ConPc5 = new CableDeRedLogico(pcNumero4, pcNumero5);

			pcNumero1.EnviarMensaje("holaPC2", MACAddress.New(79, 69, 79));
			pcNumero1.EnviarMensaje("holaPC3", MACAddress.New(7, 8, 9));
			cablePc1ConSwitch.DesconectarPuertos();
			cablePc4ConPc5.DesconectarPuertos();
			pcNumero3.EnviarMensaje("holaPC1", MACAddress.New(1, 2, 3));
		}



		private void OnCambioDeAlgunaLinea(object sender, EventArgs e)
		{
			Invalidate();
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			_dibujadorCables.PintarLineas(e.Graphics);

		}



	}
}