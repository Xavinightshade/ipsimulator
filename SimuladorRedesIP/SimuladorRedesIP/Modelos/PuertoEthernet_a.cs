using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RedesIP.Modelos.Datos;
using System.Collections.ObjectModel;

namespace RedesIP.Modelos
{

	public class PuertoEthernet:IEnvioReciboDatos
	{

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
		public PuertoEthernet(MACAddress MACAddress)
		{
            
			_MACAddress = MACAddress;
         

		}


        private void ProcesarFramesAEnviar()
        {

            while (_bufferFramesAEnviar.Count != 0)
              

                {
                 Thread.Sleep(r.Next(100));

                    OnFrameTransmitido(_bufferFramesAEnviar.Dequeue());
                    Console.WriteLine("Buffer a enviar== " + _bufferFramesAEnviar.Count.ToString());
                
                    
                }
            _hiloDeProcesamientoDeFramesAEnviar = null;
    
        }

	    private Random r=new Random();
        private void ProcesarFramesRecibidos()
        {

 
               while (_bufferFramesRecibidos.Count != 0)
                {
                    Thread.Sleep(r.Next(120));

                    OnFrameRecibido(_bufferFramesRecibidos.Dequeue());
                    Console.WriteLine("Buffer recubidos==  " + _bufferFramesRecibidos.Count.ToString());
                }

            _hiloDeProcesamientoDeFramesRecibidos = null;
   
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
            _bufferFramesAEnviar.Enqueue(frame);
            if (_hiloDeProcesamientoDeFramesAEnviar == null)
            {
                _hiloDeProcesamientoDeFramesAEnviar = new Thread(ProcesarFramesAEnviar);
                _hiloDeProcesamientoDeFramesAEnviar.Start();
            }
        }

        void IEnvioReciboDatos.RecibirFrame(Frame frame)
        {

            _bufferFramesRecibidos.Enqueue(frame);
            if (_hiloDeProcesamientoDeFramesRecibidos == null)
            {
                _hiloDeProcesamientoDeFramesRecibidos = new Thread(ProcesarFramesRecibidos);
                _hiloDeProcesamientoDeFramesRecibidos.Start();
            }
        }

        #endregion
    }
}
