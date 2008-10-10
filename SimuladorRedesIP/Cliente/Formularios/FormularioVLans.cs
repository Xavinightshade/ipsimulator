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
using BusinessLogic;

namespace SimuladorCliente.Formularios
{
    public partial class FormularioVLans : Form
    {
        public FormularioVLans()
        {
            InitializeComponent();

        }



        internal void Inicializar(List<PuertoBaseSOA> puertosEthernet)
        {
            _puertosDisponiblesBS.DataSource = new BindingList<PuertoBaseSOA>(puertosEthernet);
            
        }

        private void _Aceptar_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
        }

        private void _cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        public string NombreSwitch
        {
            get { return _nombreSwitch.Text; }
            set { _nombreSwitch.Text = value; }
        }
    }
}
