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

namespace SimuladorCliente
{
    public partial class SnifferBeta : DockContent
    {
        public SnifferBeta(Marcador marcador)
        {
            InitializeComponent();
            ConfigurarGrilla();
            marcadorImagen1.Color = marcador.Color;
            this.TabText = marcador.Id.ToString().Substring(0, 5);
            this.label1.Text = marcador.Id.ToString();
            marcador.NuevoMensaje += new EventHandler<NuevoMensajeEventArgs>(OnMensaje);
        }

        void OnMensaje(object sender, NuevoMensajeEventArgs e)
        {
            ReportarMensaje(e.Mensaje.IdConexion, e.Mensaje);
        }



        private void ConfigurarGrilla()
        {
            grid.Rows.Clear();
            grid.Redim(1, 7);

            grid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            grid.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            grid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;
            grid.Columns[3].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;

            grid.FixedRows = 1;

            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("Consecutivo");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("Hora Transmision");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("Hora Recepcion");
            grid[0, 3] = new SourceGrid.Cells.ColumnHeader("MAC Origen");
            grid[0, 4] = new SourceGrid.Cells.ColumnHeader("MAC Destino");
            grid[0, 5] = new SourceGrid.Cells.ColumnHeader("Datos");

            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid.Columns.AutoSize(true);
        }


        private IView _vista = new CellBackColorAlternate(Color.LightSkyBlue, Color.WhiteSmoke);
        private void LlenarGrilla(List<Mensaje> mensajes)
        {
            int c = 0;
            ConfigurarGrilla();
            foreach (Mensaje mensaje in mensajes)
            {
                grid.Rows.Insert(1);
                grid[1, 0] = new SourceGrid.Cells.Cell(c++.ToString());
                grid[1, 1] = new SourceGrid.Cells.Cell(mensaje.HoraTransmision.ToString() + mensaje.HoraTransmision.Millisecond.ToString());
                grid[1, 2] = new SourceGrid.Cells.Cell(mensaje.HoraRecepcion.ToString() + mensaje.HoraRecepcion.Millisecond.ToString());
                grid[1, 3] = new SourceGrid.Cells.Cell(mensaje.MacOrigen.ToString());
                grid[1, 4] = new SourceGrid.Cells.Cell(mensaje.MacDestino.ToString());
                grid[1, 5] = new SourceGrid.Cells.Cell(mensaje.Datos);

                grid[1, 0].View = _vista;
                grid[1, 1].View = _vista;
                grid[1, 2].View = _vista;
                grid[1, 3].View = _vista;
                grid[1, 4].View = _vista;
                grid[1, 5].View = _vista;

            }
            grid.Columns.AutoSizeView();

        }

        private delegate void SetLabelTextDelegate(Guid idConexion, Mensaje mensaje);
        List<Mensaje> _mensajes = new List<Mensaje>();
        internal void ReportarMensaje(Guid idConexion, Mensaje mensaje)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetLabelTextDelegate(ReportarMensaje),
                                                            new object[] { idConexion, mensaje });

                return;
            }
            _mensajes.Add(mensaje);

            LlenarGrilla(_mensajes);

        }

    }

}
