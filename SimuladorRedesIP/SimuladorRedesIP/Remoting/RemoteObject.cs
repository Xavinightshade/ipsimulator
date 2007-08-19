using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos;
using RedesIP.Presenters;
using System.Collections.ObjectModel;

namespace RedesIP.Remoting
{
	public class RemoteServerObject:MarshalByRefObject
	{
		private EstacionModelo _listaDispositivos;
		public EstacionModelo ListaDispositivos
		{
			get { return _listaDispositivos; }
		}
	
	
		public RemoteServerObject()
		{
			Console.WriteLine("nuevo objeto remoto");
			_listaDispositivos = new EstacionModelo();
		}




	}

}
