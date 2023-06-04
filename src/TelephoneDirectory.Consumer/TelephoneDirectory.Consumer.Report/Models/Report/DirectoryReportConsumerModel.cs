using TelephoneDirectory.Framework.RabbitMQ.Publishers.Commands;

namespace TelephoneDirectory.Consumer.Report.Models.Report
{
    public class DirectoryReportConsumerModel : ICommand
    {
        public Guid Id { get; set; }
    }
}
