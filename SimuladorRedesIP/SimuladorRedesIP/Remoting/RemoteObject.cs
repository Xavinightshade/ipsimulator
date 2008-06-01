using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos;



namespace RedesIP.Remoting
{
	public class RemoteServerObject:MarshalByRefObject
	{
		private IEstacion _estacionModelo;
		public IEstacion EstacionModelo
		{
			get { return _estacionModelo; }
		}	
	
		public RemoteServerObject()
		{
			Console.WriteLine("nuevo objeto remoto");
			_estacionModelo = new Estacion();
		}




	}

}
