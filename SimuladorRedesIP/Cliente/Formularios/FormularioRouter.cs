using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedesIP.Vistas.Equipos.Componentes;

namespace SimuladorCliente.Formularios
{
    public partial class FormularioRouter : Form
    {
        public FormularioRouter()
        {
            InitializeComponent();
            macTextBox1.SetAsReadOnly();
        }



        internal void Inicializar(List<PuertoEthernetViewCompleto> puertosEthernet)
        {
            _puertosBS.DataSource = new BindingList<PuertoEthernetViewCompleto>(puertosEthernet);
        }
    }
}
