using System;

namespace Models
{
    public class ServiceBusConfiguration
    {
        public string ServerName { get; set; }
        public string VirtualHost { get; set; }
        public string QueueName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
