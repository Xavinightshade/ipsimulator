using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimuladorCliente.Vistas;
using WeifenLuo.WinFormsUI.Docking;
using SourceGrid.Cells.Views;
using RedesIP.Vistas;
using RedesIP.SOA.Elementos;
using DevAge.Windows.Forms;
using SimuladorCliente.Marcadores;
using SimuladorCliente.Sniffers;
using SourceGrid;

namespace SimuladorCliente
{
    public partial class FormaSnifferBase : DockContent
    {
        MarcadorBase _marcador;
        protected Grid Grid
        {
            get { return grid; } 
        }
        protected MarcadorBase Marcador
        {
            get { return _marcador; }
        }
        public FormaSnifferBase()
        {
            InitializeComponent();

        }
        public FormaSnifferBase(MarcadorBase marcador)
        {
            this.CloseButton = false;
            _marcador = marcador;
            InitializeComponent();
            ConfigurarGrilla();
            marcadorImagen1.Color = marcador.Color;
            this.TabText = _marcador.Nombre;
            this.textBox1.Text = _marcador.Nombre;
            this.textBox1.TextChanged += new EventHandler(textBox1_TextChanged);

        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {
            TabText = textBox1.Text;
            _marcador.Nombre = textBox1.Text;

        }




        protected virtual void ConfigurarGrilla()
        {
            throw new NotImplementedException();
        }


        private IView _vista = new CellBackColorAlternate(Color.LightSkyBlue, Color.WhiteSmoke);

        protected IView Vista
        {
            get { return _vista; }
        }





        private void marcadorImagen1_DoubleClick(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _marcador.Color = colorDialog.Color;
                    marcadorImagen1.Color = _marcador.Color;
                }
            }
        }




        private delegate void CloseDelegate();

        public   void CerrarSniffer()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CloseDelegate(CerrarSniffer));
                return;
            }
            Dispose();
            this.Close();
        }
        protected new virtual void  Dispose()
        {
            _marcador = null;
            _vista = null;
            base.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _marcador.EliminarMarcador();
        }
    }

}
