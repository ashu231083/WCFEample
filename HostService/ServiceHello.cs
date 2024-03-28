using HelloService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HostService
{
    public partial class ServiceHello : ServiceBase
    {
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
                ServiceHost serviceHost = new ServiceHost(typeof(HelloService.HelloService));
                Console.WriteLine("Welcome to Hello Service  Loading....");
                serviceHost.Open();
                Console.WriteLine("Hello Service is Started...");
                Console.ReadKey();
            }
            catch (UriFormatException ex)
            {
                Console.WriteLine("Error creating URI: " + ex.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.ToString());
                Console.ReadKey();

            }
        }

        protected override void OnStop()
        {
        }



        internal void DebugStart()
        {
            StartWcfHelloService();
        }
    }
}
