using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RedesIP.Modelos.Datos;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Common;
using RedesIP.SOA;

namespace RedesIP.Modelos.Equipos.Componentes
{

	public class PuertoEthernetLogicoBase : IEnvioReciboDatos
	{
        public static PuertoBaseSOA ConvertirPuerto(PuertoEthernetLogicoBase puertoLogico)
        {
            PuertoBaseSOA puertoSOA = new PuertoBaseSOA(puertoLogico.Id, puertoLogico.Nombre);
            return puertoSOA;
        }
		private static int CalcularVelocidad(float porcentaje)
		{
			float m = (7000 - 10) / 100;
			return (int)(m * (100 - porcentaje) + 10);
		}
		private Guid _id;


		public Guid Id
		{
			get { return _id; }
		}
		private object _syncObjectRecibidos = new object();
		private object _syncObjectEnviados = new object();

		EventWaitHandle whTrans = new AutoResetEvent(false);
		EventWaitHandle whREc = new AutoResetEvent(false);

		public int Aenviar { get { return _bufferFramesAEnviar.Count; } }
		public int Recibidos { get { return _bufferFramesRecibidos.Count; } }
		private readonly Queue<Frame> _bufferFramesAEnviar = new Queue<Frame>();
		Thread _hiloDeProcesamientoDeFramesRecibidos;
		private readonly Queue<Frame> _bufferFramesRecibidos = new Queue<Frame>();
		private Thread _hiloDeProcesamientoDeFramesAEnviar;


		public event EventHandler<FrameTransmitidoEventArgs> FrameTransmitido;
		public event EventHandler<FrameRecibidoEventArgs> FrameRecibido;
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
		public PuertoEthernetLogicoBase(Guid id,string nombre)
		{
            _nombre = nombre;
            _id = id;
			_hiloDeProcesamientoDeFramesAEnviar = new Thread(ProcesarFramesAEnviar);
			_hiloDeProcesamientoDeFramesRecibidos = new Thread(ProcesarFramesRecibidos);
			_hiloDeProcesamientoDeFramesAEnviar.Start();

			_hiloDeProcesamientoDeFramesRecibidos.Start();


		}


		private void ProcesarFramesAEnviar()
		{


			while (true)
			{
				bool colaNoVacia = true;
				lock (_syncObjectEnviados)
				{
					colaNoVacia = _bufferFramesAEnviar.Count != 0;
				}
				if (colaNoVacia)
				{
						Thread.Sleep(r.Next(CalcularVelocidad(EstacionModelo.PorcentajeDeVelocidadSimulacion)));
					OnFrameTransmitido(_bufferFramesAEnviar.Dequeue());
				}
				else
				{
					whTrans.WaitOne();
				}

			}



		}

		private Random r = new Random();
		private void ProcesarFramesRecibidos()
		{

			while (true)
			{
				bool colaNoVacia = true;
				lock (_syncObjectRecibidos)
				{
					colaNoVacia = _bufferFramesRecibidos.Count != 0;
				}
				if (colaNoVacia)
				{
                    Thread.Sleep(r.Next(CalcularVelocidad(EstacionModelo.PorcentajeDeVelocidadSimulacion)));
					OnFrameRecibido(_bufferFramesRecibidos.Dequeue());
				}
				else
				{
					whREc.WaitOne();
				}

			}



		}


		private void OnFrameTransmitido(Frame frame)
		{
			if (FrameTransmitido != null)
				FrameTransmitido(this, new FrameTransmitidoEventArgs(frame,DateTime.Now));
		}
		private void OnFrameRecibido(Frame frame)
		{
			if (FrameRecibido != null)
                FrameRecibido(this, new FrameRecibidoEventArgs(frame,DateTime.Now));
		}


		#region IEnvioReciboDatos Members

		void IEnvioReciboDatos.TransmitirFrame(Frame frame)
		{

			lock (_syncObjectEnviados)
			{
				_bufferFramesAEnviar.Enqueue(frame);
			}
			whTrans.Set();

		}

		void IEnvioReciboDatos.RecibirFrame(Frame frame)
		{
			lock (_syncObjectRecibidos)
			{
				_bufferFramesRecibidos.Enqueue(frame);
			}
			whREc.Set();



		}

		#endregion


    }
}
