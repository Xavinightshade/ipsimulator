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
using SimuladorCliente.Marcadores;

namespace SimuladorCliente
{
    public partial class FormaSnifferRouter : FormaSnifferBase
    {
        public FormaSnifferRouter(MarcadorRouter marcador)
            :base(marcador)
        {

        }




        protected override  void ConfigurarGrillaEncapsulacion()
        {
            Grid.Rows.Clear();
            Grid.Redim(1, 3);

            Grid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            Grid.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            Grid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;

            Grid.FixedRows = 1;

            Grid[0, 0] = new SourceGrid.Cells.ColumnHeader("CONSECUTIVO");
            Grid[0, 1] = new SourceGrid.Cells.ColumnHeader("HORA RECEPCION");
            Grid[0, 2] = new SourceGrid.Cells.ColumnHeader("DESCRIPCION");


            Grid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            Grid.Columns.AutoSize(true);
        }


        private void LlenarGrilla(List<EncapsulacionSOA> mensajes)
        {
            int c = 0;
            ConfigurarGrillaEncapsulacion();
            foreach (EncapsulacionSOA mensaje in mensajes)
            {
                Grid.Rows.Insert(1);
                Grid.Rows[1].Tag = mensaje;
                Grid[1, 0] = new SourceGrid.Cells.Cell(c++.ToString());
                Grid[1, 1] = new SourceGrid.Cells.Cell(mensaje.Fecha.ToString());
                string mostrar = String.Empty;
                if (mensaje.EsEncapsulacion)
                {
                    mostrar += "Paquete Encapsulado";
                }
                else
                {
                    mostrar += "Paquete Desencapsulado";
                }
                  Grid[1, 2] = new SourceGrid.Cells.Cell(mostrar);

                  Grid[1, 0].AddController(new DoubleClickEventSnifferPC());
                  Grid[1, 1].AddController(new DoubleClickEventSnifferPC());
                  Grid[1, 2].AddController(new DoubleClickEventSnifferPC());
                  Grid[1, 0].View = Vista;
                  Grid[1, 1].View = Vista;
                  Grid[1, 2].View = Vista;


            }
            Grid.Columns.AutoSizeView();

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
