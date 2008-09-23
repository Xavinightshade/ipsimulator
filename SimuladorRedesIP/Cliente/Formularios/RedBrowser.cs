using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimuladorCliente.Formularios
{
    public partial class RedBrowser : Form
    {
        public RedBrowser()
        {
            InitializeComponent();

        }
        public RedBrowser(List<RedBrowserModel> redes)
        {
            InitializeComponent();
            BindingList<RedBrowserModel> redesBinding=new BindingList<RedBrowserModel>(redes);
            _redesSource.DataSource = redesBinding;

        }
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _id = ((RedBrowserModel)_redesSource.Current).Id;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            _id = ((RedBrowserModel)_redesSource.Current).Id;
            this.DialogResult = DialogResult.OK;


        }
    }
}
