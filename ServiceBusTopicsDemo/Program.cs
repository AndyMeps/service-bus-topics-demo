using Microsoft.Azure.ServiceBus;
using System;

namespace ServiceBusTopicsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // SET VALUES HERE:
            var endpoint = "<endpoint>";
            var topicName = "<topicName>";
            var accessKeyName = "RootManageSharedAccessKey"; // this most likely can stay as-is.
            var accessKey = "<accessKey>";
            var subscription = "<subscription>";
            // DONE
            
            Console.WriteLine("Choose an option:");
            Console.WriteLine("------------------");
            Console.WriteLine("1. SendMessages");
            Console.WriteLine("2. ReceiveMessages");
            Console.WriteLine("------------------\n");

            Console.Write("Enter choice: ");

            var sbcs = GetConnectionStringBuilder(endpoint, topicName, accessKeyName, accessKey);

            switch (Console.ReadLine())
            {
                case "1":
                    SendMessages.MainAsync(sbcs).GetAwaiter().GetResult();
                    break;
                case "2":
                    ReceiveMessages.MainAsync(sbcs, subscription).GetAwaiter().GetResult();
                    break;
                default:
                    break;
            }

            Console.WriteLine("Done, press ANY KEY to exit.");
            Console.ReadKey();
        }

        static ServiceBusConnectionStringBuilder GetConnectionStringBuilder(string endpoint, string topicName, string accessKeyName, string accessKey, TransportType transportType = TransportType.AmqpWebSockets)
        {
            return new ServiceBusConnectionStringBuilder(endpoint, topicName, accessKeyName, accessKey, transportType);
        }
    }
}
