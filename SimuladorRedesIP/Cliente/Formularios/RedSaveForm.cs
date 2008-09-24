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
    public partial class RedSaveForm : Form
    {
        public RedSaveForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public string NombreRed
        {
            get { return textBox2.Text; }
        }
        public string DescripcionRed
        {
            get { return textBox1.Text; }
        }

        internal void Inicializar(string nombre, string descripcion, Bitmap imagen)
        {
            textBox2.Text = nombre;
            textBox1.Text = descripcion;
            pictureBox1.Image = imagen;
        }
    }
}
