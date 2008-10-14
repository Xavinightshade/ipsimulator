using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOA;
using RedesIP.SOA;
using System.IO;

namespace SimuladorCliente.Formularios
{
    public partial class ArchivoForm : Form
    {
        public ArchivoForm()
        {
            InitializeComponent();
        }



        private IModeloSOA _contrato;
        private Guid _idPc;
        internal void Inicializar(Guid idPc,List<ArchivoSOA> archivos, IModeloSOA contrato)
        {
            archivoSOABindingSource.DataSource = archivos;
            _contrato = contrato;
            _idPc = idPc;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArchivoSOA archivo=(ArchivoSOA)archivoSOABindingSource.Current;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = archivo.FileName;
            string extension = archivo.FileName.Substring(archivo.FileName.IndexOf('.'));

            dialog.Filter = "(*" + extension + ")|*" + extension;
            dialog.ValidateNames = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                byte[] data = _contrato.GetFile(_idPc, archivo.Id);
                File.WriteAllBytes(dialog.FileName, data);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
