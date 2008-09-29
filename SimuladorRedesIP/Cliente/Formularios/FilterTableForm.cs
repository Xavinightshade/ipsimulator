using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedesIP.SOA.Elementos;

namespace SimuladorCliente.Formularios
{
    public partial class FilterTableForm : Form
    {
        public FilterTableForm()
        {
            InitializeComponent();
        }

        internal void Inicializar(MensajeSwitchTableSOA mensa)
        {
            _asociacionesBS.DataSource = mensa.SwiTable.Asociaciones;
            _hora.Text = mensa.HoraRecepcion.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
