namespace gls.emailsender.Business
{
    public class SmtpConfiguration
    {
        public SmtpConfiguration()
        {
        }

        public SmtpConfiguration(string smtpServer, int port, string username, string password,bool enableSsl) 
        {
            this.SmtpServer = smtpServer;
            this.Port = port;
            this.Username = username;
            this.Password = password;
            this.EnableSsl = enableSsl;
   
        }
        
        public string SmtpServer{get; set;}
        public int Port{get; set;}
        public string Username{get; set;}
        public string Password{get; set;}
        public bool EnableSsl{get; set;}
    }
}