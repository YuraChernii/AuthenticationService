using Domain.Services;
using Infrastructure.Models.Options;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using System.Text;

namespace Infrastructure.Services
{
    internal class AzureBusService : INotificationService
    {
        private readonly AzureServiceBusOptions options;
        private readonly IQueueClient queueClient;

        public AzureBusService(IOptions<AzureServiceBusOptions> options)
        {
            this.options = options.Value;
            queueClient = new QueueClient(this.options.ConnectionString, this.options.QueueName);
        }

        public async Task SendMessageAsync(string message)
        {
            Message encodedMessage = new(Encoding.UTF8.GetBytes(message));
            await queueClient.SendAsync(encodedMessage);
        }
    }
}