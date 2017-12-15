using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusTopicsDemo
{
    public static class SendMessages
    {
        static ITopicClient topicClient;

        public static async Task MainAsync(ServiceBusConnectionStringBuilder sbcsb)
        {
            const int numberOfMessages = 10;
            topicClient = new TopicClient(sbcsb);

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");

            // Send messages
            await SendMessagesAsync(numberOfMessages);

            Console.ReadKey();

            await topicClient.CloseAsync();
        }

        static async Task SendMessagesAsync(int numberOfMessagesToSend)
        {
            try
            {
                for (var i = 0; i < numberOfMessagesToSend; i++)
                {
                    // Create a new message to send to the topic.
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    // Write the body of the message to the console.
                    Console.WriteLine($"Sending message: {messageBody}");

                    // Send the message to the topic.
                    await topicClient.SendAsync(message);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception : {ex.Message}");
            }
        }
    }
}
