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
    public partial class EnviarTCPForm : Form
    {
        public EnviarTCPForm()
        {
            InitializeComponent();
        }

        public string IPAddress
        {
            get { return ipTextBox1.Text; }
            set { ipTextBox1.Text = value; }
        }
        public int SourcePort
        {
            get { return int.Parse(_puertoOrigen.Text); }
        }
        public int DestinationPort
        {
            get { return int.Parse( _puertoDestino.Text); }
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
        public void SetInfoEquipo(string info)
        {
            _equipoInfo.Text = info;
            ipTextBox1.Focus();

        }

        private void _cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
