using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HostPipeService
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string uriString = @"net.pipe://localhost/ashish/";
            //// Attempt to create a Uri instance from the URI string
            //if (Uri.TryCreate(uriString, UriKind.Absolute, out Uri uri))
            //{
            //    // The URI string is valid and has been successfully parsed
            //    Console.WriteLine("The URI string is valid.");
            //}
            //else
            //{
            //    // The URI string is not valid
            //    Console.WriteLine("The URI string is not valid.");
            //}
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
    }
}
