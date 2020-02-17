using System;
using System.Collections.Generic;
using System.Text;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace Utils
{
    public static class HostFactory
    {
        public static IRabbitMqHost CreateHost(IRabbitMqBusFactoryConfigurator cfg)
        {
            var config = Configuration.GetServiceBusConfiguration();

            return cfg.Host(new Uri($"{config.ServerName}/{config.VirtualHost}"), h =>
            {
                h.Username(config.UserName);
                h.Password(config.Password);
            });
        }
    }
}
