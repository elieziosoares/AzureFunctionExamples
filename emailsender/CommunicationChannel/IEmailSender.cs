using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gls.emailsender.Business
{
    public interface IEmailSender
    {
        void SendMessage(string receipient, string sender, string body, string subject);
    }
}