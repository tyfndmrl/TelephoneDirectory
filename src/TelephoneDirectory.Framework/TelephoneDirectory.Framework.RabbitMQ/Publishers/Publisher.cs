using DotNetCore.CAP;
using TelephoneDirectory.Framework.RabbitMQ.Publishers.Commands;
using TelephoneDirectory.Framework.RabbitMQ.Publishers.Interfaces;

namespace TelephoneDirectory.Framework.RabbitMQ.Publishers
{
    public class Publisher : IPublisher
    {
        private readonly ICapPublisher _capBus;
        private readonly string enviromentName;

        public Publisher(ICapPublisher capBus)
        {
            _capBus = capBus;
            enviromentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower();
        }

        public async Task SendAsync<TGeneric>(string queue, TGeneric model)
        {
            await _capBus.PublishAsync($"{enviromentName}.{queue}", model);
        }
    }
}
