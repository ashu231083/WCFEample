using HelloService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HostService
{
    public partial class ServiceHello : ServiceBase
    {
        private ServiceHost serviceHost;
        public ServiceHello()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartWcfHelloService();            
        }

        private void StartWcfHelloService()
        {
            try
            {
                //Uri baseAddress = new Uri(uriString);
                serviceHost = new ServiceHost(typeof(HelloService.HelloService));
                Console.WriteLine("Welcome to Hello Service  Loading....");
                Console.WriteLine(serviceHost.Description.ConfigurationName);
                Console.WriteLine("\tName: " + serviceHost.Description.Name);
                Console.WriteLine("\tNamespace: " + serviceHost.Description.Namespace);
                Console.WriteLine("\tEndpoints:");
                foreach (ServiceEndpoint serviceEndpoint in serviceHost.Description.Endpoints)
                {
                    string str = "\t\t";
                    EndpointAddress address = serviceEndpoint.Address;
                    Console.WriteLine(str + (address?.ToString()));
                }
                serviceHost.Open();
                Console.WriteLine("Hello Service is Started...");
                Console.ReadKey();
            }
            catch (UriFormatException ex)
            {
                Console.WriteLine("Error creating URI: " + ex.Message);
                //Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.ToString());
                //Console.ReadKey();

            }
        }

        protected override void OnStop()
        {
            // Close the WCF service host when the service is stopped
            serviceHost?.Close();
        }



        internal void DebugStart()
        {
            StartWcfHelloService();
        }
    }
}
