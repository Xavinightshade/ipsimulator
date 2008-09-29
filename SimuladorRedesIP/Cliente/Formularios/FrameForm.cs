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
    public partial class FrameForm : Form
    {
        public FrameForm()
        {
            InitializeComponent();
            _macOrigen.SetAsReadOnly();
            _macDestino.SetAsReadOnly();
        }

        internal void Inicializar(MensajeCableSOA mensajeCableSOA)
        {
            _macOrigen.Text = mensajeCableSOA.Frame.MACAddressOrigen;
            _macDestino.Text = mensajeCableSOA.Frame.MACAddressDestino;
            _datos.Text = mensajeCableSOA.Frame.Info.Replace(",,",Environment.NewLine);
            _hora.Text = mensajeCableSOA.HoraRecepcion.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
