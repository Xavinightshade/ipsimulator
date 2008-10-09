using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SimuladorCliente.Properties;

namespace SimuladorCliente.Herramientas
{
    public partial class PaletaHerramienta : DockContent
    {
        public ToolStripMenuItem _PaletabdDefault = new ToolStripMenuItem("Seleccionar base de datos predeterminada", Resources.database_process_16x16);
        public ToolStripMenuItem _PaletadbArchivo = new ToolStripMenuItem("Seleccionar base de datos desde archivo", Resources.database_search_16x16);
        public ToolStripMenuItem _PaletadbSave = new ToolStripMenuItem("Guardar base de datos actual a archivo", Resources.database_save);


        public ToolStripMenuItem _PaletasoaConectar = new ToolStripMenuItem("Conectar a Servidor", Resources.connect_16x16);
        public ToolStripMenuItem _PaletasoaDesconectar = new ToolStripMenuItem("Desconectar del servidor", Resources.disconnect_16x16);
        public ToolStripMenuItem _PaletasoaConfigurar = new ToolStripMenuItem("Inicializar servicio", Resources.synchronize_16x16);

        public PaletaHerramienta()
        {
            InitializeComponent();
            _menuBD.Items.Add(_PaletabdDefault);
            _menuBD.Items.Add(_PaletadbArchivo);
            _menuBD.Items.Add(_PaletadbSave);



            _menuSOA.Items.Add(_PaletasoaConectar);
            _menuSOA.Items.Add(_PaletasoaDesconectar);
            _menuSOA.Items.Add(new ToolStripSeparator());
            _menuSOA.Items.Add(_PaletasoaConfigurar);

        }

 
        ContextMenuStrip _menuBD = new ContextMenuStrip();
        ContextMenuStrip _menuSOA = new ContextMenuStrip();
        private void button7_Click(object sender, EventArgs e)
        {
            
            _menuSOA.Show(button7, button7.Width, button7.Height / 2);


        }

        private void button8_Click(object sender, EventArgs e)
        {
            _menuBD.Show(button8, button8.Width, button8.Height / 2);

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _paletaValorLabel.Text = "1 seg  :  " + (11- _paletaTrackBar.Value).ToString() + " seg";
        }


        public void SetValor(int valor)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetValorDelegate(SetValor), new object[] { valor });
                return;
            }
            _paletaTrackBar.Value =11- valor;
            _paletaValorLabel.Text = "1 seg  :  " + (valor).ToString() + " seg";

        }

        private delegate void SetValorDelegate(int valor);







    }
}
