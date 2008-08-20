using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimuladorCliente.Formularios
{
    public partial class FormularioComputador : Form
    {
        public FormularioComputador()
        {
            InitializeComponent();
            macTextBox1.SetAsReadOnly();
        }
        public string MACAddress
        {
            get { return macTextBox1.Text; }
            set { macTextBox1.Text=value; }
        }
        public string NombrePuerto
        {
            get { return _nombrePuerto.Text; }
            set { _nombrePuerto.Text = value; }
        }
        public string IPAddress
        {
            get { return ipTextBox1.Text; }
            set { ipTextBox1.Text=value; }
        }

        private void _Aceptar_Click(object sender, EventArgs e)
        {
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
