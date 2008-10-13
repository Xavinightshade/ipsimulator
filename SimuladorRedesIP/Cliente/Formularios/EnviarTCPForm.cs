using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;
using System.IO;

namespace SimuladorCliente.Formularios
{
    public partial class EnviarTCPForm : Form
    {
        public EnviarTCPForm()
        {
            InitializeComponent();
            _escala.SelectedIndex = _escala.Items.Count-1;
        }
        public int TamanoSegmento
        {
            get { return int.Parse(_segmentSize.Text); }
        }
        public int EscalaWindow
        {
            get { return int.Parse(_escala.Text); }
        }
        public string IPAddress
        {
            get { return ipTextBox1.Text; }
            set { ipTextBox1.Text = value; }
        }
        public int SourcePort
        {
            get { return int.Parse(_puertoOrigen.Text); }
        }
        public int DestinationPort
        {
            get { return int.Parse(_puertoDestino.Text); }
        }
        public int SegmentSize
        {
            get { return int.Parse(_segmentSize.Text); }
        }
        public int ScaleWindow
        {
            get { return int.Parse(_escala.Text); }
        }

        private void _Aceptar_Click(object sender, EventArgs e)
        {
            if (!IPAddressFactory.EsValidaLaDireccion(IPAddress))
            {
                MessageBox.Show("Dirección IP invalida", "Dirección IP", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;

            }
            if (_stream == null)
            {
                MessageBox.Show("Seleccione un archivo para enviar", "Stream", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        public void SetInfoEquipo(string info)
        {
            _equipoInfo.Text = info;
            ipTextBox1.Focus();

        }

        private void _cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private byte[] _stream;

        public byte[] Stream
        {
            get { return _stream; }
            set { _stream = value; }
        }

        private void _escala_SelectedItemChanged(object sender, EventArgs e)
        {
            _windowSize.Text = ( (int.Parse( (string)_escala.SelectedItem)) * (int.Parse(_segmentSize.Text))).ToString();
        }

        private void _segmentSize_TextChanged(object sender, EventArgs e)
        {
            int size;
            if (!int.TryParse(_segmentSize.Text, out size))
            {
                _segmentSize.Text = string.Empty;
                return;
            }

            _windowSize.Text = ((int.Parse((string)_escala.SelectedItem)) * (int.Parse(_segmentSize.Text))).ToString();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(dialog.FileName);
                if (f.Length > 1000000)
                {
                    MessageBox.Show("Seleccione un archivo menor de 1MByte", "Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _stream = File.ReadAllBytes(dialog.FileName);
                label5.Text = dialog.FileName;
                _sizeStream.Text = _stream.Length.ToString();

            }
        }





    }
}
