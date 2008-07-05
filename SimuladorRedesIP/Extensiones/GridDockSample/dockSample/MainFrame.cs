using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace dockSample
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
            Prueba prueba = new Prueba();
            Prueba prueba2 = new Prueba();
            Prueba prueba3 = new Prueba();
            MainDock main = new MainDock();
            MainDock main2 = new MainDock();
            prueba.Show(DockMain,DockState.DockBottom);
            prueba2.Show(DockMain, DockState.DockBottom);
            prueba3.Show(DockMain, DockState.DockBottom);
            main.Show(DockMain, DockState.Document);
            main2.Show(DockMain, DockState.Document);
     
        }
    }
}
