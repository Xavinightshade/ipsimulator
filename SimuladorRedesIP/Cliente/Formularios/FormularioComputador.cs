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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(macTextBox1.Text+Environment.NewLine+ipTextBox1.Text);
        }
    }
}
