using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gls.emailsender;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using gls.emailsender.Business;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(gls.emailsender.Startup))]

namespace gls.emailsender
{
    public class Startup : FunctionsStartup
    {
                
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<SmtpConfiguration>()
            .Configure<IConfiguration>((smtpConfigurationSetting, configuration) =>
            {
                configuration.GetSection(nameof(SmtpConfiguration)).Bind(smtpConfigurationSetting);
            });

            builder.Services.AddSingleton<IEmailSender, EmailProcessor>();
        }
    }
}