using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using SimpleRemotingAsm;
using System.Windows.Forms;
using SimpleRemotingAsm;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
 
namespace SimpleRemoteObjectServer
{
	class SimpleObjServer
	{
		static void Main(string[] args)
		{
			BinaryClientFormatterSinkProvider clientProvider = null;
			BinaryServerFormatterSinkProvider serverProvider =
				new BinaryServerFormatterSinkProvider();
			serverProvider.TypeFilterLevel =

			System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

			IDictionary props = new Hashtable();
			props["port"] = 6123;
			props["typeFilterLevel"] = TypeFilterLevel.Full;
			TcpChannel chan = new TcpChannel(
			props, clientProvider, serverProvider);

			ChannelServices.RegisterChannel(chan);

			RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerObject),
								 "ParachuteExample",
								 WellKnownObjectMode.Singleton);

			Console.ReadLine();


		}
	}
}
