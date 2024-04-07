using DataModelClasses;
using HelperClasses;
using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows.Forms;

namespace ClientDataAccess
{
    public class ServiceAccess
    {
        
        private static void SafeCall(Action<HelloClientService.HelloClientService> action, bool showConnectionError)
        {
            ServiceAccess.SafeCall<bool>(delegate (HelloClientService.HelloClientService client)
            {
                action(client);
                return true;
            }, showConnectionError);
        }

        private static T SafeCall<T>(Func<HelloClientService.HelloClientService, T> action, bool showConnectionError)
        {
            T result;
            using (HelloClientService.HelloClientService client = new HelloClientService.HelloClientService())
            {
                try
                {
                    T t = action(client);
                    client.Close();
                    result = t;
                }
                catch (Exception ex)
                {
                    client.Abort();
                    if ((ex is CommunicationException || ex is TimeoutException) && showConnectionError)
                    {
                        Console.WriteLine(ex.Message);
                        ShowCommunicationError(ex);
                    }
                    throw;
                }
            }

            return result;
        }

        private static void ShowCommunicationError(Exception ex)
        {
            if (MessageBox.Show("Could not connect Servers.\nPlease check your Internet connection." + ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand) != DialogResult.Retry)
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        public AuthenticateResponse AuthenticateUser(bool autoLogin, string authString, string newAuthString, bool remindTomorrow, string version)
        {
            AuthenticateResponse response = new AuthenticateResponse();
            response = ContractSerialization.DeserializeObject<AuthenticateResponse>(
                SafeCall((HelloClientService.HelloClientService client) =>
                    client.GetMessage(ContractSerialization.SerializeObject(new AuthenticateRequest
                    {
                        AutoLogin = autoLogin,
                        AuthString = authString,
                        NewAuthString = newAuthString,
                        RemindTomorrow = remindTomorrow,
                        ViewerVersion = version
                    })
                ), true)
            );
            return response;
        }

        public AuthenticateResponse GetUsers(bool autoLogin, string authString, string newAuthString, bool remindTomorrow, string version)
        {
            AuthenticateResponse response = new AuthenticateResponse();
            response = ContractSerialization.DeserializeObject<AuthenticateResponse>(SafeCall((HelloClientService.HelloClientService client) =>
            client.ReadMessage(ContractSerialization.SerializeObject(new AuthenticateRequest
            {
                AutoLogin = autoLogin,
                AuthString = authString,
                NewAuthString = newAuthString,
                RemindTomorrow = remindTomorrow,
                ViewerVersion = version
            })), false));
            return response;
        }

        public AuthenticateResponse AddUser(bool autoLogin, string authString, string newAuthString, bool remindTomorrow, string version)
        {
            AuthenticateResponse response = new AuthenticateResponse();
            response = ContractSerialization.DeserializeObject<AuthenticateResponse>(SafeCall((HelloClientService.HelloClientService client) =>
            client.AddMessage(ContractSerialization.SerializeObject(new AuthenticateRequest
            {
                AutoLogin = autoLogin,
                AuthString = authString,
                NewAuthString = newAuthString,
                RemindTomorrow = remindTomorrow,
                ViewerVersion = version
            })), false));
            return response;
        }

        public string TestMessage(string message)
        {
            HelloClientService.HelloClientService client = new HelloClientService.HelloClientService();
            return "Teting message response = " + client.TestMessage(message);
        }
    }
}
