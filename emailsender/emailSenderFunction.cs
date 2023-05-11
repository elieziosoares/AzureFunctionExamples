using System;
using gls.emailsender;
using gls.emailsender.Business;
using gls.emailsender.DtoModel;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace gls.emailsender
{
    public class emailSenderFunction
    {

        private readonly IEmailSender _emailClient;
        
        public emailSenderFunction(IEmailSender emailClient){
            _emailClient = emailClient;
        }

        [FunctionName("emailSenderFunction")]
        public void Run([ServiceBusTrigger("queue-email-sending-test", Connection = "servicebusemailtest_SERVICEBUS")]string MessageBody, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {MessageBody}");

            var emailMessage = JsonConvert.DeserializeObject<EmailServiceBusMessage>(MessageBody);
            _emailClient.SendMessage(emailMessage.RecipientEmail,emailMessage.SenderEmail,emailMessage.MessageBody,emailMessage.Subject);
        }
    }
}
