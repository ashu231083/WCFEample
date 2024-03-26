using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class GreetingService : IGreetingService
    {
        public string GetGreeting(string name)
        {
            return $"Hello, {name}! Welcome to the WCF named pipe example.";
        }
    }
}
