using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Collections;
using System.Runtime.Serialization.Formatters;

namespace SimuladorServidor
{
	static class ApplicationEntry
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
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

			RemotingConfiguration.RegisterWellKnownServiceType(typeof(RedesIP.Remoting.RemoteServerObject),
								 "ParachuteExample",
								 WellKnownObjectMode.Singleton);

			Console.ReadLine();
		}
	}
}