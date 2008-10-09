using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace SimuladorCliente.Formularios
{
    public partial class FormularioComputador : Form
    {
        public FormularioComputador()
        {
            InitializeComponent();
            macTextBox1.SetAsReadOnly();
        }
        public string MACAddress
        {
            get { return macTextBox1.Text; }
            set { macTextBox1.Text=value; }
        }
        public string NombrePuerto
        {
            get { return _nombrePuerto.Text; }
            set { _nombrePuerto.Text = value; }
        }
        public string IPAddress
        {
            get { return ipTextBox1.Text; }
            set { ipTextBox1.Text=value; }
        }
        public string DefaultGateWay
        {
            get { return _defaultGW.Text; }
            set { _defaultGW.Text = value; }
        }
        public string NombrePC
        {
            get { return _nombrePc.Text; }
            set { _nombrePc.Text = value; }
        }
        public string Mask
        {
            get { return _mask.Text; }
            set { _mask.Text = value; }
        }
        public bool PuertoHabilitado
        {
            get { return _ChkBoxpuertoHabilitado.Checked; }
            set { _ChkBoxpuertoHabilitado.Checked = value; }
        }

        private void _Aceptar_Click(object sender, EventArgs e)
        {
            string mensajeDeError = string.Empty;
            if (PuertoHabilitado)
            {
                if (!IPAddressFactory.EsValidaLaDireccion(IPAddress))
                    mensajeDeError += "Dirección IP invalida";
                if (!IPAddressFactory.EsValidaLaDireccion(DefaultGateWay))
                    mensajeDeError += "Dirección IP Default Gate Way invalida";
                if ((string.IsNullOrEmpty(Mask)) || (!IPAddressFactory.EsValidaLaMascara(int.Parse(Mask))))
                    mensajeDeError += "Valor de Mascara invalida";
            }
            if (mensajeDeError!=string.Empty)
            {
                mensajeDeError += Environment.NewLine + "Rectificar los datos";
                MessageBox.Show(mensajeDeError, "Datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void _cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



    }
}
