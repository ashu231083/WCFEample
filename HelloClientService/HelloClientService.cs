using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace HelloClientService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloClientService" in both code and config file together.
    public class HelloClientService : ClientBase<IHelloClientService>, IHelloClientService
    {
        public HelloClientService()
        {
        }

        public HelloClientService(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public HelloClientService(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public HelloClientService(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public HelloClientService(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }
        public byte[] AddMessage(byte[] request)
        {
            return base.Channel.AddMessage(request);
        }

        public Task<byte[]> AddMessageAsync(byte[] request)
        {
            return base.Channel.AddMessageAsync(request);
        }

        public byte[] GetMessage(byte[] request)
        {
            return base.Channel.GetMessage(request);
        }

        public byte[] ReadMessage(byte[] request)
        {
            return base.Channel.ReadMessage(request);
        }

        public string TestMessage(string request)
        {
            return base.Channel.TestMessage(request);
        }

        public Task<string> TestMessageAsync(string request)
        {
            return base.Channel.TestMessageAsync(request);
        }
    }
}
