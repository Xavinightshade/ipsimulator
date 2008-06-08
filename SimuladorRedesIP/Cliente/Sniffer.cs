using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SimuladorCliente.Vistas;
using RedesIP.Vistas;

namespace SimuladorCliente
{
	public partial class Sniffer : UserControl
	{
		public Sniffer()
		{
			InitializeComponent();
			comboBoxEx1.SelectedIndexChanged += new EventHandler(comboBoxEx1_SelectedIndexChanged);
		}

		void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBoxExItem item = (ComboBoxExItem)comboBoxEx1.SelectedItem;
			Guid idConexion = item.Marcador.Conexion.Id;
			List<string> mensajes=_mensajes[idConexion];
			listBox1.DataSource = mensajes;
			
		}
		private Dictionary<Guid, List<string>> _mensajes = new Dictionary<Guid, List<string>>();
		private List<Marcador> _marcadores = new List<Marcador>();
		public void AgregarMarcador(Marcador marcador)
		{
			_marcadores.Add(marcador);
			_mensajes.Add(marcador.Conexion.Id, new List<string>());
			comboBoxEx1.Items.Add(new ComboBoxExItem(marcador, marcador.Color));
		}
		private delegate void SetLabelTextDelegate(Guid idConexion, string mensaje);

		internal void ReportarMensaje(Guid idConexion, string mensaje)
		{
			
			if (this.InvokeRequired)
			{
				// Pass the same function to BeginInvoke,
				// but the call would come on the correct
				// thread and InvokeRequired will be false.
				this.BeginInvoke(new SetLabelTextDelegate(ReportarMensaje),
															new object[] {idConexion,mensaje });

				return;
			}
			_mensajes[idConexion].Add(mensaje);
			ComboBoxExItem item = (ComboBoxExItem)comboBoxEx1.SelectedItem;
			if (item == null)
				return;
			if (item.Marcador.Conexion.Id == idConexion)
			{
				List<string> mensajes = _mensajes[idConexion];
				listBox1.DataSource = new List<string>();
				listBox1.DataSource = mensajes;
			}
		}
	}
}
