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
            string mensajeDeError = string.Empty;

            foreach (PuertoCompletoSOA puerto in (BindingList<PuertoCompletoSOA>)_puertosBS.DataSource)
            {
                string mensajePuerto = string.Empty;
                if (puerto.Habilitado)
                {
                    if (!IPAddressFactory.EsValidaLaDireccion(puerto.IPAddress))
                        mensajePuerto += "Dirección IP invalida";
                    if (!IPAddressFactory.EsValidaLaMascara(puerto.Mask))
                        mensajePuerto += ", Valor de Mascara invalida";
                    if (mensajePuerto != string.Empty)
                    {
                        mensajeDeError += puerto.Nombre + ": " + mensajePuerto + Environment.NewLine;
                    }
                }
            }
            if (mensajeDeError != string.Empty)
            {
                MessageBox.Show(mensajeDeError, "Datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
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
        public bool RipHabilitado
        {
            get { return _chbboxRip.Checked; }
            set { _chbboxRip.Checked = value; }
        }
    }
}
