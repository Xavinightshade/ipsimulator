using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOA.Componentes;
using RedesIP.Vistas.Equipos.Componentes;

namespace SimuladorCliente.Formularios
{
    public partial class RouteTableForm : Form
    {
        public RouteTableForm()
        {
            InitializeComponent();
        }
        private List<PuertoEthernetViewCompleto> _puertos;
        BindingList<RutaSOA> _rutasMD;
        internal void Inicializar(List<RutaSOA> rutas,List<PuertoEthernetViewCompleto> puertos)
        {
            _puertos = puertos;
            _rutasMD = new BindingList<RutaSOA>(rutas);
            _rutas.DataSource = _rutasMD;
            _puertosBS.DataSource = _puertos;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RutaSOA ruta = new RutaSOA(Guid.NewGuid());
            ruta.IdPuerto = ((PuertoEthernetViewCompleto)comboBox1.SelectedItem).Id;
            _rutasMD.Add(ruta);
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _rutasMD.Remove((RutaSOA)_rutas.Current);
        }
    }
}
