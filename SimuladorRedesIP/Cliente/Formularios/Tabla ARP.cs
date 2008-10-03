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
    public partial class Tabla_ARP : Form
    {
        public Tabla_ARP()
        {
            InitializeComponent();
            
        }


        internal void Inicializar(SOA.Datos.ARP_SOA mensa)
        {
            _fecha.Text = mensa.Fecha.ToString();
            _ArpBS.DataSource = mensa.Asociaciones;

        }
    }
}
