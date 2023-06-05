using DotNetCore.CAP;
using TelephoneDirectory.Consumer.Report.Consumers.Interfaces;
using TelephoneDirectory.Consumer.Report.Models.Report;
using TelephoneDirectory.Consumer.Report.Services.Interfaces;
using TelephoneDirectory.Framework.RabbitMQ.Attributes;

namespace TelephoneDirectory.Consumer.Report.Consumers
{
    public class ReportTrackerConsumer : IReportTrackerConsumer, ICapSubscribe
    {
        private readonly IReportService _reportService;
        public ReportTrackerConsumer(IReportService reportService)
        {
            _reportService = reportService;
        }

        [Subscribe("report-tracker.directory-location-report.queue")]
        public async Task DirectoryLocationReport(DirectoryLocationReportConsumerModel model)
        {
            await _reportService.DirectoryLocationReport(model);
        }
    }
}
