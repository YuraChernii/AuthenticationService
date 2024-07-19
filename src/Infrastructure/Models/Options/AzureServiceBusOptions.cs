namespace Infrastructure.Models.Options
{
    public class AzureServiceBusOptions
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}