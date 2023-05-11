using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Azure.Messaging.ServiceBus;
using checkdb.Service;
using checkdb.DtoModel;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace checkdb
{
    public class CheckDB
    {
        private readonly IQueueSender _queueClient;

        public CheckDB(IQueueSender queueClient)
        {
            _queueClient = queueClient;
        }

        [FunctionName("CheckDB")]
        public void Run([TimerTrigger("*/59 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var emails = getEmails();
            foreach(var e in emails)
                _queueClient.sendMessage(JsonConvert.SerializeObject(e));
                
        }

        private List<EmailServiceBusMessage> getEmails(){
            var emails = new List<EmailServiceBusMessage>();
            int i=0;

            for(i=0; i<3; i++){
                EmailServiceBusMessage emailMessage = new EmailServiceBusMessage(){
                    SenderEmail = "globallabsystemstest@gmail.com",
                    RecipientEmail = "vowovo4031@andorem.com",
                    MessageBody = "This is a test",
                    Subject = "Testing "+ DateTime.Now.ToShortTimeString()
                };
                emails.Add(emailMessage);
            }

            return emails;
        }
    }
}
