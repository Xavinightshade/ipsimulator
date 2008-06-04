using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RedesIP.ModelosLogicos;
using RedesIP.Vistas;
using RedesIP.Presenters;
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using RedesIP.ModelosLogicos.Equipos;
using RedesIP.ModelosLogicos.Datos;
using RedesIP.ModelosVisualizacion;

namespace SimuladorCliente
{
	public partial class MainFrame : Form
	{
		public MainFrame()
		{
			InitializeComponent();
		}
        private delegate void ImprimirReporte(FrameRecibidoEventArgs e);
	    private ComputadorLogico pc;
	    private ComputadorLogico pc2;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

		_estacionModelo = new Estacion();
 



		new EstacionPresenter(_estacionModelo, estacionVista1);


		     pc = new ComputadorLogico("pc1", MACAddress.Direccion(1, 2, 3));
		    pc2 = new ComputadorLogico("pc2", MACAddress.Direccion(4, 5, 6));
		//    CableDeRed cab=new CableDeRed(pc,pc2);
            pc2.PuertoEthernet.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(PuertoEthernet_FrameRecibido);
		    SwitchLogico swi = new SwitchLogico(30);
            SwitchLogico swi2 = new SwitchLogico(30);

            CableDeRedLogico cab2 = new CableDeRedLogico(pc.PuertoEthernet, swi.PuertosEthernet[0]);
            CableDeRedLogico cab3 = new CableDeRedLogico(swi.PuertosEthernet[1], swi2.PuertosEthernet[0]);
            CableDeRedLogico cab4 = new CableDeRedLogico(pc2.PuertoEthernet, swi2.PuertosEthernet[1]);





		}

        void PuertoEthernet_FrameRecibido(object sender, FrameRecibidoEventArgs e)
        {
            if (this.InvokeRequired)
            {

                ImprimirReporte agregarControl = new ImprimirReporte(Imprimir);
                this.BeginInvoke(agregarControl, e);
            }
            else
            {
                Imprimir(e);
            }


           
        }
       private void Imprimir(FrameRecibidoEventArgs e)
	{
//	    textBox1.Text += "yo : "  + "@@@ recibi frame: " +e.FrameRecibido.Informacion + " a lassss " +
  //                           DateTime.Now.ToString() + Environment.NewLine;
           textBox2.Text = pc.PuertoEthernet.Aenviar.ToString();
           textBox3.Text = pc2.PuertoEthernet.Recibidos.ToString();
           progressBar1.Value = pc.PuertoEthernet.Aenviar;
           progressBar2.Value = pc2.PuertoEthernet.Recibidos;
          
	}

		private void button1_Click(object sender, EventArgs e)
		
		{
			int numeroDispo = 20;
			int deltax=1000/numeroDispo;
			int deltay = 1000 / numeroDispo;
			int posX = 0;
			int posY = 0;
			for (int i = 0; i < numeroDispo; i++)
			{
				posX += deltax;
				posY += deltay;
				_estacionModelo.CrearDispositivo(posX, 80);
			}
			int length = 0;
			for (int i = 0; i < numeroDispo; i++)
			{
				length += 1;
				for (int j = length; j < numeroDispo; j++)
				{
					_estacionModelo.Conectar(i, j);
				}


			}

		}
		IEstacion _estacionModelo;
	    private int enviados;
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                enviados++;
               // pc.EnviarMensajeDeTexto(DateTime.Now.ToString(), MACAddress.Direccion(4, 5, 6));
					 pc.Ping(MACAddress.Direccion(4, 5, 6));
                progressBar1.Maximum = enviados;
                progressBar2.Maximum = enviados;
   
            }
           // MessageBox.Show("Test");
            
        }

















	}
}