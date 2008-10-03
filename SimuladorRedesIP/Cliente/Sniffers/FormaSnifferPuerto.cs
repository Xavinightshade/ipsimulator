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
using SOA.Datos;
using SimuladorCliente.Sniffers;

namespace SimuladorCliente
{
    public partial class FormaSnifferPuerto: DockContent
    {
        MarcadorPuertoCompleto _marcador;
        public FormaSnifferPuerto(MarcadorPuertoCompleto marcador)
        {
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




        private void ConfigurarGrilla()
        {
            grid.Rows.Clear();
            grid.Redim(1, 3);

            grid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            grid.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            grid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;


            grid.FixedRows = 1;

            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("CONSECUTIVO");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("HORA RECEPCION");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("Asociaciones");


            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid.Columns.AutoSize(true);
        }


        private IView _vista = new CellBackColorAlternate(Color.LightSkyBlue, Color.WhiteSmoke);
        private void LlenarGrilla(List<ARP_SOA> mensajes)
        {
            int c = 0;
            ConfigurarGrilla();
            foreach (ARP_SOA mensaje in mensajes)
            {
                string asociaciones = string.Empty;
                foreach (AsociacionIpMacSOA item in mensaje.Asociaciones)
                {
                    asociaciones += "Ip: " + item.Ip + "-> MAC: " + item.MacAddress + "@@ ";
                }
                grid.Rows.Insert(1);
                grid.Rows[1].Tag = mensaje;
                grid[1, 0] = new SourceGrid.Cells.Cell(c++.ToString());
                grid[1, 1] = new SourceGrid.Cells.Cell(mensaje.Fecha);
                grid[1, 2] = new SourceGrid.Cells.Cell(asociaciones);

                grid[1, 0].AddController(new DoubleClickEventPuertoCompleto());
                grid[1, 1].AddController(new DoubleClickEventPuertoCompleto());
                grid[1, 2].AddController(new DoubleClickEventPuertoCompleto());

                grid[1, 0].View = _vista;
                grid[1, 1].View = _vista;
                grid[1, 2].View = _vista;

            }
            grid.Columns.AutoSizeView();

        }

        private delegate void SetLabelTextDelegate(ARP_SOA mensajes);




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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private List<ARP_SOA> _mensajes = new List<ARP_SOA>();
        internal void ReportarMensaje(ARP_SOA listARP)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetLabelTextDelegate(ReportarMensaje),
                                                            new object[] { listARP });

                return;
            }

            _mensajes.Add(listARP);
            LlenarGrilla(_mensajes);
        }
    }

}
