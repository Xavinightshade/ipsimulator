using System;
using System.Collections.Generic;

namespace SimpleRemotingAsm
{
    // This is a type that will be 
    // marshaled by reference (MBR) if accessed remotely.
	public class RemoteServerObject: MarshalByRefObject
	{
        public RemoteServerObject()
        {
            Console.WriteLine("Constructing RemoteMessageObject!");
				Console.WriteLine();
        }



		  Dictionary<Guid, ClientObject> _clientes = new Dictionary<Guid, ClientObject>();

		  public Dictionary<Guid, ClientObject> Clientes
		  {
			  get { return _clientes; }
		  }

		public void ConectarNuevoCliente(ClientObject cliente)
		{
			Console.WriteLine("Nuevo Cliente : "+cliente.NombreCliente+" "+cliente.Id.ToString());
			_clientes.Add(cliente.Id, cliente);
			Console.WriteLine();
		}

		public void ListarClientes()
		{
			foreach (ClientObject cliente  in _clientes.Values)
			{
				Console.WriteLine(cliente.NombreCliente+ "   "+cliente.Id.ToString());
			}
			Console.WriteLine();
		}
		public void MandarMensajeAlCliente(Guid id, string mensaje)
		{
			_clientes[id].MandarMensajeCliente(mensaje);
		}
		public void DesconectarCliente(Guid id)
		{
			Console.WriteLine("Cliente Desconectado: "+ _clientes[id].NombreCliente+ " "+ _clientes[id].Id.ToString());
			Console.WriteLine();
			_clientes.Remove(id);
		}

		// This method returns a value to the
		// caller.
		public int NumeroDeClientes
		{
			get { return _clientes.Count; }
		}
	}

	public class ClientObject:MarshalByRefObject
	{
		private Guid _id;
	public Guid Id
	{
	  get { return _id;}
	}
		private string _nombreClient;
	public string NombreCliente
	{
	  get { return _nombreClient;}
	}


		public ClientObject (string nombreCliente)
	{
			_id=Guid.NewGuid();
			_nombreClient=nombreCliente;
	}
		public void MandarMensajeCliente(string mensaje)
		{
			global::System.Windows.Forms.MessageBox.Show(mensaje,_nombreClient);
		}
	}
}
