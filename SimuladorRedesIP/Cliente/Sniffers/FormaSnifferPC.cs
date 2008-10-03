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
using RedesIP.Vistas.Equipos;
using SimuladorCliente.Sniffers;
using SOA.Datos;

namespace SimuladorCliente
{
    public partial class FormaSnifferPC : DockContent
    {
        ComputadorView _pc;
        public FormaSnifferPC(ComputadorView pc, Color color)
        {
            _pc = pc;
            InitializeComponent();
            ConfigurarGrilla();
            marcadorImagen1.Color = color;
            this.TabText = pc.Id.ToString().Substring(0, 5);
            this.label1.Text = pc.Id.ToString();
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
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("DESCRIPCION");


            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid.Columns.AutoSize(true);
        }


        private IView _vista = new CellBackColorAlternate(Color.LightSkyBlue, Color.WhiteSmoke);
        private void LlenarGrilla(List<EncapsulacionSOA> mensajes)
        {
            int c = 0;
            ConfigurarGrilla();
            foreach (EncapsulacionSOA mensaje in mensajes)
            {
                grid.Rows.Insert(1);
                grid.Rows[1].Tag = mensaje;
                grid[1, 0] = new SourceGrid.Cells.Cell(c++.ToString());
                grid[1, 1] = new SourceGrid.Cells.Cell(mensaje.Fecha.ToString());
                string mostrar = String.Empty;
                if (mensaje.EsEncapsulacion)
                {
                    mostrar += "Encap";
                }
                else
                {
                    mostrar += "Desencap";
                }
                  grid[1, 2] = new SourceGrid.Cells.Cell(mostrar);

                  grid[1, 0].AddController(new DoubleClickEventSnifferPC());
                  grid[1, 1].AddController(new DoubleClickEventSnifferPC());
                  grid[1, 2].AddController(new DoubleClickEventSnifferPC());
                grid[1, 0].View = _vista;
                grid[1, 1].View = _vista;
                grid[1, 2].View = _vista;


            }
            grid.Columns.AutoSizeView();

        }

        private delegate void SetLabelTextDelegate(EncapsulacionSOA mensaje);
        List<EncapsulacionSOA> _mensajes = new List<EncapsulacionSOA>();
        public void ReportarMensaje(EncapsulacionSOA mensaje)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetLabelTextDelegate(ReportarMensaje),
                                                            new object[] { mensaje});

                return;
            }
            _mensajes.Add(mensaje);

            LlenarGrilla(_mensajes);

        }

    }

}
