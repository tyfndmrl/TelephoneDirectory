using DotNetCore.CAP;
using System.Diagnostics;
using TelephoneDirectory.Consumer.Report.Consumers.Interfaces;
using TelephoneDirectory.Consumer.Report.Models.Report;
using TelephoneDirectory.Framework.RabbitMQ.Attributes;

namespace TelephoneDirectory.Consumer.Report.Consumers
{
    public class ReportTrackerConsumer : IReportTrackerConsumer, ICapSubscribe
    {
        [Subscribe("report-tracker.directory-report.queue")]
        public Task DirectoryReport(DirectoryReportConsumerModel model)
        {
            Debug.WriteLine("test denemesi");
            throw new NotImplementedException();
        }
    }
}
