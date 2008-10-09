using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RedesIP.Modelos.Datos;
using System.Collections.ObjectModel;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Common;
using RedesIP.SOA;
using BusinessLogic.Threads;

namespace RedesIP.Modelos.Equipos.Componentes
{

	public class PuertoEthernetLogicoBase : IEnvioReciboDatos
	{
        public static PuertoBaseSOA ConvertirPuerto(PuertoEthernetLogicoBase puertoLogico)
        {
            PuertoBaseSOA puertoSOA = new PuertoBaseSOA(puertoLogico.Id, puertoLogico.Nombre,puertoLogico.Habilitado);
            return puertoSOA;
        }

		private Guid _id;


		public Guid Id
		{
			get { return _id; }
		}

        private bool _habilitado;

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }
		private object _syncObjectRecibidos = new object();
		private object _syncObjectEnviados = new object();

		EventWaitHandle whTrans = new AutoResetEvent(false);
		EventWaitHandle whREc = new AutoResetEvent(false);

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
		public PuertoEthernetLogicoBase(Guid id,string nombre,bool habilitado)
		{
            _habilitado = habilitado;
            _nombre = nombre;
            _id = id;
			_hiloDeProcesamientoDeFramesAEnviar = new Thread(ProcesarFramesAEnviar);
            _hiloDeProcesamientoDeFramesAEnviar.IsBackground = true;
			_hiloDeProcesamientoDeFramesRecibidos = new Thread(ProcesarFramesRecibidos);
            _hiloDeProcesamientoDeFramesRecibidos.IsBackground = true;
			_hiloDeProcesamientoDeFramesAEnviar.Start();

			_hiloDeProcesamientoDeFramesRecibidos.Start();


		}

        private static Random _r = new Random();

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
                    ThreadManager.Sleep(_r.Next(100));
					OnFrameTransmitido(_bufferFramesAEnviar.Dequeue());
				}
				else
				{
					whTrans.WaitOne();
				}

			}



		}

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
                    ThreadManager.Sleep(_r.Next(100));
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
                FrameTransmitido(this, new FrameTransmitidoEventArgs(frame, BusinessLogic.Threads.ThreadManager.HoraActual));
		}
		private void OnFrameRecibido(Frame frame)
		{
			if (FrameRecibido != null)
                FrameRecibido(this, new FrameRecibidoEventArgs(frame, BusinessLogic.Threads.ThreadManager.HoraActual));
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
