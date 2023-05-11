using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using checkdb.ConfigurationModels;
using checkdb.DtoModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace checkdb.Service
{
    public class QueueProcessor : IQueueSender
    {
        private readonly ILogger<QueueProcessor> _logger;
        private readonly QueueConfiguration _configuration;

        public QueueProcessor(ILogger<QueueProcessor> logger,
                              IOptions<QueueConfiguration> configuration)
        {
            _logger = logger;
            _configuration = configuration.Value;
        }
        
        public async void sendMessage(string message)
        {
            _logger.LogInformation($"Enqueuing message in the queue...");

            try{
                
                var QueueMessage = new ServiceBusMessage(message);

                var queueClient = new ServiceBusClient(_configuration.ConnectionString);
                var queueSender = queueClient.CreateSender(_configuration.Name);

                await queueSender.SendMessageAsync(QueueMessage);
                _logger.LogInformation("    Sent!");

                await queueSender.CloseAsync();

               
            }
            catch(Exception ex){
                _logger.LogError($"Error occurred while enqueuing email message {message} in the service bus. Error message: {ex.Message}");
                throw;
            }
        }
    }
}