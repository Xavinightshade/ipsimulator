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
		private object _syncObjectEnviados= new object();

		EventWaitHandle wh = new AutoResetEvent(true);

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


		}


		private void ProcesarFramesAEnviar()
		{

			while (true)
			{
				lock (_syncObjectEnviados)
				{
					if (_bufferFramesAEnviar.Count != 0)
					{
						OnFrameTransmitido(_bufferFramesAEnviar.Dequeue());
					}
					else
					{
						wh.WaitOne();
					}
				}
			}
				
			

		}

		private Random r = new Random();
		private void ProcesarFramesRecibidos()
		{

			while (true)
			{
				lock (_syncObjectRecibidos)
				{
					if (_bufferFramesRecibidos.Count != 0)
					{
						OnFrameRecibido(_bufferFramesRecibidos.Dequeue());
					}
					else
					{
						wh.WaitOne();
					}
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
			lock (_syncObjectEnviados)
			{
						_bufferFramesAEnviar.Enqueue(frame);
			}
			wh.Set();
	
		}

		void IEnvioReciboDatos.RecibirFrame(Frame frame)
		{
			lock (_syncObjectRecibidos)
			{
							_bufferFramesRecibidos.Enqueue(frame);
			}
			wh.Set();
			


		}

		#endregion
	}
}
