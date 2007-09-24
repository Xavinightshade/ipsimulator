using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos;



namespace RedesIP.Remoting
{
	public class RemoteServerObject:MarshalByRefObject
	{
		private IEstacionModelo _estacionModelo;
		public IEstacionModelo EstacionModelo
		{
			get { return _estacionModelo; }
		}	
	
		public RemoteServerObject()
		{
			Console.WriteLine("nuevo objeto remoto");
			_estacionModelo = new EstacionModelo();
		}




	}

}
