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
    public partial class PingForm : Form
    {
        public PingForm()
        {
            InitializeComponent();
        }

        public string IPAddress
        {
            get { return ipTextBox1.Text; }
            set { ipTextBox1.Text=value; }
        }
        public string Dato
        {
            get { return _dato.Text; }
        }
        public int Numero
        {
            get { return int.Parse(_numero.Text); }
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
