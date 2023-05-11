using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using checkdb.ConfigurationModels;
using checkdb.Service;

[assembly: FunctionsStartup(typeof(checkdb.Startup))]

namespace checkdb
{
    public class Startup : FunctionsStartup
    {
                
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<QueueConfiguration>()
            .Configure<IConfiguration>((queueConfigurationSetting, configuration) =>
            {
                configuration.GetSection(nameof(QueueConfiguration)).Bind(queueConfigurationSetting);
            });

            builder.Services.AddSingleton<IQueueSender, QueueProcessor>();
        }
    }
}