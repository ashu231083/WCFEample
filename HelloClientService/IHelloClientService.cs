using System.ServiceModel;
using System.Threading.Tasks;

namespace HelloClientService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHelloClientService" in both code and config file together.
    [ServiceContract]
    public interface IHelloClientService
    {
        [OperationContract(Action = "HelloService/TestMessage", ReplyAction = "HelloService/TestMessageResponse")]
        string TestMessage(string request);

        [OperationContract(Action = "HelloService/TestMessage", ReplyAction = "HelloService/TestMessageResponse")]
        Task<string> TestMessageAsync(string request);

        [OperationContract(Action = "HelloService/AddMessage", ReplyAction = "HelloService/AddMessageResponse")]
        byte[] AddMessage(byte[] request);

        [OperationContract(Action = "HelloService/AddMessage", ReplyAction = "HelloService/AddMessageResponse")]
        Task<byte[]> AddMessageAsync(byte[] request);

        [OperationContract(Action = "HelloService/GetMessage", ReplyAction = "HelloService/GetMessageResponse")]
        byte[] GetMessage(byte[] request);
        
        [OperationContract(Action = "HelloService/ReadMessage", ReplyAction = "HelloService/ReadMessageResponse")]
        byte[] ReadMessage(byte[] request);
    }
}
