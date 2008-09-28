using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace SimuladorCliente.Formularios
{
    public partial class ConexionServidor : Form
    {
        public ConexionServidor()
        {
            InitializeComponent();
        }

        public string IPAddress
        {
            get { return ipTextBox1.Text; }
            set { ipTextBox1.Text=value; }
        }

        public int Puerto
        {
            get {
                return int.Parse(_puerto.Text); }
        }

        private void _Aceptar_Click(object sender, EventArgs e)
        {
            if (!IPAddressFactory.EsValidaLaDireccion(IPAddress))
            {
                MessageBox.Show("Dirección IP invalida", "Dirección IP", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;

            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void _cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
