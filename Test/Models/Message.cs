using System;

namespace Test.Models
{
    public class Message:IMessage
    {
        public Message()
        {
            CorrelationId=Guid.NewGuid();
        }
        public Guid CorrelationId { get; set; }
        public string Text { get; set; }
    }


}
