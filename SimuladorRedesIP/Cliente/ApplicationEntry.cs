using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.ServiceModel;
using RedesIP;
using RedesIP.SOA;

namespace SimuladorServidor
{
	static class ApplicationEntry
	{

			        public static void Main2()
        {


            IContract singletonCalculator =
new EstacionSOA();

            ServiceHost calculatorHost =
                new ServiceHost(singletonCalculator);

            NetTcpBinding binding =
                new NetTcpBinding(SecurityMode.None, true);
            Uri address =
                new Uri(@"net.tcp://192.168.0.101:8000/Simulador");

            calculatorHost.AddServiceEndpoint(
                typeof(IContract), binding, address);

            calculatorHost.Open();
            Console.WriteLine(calculatorHost.State);
            Console.WriteLine
                ("CalculatorService started, press any ENTER to close...");

            Console.ReadLine();
            calculatorHost.Close();


        }
		
	}
}