using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace gls.emailsender.Business
{
    public class EmailProcessor : IEmailSender
    {
        private readonly ILogger<EmailProcessor> _logger;
        private readonly SmtpConfiguration _configuration;

        public EmailProcessor(ILogger<EmailProcessor> logger,
                              IOptions<SmtpConfiguration> configuration)
        {
            _logger = logger;
            _configuration = configuration.Value;
        }
        public void SendMessage(string receipient, string sender, string body, string subject)
        {
            _logger.LogInformation($"Sending message to the {receipient}...");

            try{
                /*MailMessage message = new MailMessage(_configuration.Username,receipient,subject,body);
            
                using(var smtpClient = new SmtpClient(_configuration.SmtpServer, _configuration.Port)){
                    smtpClient.EnableSsl = _configuration.EnableSsl;
                    smtpClient.Credentials = new NetworkCredential(_configuration.Username,_configuration.Password);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    smtpClient.Send(message);
                }*/
                
                SmtpConfiguration config = new SmtpConfiguration("smtp.gmail.com",587,"globallabsystemstest@gmail.com","jxxtwmgxzywzdahw",true);
                
                MailMessage message = new MailMessage(config.Username,receipient,subject,body);
                using(var smtpClient = new SmtpClient(config.SmtpServer, config.Port)){
                    smtpClient.EnableSsl = config.EnableSsl;
                    smtpClient.Credentials = new NetworkCredential(config.Username,config.Password);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    smtpClient.Send(message);
                }
            }
            catch(Exception ex){
                _logger.LogError($"Error occurred while sending email to {receipient}. Error message: {ex.Message}");
                throw;
            }
        }
    }
}