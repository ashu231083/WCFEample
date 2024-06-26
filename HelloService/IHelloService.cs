﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract(Action = "HelloService/TestMessage", ReplyAction = "HelloService/TestMessageResponse")]
        string TestMessage(string request);

        [OperationContract(Action = "HelloService/AddMessage", ReplyAction = "HelloService/AddMessageResponse")]
        byte[] AddMessage(byte[] request);
        [OperationContract(Action = "HelloService/GetMessage", ReplyAction = "HelloService/GetMessageResponse")]
        byte[] GetMessage(byte[] request);
        [OperationContract(Action = "HelloService/ReadMessage", ReplyAction = "HelloService/ReadMessageResponse")]
        byte[] ReadMessage(byte[] request);
    }
}
