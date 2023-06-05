using TelephoneDirectory.Consumer.Report.Models.Directory.Enums;

namespace TelephoneDirectory.Consumer.Report.Models.Directory.ResponseModels
{
    public class ReportResponseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public ReportStatusEnum Status { get; set; }
    }
}
