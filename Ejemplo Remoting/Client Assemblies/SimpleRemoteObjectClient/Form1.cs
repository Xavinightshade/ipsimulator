using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimpleRemotingAsm;

namespace SimpleRemoteObjectClient
{
	public partial class Form1 : Form
	{
		RemoteServerObject _servidor;
		ClientObject _cliente;
		public Form1(RemoteServerObject servidor)
		{
			InitializeComponent();
			_servidor = servidor;
		}

		protected override void OnLoad(EventArgs e)
		{
			RefrescarListaClientes();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			RefrescarListaClientes();
			if (_cliente == null)
			{
				_cliente = new ClientObject(textBox1.Text);
				_servidor.ConectarNuevoCliente(_cliente);
			}
			button1.Enabled = false;
			textBox1.Enabled = false;


		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			_servidor.DesconectarCliente(_cliente.Id);		

		}

		private void RefrescarListaClientes()
		{
			listBox1.Items.Clear();
			List<ClientObject> listaClientes = new List<ClientObject>();
			foreach (ClientObject cliente in _servidor.Clientes.Values)
			{
				listBox1.Items.Add(cliente.Id);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			_servidor.MandarMensajeAlCliente( (Guid)listBox1.SelectedItem, textBox2.Text);
		}
	}
	public class MyClass
	{
		private string jj;
		public string MyProperty
		{
			get { return jj; }
		}
	
	}
}