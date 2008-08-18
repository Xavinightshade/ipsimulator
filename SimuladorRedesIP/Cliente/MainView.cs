using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SimuladorCliente.Vistas;
using SimuladorCliente.Herramientas;

namespace SimuladorCliente
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            MainFrame mainFrame = new MainFrame(DockMain);
            PaletaHerramienta paleta = new PaletaHerramienta();
            mainFrame.Show(DockMain, DockState.Document);
            paleta.Show(DockMain, DockState.DockLeft);
          
      

        }
    }
}
