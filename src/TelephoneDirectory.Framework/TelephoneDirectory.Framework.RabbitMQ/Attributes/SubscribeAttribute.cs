using DotNetCore.CAP;

namespace TelephoneDirectory.Framework.RabbitMQ.Attributes
{
    public class SubscribeAttribute : CapSubscribeAttribute
    {
        public SubscribeAttribute(string name, bool isPartial = false): base($"{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower()}.{name}", isPartial)
        {
            
        }
    }
}
