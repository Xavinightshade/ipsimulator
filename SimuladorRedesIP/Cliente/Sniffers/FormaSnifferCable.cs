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
using SimuladorCliente.Sniffers;

namespace SimuladorCliente
{
    public partial class FormaSnifferCable : FormaSnifferBase
    {



        public FormaSnifferCable(MarcadorCable marcador)
            :base(marcador)
        {
            

        }






        protected override  void ConfigurarGrilla()
        {
            Grid.Rows.Clear();
            Grid.Redim(1, 5);

            Grid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            Grid.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            Grid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;
            Grid.Columns[3].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;
            Grid.Columns[4].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;


            Grid.FixedRows = 1;

            Grid[0, 0] = new SourceGrid.Cells.ColumnHeader("CONSECUTIVO");
            Grid[0, 1] = new SourceGrid.Cells.ColumnHeader("HORA RECEPCION");
            Grid[0, 2] = new SourceGrid.Cells.ColumnHeader("MAC ORIGEN");
            Grid[0, 3] = new SourceGrid.Cells.ColumnHeader("MAC DESTINO");
            Grid[0, 4] = new SourceGrid.Cells.ColumnHeader("DATOS");

            Grid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            Grid.Columns.AutoSize(true);
        }


        private void LlenarGrilla(List<MensajeCableSOA> mensajes)
        {
            int c = 0;
            ConfigurarGrilla();
            foreach (MensajeCableSOA mensaje in mensajes)
            {
                Grid.Rows.Insert(1);
                Grid.Rows[1].Tag = mensaje;
                Grid[1, 0] = new SourceGrid.Cells.Cell(c++.ToString());
                Grid[1, 1] = new SourceGrid.Cells.Cell(mensaje.HoraRecepcion.ToString());
                Grid[1, 2] = new SourceGrid.Cells.Cell(mensaje.Frame.MACAddressOrigen);
                Grid[1, 3] = new SourceGrid.Cells.Cell(mensaje.Frame.MACAddressDestino);
                Grid[1, 4] = new SourceGrid.Cells.Cell(mensaje.Frame.Info);
                Grid[1, 0].AddController(new DoubleClickEventSnifferCable());
                Grid[1, 1].AddController(new DoubleClickEventSnifferCable());
                Grid[1, 2].AddController(new DoubleClickEventSnifferCable());
                Grid[1, 3].AddController(new DoubleClickEventSnifferCable());
                Grid[1, 4].AddController(new DoubleClickEventSnifferCable());
                Grid[1, 0].View = Vista;
                Grid[1, 1].View = Vista;
                Grid[1, 2].View = Vista;
                Grid[1, 3].View = Vista;
                Grid[1, 4].View = Vista;

            }
            Grid.Columns.AutoSizeView();

        }

        private delegate void SetLabelTextDelegate(MensajeCableSOA mensaje);
        List<MensajeCableSOA> _mensajes = new List<MensajeCableSOA>();
        public void ReportarMensaje(MensajeCableSOA mensaje)
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
