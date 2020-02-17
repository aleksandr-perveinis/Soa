using System.IO;
using Microsoft.Extensions.Configuration;
using Models;

namespace Utils
{
    public class Configuration
    {
        public static ServiceBusConfiguration GetServiceBusConfiguration()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = configBuilder.Build();
            var config = configuration.GetSection("ServiceBusConfiguration").Get<ServiceBusConfiguration>();
            return config;
        }
    }
}
