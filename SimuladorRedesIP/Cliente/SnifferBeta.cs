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

namespace SimuladorCliente
{
    public partial class SnifferBeta : DockContent
    {
        public SnifferBeta(IMarker marcador)
        {
            InitializeComponent();
            ConfigurarGrilla();
            
			_markerCmbBox.SelectedIndexChanged += new EventHandler(comboBoxEx1_SelectedIndexChanged);
            marcador.NuevoMarcador += new EventHandler<NuevoMarcadorEventArgs>(marcador_NuevoMarcador);
            marcador.NuevoMensaje += new EventHandler<NuevoMensajeEventArgs>(marcador_NuevoMensaje);
		}

        void marcador_NuevoMensaje(object sender, NuevoMensajeEventArgs e)
        {
            ReportarMensaje(e.Mensaje.IdConexion,e.Mensaje);
        }

        void marcador_NuevoMarcador(object sender, NuevoMarcadorEventArgs e)
        {
            AgregarMarcador(e.Marcador);
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
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("Puerto MAC");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("Hora Transmision");
            grid[0, 3] = new SourceGrid.Cells.ColumnHeader("Hora Recepcion");
            grid[0, 4] = new SourceGrid.Cells.ColumnHeader("MAC Origen");
            grid[0, 5] = new SourceGrid.Cells.ColumnHeader("MAC Destino");
            grid[0, 6] = new SourceGrid.Cells.ColumnHeader("Datos");

            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid.Columns.AutoSize(true);
}

		void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
		{
            Marcador marcador = (Marcador)_markerCmbBox.SelectedItem;
            Guid idConexion = marcador.Conexion.Id;
			List<Mensaje> mensajes=_mensajes[idConexion];
            LlenarGrilla(mensajes);
			// todo llenar grilla
			
		}
        private IView _vista = new CellBackColorAlternate(Color.White, Color.WhiteSmoke);
private void LlenarGrilla(List<Mensaje> mensajes)
{
    int c = 0;
    ConfigurarGrilla();
 	foreach (Mensaje mensaje in mensajes)
	{
        grid.Rows.Insert(1);
        grid[1, 0] = new SourceGrid.Cells.Cell(c++.ToString());
        grid[1, 1] = new SourceGrid.Cells.Cell(mensaje.MacPuerto.ToString());
            grid[1, 2] = new SourceGrid.Cells.Cell(mensaje.HoraTransmision.ToLongTimeString());
            grid[1, 3] = new SourceGrid.Cells.Cell(mensaje.HoraRecepcion.ToLongTimeString());
         grid[1, 4] = new SourceGrid.Cells.Cell(mensaje.MacOrigen.ToString());
         grid[1, 5] = new SourceGrid.Cells.Cell(mensaje.MacDestino.ToString());
            grid[1, 6] = new SourceGrid.Cells.Cell(mensaje.Datos);

            grid[1, 0].View = _vista;
            grid[1, 1].View = _vista;
            grid[1, 2].View = _vista;
            grid[1, 3].View = _vista;
            grid[1, 4].View = _vista;
            grid[1, 5].View = _vista;
            grid[1, 6].View = _vista;

	}
    grid.Columns.AutoSizeView();

}
		private Dictionary<Guid, List<Mensaje>> _mensajes = new Dictionary<Guid, List<Mensaje>>();
		private List<Marcador> _marcadores = new List<Marcador>();
		public void AgregarMarcador(Marcador marcador)
		{
			_marcadores.Add(marcador);
			_mensajes.Add(marcador.Conexion.Id, new List<Mensaje>());
            _markerCmbBox.Items.Add(marcador);
		}
		private delegate void SetLabelTextDelegate(Guid idConexion, Mensaje mensaje);

		internal void ReportarMensaje(Guid idConexion, Mensaje mensaje)
		{
			
			if (this.InvokeRequired)
			{
				// Pass the same function to BeginInvoke,
				// but the call would come on the correct
				// thread and InvokeRequired will be false.
				this.BeginInvoke(new SetLabelTextDelegate(ReportarMensaje),
															new object[] {idConexion,mensaje });

				return;
			}
			_mensajes[idConexion].Add(mensaje);
            Marcador item = (Marcador)_markerCmbBox.SelectedItem;
			if (item == null)
				return;
			if (item.Conexion.Id == idConexion)
			{
               
				List<Mensaje> mensajes = _mensajes[idConexion];
				
				LlenarGrilla(mensajes);
			}
		}

	}
    
}
