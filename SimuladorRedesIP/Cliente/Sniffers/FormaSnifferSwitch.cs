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

namespace SimuladorCliente
{
    public partial class FormaSnifferSwitch : DockContent
    {
        SwitchView _switch;
        public FormaSnifferSwitch(SwitchView swi, Color color)
        {
            _switch = swi;
            InitializeComponent();
            ConfigurarGrilla();
            marcadorImagen1.Color = color;
            this.TabText = swi.Id.ToString().Substring(0, 5);
            this.label1.Text = swi.Id.ToString();
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
        private void LlenarGrilla(List<MensajeSwitchTableSOA> mensajes)
        {
            int c = 0;
            ConfigurarGrilla();
            foreach (MensajeSwitchTableSOA mensaje in mensajes)
            {
                grid.Rows.Insert(1);
                grid.Rows[1].Tag = mensaje;
                grid[1, 0] = new SourceGrid.Cells.Cell(c++.ToString());
                grid[1, 1] = new SourceGrid.Cells.Cell(mensaje.HoraRecepcion.ToString());
                string mostrar = String.Empty;
                for (int i = 0; i < mensaje.SwiTable.Asociaciones.Count; i++)
                {
                    mostrar+=  "Dir: " + mensaje.SwiTable.Asociaciones[i].MacAddress + " Puerto: " + mensaje.SwiTable.Asociaciones[i].Puerto.Nombre+"@@ ";
                }
                  grid[1, 2] = new SourceGrid.Cells.Cell(mostrar);

                grid[1, 0].AddController(new DoubleClickEventSnifferSwitch());
                grid[1, 1].AddController(new DoubleClickEventSnifferSwitch());
                grid[1, 2].AddController(new DoubleClickEventSnifferSwitch());
                grid[1, 0].View = _vista;
                grid[1, 1].View = _vista;
                grid[1, 2].View = _vista;


            }
            grid.Columns.AutoSizeView();

        }

        private delegate void SetLabelTextDelegate(MensajeSwitchTableSOA mensaje);
        List<MensajeSwitchTableSOA> _mensajes = new List<MensajeSwitchTableSOA>();
        public void ReportarMensaje(MensajeSwitchTableSOA mensaje)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetLabelTextDelegate(ReportarMensaje),
                                                            new object[] { mensaje });

                return;
            }
            _mensajes.Add(mensaje);

            LlenarGrilla(_mensajes);

        }

    }

}
