using MassTransit;
using System;
using System.Threading.Tasks;

namespace Orders.App
{
    class Program
    {
        private static IBusControl _bus;
        public static async Task Main()
        {
            var config = Utils.Configuration.GetServiceBusConfiguration();
            Console.Title = config.QueueName;

            _bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                Utils.HostFactory.CreateHost(cfg);
            });

            await _bus.StartAsync();

            await Task.Run(Console.ReadKey);
            Console.WriteLine("Press any to send new order, 'c' to cancel");

            await _bus.StopAsync();
        }

    }
}
