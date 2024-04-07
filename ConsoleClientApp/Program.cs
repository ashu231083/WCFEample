using System;
using DataModelClasses;

namespace ConsoleClientApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            OperationMenu();
        }

        private static void OperationMenu()
        {
            // Prompt the user to enter a text
            Console.WriteLine("Testing operation command");
            Console.WriteLine("1. GetMessage");
            Console.WriteLine("2. ReadMessage");
            Console.WriteLine("3. AddMessage");

            Console.WriteLine("Please enter input (1, 2, 3): ");
            // Read the text entered by the user
            string userInput = Console.ReadLine();

            // Pass the user input to a function
            ProcessMessage(userInput);
        }

        private static void ProcessMessage(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    StartLogin(false, "Ashish", false);
                    Console.ReadLine();
                    break;
                case "2":
                    StartLogin(false, "User1", false);
                    Console.ReadLine();
                    break;
                case "3":
                    TestMessage("My Test message");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Thanks...");
                    Console.ReadLine();
                    break;
            }
        }

        private static void StartLogin(bool autoLogin, string authString, bool remindTomorrow)
        {
            try
            {
                DataProviderAsync.Login(autoLogin, authString, null, remindTomorrow, new Action<bool, AuthenticateResponse>(FinishLogin));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                OperationMenu();
            }
            
        }
        private static void FinishLogin(bool arg1, AuthenticateResponse response)
        {
            Console.WriteLine(response.ServiceMessage);
            OperationMenu();
        }

        private static void TestMessage(string message)
        {
            try
            {
                DataProviderAsync.TestMessage(message, new Action<bool, string>(FinishTestMessage));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                OperationMenu();
            }
            
        }

        private static void FinishTestMessage(bool arg1, string arg2)
        {
            Console.WriteLine(arg2);
            OperationMenu();
        }

        
    }
}
