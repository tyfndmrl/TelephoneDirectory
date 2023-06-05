namespace TelephoneDirectory.Framework.RabbitMQ.Publishers.Interfaces
{
    public interface IPublisher
    {
        Task SendAsync<TGeneric>(string queue, TGeneric model);
    }
}
