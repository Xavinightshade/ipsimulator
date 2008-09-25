using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.SOA;

namespace SimuladorCliente.Formularios
{
    public partial class FormularioRouter : Form
    {
        public FormularioRouter()
        {
            InitializeComponent();

        }



        internal void Inicializar(List<PuertoCompletoSOA> puertosEthernet)
        {
            _puertosBS.DataSource = new BindingList<PuertoCompletoSOA>(puertosEthernet);
            
        }

        private void _Aceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void _cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        public string NombreRouter
        {
            get { return _nombrePc.Text; }
            set { _nombrePc.Text = value; }
        }
    }
}
