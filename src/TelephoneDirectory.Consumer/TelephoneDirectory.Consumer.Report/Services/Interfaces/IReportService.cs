using TelephoneDirectory.Consumer.Report.Models.Report;

namespace TelephoneDirectory.Consumer.Report.Services.Interfaces
{
    public interface IReportService
    {
        Task DirectoryLocationReport(DirectoryLocationReportConsumerModel model);
    }
}
