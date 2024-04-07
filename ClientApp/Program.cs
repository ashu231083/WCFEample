using HelloService;
using System;
using System.ServiceModel;

namespace ClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteMessage();
        }

        private static void WriteMessage()
        {
            // Prompt the user to enter a text
            Console.WriteLine("Enter a Message:");

            // Read the text entered by the user
            string userInput = Console.ReadLine();

            // Pass the user input to a function
            ProcessMessage(userInput);
        }

        private static void ProcessMessage(string userInput)
        {
            // Define the URI of the service
            Uri serviceUri = new Uri("net.pipe://localhost/ashish/");

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
                string result = channel.TestMessage(userInput);
                Console.WriteLine("Result from service: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
            }

            // Close the channel and the channel factory
            ((ICommunicationObject)channel).Close();
            channelFactory.Close();

            IsContinueProcess();
        }

        private static void IsContinueProcess()
        {
            Console.WriteLine("Please enter 'y' or 'n' : ");
            string userInput = Console.ReadLine();
            // Check if the input is valid
            if (userInput.ToLower() == "y")
            {             
                Console.WriteLine("You entered 'Yes'.");
                WriteMessage();
            }
            else if (userInput.ToLower() == "n")
            {
                Console.WriteLine("You entered 'No'.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid input...");
                IsContinueProcess();
            }
        }
    }
}
