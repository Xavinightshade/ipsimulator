using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using SimpleRemotingAsm;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace SimpleRemoteObjectClient
{
	class SimpleObjClient
	{
		static void Main(string[] args)
		{
			BinaryClientFormatterSinkProvider clientProvider =
				new BinaryClientFormatterSinkProvider();
			BinaryServerFormatterSinkProvider serverProvider =
				new BinaryServerFormatterSinkProvider();
			serverProvider.TypeFilterLevel =

			System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

			IDictionary props = new Hashtable();
			props["port"] = 0;
			string s = System.Guid.NewGuid().ToString();
			props["name"] = s;
			props["typeFilterLevel"] = TypeFilterLevel.Full;
			TcpChannel chan = new TcpChannel(
			props, clientProvider, serverProvider);

			ChannelServices.RegisterChannel(chan);


			Type typeofRI = typeof(RemoteServerObject);
			RemoteServerObject servidor = (RemoteServerObject)Activator.GetObject(typeofRI,
								 "tcp://192.168.16.63:6123/ParachuteExample");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1(servidor));



		}
	}
}
