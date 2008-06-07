using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RedesIP.Modelos.Datos;
using System.Collections.ObjectModel;

namespace RedesIP.Modelos.Equipos.Componentes
{

	public class PuertoEthernetLogico : IEnvioReciboDatos
	{
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

		private MACAddress _MACAddress;

		public MACAddress MACAddress
		{
			get { return _MACAddress; }
		}
		public event EventHandler<FrameTransmitidoEventArgs> FrameTransmitido;
		public event EventHandler<FrameRecibidoEventArgs> FrameRecibido;
		public PuertoEthernetLogico(MACAddress MACAddress)
		{

			_MACAddress = MACAddress;
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
				//	Thread.Sleep(r.Next(1000));
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
					if (_MACAddress.EsIgual(MACAddress.Direccion(4, 5, 6)))
					{

					}
				//	Thread.Sleep(r.Next(1000));
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
				FrameTransmitido(this, new FrameTransmitidoEventArgs(frame));
		}
		private void OnFrameRecibido(Frame frame)
		{
			if (FrameRecibido != null)
				FrameRecibido(this, new FrameRecibidoEventArgs(frame));
		}


		#region IEnvioReciboDatos Members

		void IEnvioReciboDatos.TransmitirFrame(Frame frame)
		{
			if (_MACAddress.EsIgual(MACAddress.Direccion(1, 2, 3)))
			{

			}
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
