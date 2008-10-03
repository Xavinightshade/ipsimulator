using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOA.Datos;

namespace SimuladorCliente.Formularios
{
    public partial class Encapsulacion : Form
    {
        public Encapsulacion()
        {
            InitializeComponent();
        }





        internal void Inicializar(EncapsulacionSOA mensa)
        {
            _fecha.Text = mensa.Fecha.ToString();
            _macOrigen.Text = mensa.Frame.MACAddressOrigen;
            _macDestino.Text = mensa.Frame.MACAddressDestino;
            _ipOrigen1.Text = mensa.Paquete.IpOrigen;
            _ipOrigen2.Text = mensa.Paquete.IpOrigen;
            _ipDestino1.Text = mensa.Paquete.IpDestino;
            _ipDestino2.Text = mensa.Paquete.IpDestino;
            _datos1.Text = mensa.Paquete.Datos;
            _datos2.Text = mensa.Paquete.Datos;
        }
    }
}
