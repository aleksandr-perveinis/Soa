using System;

namespace Test.Models
{
    public interface IMessage
    {
        public Guid CorrelationId { get; set; }
        public string Text { get; set; }
    }


}
