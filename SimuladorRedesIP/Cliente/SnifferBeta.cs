using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimuladorCliente.Vistas;
using WeifenLuo.WinFormsUI.Docking;

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
            ReportarMensaje(e.IdConexion, e.Mensaje);
        }

        void marcador_NuevoMarcador(object sender, NuevoMarcadorEventArgs e)
        {
            AgregarMarcador(e.Marcador);
        }

private void ConfigurarGrilla()
{

            grid.Redim(1, 4);

            grid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            grid.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            grid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;
            grid.Columns[3].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;

            grid.FixedRows = 1;

            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("Fecha");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("MAC Origen");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("MAC Destino");
            grid[0, 3] = new SourceGrid.Cells.ColumnHeader("Datos");

            grid.AutoStretchColumnsToFitWidth = true;
            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid.Columns.AutoSize(true);
            grid.Columns.StretchToFit();
}

		void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
		{
            Marcador marcador = (Marcador)_markerCmbBox.SelectedItem;
            Guid idConexion = marcador.Conexion.Id;
			List<string> mensajes=_mensajes[idConexion];
            LlenarGrilla(mensajes);
			// todo llenar grilla
			
		}

private void LlenarGrilla(List<string> mensajes)
{

 //   grid.Rows.Clear();
 	foreach (string mensaje in mensajes)
	{
        grid.Rows.Insert(1);
             grid[1, 0] = new SourceGrid.Cells.Cell(DateTime.Now);
            grid[1, 1] = new SourceGrid.Cells.Cell("Mac origen");
         grid[1, 2] = new SourceGrid.Cells.Cell("Mac destino");
            grid[1, 3] = new SourceGrid.Cells.Cell(mensaje);
	}
}
		private Dictionary<Guid, List<string>> _mensajes = new Dictionary<Guid, List<string>>();
		private List<Marcador> _marcadores = new List<Marcador>();
		public void AgregarMarcador(Marcador marcador)
		{
			_marcadores.Add(marcador);
			_mensajes.Add(marcador.Conexion.Id, new List<string>());
            _markerCmbBox.Items.Add(marcador);
		}
		private delegate void SetLabelTextDelegate(Guid idConexion, string mensaje);

		internal void ReportarMensaje(Guid idConexion, string mensaje)
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
               
				List<string> mensajes = _mensajes[idConexion];
				
				LlenarGrilla(mensajes);
			}
		}

	}
    
}
