using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.ServiceModel;
using RedesIP;

namespace SimuladorServidor
{
	static class ApplicationEntry
	{

			        public static void Main(string[] args)
        {
            Console.WriteLine("Initializing Service...");

            // The service configuration is loaded from app.config
            using (ServiceHost host = new ServiceHost(typeof(Estacion)))
            {
                host.Open();
                
                Console.WriteLine("Service is ready for requests.  Press any key to close service.");
                Console.WriteLine();
                Console.Read();

                Console.WriteLine("Closing service...");
            }
        }
		
	}
}