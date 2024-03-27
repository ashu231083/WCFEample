using HelloService;
using System;
using System.ServiceModel;

namespace ClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Define the URI of the service
            Uri serviceUri = new Uri("net.pipe://localhost/ashish/HelloService");

            // Create a ChannelFactory to create a channel to the service
            ChannelFactory<IHelloService> channelFactory = new ChannelFactory<IHelloService>(
                new NetNamedPipeBinding(), 
                new EndpointAddress(serviceUri)
                );

            // Create a channel to the service
            IHelloService channel = channelFactory.CreateChannel();

            try
            {
                // Call a method on the service
                string result = channel.GetMessage("World");
                Console.WriteLine("Result from service: " + result);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
            }

        // Close the channel and the channel factory
        ((ICommunicationObject)channel).Close();
            channelFactory.Close();

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

    }
}
