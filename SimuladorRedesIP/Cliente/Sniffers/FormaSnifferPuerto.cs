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
    public partial class FormaSnifferPuerto: FormaSnifferBase
    {
        MarcadorPuertoCompleto _marcador;
        public FormaSnifferPuerto(MarcadorPuertoCompleto marcador)
            :base(marcador)
        {


        }






        protected override  void ConfigurarGrilla()
        {
            Grid.Rows.Clear();
            Grid.Redim(1, 3);

            Grid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            Grid.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            Grid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;


            Grid.FixedRows = 1;

            Grid[0, 0] = new SourceGrid.Cells.ColumnHeader("CONSECUTIVO");
            Grid[0, 1] = new SourceGrid.Cells.ColumnHeader("HORA RECEPCION");
            Grid[0, 2] = new SourceGrid.Cells.ColumnHeader("Asociaciones");


            Grid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            Grid.Columns.AutoSize(true);
        }


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
                Grid.Rows.Insert(1);
                Grid.Rows[1].Tag = mensaje;
                Grid[1, 0] = new SourceGrid.Cells.Cell(c++.ToString());
                Grid[1, 1] = new SourceGrid.Cells.Cell(mensaje.Fecha);
                Grid[1, 2] = new SourceGrid.Cells.Cell(asociaciones);

                Grid[1, 0].AddController(new DoubleClickEventPuertoCompleto());
                Grid[1, 1].AddController(new DoubleClickEventPuertoCompleto());
                Grid[1, 2].AddController(new DoubleClickEventPuertoCompleto());

                Grid[1, 0].View = Vista;
                Grid[1, 1].View = Vista;
                Grid[1, 2].View = Vista;

            }
            Grid.Columns.AutoSizeView();

        }

        private delegate void SetLabelTextDelegate(ARP_SOA mensajes);







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
