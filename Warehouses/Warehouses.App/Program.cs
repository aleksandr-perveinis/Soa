using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Warehouses.App
{
    class Program
    {
        static async Task Main()
        {
            var services = new ServiceCollection();

            var config = Utils.Configuration.GetServiceBusConfiguration();
            Console.Title = config.QueueName;

            var consumers = new Type[]
            {

            };

            services.AddMassTransit(cfg =>
             {
                 cfg.AddConsumers(consumers);
             });

            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = Utils.HostFactory.CreateHost(cfg);

                cfg.ReceiveEndpoint(config.QueueName, e => { e.ConfigureConsumer(provider, consumers); });
            }));


            var serviceProvider = services.BuildServiceProvider();

            var bus = serviceProvider.GetRequiredService<IBusControl>();

            await bus.StartAsync();

            Console.WriteLine("Press any key to exit");

            await Task.Run(Console.ReadKey);

            await bus.StopAsync();
        }
    }
}
