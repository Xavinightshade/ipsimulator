using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedesIP.Vistas;
using WeifenLuo.WinFormsUI.Docking;

namespace SimuladorCliente
{
    public partial class FormaEstacion : DockContent
    {
        public FormaEstacion()
        {
            InitializeComponent();
        }
        public EstacionView EstacionView
        {
            get { return _estacionView; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _estacionView.GetImagen();
        }
    }
}
