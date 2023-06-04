using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelephoneDirectory.Framework.RabbitMQ.Publishers.Interfaces;
using TelephoneDirectory.Framework.RabbitMQ.Publishers;

namespace TelephoneDirectory.Framework.Repository.Extensions
{
    public static class RabbitMQManager
    {
        public static void RabbitMQManagerInit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCap(x =>
            {
                var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower();
                var defaultCapName = configuration.GetSection("RabbitMq:CAPDefaultName").Value;
                x.DefaultGroupName = $"{enviroment}.{defaultCapName}.queue";
                x.UseDashboard();
                x.UseMongoDB(opt =>
                {
                    opt.DatabaseConnection = configuration.GetSection("MongoDBConfiguration:ConnectionString").Value;
                    opt.DatabaseName = $"cap_{defaultCapName}_{enviroment}";
                });
                x.UseRabbitMQ(options =>
                {
                    options.ConnectionFactoryOptions = options =>
                    {
                        options.Ssl.Enabled = false;
                        options.HostName = configuration.GetSection("RabbitMq:Host").Value;
                        options.UserName = configuration.GetSection("RabbitMq:UserName").Value;
                        options.Password = configuration.GetSection("RabbitMq:Password").Value;
                        options.Port = 5672;
                    };
                });
            });
        }

        public static void RabbitMQPublisherInit(this IServiceCollection services)
        {
            services.AddScoped<IPublisher, Publisher>();
        }
    }
}
