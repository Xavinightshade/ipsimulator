using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SimuladorCliente.Vistas;

namespace SimuladorCliente
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            MainFrame mainFrame = new MainFrame();

         //   SnifferBeta sniffer = new SnifferBeta(mainFrame.Marcador);
           // sniffer.AllowEndUserDocking = false;
            mainFrame.Show(DockMain, DockState.Document);
          //  sniffer.Show(DockMain, DockState.DockBottomAutoHide);
          
           // 

        }
    }
}
