using TelephoneDirectory.Report.DDD.Entities.Enums;

namespace TelephoneDirectory.Report.DTO.Dto.Report.ResponseModels
{
    public class ReportResponseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public ReportStatusEnum Status { get; set; }
    }
}
