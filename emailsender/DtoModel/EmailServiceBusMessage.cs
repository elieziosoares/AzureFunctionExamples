using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gls.emailsender.DtoModel
{
    public class EmailServiceBusMessage
    {
        public string SenderEmail{get; set;}
        public string RecipientEmail{get; set;}
        public string MessageBody{get; set;}
        public string Subject{get; set;}
    }
}