using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SimuladorCliente.Herramientas
{
    public partial class PaletaHerramienta : DockContent
    {
        public PaletaHerramienta()
        {
            InitializeComponent();
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






    }
}
