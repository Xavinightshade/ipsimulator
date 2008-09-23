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
        public PaletaHerramienta()
        {
            InitializeComponent();
            ToolStripMenuItem bdDefault=new ToolStripMenuItem("Cargar base de datos Predeterminada",Resources.database_process_16x16);
            ToolStripMenuItem dbArchivo = new ToolStripMenuItem("Cargar base de datos desde archivo", Resources.database_search_16x16);
            _menuBD.Items.Add(bdDefault);
            //_menuBD.Items.Add(new ToolStripSeparator());
            _menuBD.Items.Add(dbArchivo);

            ToolStripMenuItem soaConectar = new ToolStripMenuItem("Conectar a Servidor", Resources.connect_16x16);
            ToolStripMenuItem soaDesconectar = new ToolStripMenuItem("Desconectar del servidor", Resources.disconnect_16x16);
            ToolStripMenuItem soaConfigurar = new ToolStripMenuItem("Inicializar servicio", Resources.synchronize_16x16);

            _menuSOA.Items.Add(soaConectar);
            _menuSOA.Items.Add(soaDesconectar);
            _menuSOA.Items.Add(new ToolStripSeparator());
            _menuSOA.Items.Add(soaConfigurar);

        }

        private void _mouse_Click(object sender, EventArgs e)
        {
            _mouse.FlatStyle = FlatStyle.Flat;
            _pc.FlatStyle = FlatStyle.Standard;
            _switch.FlatStyle = FlatStyle.Standard;
            _router.FlatStyle = FlatStyle.Standard;
            _conexion.FlatStyle = FlatStyle.Standard;
            _punta.FlatStyle = FlatStyle.Standard;
            //_pc.Enabled = true;
            //_switch.Enabled = true;
            //_router.Enabled = true;
            //_punta.Enabled = true;
            //_conexion.Enabled = true;

        }

        private void _pc_Click(object sender, EventArgs e)
        {
            _mouse.FlatStyle = FlatStyle.Standard;
            _pc.FlatStyle = FlatStyle.Flat;
            _switch.FlatStyle = FlatStyle.Standard;
            _router.FlatStyle = FlatStyle.Standard;
            _conexion.FlatStyle = FlatStyle.Standard;
            _punta.FlatStyle = FlatStyle.Standard;
  
        }

        private void _switch_Click(object sender, EventArgs e)
        {
            _mouse.FlatStyle = FlatStyle.Standard;
            _pc.FlatStyle = FlatStyle.Standard;
            _switch.FlatStyle = FlatStyle.Flat;
            _router.FlatStyle = FlatStyle.Standard;
            _conexion.FlatStyle = FlatStyle.Standard;
            _punta.FlatStyle = FlatStyle.Standard;
        }

        private void _router_Click(object sender, EventArgs e)
        {
            _mouse.FlatStyle = FlatStyle.Standard;
            _pc.FlatStyle = FlatStyle.Standard;
            _switch.FlatStyle = FlatStyle.Standard;
            _router.FlatStyle = FlatStyle.Flat;
            _conexion.FlatStyle = FlatStyle.Standard;
            _punta.FlatStyle = FlatStyle.Standard;
        }

        private void _conexion_Click(object sender, EventArgs e)
        {
            _mouse.FlatStyle = FlatStyle.Standard;
            _pc.FlatStyle = FlatStyle.Standard;
            _switch.FlatStyle = FlatStyle.Standard;
            _router.FlatStyle = FlatStyle.Standard;
            _conexion.FlatStyle = FlatStyle.Flat;
            _punta.FlatStyle = FlatStyle.Standard;
        }

        private void _punta_Click(object sender, EventArgs e)
        {
            _mouse.FlatStyle = FlatStyle.Standard;
            _pc.FlatStyle = FlatStyle.Standard;
            _switch.FlatStyle = FlatStyle.Standard;
            _router.FlatStyle = FlatStyle.Standard;
            _conexion.FlatStyle = FlatStyle.Standard;
            _punta.FlatStyle = FlatStyle.Flat;
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








    }
}
