﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimuladorCliente.Formularios
{
    public partial class FilterTableForm : Form
    {
        public FilterTableForm()
        {
            InitializeComponent();
            macTextBox1.SetAsReadOnly();
        }
    }
}
