using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos;
using RedesIers;
using System.Collections.ObjectModel;
using RedesIP.Vistas;

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
