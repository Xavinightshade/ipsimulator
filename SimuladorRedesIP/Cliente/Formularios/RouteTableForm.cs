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
        internal void Inicializar(List<RutaSOA> rutasEstaticas,List<RutaSOA> rutasRouter, List<PuertoEthernetViewCompleto> puertos)
        {
            _puertos = puertos;
            _rutasMD = new BindingList<RutaSOA>(rutasEstaticas);
            _rutasEstaticas.DataSource = _rutasMD;
            _rutasRouter.DataSource = rutasRouter;
            _puertosBS.DataSource = _puertos;
            _rutasEstaticas.Position = 0;
                if (_rutasMD.Count == 0)
                {
                    _eliminar.Enabled = false;
                    groupBox1.Enabled = false;
                }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndexChanged -= new System.EventHandler(this.comboBox1_SelectedIndexChanged);

            this.DialogResult = DialogResult.OK;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndexChanged -= new System.EventHandler(this.comboBox1_SelectedIndexChanged);

            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RutaSOA ruta = new RutaSOA(Guid.NewGuid());
            ruta.IdPuerto = _puertos[0].Id;
            ruta.NombrePuerto = _puertos[0].Nombre;
            _rutasMD.Add(ruta);
            _rutasEstaticas.Position = _rutasEstaticas.IndexOf(ruta);
            comboBox1.SelectedIndex = 0;
            _eliminar.Enabled = true;
            groupBox1.Enabled = true;
            ipTextBox1.Focus();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _rutasMD.Remove((RutaSOA)_rutasEstaticas.Current);
            if (_rutasMD.Count == 0)
            {
                _eliminar.Enabled = false;
                groupBox1.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((RutaSOA)_rutasEstaticas.Current).IdPuerto = ((PuertoEthernetViewCompleto)comboBox1.SelectedItem).Id;
        }

        private void RouteTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.comboBox1.SelectedIndexChanged -= new System.EventHandler(this.comboBox1_SelectedIndexChanged);

        }
    }
}
