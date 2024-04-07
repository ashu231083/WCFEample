using DataModelClasses;
using HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class HelloService : IHelloService
    {

        public byte[] AddMessage(byte[] request)
        {
            AuthenticateResponse authenticateResponse = new AuthenticateResponse();
            AuthenticateRequest authenticateRequest = ContractSerialization.DeserializeObject<AuthenticateRequest>(request);

            Console.WriteLine("1Requset = " + authenticateRequest.AuthString + "__" + authenticateRequest.NewAuthString);

            authenticateResponse.ServiceMessage = "Add Message Successfully" + authenticateRequest.AuthString + "__" + authenticateRequest.NewAuthString;
            authenticateResponse.IsSuccess = true;
            authenticateResponse.User.FirstName = "Ashish";
            authenticateResponse.User.LastName = "Panchal";
            authenticateResponse.User.Id = 1000;
            return ContractSerialization.SerializeObject(authenticateResponse);
        }

        public byte[] GetMessage(byte[] request)
        {
            AuthenticateRequest authenticateRequest = ContractSerialization.DeserializeObject<AuthenticateRequest>(request);

            Console.WriteLine("2Requset = " + authenticateRequest.AuthString + "__" + authenticateRequest.NewAuthString);

            UserData userData = new UserData
            {
                FirstName = "ashish",
                Id = 1000,
                LastName = "panchal"
            };

            AuthenticateResponse authenticateResponse = new AuthenticateResponse
            {
                ServiceMessage = "Add Message Successfully" + authenticateRequest.AuthString + "__" + authenticateRequest.NewAuthString,
                IsSuccess = true,
                User = userData
            };
            return ContractSerialization.SerializeObject(authenticateResponse);
        }

        public byte[] ReadMessage(byte[] request)
        {
            
            AuthenticateRequest authenticateRequest = ContractSerialization.DeserializeObject<AuthenticateRequest>(request);

            Console.WriteLine("3Requset = " + authenticateRequest.AuthString + "__" + authenticateRequest.NewAuthString);

            UserData userData = new UserData
            {
                FirstName = "ashish",
                Id = 1000,
                LastName = "panchal"
            };

            AuthenticateResponse authenticateResponse = new AuthenticateResponse
            {
                ServiceMessage = "Add Message Successfully" + authenticateRequest.AuthString + "__" + authenticateRequest.NewAuthString,
                IsSuccess = true,
                User = userData
            };
            return ContractSerialization.SerializeObject(authenticateResponse);
        }

        public string TestMessage(string request)
        {
            Console.WriteLine("Request is = " + request);
            return "Response Service - " + request;
        }
    }
}
