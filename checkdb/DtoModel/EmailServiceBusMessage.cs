using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkdb.DtoModel
{
    public class EmailServiceBusMessage
    {
        public EmailServiceBusMessage()
        {
        }

        public EmailServiceBusMessage(string senderEmail, string recipient, string messageBody, string subject) 
        {
            this.SenderEmail = senderEmail;
            this.RecipientEmail = recipient;
            this.MessageBody = messageBody;
            this.Subject = subject;
        }
        public string SenderEmail{get; set;}
        public string RecipientEmail{get; set;}
        public string MessageBody{get; set;}
        public string Subject{get; set;}
    }
}