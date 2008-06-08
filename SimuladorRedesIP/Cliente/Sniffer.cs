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
			dataGridView1.DataSource = _mensajes[idConexion];
		}
		private Dictionary<Guid, List<string>> _mensajes = new Dictionary<Guid, List<string>>();
		private List<Marcador> _marcadores = new List<Marcador>();
		public void AgregarMarcador(Marcador marcador)
		{
			_marcadores.Add(marcador);
			_mensajes.Add(marcador.Conexion.Id, new List<string>());
			comboBoxEx1.Items.Add(new ComboBoxExItem(marcador, marcador.Color));
		}

		internal void ReportarMensaje(Guid idConexion, string mensaje)
		{
			_mensajes[idConexion].Add(mensaje);
		}
	}
}
