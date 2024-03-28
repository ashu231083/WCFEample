using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HostService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            //If the mode is in debugging
            //create a new service instance
            ServiceHello myService = new ServiceHello();
            //call the start method - this will start the Timer.
            myService.DebugStart();
            //Set the Thread to sleep
            //Thread.Sleep(60000);
            //Call the Stop method-this will stop the Timer.
            //myService.Stop();
#else
            //The following is the default code - You may fine tune
            //the code to create one instance of the service on the top
            //and use the instance variable in both debug and release mode
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServiceHello()
            };
            ServiceBase.Run(ServicesToRun);
#endif

        }
    }
}
