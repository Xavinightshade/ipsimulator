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
    public partial class FormaSnifferPC : FormaSnifferBase
    {
        public FormaSnifferPC(MarcadorPC marcador)
            :base(marcador)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
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
        private void ConfigurarGrillaSegmentos()
        {
            Grid.Rows.Clear();
            Grid.Redim(1, 12);


            Grid.FixedRows = 1;

            Grid[0, 0] = new SourceGrid.Cells.ColumnHeader("CONSECUTIVO");
            Grid[0, 1] = new SourceGrid.Cells.ColumnHeader("HORA RECEPCION");
            Grid[0, 2] = new SourceGrid.Cells.ColumnHeader("ENVIADO");
            Grid[0, 3] = new SourceGrid.Cells.ColumnHeader("RECIBIDO");
            Grid[0, 4] = new SourceGrid.Cells.ColumnHeader("IP ORIGEN");
            Grid[0, 5] = new SourceGrid.Cells.ColumnHeader("IP DESTINO");
            Grid[0, 6] = new SourceGrid.Cells.ColumnHeader("PUERTO ORIGEN");
            Grid[0, 7] = new SourceGrid.Cells.ColumnHeader("PUERTO DESTINO");
            Grid[0, 8] = new SourceGrid.Cells.ColumnHeader("SEQ NUMBER");
            Grid[0, 9] = new SourceGrid.Cells.ColumnHeader("ACK NUMBER");
            Grid[0, 10] = new SourceGrid.Cells.ColumnHeader("SYN FLAG");
            Grid[0, 11] = new SourceGrid.Cells.ColumnHeader("ACK FLAG");


            Grid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            Grid.Columns.AutoSize(true);
        }


        private void LlenarGrillaEncapsulacion(List<EncapsulacionSOA> mensajes)
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
        private void LlenarGrillaSegmentos(List<TCPSegmentSOA> mensajesSegmentos)
        {
            

            int c = 0;
            ConfigurarGrillaSegmentos();
            foreach (TCPSegmentSOA mensaje in mensajesSegmentos)
            {
                Grid.Rows.Insert(1);
                Grid.Rows[1].Tag = mensaje;
                Grid[1, 0] = new SourceGrid.Cells.Cell(c++.ToString());
                Grid[1, 1] = new SourceGrid.Cells.Cell(mensaje.Fecha.ToString());
                if (mensaje.EsEnviado)
                {
                    Grid[1, 2] = new SourceGrid.Cells.Cell("1");
                    Grid[1, 3] = new SourceGrid.Cells.Cell("0");
                }
                else
                {
                    Grid[1, 2] = new SourceGrid.Cells.Cell("0");
                    Grid[1, 3] = new SourceGrid.Cells.Cell("1");
                }
                Grid[1, 4] = new SourceGrid.Cells.Cell(mensaje.Paquete.IpOrigen);
                Grid[1, 5] = new SourceGrid.Cells.Cell(mensaje.Paquete.IpDestino);
                Grid[1, 6] = new SourceGrid.Cells.Cell(mensaje.SourcePort.ToString());
                Grid[1, 7] = new SourceGrid.Cells.Cell(mensaje.DestinationPort.ToString());
                Grid[1, 8] = new SourceGrid.Cells.Cell(mensaje.SEQ_Number.ToString());
                Grid[1, 9] = new SourceGrid.Cells.Cell(mensaje.ACK_Number.ToString());
                Grid[1, 10] = new SourceGrid.Cells.Cell(ConvertirValor(mensaje.SYN_Flag));
                Grid[1, 11] = new SourceGrid.Cells.Cell(ConvertirValor(mensaje.ACK_Flag));
                for (int i = 0; i < 11; i++)
                {
                    Grid[1, i].View = Vista;
                }
            }
            Grid.Columns.AutoSizeView();
        }
        private int ConvertirValor(bool valor)
        {
            if (valor)
                return 1;
            return 0;
        }

        private System.Windows.Forms.ComboBox comboBox1;
        private Label label1;

        private delegate void SetLabelTextDelegate(EncapsulacionSOA mensajeEncapsulacion);
        private delegate void SetSegmentDelegate(TCPSegmentSOA segmento);

        List<EncapsulacionSOA> _mensajesEncapsulacion = new List<EncapsulacionSOA>();
        List<TCPSegmentSOA> _mensajesSegmentos = new List<TCPSegmentSOA>();

        public void ReportarMensajeEncapsulacion(EncapsulacionSOA mensaje)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetLabelTextDelegate(ReportarMensajeEncapsulacion),
                                                            new object[] { mensaje});

                return;
            }
            _mensajesEncapsulacion.Add(mensaje);
            SeleccionSniffer();

        }

        public void ReportarSegmentoEnviado(TCPSegmentSOA segment)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetSegmentDelegate(ReportarSegmentoEnviado),
                                                            new object[] { segment });

                return;
            }
            _mensajesSegmentos.Add(segment);

            SeleccionSniffer();
            
        }



        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.SetChildIndex(this.comboBox1, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "TCP",
            "UDP",
            "Encapsulación"});
            this.comboBox1.Location = new System.Drawing.Point(263, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tipo de Punta :";
            // 
            // FormaSnifferPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(682, 334);
            this.Name = "FormaSnifferPC";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleccionSniffer();
        }

        private void SeleccionSniffer()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                LlenarGrillaSegmentos(_mensajesSegmentos);
                return;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                LlenarGrillaEncapsulacion(_mensajesEncapsulacion);
                return;
            }
        }



    }

}
