using System;
using System.Threading.Tasks;
using MassTransit;

namespace Test.Consumers
{
    public class TestConsumer : IConsumer<Models.Message>
    {
        public async Task Consume(ConsumeContext<Models.Message> context)
        {
            await Console.Out.WriteLineAsync($"Received in consumer: {context.Message.Text}");
       }
    }
}
