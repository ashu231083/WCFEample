using ClientDataAccess;
using DataModelClasses;
using System;
using System.Threading;

namespace ConsoleClientApp
{
    public static class DataProviderAsync
    {
        public static ServiceAccess DataAccess { get; private set; }
        static DataProviderAsync()
        {
            DataAccess = new ServiceAccess();
        }


        public static void Login(bool autoLogin, string authString, string newAuthString, bool remindTomorrow, Action<bool, AuthenticateResponse> postAction)
        {
            ThreadPool.QueueUserWorkItem(delegate (object stat)
            {
                AuthenticateResponse authenticateResponse;
                try
                {
                    authenticateResponse = DataProviderAsync.DataAccess.AuthenticateUser(autoLogin, authString, newAuthString, remindTomorrow, "1.0.0");
                    if (authenticateResponse.User != null)
                    {
                        Console.WriteLine(authenticateResponse.User);
                        Console.WriteLine(authenticateResponse.ServiceMessage);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    authenticateResponse = new AuthenticateResponse();
                }
                postAction(autoLogin, authenticateResponse);
            });
        }

        public static void TestMessage(string message, Action<bool, string> postAction)
        {
            string response;
            try
            {
                response = DataProviderAsync.DataAccess.TestMessage(message);
                
            }
            catch (Exception exception)
            {
                response = "";
                Console.WriteLine($"Test message Exception: {exception.Message}");
            }
            postAction(true, response);

        }
    }
}
