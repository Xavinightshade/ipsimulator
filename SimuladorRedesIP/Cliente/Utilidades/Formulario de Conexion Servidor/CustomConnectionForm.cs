using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TesGestion.SOA
{
    public partial class CustomConnectionForm : Form
    {
		 public CustomConnectionForm(CustomConnectionModel modelo)
		 {
			 InitializeComponent();
			 _bsConfiguracion.DataSource = modelo;
		 }
         public CustomConnectionForm()
         {
             InitializeComponent();
         }

	

        private void button1_Click(object sender, EventArgs e)
        {           
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}